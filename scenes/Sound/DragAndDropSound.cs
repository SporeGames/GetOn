using Godot;
using System;

public class DragAndDropSound : KinematicBody2D
{
	private bool hovered;
	private bool attached;
	private Vector2 offset;
	private Vector2 originalPosition;
	private const string YourGroupName = "Sound";
	
	private DragAndDropSound currentlyDraggedObject;
	
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
			
			
			DisablePickable();
			//SetDisableHover();

			this.InputPickable = true;
			this.ZIndex = 20;
			currentlyDraggedObject = this; 
			attached = true;
		}

		if (!Input.IsActionPressed("left_click"))
		{
			attached = false;
			this.ZIndex = 1;
			EnablePickable();
			//SetEnableHover();
			
			if (currentlyDraggedObject == this)
			{
				currentlyDraggedObject = null; 
			}
		}
		if (@event is InputEventMouseMotion motion)
		{
			offset = GetViewport().GetMousePosition();
		}
	}
	public void OnMouseEntered()
	{
		hovered = true;
	}
	
	public void OnMouseLeft()
	{
		hovered = false;
	}
	
	public override void _Process(float delta)
	{
		if (attached == true && currentlyDraggedObject == this)
		{
			Position = new Vector2(offset);
		}
	}

	public void DisablePickable()
	{
		Godot.Collections.Array groupNodes = GetTree().GetNodesInGroup(YourGroupName);
		
		foreach (Node node in groupNodes)
		{
			ChangeInputPickable(node, false);
		}
	}

	public void EnablePickable()
	{
		Godot.Collections.Array groupNodes = GetTree().GetNodesInGroup(YourGroupName);
		
		foreach (Node node in groupNodes)
		{
			ChangeInputPickable(node, true);
		}
	}
	
	private void ChangeInputPickable(Node node, bool newValue)
	{
		if (node is KinematicBody2D kinematicBody)
		{
			kinematicBody.InputPickable = newValue;
		}
	}
	
}
