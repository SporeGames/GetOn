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
			var speed = Mathf.Abs(player.Position.x - x);
			if (player is Player body) {
				if ((body.Position.x + x) > body.Position.x) {
					GetNode<Checklist>("/root/Programming/Checklist").OnMove();
				}
				body.Speed = (int) speed * 20;
				body.MovingRight = true;
			}
			return new BlockVariable("posReturn", this, true);
		}
		
		public override bool Validate() {
			if (Inputs[1] == null || Inputs[2] == null || Inputs[3] == null) {
				ValidationErrorMessage = "The Set Position node must have three inputs. Make sure a Player reference and two numbers are connected.";
				return false;
			}
			return true;
		}
	}
}
