using Godot;
using System;

public class DragAndDrop : KinematicBody2D
{
	private bool hovered;
	private bool attached;
	private Vector2 offset;
	
	private Vector2 originalPosition;
	private float snapDistance = 100f; 
	private bool isSnapped = false;

	private KinematicBody2D _xBOX;
	private KinematicBody2D _nES;
	private KinematicBody2D _gameBoy;
	private KinematicBody2D _megaDrive1;
	
	private Node2D _introGameStudy;
	private Button _introReady;
	
	private static DragAndDrop currentlyDraggedObject;

	public override void _Ready()
	{
		_introGameStudy = GetNode<Node2D>("/root/GameStudy/Intro");
		_introReady = GetNode<Button>("/root/GameStudy/Intro/Button");
		_xBOX = GetNode<KinematicBody2D>("/root/GameStudy/XBOX");
		_nES = GetNode<KinematicBody2D>("/root/GameStudy/NES");
		_gameBoy = GetNode<KinematicBody2D>("/root/GameStudy/GameBoy");
		_megaDrive1 = GetNode<KinematicBody2D>("/root/GameStudy/MegaDrive1");
		Connect("mouse_entered", this, "OnMouseEntered");
		Connect("mouse_exited", this, "OnMouseLeft");
		_introReady.Connect("pressed",this, nameof(OnIntroReadyPressed));
		originalPosition = Position;
		GD.Print(_xBOX);
	}

	public override void _Input(InputEvent @event)
	{
		
		if (Input.IsActionPressed("left_click") && hovered == true)
		{
			_xBOX.InputPickable = false;
			_nES.InputPickable = false;
			_gameBoy.InputPickable = false;
			_megaDrive1.InputPickable = false;
			this.InputPickable = true;
			this.ZIndex = 20;
			currentlyDraggedObject = this; 
			attached = true;
			//offset = GetViewport().GetMousePosition();
		}

		if (!Input.IsActionPressed("left_click"))
		{
			attached = false;
			this.ZIndex = 0;
			_xBOX.InputPickable = true;
			_nES.InputPickable = true;
			_gameBoy.InputPickable = true;
			_megaDrive1.InputPickable = true;
		
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

	public void OnMouseLeft() {
		//attached = false;
		hovered = false;
		/*this.ZIndex = 0;
		_xBOX.InputPickable = true;
		_nES.InputPickable = true;
		_gameBoy.InputPickable = true;
		_megaDrive1.InputPickable = true;
		
		if (currentlyDraggedObject == this)
		{
			currentlyDraggedObject = null; 
		}*/	
	}

	public override void _Process(float delta)
	{
		if (attached == true && currentlyDraggedObject == this)
		{
			Position = new Vector2(offset);
			CheckSnap();
		}
	}
	
	public void OnIntroReadyPressed()
	{
		_introGameStudy.Visible = false;
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


