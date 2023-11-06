using GetOn.scenes.Programming.blocks.logic;
using Godot;

namespace GetOn.scenes.Programming.blocks.godot {
    public class VariableNode : GodotNode {

        [Export]
        public BlockVariableType Type = BlockVariableType.Node;

        [Export] public bool configureable = false;
        public float configureableValue = 0;
        
        private HSlider _slider;
        private RichTextLabel _label;

        public override void _Ready() {
            _slider = GetNode<HSlider>("InputSlider");
            _slider.Connect("value_changed", this, nameof(OnValueChanged));
            _label = GetNode<RichTextLabel>("InputSlider/InputSliderText");
            if (configureable) {
                _slider.Show();
            }
            RectMinSize = new Vector2(0, 50);
            if (configureable) {
                SetSlotTypeRight(0, 3);
                SetSlotColorRight(0, Colors.Cyan);
                return;
            }
            switch (Type) {
                case BlockVariableType.Node:
                    SetSlotTypeRight(0, 2);
                    SetSlotColorRight(0, Colors.Blue);
                    break;
                case BlockVariableType.PositionX:
                    SetSlotTypeRight(0, 3);
                    SetSlotColorRight(0, Colors.Cyan);
                    break;
                case BlockVariableType.PositionY:
                    SetSlotTypeRight(0, 3);
                    SetSlotColorRight(0, Colors.Cyan);
                    break;
            }
        }

        public Node2D GetPlayer() {
            return VariableProvider.PlayerNode;
        }
        
        public Node2D GetFlag() {
            return VariableProvider.FlagNode;
        }
        
        public int GetRandom() {
            return VariableProvider.RandomInt();
        }

        public float GetFloat() {
            return configureableValue;
        }
        
        private void OnValueChanged(float value) {
            configureableValue = (float) _slider.Value;
            _label.Text = configureableValue.ToString();
            GetNode<Checklist>("/root/Programming/Checklist").MoveSpeed(configureableValue);
        }

        public float getPosX() {
            return VariableProvider.PlayerNode.Position.x;
        }
        
        public float getPosY() {
            return VariableProvider.PlayerNode.Position.y;
        }
    }
}