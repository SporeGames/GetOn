using Godot.Collections;

namespace GetOn.scenes.Programming.blocks.logic {
    public static class BlockTypes {
        public static Dictionary<string, AbstractBlock> Blocks = new Dictionary<string, AbstractBlock>();
        
        public static void RegisterBlock(AbstractBlock block) {
            Blocks.Add(block.Name, block);
        }
    }
}