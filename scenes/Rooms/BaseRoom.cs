using GetOn.scenes;
using Godot;

public class BaseRoom : Node2D {
	[Export] public bool HasDoor = false;
	
	private TextureButton _doorButton;
	private TextureButton _backButton;
	
	public override void _Ready() {
		if (HasDoor) {
			_doorButton = GetNode<TextureButton>("DoorButton");
			_doorButton.Connect("pressed", this, nameof(OnDoorButtonPressed));
		}
		_backButton = GetNode<TextureButton>("BackButton");
		_backButton.Connect("pressed", this, nameof(OnBackButtonPressed));
	}
	
	private void OnBackButtonPressed() {
		GetNode<SharedNode>("/root/SharedNode").SwitchScene("res://scenes/GameSelectionRoom/GameSelectionRoom.tscn");
	}
	
	public void OnDoorButtonPressed() {
		GetNode<SharedNode>("/root/SharedNode").SwitchScene("res://scenes/GameSelectionRoom/GameSelectionRoom.tscn");
	}
	
}
