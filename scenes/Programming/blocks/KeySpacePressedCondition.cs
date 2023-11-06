using GetOn.scenes.Programming.blocks.godot;
using Godot;

namespace GetOn.scenes.Programming.blocks {
    public class KeySpacePressedCondition : ConditionNode{
        public override bool Check() {
            return Input.IsPhysicalKeyPressed((int) KeyList.Space);
        }
    }
}