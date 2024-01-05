using Godot;

namespace GetOn.scenes.Rooms {
    public class Decoration : Node2D {

        [Export] public Texture Texture;
        [Export(PropertyHint.Range, "0, 5")] public float NormalScale = 0.5f;
        [Export(PropertyHint.Range, "0, 5")] public float PopupScale = 1.0f;
    
        private TextureButton _decorationSprite;
        private Sprite _popUpSprite;
        private Node2D _popUp;

        private Material _material;
    
        public override void _Ready() {
            _material = ResourceLoader.Load<Material>("res://SharedAssets/OutlineMaterial.tres");
            _decorationSprite = GetNode<TextureButton>("Sprite");
            _popUp = GetNode<Node2D>("Popup");
            _popUpSprite = GetNode<Sprite>("Popup/Sprite");
            _popUp.Visible = false;
            _popUpSprite.Texture = Texture;
            _popUpSprite.Scale = new Vector2(PopupScale, PopupScale);
            _decorationSprite.TextureNormal = Texture;
            _decorationSprite.RectScale = new Vector2(NormalScale, NormalScale);
            _decorationSprite.Connect("mouse_entered", this, nameof(OnMouseEntered));
            _decorationSprite.Connect("mouse_exited", this, nameof(OnMouseExited));
            _decorationSprite.Connect("pressed", this, nameof(OnClicked));
        }


        public override void _UnhandledInput(InputEvent @event) {
            if (@event is InputEventMouseButton eventMouseButton && eventMouseButton.Pressed) {
                if (_popUp.Visible) {
                    _popUp.Visible = false;
                    GetViewport().SetInputAsHandled();
                }
            }
        }
    
    

        private void OnClicked() {
            _popUp.Visible = true;
            var center = GetViewportRect().Size / 2;
            _popUp.GlobalPosition = center;
        }
    
        private void OnMouseEntered() {
            _decorationSprite.Material = _material;
        }
    
        private void OnMouseExited() {
            _decorationSprite.Material = null;
        }

    
    }
}
