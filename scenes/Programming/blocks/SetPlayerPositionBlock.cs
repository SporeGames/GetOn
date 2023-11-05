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
			var output = "";
			foreach (var input in Inputs) {
				if (input == null) {
					output += "none/";
					continue;
				}
				output += input.Type + "/";
			}
			GD.Print(output);
			if (Inputs[0] == null || Inputs[1] == null || Inputs[2] == null) {
				ValidationErrorMessage = "SetPositionBlock must have 3 inputs!";
				return false;
			}
			return true;
		}
	}
}
