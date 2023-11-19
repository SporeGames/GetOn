using Godot;
using System;


public class DragAndDropStory : KinematicBody2D
{
	private bool hovered;
	private bool attached;
	private Vector2 offset;
		
	private Vector2 originalPosition;
	private float snapDistance = 100f; 
	private bool isSnapped = false;

	private DropDownAttribute _dropDownAttribute1;
	private DropDownAttribute _dropDownAttribute2;
	private DropDownAttribute _dropDownAttribute3;
	private DropDownAttribute _dropDownAttribute4;
	private DropDownAttribute _dropDownAttribute5;
	private DropDownAttribute _dropDownAttribute6;
	private DropDownAttribute _dropDownAttribute7;
	private DropDownAttribute _dropDownAttribute8;
	private DropDownSetting _dropDownSetting;
	private OpenStory _story1;
	
	private DropDownAttribute _dropDownAttribute21;
	private DropDownAttribute _dropDownAttribute22;
	private DropDownAttribute _dropDownAttribute23;
	private DropDownAttribute _dropDownAttribute24;
	private DropDownAttribute _dropDownAttribute25;
	private DropDownAttribute _dropDownAttribute26;
	private DropDownAttribute _dropDownAttribute27;
	private DropDownAttribute _dropDownAttribute28;
	private DropDownSetting _dropDownSetting2;
	private OpenStory _story2;
	
	private DropDownAttribute _dropDownAttribute31;
	private DropDownAttribute _dropDownAttribute32;
	private DropDownAttribute _dropDownAttribute33;
	private DropDownAttribute _dropDownAttribute34;
	private DropDownAttribute _dropDownAttribute35;
	private DropDownAttribute _dropDownAttribute36;
	private DropDownAttribute _dropDownAttribute37;
	private DropDownAttribute _dropDownAttribute38;
	private DropDownSetting _dropDownSetting3;
	private OpenStory _story3;
	
	private KinematicBody2D _ending1;
	private KinematicBody2D _ending2;
	private KinematicBody2D _ending3;

	private KinematicBody2D _ending21;
	private KinematicBody2D _ending22;
	private KinematicBody2D _ending23;

	private KinematicBody2D _ending31;
	private KinematicBody2D _ending32;
	private KinematicBody2D _ending33;

	private OpenStory _openEnding1;
	private OpenStory _openEnding2;
	private OpenStory _openEnding3;
	
	private OpenStory _openEnding21;
	private OpenStory _openEnding22;
	private OpenStory _openEnding23;
	
	private OpenStory _openEnding31;
	private OpenStory _openEnding32;
	private OpenStory _openEnding33;
	
		
	private DragAndDropStory currentlyDraggedObject;
	
