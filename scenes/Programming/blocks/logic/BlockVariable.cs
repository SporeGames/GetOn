using GetOn.scenes.Programming.blocks.godot;
using Godot;

namespace GetOn.scenes.Programming.blocks.logic {
    public class BlockVariable {
        public BlockVariableType Type { get; }
        public GodotNode Block { get; }
        
        public int IntValue { get; }
        public float FloatValue { get; }
        public bool BoolValue { get; }
        public string StringValue { get; }
        public Vector2 VectorValue { get; }
        public Node2D NodeValue { get; }

        public BlockVariable() {
            
        }

        public BlockVariable(BlockVariableType type, GodotNode block) {
            Type = type;
            Block = block;
        }
        
        public BlockVariable(GodotNode block, int value) {
            Block = block;
            Type = BlockVariableType.Int;
            IntValue = value;
        }
        
        public BlockVariable(GodotNode block, float value) {
            Block = block;
            Type = BlockVariableType.Float;
            FloatValue = value;
        }
        
        public BlockVariable(GodotNode block, bool value) {
            Block = block;
            Type = BlockVariableType.Bool;
            BoolValue = value;
        }
        
        public BlockVariable(GodotNode block, string value) {
            Block = block;
            Type = BlockVariableType.String;
            StringValue = value;
        }
        
        public BlockVariable(GodotNode block, Vector2 value) {
            Block = block;
            Type = BlockVariableType.Vector;
            VectorValue = value;
        }
        
        public BlockVariable(GodotNode block, Node2D value) {
            Block = block;
            Type = BlockVariableType.Node;
            NodeValue = value;
        }
    }
}