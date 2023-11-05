using Godot;
using System;
using GetOn.scenes.Programming.blocks.godot;
using GetOn.scenes.Programming.blocks.logic;

namespace GetOn.scenes.GameSelectionRoom
{
	public class Programming : Node2D
	{
		private SharedNode _sharedNode;
		
		private Button _backToGameSelectionRoom;
		
		private Button _runButton;
		private ColorRect _runOverlay;
		private NodeGraph _programmingUI;

		private bool running = false;
		public override void _Ready() {
			_sharedNode = GetNode<SharedNode>("/root/SharedNode");
			_backToGameSelectionRoom = GetNode<Button>("Game/BackToGameSelection");
			_backToGameSelectionRoom.Connect("pressed", this, nameof(OnBackToSelectionRoomPressed));
			_programmingUI = GetNode<NodeGraph>("ProgrammingUI/AspectRatioContainer/NodeGraph");
			_runButton = GetNode<Button>("ProgrammingUI/RunButton");
			_runButton.Connect("pressed", this, nameof(OnRunPressed));
			_runOverlay = GetNode<ColorRect>("ProgrammingUI/RunOverlay");
		}

		public override void _Process(float delta) {
			if (running) {
				_programmingUI.Executor.Start();
			}
		}

		public void OnBackToSelectionRoomPressed() {
			_sharedNode.SwitchScene("res://scenes/GameSelectionRoom/GameSelectionRoom.tscn");
		}

		public void OnRunPressed() {
			if (running) {
				GD.Print("Stopping...");
				Stop();
			} else {
				GD.Print("Running...");
				Run();
			}
		}
		
		private void Run() {
			_runOverlay.Visible = true;
			_runButton.Text = "Stop";
			running = true;
		}
		
		private void Stop() {
			_runOverlay.Visible = false;
			_runButton.Text = "Run";
			running = false;
			_programmingUI.Executor.Kill();
		}
	}
}

