using Godot;
using GetOn.scenes;

public class Credits : Node2D {
    
    private TextureButton _printButton;
    private TextureButton _creditsButton;
    private TextureButton _resetButton;
    private Node2D _downloadNotification;
    private Timer _timer;
    
    public override void _Ready() {
        _printButton = GetNode<TextureButton>("PrintButton");
        _creditsButton = GetNode<TextureButton>("CreditsButton");
        _resetButton = GetNode<TextureButton>("ResetButton");
        _downloadNotification = GetNode<Node2D>("Notification");
        _timer = GetNode<Timer>("Notification/Timer");
        _timer.Connect("timeout", this, nameof(OnTimerTimeout));
        _printButton.Connect("pressed", this, nameof(OnPrintButtonPressed));
        _creditsButton.Connect("pressed", this, nameof(OnCreditsButtonPressed));
        _resetButton.Connect("pressed", this, nameof(OnResetButtonPressed));
    }

    public override void _Process(float delta) {
        if (_downloadNotification.Visible && _downloadNotification.Position.y < 800) {
            _downloadNotification.Position = new Vector2(_downloadNotification.Position.x, _downloadNotification.Position.y + 3);
        }
    }

    private void OnPrintButtonPressed() {
        GetNode<SharedNode>("/root/SharedNode").Print();
        _downloadNotification.Visible = true;
        _timer.Start();
    }
    
    private void OnTimerTimeout() {
        _downloadNotification.Visible = false;
    }
    
    private void OnCreditsButtonPressed() {
        GetNode<SharedNode>("/root/SharedNode").SwitchScene("res://scenes/Credits/ScrollingCredits.tscn");
    }
    
    private void OnResetButtonPressed() {
        GetNode<SharedNode>("/root/SharedNode").ResetGame();
    }


}
