using System.Collections.Generic;
using GetOn.scenes.Programming.blocks.logic;
using Godot;

namespace GetOn.scenes.Programming.blocks {
	public class SetPlayerPositionBlock : AbstractBlock {
		public SetPlayerPositionBlock() {
			InputTypes = new List<BlockVariableType> {BlockVariableType.Node, BlockVariableType.Float, BlockVariableType.Float};
			Name = "SetPlayerPosition";
		}
		
		public override BlockVariable Execute() {
			Node2D player = Inputs[0].NodeValue;
			var x = Inputs[1].FloatValue;
			var y = Inputs[2].FloatValue;
			player.Position = new Vector2(x, y);
			return new BlockVariable(this, true);
		}
		
		public override bool Validate() {
			if (Inputs.Count != 3) {
				ValidationErrorMessage = "SetPlayerPosition block must have exactly 3 inputs!";
				GD.Print(Inputs.ToString());
				return false;
			}
			if (Inputs[0].Type != BlockVariableType.Node || Inputs[1].Type != BlockVariableType.Float || Inputs[2].Type != BlockVariableType.Float) {
				ValidationErrorMessage = "SetPlayerPosition block must have 2 ;float inputs and one Node input!";
				return false;
			}
			return true;
		}
	}
}
