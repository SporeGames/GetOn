using GetOn.scenes.Programming.blocks.logic;
using Godot;

namespace GetOn.scenes.Programming.blocks.godot {
    public class VariableNode : GodotNode {

        public BlockVariableType Type;
        
        public override void _Ready() {
            RectMinSize = new Vector2(0, 50);
            var list = GetNode<ItemList>("ItemList");
            list.AddItem("Player");
            list.AddItem("Random");
            list.Connect("item_selected", this, nameof(OnItemSelected));
        }
        
        public void OnItemSelected(int index) {
            switch (index) {
                case 0:
                    Type = BlockVariableType.Node;
                    break;
                case 1:
                    Type = BlockVariableType.None;
                    break;
                case 2:
                    Type = BlockVariableType.Int;
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
    }
}