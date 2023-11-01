using Godot;

namespace GetOn.scenes.Programming.blocks.logic {
    public class BlockVariable {
        public BlockVariableType Type { get; }
        public AbstractBlock Block { get; }
        
        public int IntValue { get; }
        public bool BoolValue { get; }
        public string StringValue { get; }
        public Vector2 VectorValue { get; }
        public Node2D NodeValue { get; }
        
        public BlockVariable(BlockVariableType type, AbstractBlock block) {
            Type = type;
            Block = block;
        }
        
        public BlockVariable(AbstractBlock block, int value) {
            Block = block;
            Type = BlockVariableType.Int;
            IntValue = value;
        }
        
        public BlockVariable(AbstractBlock block, bool value) {
            Block = block;
            Type = BlockVariableType.Bool;
            BoolValue = value;
        }
        
        public BlockVariable(AbstractBlock block, string value) {
            Block = block;
            Type = BlockVariableType.String;
            StringValue = value;
        }
        
        public BlockVariable(AbstractBlock block, Vector2 value) {
            Block = block;
            Type = BlockVariableType.Vector;
            VectorValue = value;
        }
        
        public BlockVariable(AbstractBlock block, Node2D value) {
            Block = block;
            Type = BlockVariableType.Node;
            NodeValue = value;
        }
    }
}