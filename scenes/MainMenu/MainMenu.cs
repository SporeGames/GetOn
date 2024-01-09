using System;
using Godot;

namespace GetOn.scenes.MainMenu {
	public class MainMenu : Control {

		private SharedNode _sharedNode;

		private LineEdit _nameInput;
		private TextureButton _submitButton;
		private Button _testPDFButton;
		private OptionButton _specializationSelect;

		public override void _Ready() {
			// Hi! I'm the main menu. I'm the first thing you see when you start the game.
			_sharedNode = GetNode<SharedNode>("/root/SharedNode");
			_nameInput = GetNode<LineEdit>("NameInput");
			_specializationSelect = GetNode<OptionButton>("SpecializationSelect");
			_specializationSelect.Connect("item_selected", this, nameof(OnSpecSelect));
			_nameInput.Connect("text_changed", this, nameof(OnTextEntered));
			_submitButton = GetNode<TextureButton>("SubmitButton");
			_submitButton.Connect("pressed", this, nameof(OnSubmitButtonPressed));
			_testPDFButton = GetNode<Button>("TestPDFGenButton");
			_testPDFButton.Connect("pressed", this, nameof(TestPDF));

			foreach (var focus in Enum.GetValues(typeof(AbilitySpecialization))) {
				_specializationSelect.AddItem(focus.ToString().Replace("_", " "));
			}
		}

		public override void _Process(float delta) {
			_submitButton.Disabled = _nameInput.Text.Trim().Empty() || _specializationSelect.Selected == -1 || _specializationSelect.Selected == 0;
		}

		private void OnTextEntered(string text) {
			// Idk if we should do some validation here, some people have weird names
			var input = _nameInput.Text.Trim();
			_sharedNode.PlayerName = input;
		}
		
		private void OnSpecSelect(int index) {
			_sharedNode.Specialization = (AbilitySpecialization) index;
		}

		public override void _Input(InputEvent @event) {
			if (@event is InputEventKey keyEvent) {
				if (keyEvent.Pressed && keyEvent.Scancode == (int) KeyList.Enter && _submitButton.Disabled == false) {
					OnSubmitButtonPressed();
				}
			}
		}

		private void OnSubmitButtonPressed() {
			_sharedNode.SwitchScene("res://scenes/GameSelectionRoom/GameSelectionRoom.tscn");
		}

		private void TestPDF() {
			_sharedNode.Print();
		}

		
	}
}
