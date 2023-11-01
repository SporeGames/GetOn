using Godot;
using System;

public class DragAndDrop : StaticBody2D
{

	private bool hovered;
	private bool attached;
	private Vector2 offset;
	
	private Vector2 originalPosition;
	private float snapDistance = 100f; 
	private bool isSnapped = false;
	
	private static DragAndDrop currentlyDraggedObject;

	public override void _Ready()
	{
		Connect("mouse_entered", this, "OnMouseEntered");
		Connect("mouse_exited", this, "OnMouseLeft");
		originalPosition = Position;
	}

	public override void _Input(InputEvent @event)
	{
		
		if (Input.IsActionPressed("left_click") && hovered == true)
		{
			currentlyDraggedObject = this; 
			attached = true;
			offset = GetViewport().GetMousePosition();
		}
	}

	public void OnMouseEntered()
	{
			hovered = true;
	}

	public void OnMouseLeft()
	{
		attached = false;
		hovered = false;
		
		
		if (currentlyDraggedObject == this)
		{
			currentlyDraggedObject = null; 
		}
	}

	public override void _Process(float delta)
	{
		if (attached == true && currentlyDraggedObject == this)
		{
			Position = new Vector2(offset);
			CheckSnap();
		}
	}
	
	private void CheckSnap()
	{
		foreach (Node2D node in GetTree().GetNodesInGroup("DragAndDropGroup"))
		{
			//if (node != this && Mathf.Abs(node.Position.y - Position.y) < snapDistance && node.Position.y < Position.y && Mathf.Abs(node.Position.y - Position.y) < snapDistance)
			if (node != this && Position.x > node.Position.x && Mathf.Abs(node.Position.y - Position.y) < snapDistance && Mathf.Abs(Position.x - (node.Position.x + node.GetNode<Sprite>("Sprite").Texture.GetSize().x)) < 40f)
			{
				Position = new Vector2(node.Position.x + 80f, node.Position.y);
				//hovered = false;
				break;
			}
		}
	}
}


