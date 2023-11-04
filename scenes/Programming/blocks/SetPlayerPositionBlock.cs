using System.Collections.Generic;
using GetOn.scenes.Programming.blocks.logic;
using Godot;

namespace GetOn.scenes.Programming.blocks {
	public class SetPlayerPositionBlock : AbstractBlock {
		public SetPlayerPositionBlock() {
			InputTypes = new List<BlockVariableType> {BlockVariableType.Node, BlockVariableType.Int, BlockVariableType.Int};
		}
		
		public override BlockVariable Execute() {
			Node2D player = Inputs[0].NodeValue;
			var x = Inputs[1].IntValue;
			var y = Inputs[2].IntValue;
			player.Position = new Vector2(x, y);
			return new BlockVariable(this, true);
		}
		
		public override bool Validate() {
			if (Inputs.Count != 2) {
				ValidationErrorMessage = "SetPlayerPosition block must have exactly 3 inputs!";
				return false;
			}
			if (Inputs[0].Type != BlockVariableType.Node || Inputs[1].Type != BlockVariableType.Int || Inputs[2].Type != BlockVariableType.Int) {
				ValidationErrorMessage = "SetPlayerPosition block must have 2 integer inputs and one Node input!";
				return false;
			}
			return true;
		}
	}
}
