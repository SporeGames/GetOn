using Godot;
using System;
using GetOn.scenes;

public class IntroScene : Control
{
		private SharedNode _sharedNode;
		private TextureButton _understandButton;
		private TextureButton _startButton;
		private Button _testPDFButton;
		private Node2D _introScreen;
		private Node2D _homeScreen;
		

		// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		_understandButton = GetNode<TextureButton>("UnderstandButton");
		_understandButton.Connect("pressed", this, nameof(OnUnderstandButtonPressed));  
		_startButton = GetNode<TextureButton>("StartButton");
		_startButton.Connect("pressed", this, nameof(OnStartButtonPressed));  
		_testPDFButton = GetNode<Button>("TestPDFButton");
		_testPDFButton.Connect("pressed", this, nameof(TestPDF));
		
		_introScreen = GetNode<Node2D>("IntroScreen");
		
		
		_homeScreen = GetNode<Node2D>("HomeScreen");
		_homeScreen.Hide();
		_sharedNode = GetNode<SharedNode>("/root/SharedNode");
		
		
	}

		private void OnStartButtonPressed() {
			_sharedNode.SwitchScene("res://scenes/Intermission/IntermissionScene.tscn");
		}
		
		private void OnUnderstandButtonPressed() {
			_introScreen.Hide();
			_homeScreen.Show();
			_startButton.Show();
			_understandButton.Hide();
		}
		
		private void TestPDF() {
			_sharedNode.Print();
		}
}
