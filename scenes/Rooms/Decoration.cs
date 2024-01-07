using Godot;

namespace GetOn.scenes.Rooms {
	public class Decoration : Node2D {

		[Export] public Texture PopupTexture;
		[Export] public Texture SmallTexture;
		[Export(PropertyHint.Range, "0, 5")] public float SmallScale = 1.0f;
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
			_popUpSprite.Texture = PopupTexture;
			_popUpSprite.Scale = new Vector2(PopupScale, PopupScale);
			_decorationSprite.TextureNormal = SmallTexture;
			_decorationSprite.RectScale = new Vector2(SmallScale, SmallScale);
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
