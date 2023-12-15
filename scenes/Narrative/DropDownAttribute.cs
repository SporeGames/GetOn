using Godot;
using System;



public class DropDownAttribute : OptionButton
{
		// Declare member variables here. Examples:
		// private int a = 2;
		// private string b = "text";

		// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		this.AddItem("Attribute");
		this.AddItem("Befriended");				//1
		this.AddItem("Heroic");					//2
		this.AddItem("Stubborn");					//3
		this.AddItem("Integrated");				//4
		this.AddItem("Possessed");					//5
		this.AddItem("Sacrificing");				//6
		this.AddItem("Aggressive");				//7
		this.AddItem("Egoistic");					//8
		this.AddItem("Cocky");						//9
		this.AddItem("Hopeless");					//10
		this.AddItem("Depressed");					//11
		this.AddItem("Well-Liked");				//12
		this.AddItem("Feels Guilty");				//13
		this.AddItem("Heroic/Fulfilled");			//14
		this.AddItem("Twisted");					//15
		this.AddItem("Betrayed");					//16
		this.AddItem("Leading");					//17
	}

	public void DisableHover()
	{
		SetMouseFilter(MouseFilterEnum.Ignore);
	}

	public void EnabelHover()
	{
		SetMouseFilter(MouseFilterEnum.Stop);
	}

	public void Reset()
	{
		this.Select(0);
	}
	


//  // Called every frame. 'delta' is the elapsed time since the previous frame.
//  public override void _Process(float delta)
//  {
//      
//  }
}

