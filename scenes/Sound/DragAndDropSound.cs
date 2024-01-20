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
	
	private ulong lastClickTime = 0;
	private float doubleClickThreshold = 0.5f;
	private LineEdit _lineEdit;
	public bool lineEdit;
	
	private bool colliding;
	private bool area1;
	private bool area2;
	
	private int enteredAreasCount = 0;
	
	public override void _Ready()
	{
		Connect("mouse_entered", this, "OnMouseEntered");
		Connect("mouse_exited", this, "OnMouseLeft");

		_lineEdit = GetNode<LineEdit>("LineEdit");
		
		originalPosition = Position;
	}

	public void ChangeText(string name)
	{
		GD.Print("name:",name);
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

		if (!Input.IsActionPressed("left_click") && colliding == false)
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

		if (Input.IsActionJustReleased("left_click") && hovered)
		{
			ulong currentTime = OS.GetTicksUsec() / 1000; 

			if (currentTime - lastClickTime < (ulong)(doubleClickThreshold * 1000))
			{
				OnDoubleClick();
			}

			lastClickTime = currentTime;
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
		/*
		if (rayCast.IsColliding())
		{
			raycastColliding = true;
			GD.Print("Cannot place here. Another object is present.");
		}
		else
		{
			raycastColliding = false;
			GD.Print("You can place the object here.");
		}
		*/
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

	private void OnDoubleClick()
	{
		if (!lineEdit)
		{
			_lineEdit.SetMouseFilter(Control.MouseFilterEnum.Stop);
			lineEdit = true;
		}
		else
		{
			_lineEdit.SetMouseFilter(Control.MouseFilterEnum.Ignore);
			lineEdit = false;
		}

	}
	private void _on_LineEdit_text_changed(String new_text)
	{
		//_lineEdit.SetMouseFilter(Control.MouseFilterEnum.Ignore);
		//lineEdit = false;
	}


	
	private void _on_LineEdit_text_entered(String new_text)
	{
		_lineEdit.SetMouseFilter(Control.MouseFilterEnum.Ignore);
		lineEdit = false;
	}
	
	private void _on_Area2D_area_entered(object area)
	{
		
		if (area is Area2D area2d && area2d.Name == "Area2D")
		{
			
			enteredAreasCount++;
			colliding = true;
			
		}
		
		/*
		if (area is Area2D area2d)
		{
			if (area2d.Name == "Area2D")
			{
				area1 = true;
				colliding = true;
			}
			if (area2d.Name == "Area2D2")
			{
				area2 = true;
				colliding = true;
			}
		}
		*/
	}

	private void _on_Area2D_area_exited(object area)
	{
		
		if (area is Area2D area2d && area2d.Name == "Area2D")
		{
			
			enteredAreasCount--;

			
			if (enteredAreasCount <= 0)
			{
				enteredAreasCount = 0; 
				colliding = false;
				
			}
		}
		
		/*
		if (area is Area2D area2d)
		{
			if (area2d.Name == "Area2D")
			{
				area1 = false;
			}
			if (area2d.Name == "Area2D2")
			{
				area2 = false;
			}

			if (area1 == false && area2 == false)
				colliding = false;
		}
		*/
	}
}
















