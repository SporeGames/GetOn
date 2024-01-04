using Godot;
using System;

public class TabContainer : Godot.TabContainer
{
	// Declare member variables here. Examples:
	// private int a = 2;
	// private string b = "text";

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		Connect("gui_input", this, "_OnGuiInput");
	}
	
	private void _OnGuiInput(InputEvent @event)
	{
		GD.Print("TabContainer received input:", @event);
	}

	private void _on_CheckIfMouseInContainer_mouse_entered()
	{
		//SetMouseFilter(MouseFilterEnum.Ignore);
		GD.Print("An");
	}


	private void _on_CheckIfMouseInContainer_mouse_exited()
	{
		//SetMouseFilter(MouseFilterEnum.Stop);
		GD.Print("Aus");
	}
	
	private void _on_Tabs_mouse_entered()
	{
		SetMouseFilter(MouseFilterEnum.Ignore);
		
		GD.Print("An");
		GD.Print(MouseFilter);
	}


	private void _on_Tabs_mouse_exited()
	{
		SetMouseFilter(MouseFilterEnum.Stop);
		GD.Print("Aus");
		GD.Print(MouseFilter);
	}
	
}





