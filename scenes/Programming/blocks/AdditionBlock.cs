using System.Collections.Generic;
using GetOn.scenes.Programming.blocks.logic;

namespace GetOn.scenes.Programming.blocks {
    public class AdditionBlock : AbstractBlock {

        public AdditionBlock() {
            Name = "Addition";
            InputTypes = new List<BlockVariableType> {BlockVariableType.Int, BlockVariableType.Int};
        }
        
        public override BlockVariable Execute() {
            var firstNumber = Inputs[0].IntValue;
            var secondNumber = Inputs[1].IntValue;
            return new BlockVariable(this, firstNumber + secondNumber);
        }
        
        public override bool Validate() {
            if (Inputs.Count != 2) {
                ValidationErrorMessage = "Addition block must have exactly 2 inputs!";
                return false;
            }
            if (Inputs[0].Type != BlockVariableType.Int || Inputs[1].Type != BlockVariableType.Int) {
                ValidationErrorMessage = "Addition block must have 2 integer inputs!";
                return false;
            }
            return true;
        }
    }
}