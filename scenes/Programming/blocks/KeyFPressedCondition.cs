using GetOn.scenes.Programming.blocks.godot;
using Godot;

namespace GetOn.scenes.Programming.blocks {
    public class KeyFPressedCondition : ConditionNode {
        public override bool Check() {
            return Input.IsActionPressed("f_pressed");
        }
    }
}