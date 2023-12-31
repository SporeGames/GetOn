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
            return new BlockVariable("ifReturn", this, result);
        }
        
        public override bool Validate() {
            if (ConnectedConditions.Count == 0) {
                throw new BlockLogicException("One If node has no conditions connected. Please connect a condition (purple) node to it.");
            }
            return true;
        }
    }
}