	public override void _Ready()
	{
		_dropDownAttribute1 = GetNode<DropDownAttribute>("/root/Narrative/1/DropDownAttribute1");
		_dropDownAttribute2 = GetNode<DropDownAttribute>("/root/Narrative/1/DropDownAttribute2");
		_dropDownAttribute3 = GetNode<DropDownAttribute>("/root/Narrative/1/DropDownAttribute3");
		_dropDownAttribute4 = GetNode<DropDownAttribute>("/root/Narrative/1/DropDownAttribute4");
		_dropDownAttribute5 = GetNode<DropDownAttribute>("/root/Narrative/1/DropDownAttribute5");
		_dropDownAttribute6 = GetNode<DropDownAttribute>("/root/Narrative/1/DropDownAttribute6");
		_dropDownAttribute7 = GetNode<DropDownAttribute>("/root/Narrative/1/DropDownAttribute7");
		_dropDownAttribute8 = GetNode<DropDownAttribute>("/root/Narrative/1/DropDownAttribute8");
		
		_story1 = GetNode<OpenStory>("/root/Narrative/1/Story1");
		_dropDownSetting = GetNode<DropDownSetting>("/root/Narrative/1/DropDownSetting");
		
		_dropDownAttribute21 = GetNode<DropDownAttribute>("/root/Narrative/2/DropDownAttribute21");
		_dropDownAttribute22 = GetNode<DropDownAttribute>("/root/Narrative/2/DropDownAttribute22");
		_dropDownAttribute23 = GetNode<DropDownAttribute>("/root/Narrative/2/DropDownAttribute23");
		_dropDownAttribute24 = GetNode<DropDownAttribute>("/root/Narrative/2/DropDownAttribute24");
		_dropDownAttribute25 = GetNode<DropDownAttribute>("/root/Narrative/2/DropDownAttribute25");
		_dropDownAttribute26 = GetNode<DropDownAttribute>("/root/Narrative/2/DropDownAttribute26");
		_dropDownAttribute27 = GetNode<DropDownAttribute>("/root/Narrative/2/DropDownAttribute27");
		_dropDownAttribute28 = GetNode<DropDownAttribute>("/root/Narrative/2/DropDownAttribute28");
		
		_story2 = GetNode<OpenStory>("/root/Narrative/2/Story2");
		_dropDownSetting2 = GetNode<DropDownSetting>("/root/Narrative/2/DropDownSetting2");
		
		_dropDownAttribute31 = GetNode<DropDownAttribute>("/root/Narrative/3/DropDownAttribute31");
		_dropDownAttribute32 = GetNode<DropDownAttribute>("/root/Narrative/3/DropDownAttribute32");
		_dropDownAttribute33 = GetNode<DropDownAttribute>("/root/Narrative/3/DropDownAttribute33");
		_dropDownAttribute34 = GetNode<DropDownAttribute>("/root/Narrative/3/DropDownAttribute34");
		_dropDownAttribute35 = GetNode<DropDownAttribute>("/root/Narrative/3/DropDownAttribute35");
		_dropDownAttribute36 = GetNode<DropDownAttribute>("/root/Narrative/3/DropDownAttribute36");
		_dropDownAttribute37 = GetNode<DropDownAttribute>("/root/Narrative/3/DropDownAttribute37");
		_dropDownAttribute38 = GetNode<DropDownAttribute>("/root/Narrative/3/DropDownAttribute38");
		
		_story3 = GetNode<OpenStory>("/root/Narrative/3/Story3");
		_dropDownSetting3 = GetNode<DropDownSetting>("/root/Narrative/3/DropDownSetting3");
		
		_ending1 = GetNode<KinematicBody2D>("/root/Narrative/1/Ending1");
		_ending2 = GetNode<KinematicBody2D>("/root/Narrative/1/Ending2");
		_ending3 = GetNode<KinematicBody2D>("/root/Narrative/1/Ending3");
		
		_ending21 = GetNode<KinematicBody2D>("/root/Narrative/2/Ending21");
		_ending22 = GetNode<KinematicBody2D>("/root/Narrative/2/Ending22");
		_ending23 = GetNode<KinematicBody2D>("/root/Narrative/2/Ending23");
		
		_ending31 = GetNode<KinematicBody2D>("/root/Narrative/3/Ending31");
		_ending32 = GetNode<KinematicBody2D>("/root/Narrative/3/Ending32");
		_ending33 = GetNode<KinematicBody2D>("/root/Narrative/3/Ending33");
		
		
		_openEnding1 = GetNode<OpenStory>("/root/Narrative/1/Ending1/Ending1");
		_openEnding2 = GetNode<OpenStory>("/root/Narrative/1/Ending2/Ending2");
		_openEnding3 = GetNode<OpenStory>("/root/Narrative/1/Ending3/Ending3");
		
		_openEnding21 = GetNode<OpenStory>("/root/Narrative/2/Ending21/Ending21");
		_openEnding22 = GetNode<OpenStory>("/root/Narrative/2/Ending22/Ending22");
		_openEnding23 = GetNode<OpenStory>("/root/Narrative/2/Ending23/Ending23");
		
		_openEnding31 = GetNode<OpenStory>("/root/Narrative/3/Ending31/Ending31");
		_openEnding32 = GetNode<OpenStory>("/root/Narrative/3/Ending32/Ending32");
		_openEnding33 = GetNode<OpenStory>("/root/Narrative/3/Ending33/Ending33");
	
			
		Connect("mouse_entered", this, "OnMouseEntered");
		Connect("mouse_exited", this, "OnMouseLeft");
		originalPosition = Position;
	}
	
