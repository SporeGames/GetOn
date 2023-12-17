using Godot;
using System;
using GetOn.scenes;

public class IntroScene : Control
{
		private SharedNode _sharedNode;
		private Button _understandButton;
		private Button _startButton;
		private Node2D _introScreen;
		private Node2D _homeScreen;
		

		// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		_understandButton = GetNode<Button>("UnderstandButton");
		_understandButton.Connect("pressed", this, nameof(OnUnderstandButtonPressed));  
		_startButton = GetNode<Button>("StartButton");
		_startButton.Connect("pressed", this, nameof(OnStartButtonPressed));  
		
		_introScreen = GetNode<Node2D>("IntroScreen");
		_introScreen.Hide(); // Assuming you want to initially hide the 2D node
		
		_homeScreen = GetNode<Node2D>("HomeScreen");
		_sharedNode = GetNode<SharedNode>("/root/SharedNode");
		
		
	}

		private void OnUnderstandButtonPressed() {
			_sharedNode.SwitchScene("res://scenes/MainMenu/MainMenu.tscn");
		}
		
		private void OnStartButtonPressed() {
			_introScreen.Show();
			_homeScreen.Hide();
			_startButton.Hide();
			_understandButton.Show();
		}
		
}
