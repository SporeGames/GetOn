using GetOn.scenes;
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
	private BlockNode _truckBlock;
	private BlockNode _fpressedBlock;
	private BlockNode _ifBlock;
	private BlockNode _secondIfBlock;
	private BlockNode _processBlock;
	
	public override void _Ready() {
		Start = GetNode<AbstractBlock>("Process");
		Executor.StartBlock = Start;
		VariableProvider.PlayerNode = GetNode<KinematicBody2D>("/root/Programming/Game/Player");
		VariableProvider.FlagNode = GetNode<Area2D>("/root/Programming/Game/EasyFlag");
		Connect("connection_request", this, nameof(ConnectRequest));
		Connect("disconnection_request", this, nameof(DisconnectRequest));
		_ifBlock = GetNode<BlockNode>("IfBlock3");
		_secondIfBlock = GetNode<BlockNode>("IfBlock2");
		_truckBlock = GetNode<BlockNode>("MoveTruck");
		_fpressedBlock = GetNode<BlockNode>("IfFPressed");
		_processBlock = GetNode<BlockNode>("Process");
		int x = -200;
		int y = 200;
		int rowCounter = 0;
		foreach (var node in  GetChildren()) {
			if (node is GraphNode blockNode) {
				blockNode.Offset = new Vector2(x, y);
				x += 200;
				rowCounter++;
				if (rowCounter > 3) {
					rowCounter = 0;
					y += 200;
					x = -200;
				}
			}
		}
		// Setup example
		_processBlock.Offset = new Vector2(-200, -200);
		_ifBlock.Offset = new Vector2(0, -200);
		_secondIfBlock.Offset = new Vector2(0, 0);
		_truckBlock.Offset = new Vector2(200, -200);
		_fpressedBlock.Offset = new Vector2(0, -100);
		ConnectRequest(_processBlock.Name, 0, _ifBlock.Name, 0);
		ConnectRequest(_processBlock.Name, 0, _secondIfBlock.Name, 0);
		ConnectRequest(_ifBlock.Name, 0, _truckBlock.Name, 0);
		ConnectRequest(_fpressedBlock.Name, 0, _ifBlock.Name, 1);
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
			if (toCondBlock is AbstractBlock abstractBlock) {
				if (!abstractBlock.Connected(fromCondNode, to_port, from_port)) {
					return;
				}
			}
			ConnectNode(from_node, 0, to_node, to_port);
			toCondBlock.ConnectedConditions.Add(fromCondNode);
			GD.Print("Connected condition " + from_node + " to " + to_node + " at port " + (to_port));
		}
		
		if (from is VariableNode fromVariable && to is BlockNode toVariableBlock) {
			if (to_port == 0) { // Don't allow plugging variables into execution inputs
				GD.Print("Can't plug variable into execution input.");
				return;
			}
			if (toVariableBlock is AbstractBlock abstractBlock) {
				if (!abstractBlock.Connected(fromVariable, to_port, from_port)) {
					return;
				}
			}
			GD.Print("Added at index " + to_port + "");
			ConnectNode(from_node, 0, to_node, to_port);
			GD.Print("Connected variable " + from_node + " to " + to_node + " at port " + (to_port));
		}

		if (from is AbstractBlock fromBlock && to is AbstractBlock toBlock) {
			if (from_port == 0 && to_port == 0) { // Port 0 is always execution logic
				if (!toBlock.Connected(fromBlock, to_port, from_port)) {
					return;
				}
				toBlock.PreviousBlock = fromBlock;
				fromBlock.NextBlocks.Add(toBlock);
				ConnectNode(from_node, from_port, to_node, 0);
				GD.Print("Connected execution " + from_node + " to " + to_node + " at port " + (to_port));
				return;
			}
			if (!toBlock.Connected(fromBlock, to_port, from_port)) {
				return;
			}
			ConnectNode(from_node, from_port, to_node, to_port);
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
		GetNode<SharedNode>("/root/SharedNode").DisconnectedNodes++;
	}
	
}
