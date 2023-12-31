using Godot;
using GetOn.scenes.Programming.blocks;
using GetOn.scenes.Programming.blocks.godot;
using GetOn.scenes.Programming.blocks.logic;

public class NodeGraph : GraphEdit {
	
	/*
	 * Slot types:
	 * 0 - Execution
	 * 1 - Condition
	 * 2 - Player
	 * 3 - Float
	 */

	public BlockExecutor Executor = new BlockExecutor();
	public AbstractBlock Start;
	
	public override void _Ready() {
		GetZoomHbox().Visible = false; // Zooming is bugged, so lets disable it.
		Start = GetNode<AbstractBlock>("Process");
		Executor.StartBlock = Start;
		VariableProvider.PlayerNode = GetNode<KinematicBody2D>("/root/Programming/Game/Player");
		VariableProvider.FlagNode = GetNode<Area2D>("/root/Programming/Game/EasyFlag");
		Connect("connection_request", this, nameof(ConnectRequest));
		Connect("disconnection_request", this, nameof(DisconnectRequest));
		int i = -200;
		int y = 0;
		int rowCounter = 0;
		foreach (var node in  GetChildren()) {
			if (node is GraphNode blockNode) {
				blockNode.Offset = new Vector2(i, y);
				i += 200;
				rowCounter++;
				if (rowCounter > 3) {
					rowCounter = 0;
					y += 200;
					i = 0;
				}
			}
			
		}
	}

	public override void _Input(InputEvent @event) {
		/*if (@event is InputEventMouseButton mouse && (mouse.ButtonIndex == 4 || mouse.ButtonIndex == 5)) { // Disable scroll input
			AcceptEvent();
		}*/
	}

	public void ConnectRequest(string from_node, int from_port, string to_node, int to_port) {
		var from = GetNode<GodotNode>(from_node);
		var to = GetNode<GodotNode>(to_node);
		if (from == null || to == null) {
			GD.Print("Can't connect nodes, one of them is null.");
			return;
		}

		if (from == to) {
			GD.Print("Can't connect node to itself.");
			return;
		}

		GD.Print("Connecting " + from_node + " to " + to_node + "");
		if (from is ConditionNode fromCondNode && to is BlockNode toCondBlock) {
			if (to_port == 0) { // Don't allow plugging variables into execution inputs
				GD.Print("Can't plug variable into execution input.");
				return;
			}
			ConnectNode(from_node, 0, to_node, to_port);
			toCondBlock.ConnectedConditions.Add(fromCondNode);
			if (toCondBlock is AbstractBlock abstractBlock) {
				abstractBlock.Connected(fromCondNode, to_port, from_port);
			}
			GD.Print("Connected condition " + from_node + " to " + to_node + " at port " + (to_port));
		}
		
		if (from is VariableNode fromVariable && to is BlockNode toVariableBlock) {
			if (to_port == 0) { // Don't allow plugging variables into execution inputs
				GD.Print("Can't plug variable into execution input.");
				return;
			}
			ConnectNode(from_node, 0, to_node, to_port);
			GD.Print("Added at index " + to_port + "");
			if (toVariableBlock is AbstractBlock abstractBlock) {
				abstractBlock.Connected(fromVariable, to_port, from_port);
			}
			GD.Print("Connected variable " + from_node + " to " + to_node + " at port " + (to_port));
		}

		if (from is AbstractBlock fromBlock && to is AbstractBlock toBlock) {
			if (from_port == 0 && to_port == 0) { // Port 0 is always execution logic
				toBlock.PreviousBlock = fromBlock;
				fromBlock.NextBlocks.Add(toBlock);
				ConnectNode(from_node, from_port, to_node, 0);
				toBlock.Connected(fromBlock, to_port, from_port);
				GD.Print("Connected execution " + from_node + " to " + to_node + " at port " + (to_port));
				return;
			}
			ConnectNode(from_node, from_port, to_node, to_port);
			toBlock.Connected(fromBlock, to_port, from_port);
			GD.Print("Connected return variable " + fromBlock.Name + " to " + toBlock.Name + " at port " + (to_port));
		}
	}
	
	public void DisconnectRequest(string from_node, int from_port, string to_node, int to_port) {
		var from = GetNode<GodotNode>(from_node);
		var to = GetNode<GodotNode>(to_node);
		if (from == null || to == null) {
			return;
		}
		DisconnectNode(from_node, from_port, to_node, to_port);

		if (from_port == 0) {
			if (from is AbstractBlock blockFrom && to is AbstractBlock blockTo) {
				blockFrom.NextBlocks.Remove(blockTo);
				return;
			}
		}
		if (to is BlockNode blockNode) {
			blockNode.ConnectedVariables[to_port - 1] = null;
			if (from is ConditionNode node) {
				blockNode.ConnectedConditions.Remove(node);
			}
		}
	}
	
}
