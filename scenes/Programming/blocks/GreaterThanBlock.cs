using System.Collections.Generic;
using GetOn.scenes.Programming.blocks.logic;

namespace GetOn.scenes.Programming.blocks {
	public class GreaterThanBlock : AbstractBlock {
		public GreaterThanBlock() {
			InputTypes = new List<BlockVariableType> {BlockVariableType.Int, BlockVariableType.Int};
		}
		
		public override BlockVariable Execute() {
			var firstNumber = Inputs[0].getInt();
			var secondNumber = Inputs[1].getInt();
			if (firstNumber > secondNumber) {
				return new BlockVariable("greaterReturn", this, true);
			}
			return new BlockVariable("greaterReturn", this, false);
		}
		
		public override bool Validate() {
			if (Inputs[0] == null || Inputs[1] == null) {
				ValidationErrorMessage = "GreaterThanBlock block must have exactly 2 inputs!";
				return false;
			}
			if (Inputs[0].Type != BlockVariableType.Int || Inputs[1].Type != BlockVariableType.Int) {
				ValidationErrorMessage = "GreaterThan block must have 2 integer inputs!";
				return false;
			}
			return true;
		}
	}
}
