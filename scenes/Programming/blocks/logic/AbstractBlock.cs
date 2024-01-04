using System;
using System.Collections.Generic;
using System.Linq;
using GetOn.scenes.Programming.blocks.godot;
using Godot;

namespace GetOn.scenes.Programming.blocks.logic {
	public class AbstractBlock : BlockNode {

		public string Name { get; set; }
		public List<AbstractBlock> NextBlocks = new List<AbstractBlock>();
		public AbstractBlock PreviousBlock { get; set; }
		public BlockVariableType ReturnType { get; set; }
		public BlockVariable[] Inputs { get; set; } = new BlockVariable[8];
		public BlockVariable[] Outputs { get; set; } = new BlockVariable[8];
		public List<BlockVariableType> InputTypes { get; set; }

		public BlockVariable ReturnVariable;
		public bool Returns = false;

		protected string ValidationErrorMessage = "Block validation failed!";

		public override void _Ready() {
			if (Returns) {
				ReturnVariable = new BlockVariable("temp", this, false);
			}
		}

		public void Run() {
			try {
				if (!Validate()) {
					throw new BlockLogicException(ValidationErrorMessage);
				}
			} catch (BlockLogicException e) {
				GetNode<Programming>("/root/Programming").RegisterError(e.Message);
				return;
			}

			foreach (var block in NextBlocks) {
				foreach (var block2 in block.NextBlocks) {
					if (block2 == this) {
						GetNode<Programming>("/root/Programming").RegisterError("Loop detected! Please remove the loop.");
						return;
					}
				}
			}
			var returnValue = Execute();
			if (Returns && returnValue != null) {
				ReturnVariable = returnValue; // This seems to be wrong. Value is always reset to default (0) for some reason.
			}
			UpdateVariables(); 
			if (ReturnType == BlockVariableType.Bool) { 
				if (NextBlocks.Count != 0 && returnValue.BoolValue) {
					foreach (var block in NextBlocks) {
						block.Run();
					}
				}
			}
			else {
				if (NextBlocks.Count != 0) {
					foreach (var block in NextBlocks) {
						block.Run();
					}
				}
			}
		}

		// Executes the block. Override this method in child classes.
		public virtual BlockVariable Execute() {
			throw new BlockLogicException("Abstract block cannot be executed!");
		}

		// Checks if everything is connected correctly, called before Execute(). Override this method in child classes.
		public virtual bool Validate() {
			throw new BlockLogicException("No validation implemented for this block!");
		}

		public bool Connected(GodotNode connectingNode, int thisSlot, int connectingSlot) {
			if (connectingNode == this) {
				GD.Print("Cannot connect node to itself!");
				return false;
			}

			if (thisSlot == 0) { // Slot 0 is always the slot for execution logic (white lines)
				GD.Print("Execution slot, skipping Connected()");
				return true;
			}
			var currentNodeInSlot = ConnectedVariables[thisSlot];
			if (currentNodeInSlot != null) {
				GD.Print("Slot " + thisSlot + " already connected! (" + currentNodeInSlot.Name + ")");
				return false;
			}
			ConnectedVariables[thisSlot] = connectingNode;
			GD.Print("Connected " + connectingNode.Name + " to " + Name + " at slot " + thisSlot + "");
			if (connectingNode is VariableNode variableNode) {
				GD.Print("Node type: " + variableNode.Type);
				if (variableNode.configureable) { // This is the node with the slider
					Inputs[thisSlot] = new BlockVariable("configNodeReturn", connectingNode, variableNode.GetFloat());
					GD.Print("Added configurable float input");
					return true;
				}

				// Add a new input BlockVariable with the current value.
				switch (variableNode.Type) {
					case BlockVariableType.Node:
						Inputs[thisSlot] = new BlockVariable("node", connectingNode, variableNode.GetPlayer());
						GD.Print("Added node input");
						return true;
					case BlockVariableType.Int:
						Inputs[thisSlot] = new BlockVariable("int", connectingNode, variableNode.GetRandom());
						GD.Print("Added int input");
						return true;
					case BlockVariableType.PositionX:
						Inputs[thisSlot] = new BlockVariable("posX", connectingNode, variableNode.GetPlayer().Position.x);
						GD.Print("Added position x input");
						return true;
					case BlockVariableType.PositionY:
						Inputs[thisSlot] = new BlockVariable("posY", connectingNode, variableNode.GetPlayer().Position.y);
						GD.Print("Added position y input");
						return true;

				}
			}
			if (connectingNode is AbstractBlock connectingNodeBlock) {
				GD.Print("AbstractBlock return type: " + connectingNodeBlock.ReturnType + " for slot " + thisSlot + " with nodeBlock " + connectingNodeBlock.Name + " (this: " + Name + ", Returns: " + connectingNodeBlock.Returns + ", nodeBlock class: " + connectingNodeBlock.GetType() + ")");
				if (connectingNodeBlock.Returns) {
					Inputs[thisSlot] = new BlockVariable(connectingNodeBlock, "test").SetProvidedByBlock(true);
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

			return true;
		}

		
		private void UpdateVariables() {
			var i = 0;
			foreach (var blockVariable in Inputs) {
				if (blockVariable == null) { // Unconnected variables will be null
					i++;
					continue;
				}
				
				if (blockVariable.id == "posX") {
					blockVariable.FloatValue = VariableProvider.PlayerNode.Position.x;
				}
				if (blockVariable.id == "posY") {
					blockVariable.FloatValue = VariableProvider.PlayerNode.Position.y;
				}
				if (blockVariable.id == "configNodeReturn") {
					if (blockVariable.Block is VariableNode variableNode) {
						blockVariable.FloatValue = variableNode.configureableValue;
					}
				}
				i++;
			}
		}

		public virtual int getInt() {
			return 0;
		}

		public virtual float getFloat() {
			return 0f;
		}

		public virtual bool getBool() {
			return false;
		}
	}
}
