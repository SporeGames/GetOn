using GetOn.scenes.Programming.blocks.godot;
using Godot;

namespace GetOn.scenes.Programming.blocks {
    public class KeySpacePressedCondition : ConditionNode {
        public override bool Check() {
            GetNode<Checklist>("/root/Programming/Checklist").OnSpaceBar(Input.IsPhysicalKeyPressed((int) KeyList.Space));
            return Input.IsPhysicalKeyPressed((int) KeyList.Space);
        }
    }
}