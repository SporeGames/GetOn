using System.Collections.Generic;
using GetOn.scenes.Programming.blocks.logic;
using Godot;

namespace GetOn.scenes.Programming.blocks {
    public class JumpBlock : AbstractBlock {
        
        public JumpBlock() {
            InputTypes = new List<BlockVariableType> {BlockVariableType.Node};
            Name = "JumpBlock";
        }
		
        public override BlockVariable Execute() {
            Node2D player = Inputs[1].NodeValue;
            if (player is Player body) {
                GetNode<Checklist>("/root/Programming/Checklist").OnJump();
                body.Jump();
            }
            return new BlockVariable("jumpReturn", this, true);
        }
		
        public override bool Validate() {
            if (Inputs[1] == null) {
                ValidationErrorMessage = "JumpBlock must have 1 input!";
                return false;
            }
            return true;
        }
    }
}