using System.Collections.Generic;
using GetOn.scenes.Programming.blocks.logic;
using Godot;

namespace GetOn.scenes.Programming.blocks {
    public class JumpBlock : AbstractBlock {
        
        private ulong _lastJump = 0;
        
        public JumpBlock() {
            InputTypes = new List<BlockVariableType> {BlockVariableType.Node, BlockVariableType.Float};
            Name = "JumpBlock";
        }
		
        public override BlockVariable Execute() {
            Node2D player = Inputs[1].NodeValue;
            var y = Inputs[2].getFloat();
            Vector2 posDiff = new Vector2(player.Position.x, y) - player.Position;
            if (player is KinematicBody2D body && OS.GetTicksMsec() - _lastJump > 1000) {
                _lastJump = OS.GetTicksMsec();
                body.MoveAndCollide(posDiff);
            }
            return new BlockVariable("jumpReturn", this, true);
        }
		
        public override bool Validate() {
            if (Inputs[1] == null || Inputs[2] == null) {
                ValidationErrorMessage = "JumpBlock must have 2 inputs!";
                return false;
            }
            return true;
        }
    }
}