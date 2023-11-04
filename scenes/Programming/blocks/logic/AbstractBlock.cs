using System;
using System.Collections.Generic;
using GetOn.scenes.Programming.blocks.godot;
using Godot;

namespace GetOn.scenes.Programming.blocks.logic {
	public class AbstractBlock : BlockNode {

		public string Name { get; set; }
		public AbstractBlock NextBlock { get; set; }
		public BlockVariableType ReturnType { get; set; }
		public List<BlockVariable> Inputs { get; set; } = new List<BlockVariable>();
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
			if (NextBlock != null) {
				NextBlock.Run();
			}
		}

		public virtual BlockVariable Execute() {
			throw new BlockLogicException("Abstract block cannot be executed!");
		}

		public virtual bool Validate() {
			throw new BlockLogicException("No validation implemented for this block!");
		}

		public void Connected() {
			for (var i = 0; i < ConnectedVariables.Length; i++) {
				var node = ConnectedVariables[i];
				if (node == null) {
					continue;
				}
				GD.Print("Connecting node " + node.Name + " to block " + Name);
				if (node is VariableNode variableNode) {
					GD.Print("Node type: " + variableNode.Type);
					if (variableNode.configureable) {
						Inputs.Add(new BlockVariable(this, variableNode.GetFloat()));
						break;
					}
					switch (variableNode.Type) {
						case BlockVariableType.Node:
							Inputs.Add(new BlockVariable(this, variableNode.GetPlayer()));
							GD.Print("Added node input");
							break;
						case BlockVariableType.Int:
							Inputs.Add(new BlockVariable(this, variableNode.GetRandom()));
							GD.Print("Added int input");
							break;

					}
				}

				if (node is AbstractBlock nodeBlock) {
					GD.Print("Node type: " + nodeBlock.ReturnType);
					if (nodeBlock.Returns) {
						Inputs.Add(nodeBlock.ReturnVariable);
						GD.Print("Added return variable input");
					}
				}
			}
		}
	}
}
