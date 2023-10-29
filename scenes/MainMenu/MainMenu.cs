using Godot;

namespace GetOn.scenes.MainMenu {
    public class MainMenu : Control {

        private SharedNode _sharedNode;

        private LineEdit _nameInput;
        private Button _submitButton;
        private Button _testPDFButton;

        public override void _Ready() {
            _sharedNode = GetNode<SharedNode>("/root/SharedNode");
            _nameInput = GetNode<LineEdit>("NameInput");
            _nameInput.Connect("text_changed", this, nameof(OnTextEntered));
            _submitButton = GetNode<Button>("SubmitButton");
            _submitButton.Connect("pressed", this, nameof(OnSubmitButtonPressed));
            _testPDFButton = GetNode<Button>("TestPDFGenButton");
            _testPDFButton.Connect("pressed", this, nameof(TestPDF));
        }

        private void OnTextEntered(string text) {
            // Idk if we should do some validation here, some people have weird names
            var input = _nameInput.Text.Trim();
            _submitButton.Disabled = input.Empty();
            _sharedNode.PlayerName = input;
        }

        private void OnSubmitButtonPressed() {
            _sharedNode.SwitchScene("res://scenes/GameSelectionRoom/GameSelectionRoom.tscn");
        }

        private void TestPDF() {
            _sharedNode.Print();
        }
    }
}
