using Godot;
using GetOn.scenes.Programming.blocks;
using GetOn.scenes.Programming.blocks.godot;
using GetOn.scenes.Programming.blocks.logic;

public class NodeGraph : GraphEdit {

	private BlockExecutor _executor = new BlockExecutor();
	
	public override void _Ready() {
		BlockTypes.RegisterBlock(new AdditionBlock());
		VariableProvider.PlayerNode = GetNode<Area2D>("/root/Programming/Game/Player");
		//VariableProvider.FlagNode = GetNode<Area2D>("/root/Game/Flag");
		Connect("connection_request", this, nameof(ConnectRequest));
		Connect("disconnection_request", this, nameof(DisconnectRequest));
		int i = 0;
		foreach (var node in  GetChildren()) {
			if (node is GraphNode blockNode) {
				blockNode.Offset = new Vector2(i, -1000);
				i =+ 200;
			}
		}
	}

	public void ConnectRequest(string from_node, int from_port, string to_node, int to_port) {
		var from = GetNode<GodotNode>(from_node);
		var to = GetNode<GodotNode>(to_node);
		if (from == null || to == null) {
			return;
		}
		
		if (from is VariableNode fromNode && to is BlockNode toNode) {
			if (to_port == 0) { // Don't allow plugging variables into execution inputs
				GD.Print("Can't plug variable into execution input.");
				return;
			}
			ConnectNode(from_node, 0, to_node, to_port);
			toNode.ConnectedVariables.Add(fromNode);
			AbstractBlock abstractBlock = toNode as AbstractBlock;
			if (abstractBlock != null) {
				abstractBlock.Connected();
			}
			GD.Print("Connected variable " + from_node + " to " + to_node);
		}

		if (from is AbstractBlock fromBlock && to is AbstractBlock toBlock) {
			if (from_port == 0 && to_port == 0) { // Port 0 is always execution logic
				toBlock.Previous = fromBlock;
				fromBlock.Next = toBlock;
				ConnectNode(from_node, from_port, to_node, 0);
				toBlock.Connected();
				GD.Print("Connected execution " + from_node + " to " + to_node);
			}
		}
	}
	
	public void DisconnectRequest(string from_node, int from_port, string to_node, int to_port) {
		var from = GetNode<BlockNode>(from_node);
		var to = GetNode<BlockNode>(to_node);
		if (from == null || to == null) {
			return;
		}
		if (from_port == 0) {
			from.Previous = null;
		} else if (from_port == 1) {
			from.Next = null;
		}
	}
	
}
