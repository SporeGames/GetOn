using Godot;

namespace GetOn.scenes.Art {
    public class Art : Node2D {

        private TextureButton _backButton;
        private TextureButton _uploadButton;
        private Node2D _comingSoonPopup;

        public override void _Ready() {
            _backButton = GetNode<TextureButton>("BackButton");
            _backButton.Connect("pressed", this, nameof(OnBackButtonPressed));
            _uploadButton = GetNode<TextureButton>("UploadButton");
            _uploadButton.Connect("pressed", this, nameof(OnUploadButtonPressed));
            _comingSoonPopup = GetNode<Node2D>("ComingSoonPopup");
        }
        
        private void OnBackButtonPressed() {
            GetNode<SharedNode>("/root/SharedNode").SwitchScene("res://scenes/Rooms/SoundArtRoom.tscn");
        }
        
        private void OnUploadButtonPressed() {
            _comingSoonPopup.Visible = true;
        }
    }
}


