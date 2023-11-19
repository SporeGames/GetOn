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
		this.AddItem("Hero");
		this.AddItem("Well Liked");			//1
							//2
		this.AddItem("Justice");				//3
		this.AddItem("Loving/caring");			//4
		this.AddItem("Shadow-Magic");			//5
		this.AddItem("Letting the past go");	//6
		this.AddItem("Mentor");				//7
		this.AddItem("Possessed");				//8
		this.AddItem("Thoughtless");			//9
		this.AddItem("Stubborn");				//10
		this.AddItem("Egoistic");				//11
		this.AddItem("Vengeful");				//12
		this.AddItem("Disciplined");			//13
		this.AddItem("Chaotic");				//14
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

