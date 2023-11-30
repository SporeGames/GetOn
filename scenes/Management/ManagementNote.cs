using Godot;

public class ManagementNote : Area2D {
    
    private Management _management;

    public RichTextLabel NoteText;
    public ColorRect NoteColor;
    public Node2D LeftAnchor;
    public Node2D RightAnchor;
    private Button _leftButton;
    private Button _rightButton;
    
    private bool leftConnected = false;
    private bool rightConnected = false;
    private ManagementNote _rightNote;
    private ManagementNote _leftNote;
    private Line2D _leftLine;
    private Line2D _rightLine;
    
    
    public override void _Ready() {
        _management = GetParent<Management>();
        NoteText = GetNode<RichTextLabel>("NoteText");
        NoteColor = GetNode<ColorRect>("NoteColor");
        LeftAnchor = GetNode<Node2D>("LeftLineAnchor");
        RightAnchor = GetNode<Node2D>("RightLineAnchor");
        _leftButton = GetNode<Button>("LeftConnectButton");
        _rightButton = GetNode<Button>("RightConnectButton");
        _leftButton.Connect("pressed", this, nameof(OnConnectStartLeft));
        _rightButton.Connect("pressed", this, nameof(OnConnectStartRight));
        Connect("mouse_entered", this, nameof(OnMouseEntered));
        Connect("mouse_exited", this, nameof(OnMouseLeft));
    }
    
    public void OnConnectStartLeft() {
        _management.ConnectStartLeft(this);
    }
    
    public void OnConnectStartRight() {
        _management.ConnectStartRight(this);
    }

    public void UpdateLineAnchors() {
        if (_leftLine != null) {
            GD.Print("Left line not null");
            _leftLine.SetPointPosition(0, LeftAnchor.GlobalPosition);
        }
        if (_rightLine != null) {
            GD.Print("Right line not null");
            _rightLine.SetPointPosition(0, RightAnchor.GlobalPosition);
        }
    }
    
    
    public bool ConnectLeft(Line2D connectingLine, ManagementNote originNote) {
        if (leftConnected) {
            return false;
        }
        leftConnected = true;
        _leftNote = originNote;
        _leftLine = connectingLine;
        return true;
    }
    
    public bool ConnectRight(Line2D connectingLine, ManagementNote originNote) {
        if (rightConnected) {
            return false;
        }
        rightConnected = true;
        _rightNote = originNote;
        _rightLine = connectingLine;
        return true;
    }

    public void OnMouseEntered() {
        _management.MouseEntered(this);
    }

    public void OnMouseLeft() {
        _management.MouseLeft(this);
    }
    
    
}
