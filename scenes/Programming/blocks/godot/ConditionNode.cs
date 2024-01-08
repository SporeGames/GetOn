using Godot;

namespace GetOn.scenes.Programming.blocks.godot {
    public class ConditionNode : BlockNode {
        
        public override void _Ready() {
            RectMinSize = new Vector2(0, 50);
        }

        public virtual bool Check() {
            return false;
        }
    }
}