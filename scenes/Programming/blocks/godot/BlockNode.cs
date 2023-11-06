using System.Collections.Generic;
using GetOn.scenes.Programming.blocks.logic;
using Godot;

namespace GetOn.scenes.Programming.blocks.godot {
    public class BlockNode : GodotNode {

        [Export]
        public string BlockType = "";

        public BlockNode Previous;

        public GodotNode[] ConnectedVariables = new GodotNode[8];
        public List<ConditionNode> ConnectedConditions = new List<ConditionNode>();
        
        public override void _Ready() {
            RectMinSize = new Vector2(0, 100);
        }
        
        
    }
}