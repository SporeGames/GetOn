using System;
using System.Collections.Generic;
using GetOn.scenes.Programming.blocks.logic;
using Godot;

namespace GetOn.scenes.Programming.blocks {
	public class AdditionBlock : AbstractBlock {

		private float result = 0;

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
			float firstNumber = Inputs[1].getFloat();
			float secondNumber = Inputs[2].getFloat();
			result = firstNumber + secondNumber;
			GetNode<Checklist>("/root/Programming/Checklist").MoveSpeed(Math.Abs(firstNumber - secondNumber));
			ReturnVariable = new BlockVariable("addReturn", this, result);
			return new BlockVariable("addReturn", this, result); 
		}
		
		public override bool Validate() {
			if (Inputs[1] == null || Inputs[2] == null) {
				ValidationErrorMessage = "The Addition node must have two inputs. Please connect two numbers (cyan) to it.";
				return false;
			}
			return true;
		}

		public override float getFloat() {
			return result;
		}
	}
}
