using Godot;
using System;

namespace GetOn.scenes.GameSelectionRoom {
	public class GameSelectionRoom : Node2D
	{
		private SharedNode _sharedNode;

		
		private Button _goToProgramming;
		private Button _goToManagment;
		private Button _goToNarrativeAndGameDesign;
		private Button _goToSound;

		// Called when the node enters the scene tree for the first time.
		public override void _Ready()
		{
			_sharedNode = GetNode<SharedNode>("/root/SharedNode");
			_goToProgramming = GetNode<Button>("GoToProgramming");
			_goToProgramming.Connect("pressed", this, nameof(OnGoToProgrammingPressed));
			_goToManagment = GetNode<Button>("GoToManagment");
			_goToManagment.Connect("pressed", this, nameof(OnGoToManagmentPressed));
			_goToNarrativeAndGameDesign = GetNode<Button>("GoToNarrativeAndGameDesign");
			_goToNarrativeAndGameDesign.Connect("pressed", this, nameof(OnGoToNarrativeAndSoundPressed));
			_goToSound = GetNode<Button>("GoToSound");
			_goToSound.Connect("pressed", this, nameof(OnGoToSoundPressed));

		}

		public void OnGoToProgrammingPressed()
		{
			_sharedNode.SwitchScene("res://scenes/Programming/Programming.tscn");
		}

		public void OnGoToManagmentPressed()
		{
			_sharedNode.SwitchScene("res://scenes/Programming/Programming.tscn");
		}

		public void OnGoToNarrativeAndSoundPressed()
		{
			_sharedNode.SwitchScene("res://scenes/Programming/Programming.tscn");
		}

		public void OnGoToSoundPressed()
		{
			_sharedNode.SwitchScene("res://scenes/Programming/Programming.tscn");
		}
		//  // Called every frame. 'delta' is the elapsed time since the previous frame.
		//  public override void _Process(float delta)
		//  {
		//      
		//  }
	}
}
