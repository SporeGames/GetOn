using GetOn.scenes.Programming.blocks.godot;
using Godot;

namespace GetOn.scenes.Programming.blocks {
    public class KeyAPressedCondition : ConditionNode {
        public override bool Check() {
            return Input.IsPhysicalKeyPressed((int) KeyList.D); // They are swapped for some weird reason.
        }
    }
}