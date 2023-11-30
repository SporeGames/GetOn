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
        if (area is ManagementNote note) {
            if (ValidIDs.Contains(note.Name) || Name.Equals(note.Name)) { // lets do both so we don't have to type in all the names
                _management.BoxEntered(this, note);
            }
        }
    }
    
    private void OnLeft(Area2D area) {
    }
    
}
