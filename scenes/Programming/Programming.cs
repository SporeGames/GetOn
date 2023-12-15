using Godot;
using GetOn.scenes.Programming;

namespace GetOn.scenes.GameSelectionRoom
{
	public class Programming : Node2D
	{
		private SharedNode _sharedNode;
		
		private Button _backToGameSelectionRoom;
		
		private Button _runButton;
		private Button _resetButton;
		private ColorRect _runOverlay;
		private NodeGraph _programmingUI;
		public Checklist Checklist;

		private Vector2 _playerOrigin;

		private bool running = false;

		private bool firstStart = true;
		public override void _Ready() {
			_sharedNode = GetNode<SharedNode>("/root/SharedNode");
			_backToGameSelectionRoom = GetNode<Button>("Game/BackToGameSelection");
			_backToGameSelectionRoom.Connect("pressed", this, nameof(OnBackToSelectionRoomPressed));
			_programmingUI = GetNode<NodeGraph>("ProgrammingUI/AspectRatioContainer/NodeGraph");
			_runButton = GetNode<Button>("ProgrammingUI/RunButton");
			_runButton.Connect("pressed", this, nameof(OnRunPressed));
			_runOverlay = GetNode<ColorRect>("ProgrammingUI/RunOverlay");
			_resetButton = GetNode<Button>("ProgrammingUI/ResetButton");
			_resetButton.Connect("pressed", this, nameof(OnResetPressed));
			_playerOrigin = GetNode<KinematicBody2D>("Game/Player").Position;
			Checklist = GetNode<Checklist>("Checklist");
			GetNode<CountdownTimer>("/root/Programming/Timer").running = true;
		}

		public override void _Process(float delta) {
			/*if (running && firstStart) {
				_programmingUI.Executor.Start();
				firstStart = false;
			}*/
			if (running) {
				_programmingUI.Executor.StartBlock.Run();
			}
		}

		public void OnBackToSelectionRoomPressed() {
			_sharedNode.SwitchScene("res://scenes/GameSelectionRoom/GameSelectionRoom.tscn");
		}

		public void OnResetPressed() {
			GetNode<KinematicBody2D>("Game/Player").Position = _playerOrigin;
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
			Checklist.Reset();
		}
		
		private void Stop() {
			_runOverlay.Visible = false;
			_runButton.Text = "Run";
			running = false;
			//_programmingUI.Executor.Kill();
		}
	}
}

