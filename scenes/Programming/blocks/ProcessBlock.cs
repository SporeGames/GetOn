using GetOn.scenes.Programming.blocks.logic;

namespace GetOn.scenes.Programming.blocks {
	public class ProcessBlock : AbstractBlock {
		public override BlockVariable Execute() {
			GetNode<Checklist>("/root/Programming/Checklist").OnProcess();
			return new BlockVariable("processReturn", this, true);
		}

		public override bool Validate() {
			return true;
		}
	}
}
