using GetOn.scenes.Programming.blocks.godot;
using Godot;

namespace GetOn.scenes.Programming.blocks {
	public class KeyDPressedCondition : ConditionNode {
		public override bool Check() {
			//return Input.IsPhysicalKeyPressed((int) KeyList.A); // They are swapped for some weird reason.
			GetNode<Checklist>("/root/Programming/Checklist").OnDPressed(Input.IsActionPressed("d_pressed"));
			return Input.IsActionPressed("d_pressed");
		}
	}
}
