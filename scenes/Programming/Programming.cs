using Godot;
using System;

namespace GetOn.scenes.GameSelectionRoom
{
	public class Programming : Node2D
	{
		private SharedNode _sharedNode;
		
		private Button _backToGameSelectionRoom;

		// Called when the node enters the scene tree for the first time.
		public override void _Ready()
		{
			_sharedNode = GetNode<SharedNode>("/root/SharedNode");
			_backToGameSelectionRoom = GetNode<Button>("BackToGameSelection");
			_backToGameSelectionRoom.Connect("pressed", this, nameof(OnBackToSelectionRoomPressed));
		}

		public void OnBackToSelectionRoomPressed()
		{
			_sharedNode.SwitchScene("res://scenes/GameSelectionRoom/GameSelectionRoom.tscn");
		}
	}
}

