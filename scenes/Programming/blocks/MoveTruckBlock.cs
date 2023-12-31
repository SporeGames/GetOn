using GetOn.scenes.Programming.blocks.logic;

namespace GetOn.scenes.Programming.blocks {
    public class MoveTruckBlock : AbstractBlock {
        public MoveTruckBlock() {
            Name = "MoveTruckBlock";
        }
		
        public override BlockVariable Execute() {
            
            return new BlockVariable("jumpReturn", this, true);
        }
		
        public override bool Validate() {
            return true;
        }
    }
}