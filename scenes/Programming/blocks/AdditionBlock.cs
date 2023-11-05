using System.Collections.Generic;
using GetOn.scenes.Programming.blocks.logic;

namespace GetOn.scenes.Programming.blocks {
	public class AdditionBlock : AbstractBlock {

		public AdditionBlock() {
			Name = "Addition";
			InputTypes = new List<BlockVariableType> {BlockVariableType.Float, BlockVariableType.Float};
			Returns = true;
			ReturnType = BlockVariableType.Float;
		}

		public override void _Ready() {
			Returns = true;
			ReturnType = BlockVariableType.Float;
		}

		public override BlockVariable Execute() {
			var firstNumber = Inputs[1].FloatValue;
			var secondNumber = Inputs[2].FloatValue;
			return new BlockVariable(this, firstNumber + secondNumber);
		}
		
		public override bool Validate() {
			if (Inputs[1].Type != BlockVariableType.Float || Inputs[2].Type != BlockVariableType.Float) {
				ValidationErrorMessage = "Addition block must have 2 float inputs!";
				return false;
			}
			return true;
		}
	}
}
