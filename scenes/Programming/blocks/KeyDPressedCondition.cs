using GetOn.scenes.Programming.blocks.godot;
using Godot;

namespace GetOn.scenes.Programming.blocks {
	public class KeyDPressedCondition : ConditionNode {
		public override bool Check() {
			//return Input.IsPhysicalKeyPressed((int) KeyList.A); // They are swapped for some weird reason.
			return Input.IsActionPressed("d_pressed");
		}
	}
}
