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
		public bool Returns = false;

		protected string ValidationErrorMessage = "Block validation failed!";

		public override void _Ready() {
			if (Returns) {
				ReturnVariable = new BlockVariable(this, false);
			}
		}

		public void Run() {
			GD.Print("Executing: " + base.Name);
			try {
				if (!Validate()) {
					throw new BlockLogicException(ValidationErrorMessage);
				}
			} catch (BlockLogicException e) {
				GD.Print(e.Message);
				return;
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

		public void Connected(GodotNode connectingNode, int slot) {
			if (connectingNode == this) {
				return;
			}

			if (slot == 0) {
				return;
			}
			var currentNodeInSlot = ConnectedVariables[slot];
			if (currentNodeInSlot != null) {
				GD.Print("Slot " + slot + " already connected! (" + currentNodeInSlot.Name + ")");
				return;
			}
			ConnectedVariables[slot] = connectingNode;
			if (connectingNode is VariableNode variableNode) {
				GD.Print("Node type: " + variableNode.Type);
				if (variableNode.configureable) {
					Inputs[slot] = new BlockVariable(this, variableNode.GetFloat());
					GD.Print("Added configurable float input");
					return;
				}

				switch (variableNode.Type) {
					case BlockVariableType.Node:
						Inputs[slot] = new BlockVariable(this, variableNode.GetPlayer());
						GD.Print("Added node input");
						return;
					case BlockVariableType.Int:
						Inputs[slot] = new BlockVariable(this, variableNode.GetRandom());
						GD.Print("Added int input");
						return;
					case BlockVariableType.PositionX:
						Inputs[slot] = new BlockVariable(this, variableNode.GetPlayer().Position.x);
						GD.Print("Added position x input");
						return;
					case BlockVariableType.PositionY:
						Inputs[slot] = new BlockVariable(this, variableNode.GetPlayer().Position.y);
						GD.Print("Added position y input");
						return;

				}
			}
			if (connectingNode is AbstractBlock connectingNodeBlock) {
				GD.Print("AbstractBlock return type: " + connectingNodeBlock.ReturnType + " for slot " + slot + " with nodeBlock " + connectingNodeBlock.Name + " (this: " + Name + ", Returns: " + connectingNodeBlock.Returns + ", nodeBlock class: " + connectingNodeBlock.GetType() + ")");
				if (connectingNodeBlock.Returns) {
					Inputs[slot] = connectingNodeBlock.ReturnVariable;
					GD.Print("Added return variable input");
				}
			}

			GD.Print("Connected inputs:");
			foreach (var input in Inputs) {
				if (input == null) {
					GD.Print("null");
					continue;
				}
				GD.Print(input.Type);
			}
		}
	}
}
