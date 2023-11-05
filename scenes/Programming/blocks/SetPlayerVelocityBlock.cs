using System.Collections.Generic;
using GetOn.scenes.Programming.blocks.logic;
using Godot;

namespace GetOn.scenes.Programming.blocks {
    public class SetPlayerVelocityBlock : AbstractBlock {
        
        private const float _delta = 200f;
        
        public SetPlayerVelocityBlock() {
            InputTypes = new List<BlockVariableType> {BlockVariableType.Node, BlockVariableType.Int, BlockVariableType.Int};
        }
		
        public override BlockVariable Execute() {
            var player = Inputs[0].NodeValue;
            var x = Inputs[1].IntValue;
            var y = Inputs[2].IntValue;
            var velocity = new Vector2(x, y);
            player.Position += velocity * _delta;
            return new BlockVariable("SetVeloReturn", this, true);
        }
		
        public override bool Validate() {
            if (Inputs[0] == null || Inputs[1] == null || Inputs[2] == null) {
                ValidationErrorMessage = "SetPlayerVelocity block must have exactly 3 inputs!";
                return false;
            }
            if (Inputs[0].Type != BlockVariableType.Node || Inputs[1].Type != BlockVariableType.Int || Inputs[2].Type != BlockVariableType.Int) {
                ValidationErrorMessage = "SetPlayerVelocity block must have 2 integer inputs and one Node input!";
                return false;
            }
            return true;
        }
    }
}