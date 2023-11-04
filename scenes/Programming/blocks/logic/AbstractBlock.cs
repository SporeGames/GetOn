using System;
using System.Collections.Generic;
using System.Linq;
using GetOn.scenes.Programming.blocks.godot;
using Godot;

namespace GetOn.scenes.Programming.blocks.logic {
	public class AbstractBlock : BlockNode {

		public string Name { get; set; }
		public AbstractBlock NextBlock { get; set; }
		public BlockVariableType ReturnType { get; set; }
		public BlockVariable[] Inputs { get; set; } = new BlockVariable[8];
		public List<BlockVariableType> InputTypes { get; set; }

		public BlockVariable ReturnVariable = new BlockVariable();
		protected bool Returns = false;

		protected string ValidationErrorMessage = "Block validation failed!";

		public override void _Ready() {
			if (Returns) {
				ReturnVariable = new BlockVariable(this, false);
			}
		}

		public void Run() {
			GD.Print("Executing : " + Name);
			if (!Validate()) {
				throw new BlockLogicException(ValidationErrorMessage);
			}

			var returnValue = Execute();
			if (Returns) {
				ReturnVariable = returnValue;
			}
			if (NextBlock != null && returnValue.BoolValue) {
				NextBlock.Run();
			}
		}

		public virtual BlockVariable Execute() {
			throw new BlockLogicException("Abstract block cannot be executed!");
		}

		public virtual bool Validate() {
			throw new BlockLogicException("No validation implemented for this block!");
		}

		public void Connected(int slot) {
			if (slot == -1) {
				return;
			}
			for (var i = 0; i < ConnectedVariables.Length; i++) {
				var node = ConnectedVariables[i];
				if (node == null) {
					continue;
				}
				if (node is VariableNode variableNode) {
					GD.Print("Node type: " + variableNode.Type);
					if (variableNode.configureable) {
						Inputs[slot] = new BlockVariable(this, variableNode.GetFloat());
						GD.Print("Added configurable float input");
						break;
					}
					switch (variableNode.Type) {
						case BlockVariableType.Node:
							Inputs[slot] = new BlockVariable(this, variableNode.GetPlayer());
							GD.Print("Added node input");
							break;
						case BlockVariableType.Int:
							Inputs[slot] = new BlockVariable(this, variableNode.GetRandom());
							GD.Print("Added int input");
							break;

					}
				}
				if (node is AbstractBlock nodeBlock) {
					GD.Print("AbstractBlock return type: " + nodeBlock.ReturnType);
					if (nodeBlock.Returns) {
						Inputs[slot] = nodeBlock.ReturnVariable;
						GD.Print("Added return variable input");
					}
				}
			}
			GD.Print("Connected inputs: " + Inputs.ToString());
		}
	}
}
