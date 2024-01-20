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
	private Sound _sound;

	[Export] public string correctSoundName;

	private bool pointsSend = false;
	private string copySelectedSound;
	private int easy;
	private int mid;
	private int hard;
	
	public override void _Ready()
	{
		_headline = GetNode<Label>("Labels/Headline");
		_description = GetNode<Label>("Labels/Label2");
		_moment = GetNode<Sprite>("IngameMoment");
		_customTabContainer = GetNode<CustomTabContainer>("CustomTabContainer");
		_sound = GetNode<Sound>("/root/Sound");
		
		_headline.Text = headlineTXT;
		_description.Text = descriptionTXT;
		_moment.Texture = pathToIngameMoment;
		
		
	}

	public void CheckCorrect(string selectedSound)
	{
		points = 0;
		//GD.Print("The Selected sound: ",selectedSound);
		GD.Print("Selected Sound: "+ selectedSound, "CorrectSoundName: "+correctSoundName);
		if (selectedSound == correctSoundName && pointsSend == false) 
		{
			if (correctSoundName == "Sound13" || correctSoundName == "Sound10" || correctSoundName == "Sound15")
			{
				points+=2.5;
				easy++;
			}
			if (correctSoundName == "Sound1" || correctSoundName == "Sound2" || correctSoundName == "Sound11")
			{
				points+=5;
				mid++;
			}
			if (correctSoundName == "Sound5" || correctSoundName == "Sound14" || correctSoundName == "Sound9")
			{
				points+=7.5;
				hard++;
			}

			pointsSend = true;
			copySelectedSound = selectedSound;
		}
		/*
		else if (pointsSend == true)
		{
			if (copySelectedSound == "Sound13" || copySelectedSound == "Sound10" || copySelectedSound == "Sound15")
			{
				points-=2.5;
			}
			if (copySelectedSound == "Sound1" || copySelectedSound == "Sound2" || copySelectedSound == "Sound12")
			{
				points-=5;
			}
			if (copySelectedSound == "Sound5" || copySelectedSound == "Sound14" || copySelectedSound == "Sound9")
			{
				points-=7.5;
			}

			pointsSend = false;
		}
		*/
		_sound.CountPoints(points,easy,mid,hard);
		GD.Print("Points sent: "+points);
		//GD.Print(points);
	}

	public void CountPoints()
	{
		_customTabContainer.CheckCorrect(correctSoundName);
		
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



