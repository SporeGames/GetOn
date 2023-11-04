using Godot;
using System;
using GetOn.scenes.Programming.blocks.logic;

namespace GetOn.scenes.GameSelectionRoom
{
	public class Programming : Node2D
	{
		private SharedNode _sharedNode;
		
		private Button _backToGameSelectionRoom;
		public override void _Ready() {
			_sharedNode = GetNode<SharedNode>("/root/SharedNode");
			_backToGameSelectionRoom = GetNode<Button>("Game/BackToGameSelection");
			_backToGameSelectionRoom.Connect("pressed", this, nameof(OnBackToSelectionRoomPressed));
		}

		public void OnBackToSelectionRoomPressed() {
			_sharedNode.SwitchScene("res://scenes/GameSelectionRoom/GameSelectionRoom.tscn");
		}
	}
}

