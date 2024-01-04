using Godot;
using System;
using GetOn.scenes.Programming.blocks;

public class SoundSlider : Node2D
{

	[Export] public string headlineTXT;
	[Export] public string descriptionTXT;
	[Export] public Texture pathToIngameMoment;

	private Label _headline;
	private Label _description;
	private Sprite _moment;

	private bool correctSound;
	private double points;

	private CustomTabContainer _customTabContainer;

	[Export] public string correctSoundName;
	
	public override void _Ready()
	{
		_headline = GetNode<Label>("Labels/Headline");
		_description = GetNode<Label>("Labels/Label2");
		_moment = GetNode<Sprite>("IngameMoment");
		_customTabContainer = GetNode<CustomTabContainer>("CustomTabContainer");
		
		_headline.Text = headlineTXT;
		_description.Text = descriptionTXT;
		_moment.Texture = pathToIngameMoment;
	}

	private void _on_Area2D_body_entered(object body)
	{
		if (body is KinematicBody2D kinematicBody2D)
		{
			if (kinematicBody2D.Name == correctSoundName)
			{
				GD.Print("Sound correct");
				correctSound = true;
				//_customTabContainer.DisbaleCorrectArea(correctSoundName);
			}

			if (correctSound)
			{
				if (correctSoundName == "Sound13" || correctSoundName == "Sound10" || correctSoundName == "Sound15")
				{
					points+=2.5;
				}
				if (correctSoundName == "Sound1" || correctSoundName == "Sound2" || correctSoundName == "Sound12")
				{
					points+=5;
				}
				if (correctSoundName == "Sound5" || correctSoundName == "Sound14" || correctSoundName == "Sound9")
				{
					points+=7.5;
				}
			}
		}
		GD.Print(points);
	}


	private void _on_Area2D_body_exited(object body)
	{
		if (body is KinematicBody2D kinematicBody2D)
		{
			if (kinematicBody2D.Name == correctSoundName)
			{
				correctSound = false;
				//_customTabContainer.EnableCorrectArea(correctSoundName);
			}
			if (correctSoundName == "Sound13" || correctSoundName == "Sound10" || correctSoundName == "Sound15")
			{
				points-=2.5;
			}
			if (correctSoundName == "Sound1" || correctSoundName == "Sound2" || correctSoundName == "Sound12")
			{
				points-=5;
			}
			if (correctSoundName == "Sound5" || correctSoundName == "Sound14" || correctSoundName == "Sound9")
			{
				points-=7.5;
			}
		}
		GD.Print(points);
	}
}



