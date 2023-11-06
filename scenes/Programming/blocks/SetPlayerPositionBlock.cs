using System.Collections.Generic;
using GetOn.scenes.Programming.blocks.logic;
using Godot;
	
namespace GetOn.scenes.Programming.blocks {
	public class SetPlayerPositionBlock : AbstractBlock {
		
		[Export]
		private float _movementMultiplier = 50f;
		
		public SetPlayerPositionBlock() {
			InputTypes = new List<BlockVariableType> {BlockVariableType.Node, BlockVariableType.Float, BlockVariableType.Float};
			Name = "SetPlayerPosition";
		}
		
		public override BlockVariable Execute() {
			Node2D player = Inputs[1].NodeValue;
			var x = Inputs[2].getFloat();
			var y = Inputs[3].getFloat();
			Vector2 posDiff = new Vector2(x, y) - player.Position;
			posDiff *= _movementMultiplier;
			if (player is Player body) {
				body.MoveAndSlide(posDiff);
			}
			return new BlockVariable("posReturn", this, true);
		}
		
		public override bool Validate() {
			if (Inputs[1] == null || Inputs[2] == null || Inputs[3] == null) {
				ValidationErrorMessage = "SetPositionBlock must have 3 inputs!";
				return false;
			}
			return true;
		}
	}
}
