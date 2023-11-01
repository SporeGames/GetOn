using System.Collections.Generic;
using GetOn.scenes.Programming.blocks.logic;
using Godot;

namespace GetOn.scenes.Programming.blocks.godot {
    public class BlockNode : GodotNode {

        [Export]
        public string BlockType = "";

        public BlockNode Previous;
        public BlockNode Next;
        
        public List<VariableNode> ConnectedVariables = new List<VariableNode>();
        
        public override void _Ready() {
            RectMinSize = new Vector2(0, 100);
        }
        
        
    }
}