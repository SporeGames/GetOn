using Godot;
using System;

public class DropDownSetting : OptionButton
{
	// Declare member variables here. Examples:
	// private int a = 2;
	// private string b = "text";

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		this.AddItem("Setting");
		this.AddItem("High-Fantasy");
		this.AddItem("Low-Fantasy");
		this.AddItem("Sci-Fi");
		this.AddItem("Thriller");
		this.AddItem("Romance");
		this.AddItem("Drama");
		this.AddItem("Horror");
		this.AddItem("Comedy");
	}
	
	public void DisableHover()
	{
		SetMouseFilter(MouseFilterEnum.Ignore);
	}

	public void EnabelHover()
	{
		SetMouseFilter(MouseFilterEnum.Stop);
	}

//  // Called every frame. 'delta' is the elapsed time since the previous frame.
//  public override void _Process(float delta)
//  {
//      
//  }
}
