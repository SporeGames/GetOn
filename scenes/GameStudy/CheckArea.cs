using Godot;
using System;

public class CheckArea : Area2D
{
	private bool nESCorrect;
	private bool xBOXCorrect;
	private bool gameBoyCorrect;
	private bool megaDrive1Correct;
	private Button _submitButton;
	private int points;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		nESCorrect = false;
		xBOXCorrect = false;
		gameBoyCorrect = false;
		megaDrive1Correct = false;
		_submitButton = GetNode<Button>("/root/GameStudy/Submit");
		_submitButton.Connect("pressed", this, nameof(CheckifCorrect));
		points = 0;
	}

	private void CheckifCorrect()
	{
		if (nESCorrect == true)
		{
			points += 5;
		}

		if (xBOXCorrect)
		{
			points += 5;
		}

		if (gameBoyCorrect)
		{
			points += 5;
		}

		if (megaDrive1Correct)
		{
			points += 5;
		}
		GD.Print(points);
	}

	private void _on_CheckGameBoy_body_entered(object body)
	{
		if (body is KinematicBody2D kinematicBody)
		{
			if (kinematicBody.Name == "GameBoy")
			{
				GD.Print("GAMEBOY");
				gameBoyCorrect = true;
			}
		}
	}
	private void _on_CheckXBOX_body_entered(object body)
	{
		if (body is KinematicBody2D kinematicBody)
		{
			if (kinematicBody.Name == "XBOX")
			{
				GD.Print("XBOX");
				megaDrive1Correct = true;
			}
		}
	}
	private void _on_CheckMegaDrive1_body_entered(object body)
	{
		if (body is KinematicBody2D kinematicBody)
		{
			if (kinematicBody.Name == "MegaDrive1")
			{
				GD.Print("MegaDrive1");
				xBOXCorrect = true;
			}
		}
	}


	private void _on_CheckNES_body_entered(object body)
	{
		if (body is KinematicBody2D kinematicBody)
		{
			if (kinematicBody.Name == "NES")
			{
				GD.Print("NES");
				nESCorrect = true;
			}
		}
	}
	
	private void _on_CheckGameBoy_body_exited(object body)
	{
		if (body is KinematicBody2D kinematicBody)
		{
			if (kinematicBody.Name == "GameBoy")
			{
				gameBoyCorrect = false;
				GD.Print("GameBoy: "+gameBoyCorrect);
			}
		}
	}
	private void _on_CheckXBOX_body_exited(object body)
	{
		if (body is KinematicBody2D kinematicBody)
		{
			if (kinematicBody.Name == "XBOX")
			{
				 xBOXCorrect = false;
			}
		}
	}


	private void _on_CheckMegaDrive1_body_exited(object body)
	{
		if (body is KinematicBody2D kinematicBody)
		{
			if (kinematicBody.Name == "MegaDrive1")
			{
				megaDrive1Correct = false;
			}
		}
	}


	private void _on_CheckNES_body_exited(object body)
	{
		if (body is KinematicBody2D kinematicBody)
		{
			if (kinematicBody.Name == "NES")
			{
				nESCorrect = false;
			}
		}
	}
}


