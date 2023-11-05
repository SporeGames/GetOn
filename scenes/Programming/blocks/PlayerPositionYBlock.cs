using System.Collections.Generic;
using GetOn.scenes.Programming.blocks.logic;
using Godot;

namespace GetOn.scenes.Programming.blocks {
    public class PlayerPositionYBlock : AbstractBlock {
        public PlayerPositionYBlock() {
            InputTypes = new List<BlockVariableType> {BlockVariableType.Node};
            Returns = true;
        }
        
        public override void _Ready() {
            Returns = true;
            ReturnType = BlockVariableType.Float;
        }
		
        public override BlockVariable Execute() {
            Node2D player = Inputs[0].NodeValue;
            return new BlockVariable(this, player.Position.y);
        }
		
        public override bool Validate() {
            if (Inputs[0] == null) {
                ValidationErrorMessage = "PlayerPosition block must have one Node input!";
                return false;
            }
            if (Inputs[0].Type != BlockVariableType.Node) {
                ValidationErrorMessage = "PlayerPosition block must have one Node input!";
                return false;
            }
            return true;
        }
    }
}