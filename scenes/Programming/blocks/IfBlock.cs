using System;
using System.Collections.Generic;
using GetOn.scenes.Programming.blocks.logic;
using Godot;

namespace GetOn.scenes.Programming.blocks {
    public class IfBlock : AbstractBlock {

    public IfBlock() {
            Name = "if () {}";
            InputTypes = new List<BlockVariableType> {BlockVariableType.Condition};
            ReturnType = BlockVariableType.Bool;
    }
        
        public override BlockVariable Execute() {
            var result = true;
            foreach (var condition in ConnectedConditions) {
                if (!condition.Check()) {
                    result = false;
                }
            }
            return new BlockVariable(this, result);
        }
        
        public override bool Validate() {
            if (ConnectedConditions.Count == 0) {
                throw new BlockLogicException("If block has no conditions!");
            }
            return true;
        }
    }
}