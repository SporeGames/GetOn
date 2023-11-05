using System.Collections.Generic;
using GetOn.scenes.Programming.blocks.logic;
using Godot;

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
			GD.Print("Adding " + firstNumber + " and " + secondNumber + " = " + (firstNumber + secondNumber) + ".");
			ReturnVariable = new BlockVariable("addReturn1", this, firstNumber + secondNumber);
			return new BlockVariable("addReturn", this, firstNumber + secondNumber); // TODO: This does not seem to reach the SetPositionBlock (receives 0)
		}
		
		public override bool Validate() {
			return true;
		}
	}
}
