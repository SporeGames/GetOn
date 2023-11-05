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
        Start = GetNode<AbstractBlock>("Process");
        Executor.StartBlock = Start;
        VariableProvider.PlayerNode = GetNode<Area2D>("/root/Programming/Game/Player");
        VariableProvider.FlagNode = GetNode<Node2D>("/root/Programming/Game/Flag");
        Connect("connection_request", this, nameof(ConnectRequest));
        Connect("disconnection_request", this, nameof(DisconnectRequest));
        int i = 0;
        int y = 0;
        int rowCounter = 0;
        foreach (var node in  GetChildren()) {
            if (node is GraphNode blockNode) {
                blockNode.Offset = new Vector2(i, y);
                i += 200;
                rowCounter++;
                if (rowCounter > 5) {
                    rowCounter = 0;
                    y += 200;
                    i = 0;
                }
            }
            
        }
    }

    public void ConnectRequest(string from_node, int from_port, string to_node, int to_port) {
        var from = GetNode<GodotNode>(from_node);
        var to = GetNode<GodotNode>(to_node);
        if (from == null || to == null) {
            return;
        }

        if (from == to) {
            return;
        }

        GD.Print("Connecting " + from_node + " to " + to_node + "");
        if (from is ConditionNode && to is BlockNode toBlocknode) {
            if (to_port == 0) { // Don't allow plugging variables into execution inputs
                GD.Print("Can't plug variable into execution input.");
                return;
            }
            ConnectNode(from_node, 0, to_node, to_port);
            toBlocknode.ConnectedConditions.Add(from as ConditionNode);
            if (toBlocknode is AbstractBlock abstractBlock) {
                abstractBlock.Connected(to_port);
            }
            GD.Print("Connected condition " + from_node + " to " + to_node + " at port " + (to_port));
        }
        
        if (from is VariableNode fromNode && to is BlockNode toNode) {
            if (to_port == 0) { // Don't allow plugging variables into execution inputs
                GD.Print("Can't plug variable into execution input.");
                return;
            }
            ConnectNode(from_node, 0, to_node, to_port);
            toNode.ConnectedVariables[to_port] = fromNode;
            GD.Print("Added at index " + to_port + "");
            GD.Print(toNode.ConnectedVariables[to_port].Name);
            if (toNode is AbstractBlock abstractBlock) {
                abstractBlock.Connected(to_port);
            }
            GD.Print("Connected variable " + from_node + " to " + to_node + " at port " + (to_port));
        }

        if (from is AbstractBlock fromBlock && to is AbstractBlock toBlock) {
            if (from_port == 0 && to_port == 0) { // Port 0 is always execution logic
                toBlock.Previous = fromBlock;
                fromBlock.NextBlock = toBlock;
                ConnectNode(from_node, from_port, to_node, 0);
                toBlock.Connected(-1);
                GD.Print("Connected execution " + from_node + " to " + to_node + " at port " + (to_port));
                return;
            }
            ConnectNode(from_node, from_port, to_node, to_port);
            toBlock.ConnectedVariables[to_port] = fromBlock;
            toBlock.Connected(to_port);
            GD.Print("Connected return variable " + from_node + " to " + to_node + " at port " + (to_port));
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
                blockFrom.NextBlock = null;
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
