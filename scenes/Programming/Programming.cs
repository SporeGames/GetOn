using System.Collections.Generic;
using Godot;

namespace GetOn.scenes.Programming
{
	public class Programming : Node2D {
		private Color _errorColor = new Color(0.72f, 0.19f, 0.19f);
		
		private SharedNode _sharedNode;
		
		
		private TextureButton _runButton;
		private TextureButton _resetButton;
		private ColorRect _runOverlay;
		private NodeGraph _programmingUi;
		private Checklist _checklist;
		public KinematicBody2D Truck;

		private RichTextLabel _errorList;
		private ColorRect _errorBox;
		private AudioStreamPlayer _executeSound;

		private Vector2 _playerOrigin;

		private bool _running = false;
		
		private List<string> _errors = new List<string>();
		
		public override void _Ready() {
			_sharedNode = GetNode<SharedNode>("/root/SharedNode");
			_programmingUi = GetNode<NodeGraph>("ProgrammingUI/AspectRatioContainer/NodeGraph");
			_runButton = GetNode<TextureButton>("ProgrammingUI/RunButton");
			_runButton.Connect("pressed", this, nameof(OnRunPressed));
			_runOverlay = GetNode<ColorRect>("ProgrammingUI/RunOverlay");
			_resetButton = GetNode<TextureButton>("ProgrammingUI/ResetButton");
			_errorList = GetNode<RichTextLabel>("ProgrammingUI/ErrorBox/ErrorList");
			_errorBox = GetNode<ColorRect>("ProgrammingUI/ErrorBox");
			_resetButton.Connect("pressed", this, nameof(OnResetPressed));
			_playerOrigin = GetNode<KinematicBody2D>("Game/Player").Position;
			_checklist = GetNode<Checklist>("Checklist");
			Truck = GetNode<KinematicBody2D>("Game/Truck");
			_executeSound = GetNode<AudioStreamPlayer>("ExecuteSound");
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
			_sharedNode.PlayGenericClick();
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
			GetNode<SharedNode>("/root/SharedNode").EncounteredErrors++;
		}
		
		private void Run() {
			GetNode<Player>("Game/Player").Velocity = new Vector2(0, 0);
			_runOverlay.Visible = true;
			_runButton.GetNode<RichTextLabel>("RichTextLabel").Text  = "Stop";
			_running = true;
			_errorList.Text = "No errors!";
			_checklist.Reset();
			_checklist.SubmitButton.Disabled = false;
			GetNode<SharedNode>("/root/SharedNode").TestsRun++;
			_executeSound.Playing = true;
		}
		
		private void Stop() {
			_runOverlay.Visible = false;
			_runButton.GetNode<RichTextLabel>("RichTextLabel").Text = "Run";
			_running = false;
			_errors.Clear();
			_errorBox.Color = new Color(0f, 0f, 0f);
			_sharedNode.PlayGenericClick();
			//_programmingUI.Executor.Kill();
		}
	}
}

