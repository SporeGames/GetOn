using Godot;

public class ManagementNote : Area2D {
    
    private Management _management;
    
    [Export] public string Text = "<none>";
    [Export(PropertyHint.Range, "0,5")] public int ValidColorID = 0;
    
    private RichTextLabel _noteText;
    public ColorRect NoteColor;
        
    
    public override void _Ready() {
        _management = GetParent().GetParent<Management>();
        _noteText = GetNode<RichTextLabel>("NoteText");
        NoteColor = GetNode<ColorRect>("NoteColor");
        Connect("mouse_entered", this, nameof(OnMouseEntered));
        Connect("mouse_exited", this, nameof(OnMouseLeft));
        _noteText.Text = Text;
    }

    public void OnMouseEntered() {
        _management.MouseEntered(this);
    }

    public void OnMouseLeft() {
        _management.MouseLeft(this);
    }
    
    
}
