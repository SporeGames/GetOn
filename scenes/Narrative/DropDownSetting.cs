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
		this.AddItem("Sub-Genre");
		this.AddItem("Shooter");				
		this.AddItem("Horror");
		this.AddItem("Strategy");
		this.AddItem("Bullet Hell");
		this.AddItem("Thriller");
		this.AddItem("Fighting Game");
		//this.HintTooltip = "Yoooo Setting dies das";
		//SetItemTooltip(1,"Yoyoyoyyo");
		//SetItemTooltip(2,"hohohoh");
		
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
