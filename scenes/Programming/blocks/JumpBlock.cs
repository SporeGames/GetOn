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
                body.JumpingInput = true;
            }
            return new BlockVariable("jumpReturn", this, true);
        }
		
        public override bool Validate() {
            if (Inputs[1] == null) {
                ValidationErrorMessage = "The Jump node must have one input. Make sure a Player reference is connected.";
                return false;
            }
            return true;
        }
    }
}