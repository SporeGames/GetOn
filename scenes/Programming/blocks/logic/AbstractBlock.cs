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

		public BlockVariable ReturnVariable = new BlockVariable(); // TODO: Apparently also not being updated?!
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
			//UpdateVariables(); Doesn't work
			if (ReturnType == BlockVariableType.Bool) { 
				if (NextBlock != null && returnValue.BoolValue) {
					NextBlock.Run();
				}
			}
			else {
				if (NextBlock != null) {
					NextBlock.Run();
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

		public void Connected(GodotNode connectingNode, int slot) {
			if (connectingNode == this) {
				GD.Print("Cannot connect node to itself!");
				return;
			}

			if (slot == 0) { // Slot 0 is always the slot for execution logic (white lines)
				GD.Print("Execution slot, skipping Connected()");
				return;
			}
			var currentNodeInSlot = ConnectedVariables[slot];
			if (currentNodeInSlot != null) {
				GD.Print("Slot " + slot + " already connected! (" + currentNodeInSlot.Name + ")");
				return;
			}
			ConnectedVariables[slot] = connectingNode;
			GD.Print("Connected " + connectingNode.Name + " to " + Name + " at slot " + slot + "");
			if (connectingNode is VariableNode variableNode) {
				GD.Print("Node type: " + variableNode.Type);
				if (variableNode.configureable) { // This is the node with the slider
					Inputs[slot] = new BlockVariable(this, variableNode.GetFloat());
					GD.Print("Added configurable float input");
					return;
				}

				// Add a new input BlockVariable with the current value.
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

		
		/* Doesn't work.
		private void UpdateVariables() {
			foreach (var blockVariable in Inputs) {
				if (blockVariable == null) { // Unconnected variables will be null
					continue;
				}
				if (blockVariable.Block is VariableNode varNode && varNode.configureable) { // TODO: This does not work at all
					blockVariable.FloatValue = varNode.configureableValue;
					continue;
				}
				switch (blockVariable.Type) { // Update the current player position stored in a BlockVariable
					case BlockVariableType.PositionX:
						blockVariable.FloatValue = VariableProvider.PlayerNode.Position.x;
						break;
					case BlockVariableType.PositionY:
						blockVariable.FloatValue = VariableProvider.PlayerNode.Position.x;
						break;
				}
			}
		}*/
	}
}
