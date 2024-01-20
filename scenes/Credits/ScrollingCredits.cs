using Godot;

namespace GetOn.scenes.Credits {
    public class ScrollingCredits : Node2D {
    
        private Node2D _text;
        private TextureButton _button;

        public override void _Ready() {
            _text = GetNode<Node2D>("Label");
            _button = GetNode<TextureButton>("BackButton");
            _button.Connect("pressed", this, nameof(OnBackButtonPressed));
        }

        public override void _Process(float delta) {
            _text.Position = new Vector2(_text.Position.x, _text.Position.y - 2);
            if (_text.Position.y < -1000f) {
                GetNode<SharedNode>("/root/SharedNode").SwitchScene("res://scenes/Credits/Credits.tscn");
            }
        }
    
        private void OnBackButtonPressed() {
            GetNode<SharedNode>("/root/SharedNode").SwitchScene("res://scenes/Credits/Credits.tscn");
        }
    }
}
