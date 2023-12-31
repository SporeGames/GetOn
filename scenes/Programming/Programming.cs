using System.Collections.Generic;
using Godot;

namespace GetOn.scenes.Programming
{
	public class Programming : Node2D {
		private Color _errorColor = new Color(0.72f, 0.19f, 0.19f);
		
		private SharedNode _sharedNode;
		
		private Button _backToGameSelectionRoom;
		
		private Button _runButton;
		private Button _resetButton;
		private ColorRect _runOverlay;
		private NodeGraph _programmingUi;
		private Checklist _checklist;
		public KinematicBody2D Truck;

		private RichTextLabel _errorList;
		private ColorRect _errorBox;

		private Vector2 _playerOrigin;

		private bool _running = false;

		private Button _start;
		private Node2D _intro;
		
		private List<string> _errors = new List<string>();
		public override void _Ready() {
			_sharedNode = GetNode<SharedNode>("/root/SharedNode");
			_backToGameSelectionRoom = GetNode<Button>("Game/BackToGameSelection");
			_backToGameSelectionRoom.Connect("pressed", this, nameof(OnBackToSelectionRoomPressed));
			_programmingUi = GetNode<NodeGraph>("ProgrammingUI/AspectRatioContainer/NodeGraph");
			_runButton = GetNode<Button>("ProgrammingUI/RunButton");
			_runButton.Connect("pressed", this, nameof(OnRunPressed));
			_runOverlay = GetNode<ColorRect>("ProgrammingUI/RunOverlay");
			_resetButton = GetNode<Button>("ProgrammingUI/ResetButton");
			_errorList = GetNode<RichTextLabel>("ProgrammingUI/ErrorBox/ErrorList");
			_errorBox = GetNode<ColorRect>("ProgrammingUI/ErrorBox");
			_resetButton.Connect("pressed", this, nameof(OnResetPressed));
			_playerOrigin = GetNode<KinematicBody2D>("Game/Player").Position;
			_checklist = GetNode<Checklist>("Checklist");
			GetNode<CountdownTimer>("/root/Programming/Timer").running = true;
			Truck = GetNode<KinematicBody2D>("Game/Truck");

			_start = GetNode<Button>("/root/Programming/Intro/Button");
			_start.Connect("pressed", this, nameof(HideIntro));
			_intro = GetNode<Node2D>("/root/Programming/Intro");
		}

		public void HideIntro()
		{
			_intro.Visible = false;
		}

		public override void _Process(float delta) {
			/*if (running && firstStart) {
				_programmingUI.Executor.Start();
				firstStart = false;
			}*/
			if (_running) {
				_programmingUi.Executor.StartBlock.Run();
			}
			var text = "";
			foreach (var msg in _errors) {
				text += "- " + msg + "\n";
			}
			_errorList.Text = text;
		}

		public void OnBackToSelectionRoomPressed() {
			_sharedNode.SwitchScene("res://scenes/GameSelectionRoom/GameSelectionRoom.tscn");
		}

		public void OnResetPressed() {
			GetNode<KinematicBody2D>("Game/Player").Position = _playerOrigin;
		}

		public void OnRunPressed() {
			if (_running) {
				GD.Print("Stopping...");
				Stop();
			} else {
				GD.Print("Running...");
				Run();
			}
		}
		
		public void RegisterError(string error) {
			if (_errors.Contains(error)) return;
			_errors.Add(error);
			_errorBox.Color = _errorColor;
		}
		
		private void Run() {
			_runOverlay.Visible = true;
			_runButton.Text = "Stop";
			_running = true;
			_errorList.Text = "No errors!";
			_checklist.Reset();
			_checklist.SubmitButton.Disabled = false;
		}
		
		private void Stop() {
			_runOverlay.Visible = false;
			_runButton.Text = "Run";
			_running = false;
			_errors.Clear();
			_errorList.Text = "Press 'Execute Code' to see errors...";
			_errorBox.Color = new Color(0f, 0f, 0f);
			//_programmingUI.Executor.Kill();
		}
	}
}

