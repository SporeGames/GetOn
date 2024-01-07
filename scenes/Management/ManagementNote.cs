using Godot;

public class ManagementNote : Area2D {
	
	private Management _management;
	
	[Export(PropertyHint.MultilineText)] public string Text = "<none>";
	[Export(PropertyHint.MultilineText)] public string Hint = "";
	[Export(PropertyHint.Range, "0,5")] public int ValidColorID = 0;
	
	private RichTextLabel _noteText;
	public Sprite NoteColor;
	private Node2D _hint;
	public ColorRect ColorRect;
		
	
	public override void _Ready() {
		_management = GetParent().GetParent<Management>();
		_noteText = GetNode<RichTextLabel>("NoteText");
		NoteColor = GetNode<Sprite>("NoteColor");
		Connect("mouse_entered", this, nameof(OnMouseEntered));
		Connect("mouse_exited", this, nameof(OnMouseLeft));
		_noteText.Text = Text;
		_hint = GetNode<Node2D>("Hint");
		GetNode<RichTextLabel>("Hint/Label").Text = Hint;
		ColorRect = GetNode<ColorRect>("Hint/ColorRect");
	}

	public void OnMouseEntered() {
		_management.MouseEntered(this);
		_hint.Visible = true;
	}

	public void OnMouseLeft() {
		_management.MouseLeft(this);
		_hint.Visible = false;
	}
	
	
}
