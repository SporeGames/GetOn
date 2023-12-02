using Godot;
using System;
using System.Linq;

public class NoteBox : Area2D {

	[Export] public string[] ValidIDs = new[] {""};
	private Management _management;
	public ColorRect NoteColor;
	
	public override void _Ready() {
		_management = GetParent().GetParent<Management>();
		Connect("area_entered", this, nameof(OnEntered));
		Connect("area_exited", this, nameof(OnLeft));
		NoteColor = GetNode<ColorRect>("ColorRect");
	}
	
	private void OnEntered(Area2D area) {
		if (area is ManagementNote note && !_management.BoxedNotes.ContainsKey(this)) {
			_management.BoxEntered(this, note); // Always snap
		}
	}
	
	private void OnLeft(Area2D area) {
	}
	
}