	public override void _Input(InputEvent @event)
	{
			
		if (Input.IsActionPressed("left_click") && hovered == true)
		{
			
			
			DisbablePickable();
			SetDisableHover();

			this.InputPickable = true;
			this.ZIndex = 20;
			currentlyDraggedObject = this; 
			attached = true;
			//offset = GetViewport().GetMousePosition();
		}

		if (!Input.IsActionPressed("left_click"))
		{
			attached = false;
			//hovered = false;
			this.ZIndex = 1;
			EnablePickable();
			SetEnableHover();
			
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
		//attached = false;
		hovered = false;
		/*
		//this.ZIndex = 1;
		//EnablePickable();
		//SetEnableHover();
			
		if (currentlyDraggedObject == this)
		{
			currentlyDraggedObject = null; 
		}
		*/
	}
	
	public override void _Process(float delta)
	{
		if (attached == true && currentlyDraggedObject == this)
		{
			Position = new Vector2(offset);
		}
	}

	public void SetDisableHover()
	{
		_dropDownAttribute1.DisableHover();
		_dropDownAttribute2.DisableHover();
		_dropDownAttribute3.DisableHover();
		_dropDownAttribute4.DisableHover();
		_dropDownAttribute5.DisableHover();
		_dropDownAttribute6.DisableHover();
		_dropDownAttribute7.DisableHover();
		_dropDownAttribute8.DisableHover();
		_story1.DisableHover();
		_dropDownSetting.DisableHover();

		_openEnding1.DisableHover();
		_openEnding2.DisableHover();
		_openEnding3.DisableHover();
		
		_dropDownAttribute21.DisableHover();
		_dropDownAttribute22.DisableHover();
		_dropDownAttribute23.DisableHover();
		_dropDownAttribute24.DisableHover();
		_dropDownAttribute25.DisableHover();
		_dropDownAttribute26.DisableHover();
		_dropDownAttribute27.DisableHover();
		_dropDownAttribute28.DisableHover();
		_story2.DisableHover();
		_dropDownSetting2.DisableHover();
		
		_openEnding21.DisableHover();
		_openEnding22.DisableHover();
		_openEnding23.DisableHover();

		_dropDownAttribute31.DisableHover();
		_dropDownAttribute32.DisableHover();
		_dropDownAttribute33.DisableHover();
		_dropDownAttribute34.DisableHover();
		_dropDownAttribute35.DisableHover();
		_dropDownAttribute36.DisableHover();
		_dropDownAttribute37.DisableHover();
		_dropDownAttribute38.DisableHover();
		_story3.DisableHover();
		_dropDownSetting3.DisableHover();
		
		_openEnding31.DisableHover();
		_openEnding32.DisableHover();
		_openEnding33.DisableHover();

	
	}
	
	public void SetEnableHover()
	{
		_dropDownAttribute1.EnabelHover();
		_dropDownAttribute2.EnabelHover();
		_dropDownAttribute3.EnabelHover();
		_dropDownAttribute4.EnabelHover();
		_dropDownAttribute5.EnabelHover();
		_dropDownAttribute6.EnabelHover();
		_dropDownAttribute7.EnabelHover();
		_dropDownAttribute8.EnabelHover();
		_dropDownSetting.EnabelHover();
		_story1.EnabelHover();
		
		_openEnding1.EnabelHover();
		_openEnding2.EnabelHover();
		_openEnding3.EnabelHover();
		
		_dropDownAttribute21.EnabelHover();
		_dropDownAttribute22.EnabelHover();
		_dropDownAttribute23.EnabelHover();
		_dropDownAttribute24.EnabelHover();
		_dropDownAttribute25.EnabelHover();
		_dropDownAttribute26.EnabelHover();
		_dropDownAttribute27.EnabelHover();
		_dropDownAttribute28.EnabelHover();
		_dropDownSetting2.EnabelHover();
		_story2.EnabelHover();
		
		_openEnding21.EnabelHover();
		_openEnding22.EnabelHover();
		_openEnding23.EnabelHover();
		
		_dropDownAttribute31.EnabelHover();
		_dropDownAttribute32.EnabelHover();
		_dropDownAttribute33.EnabelHover();
		_dropDownAttribute34.EnabelHover();
		_dropDownAttribute35.EnabelHover();
		_dropDownAttribute36.EnabelHover();
		_dropDownAttribute37.EnabelHover();
		_dropDownAttribute38.EnabelHover();
		_dropDownSetting3.EnabelHover();
		_story3.EnabelHover();
		
		_openEnding31.EnabelHover();
		_openEnding32.EnabelHover();
		_openEnding33.EnabelHover();
	}

	private void EnablePickable()
	{
		_ending1.InputPickable = true;
		_ending2.InputPickable = true;
		_ending3.InputPickable = true;
		_ending21.InputPickable = true;
		_ending22.InputPickable = true;
		_ending23.InputPickable = true;
		_ending31.InputPickable = true;
		_ending32.InputPickable = true;
		_ending33.InputPickable = true;
	}

	private void DisbablePickable()
	{
		_ending1.InputPickable = false;
		_ending2.InputPickable = false;
		_ending3.InputPickable = false;
		_ending21.InputPickable = false;
		_ending22.InputPickable = false;
		_ending23.InputPickable = false;
		_ending31.InputPickable = false;
		_ending32.InputPickable = false;
		_ending33.InputPickable = false;
	}
}


