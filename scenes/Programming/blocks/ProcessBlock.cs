using GetOn.scenes.Programming.blocks.logic;

namespace GetOn.scenes.Programming.blocks {
    public class ProcessBlock : AbstractBlock {
        public override BlockVariable Execute() {
            return new BlockVariable("processReturn", this, true);
        }

        public override bool Validate() {
            return true;
        }
    }
}