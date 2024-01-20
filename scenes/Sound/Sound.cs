using Godot;
using System;
using System.Runtime.InteropServices.ComTypes;
using GetOn.scenes;

public class Sound : Node2D
{
	private SharedNode _sharedNode;
	private SubmitResults _submitResults;
	private Node2D _submitResultsPopUp;
	
	private Node2D _moment1;
	private Node2D _moment2;
	private Node2D _moment3;
	private Node2D _moment4;
	private Node2D _moment5;
	private Node2D _moment6;
	private Node2D _moment7;
	private Node2D _moment8;
	private Node2D _moment9;

	private TextureButton _nextMoment;
	private TextureButton _lastMoment;
	private TextureButton _done;
	
	private Node2D[] array; 
	private int number = 0;
	private Node2D moment;
	private double points = 0;

	private SoundSlider _soundSlider;
	private SoundSlider _soundSlider2;
	private SoundSlider _soundSlider3;
	private SoundSlider _soundSlider4;
	private SoundSlider _soundSlider5;
	private SoundSlider _soundSlider6;
	private SoundSlider _soundSlider7;
	private SoundSlider _soundSlider8;
	private SoundSlider _soundSlider9;

	private CustomTabContainer _customTabContainer;
	private CustomTabContainer _customTabContainer2;
	private CustomTabContainer _customTabContainer3;
	private CustomTabContainer _customTabContainer4;
	private CustomTabContainer _customTabContainer5;
	private CustomTabContainer _customTabContainer6;
	private CustomTabContainer _customTabContainer7;
	private CustomTabContainer _customTabContainer8;
	private CustomTabContainer _customTabContainer9;

	public string lineEdit1 = "Sound1";
	public string lineEdit2 = "Sound2";
	public string lineEdit3 = "Sound3";
	public string lineEdit4 = "Sound4";
	public string lineEdit5 = "Sound1";
	public string lineEdit6 = "Sound2";
	public string lineEdit7 = "Sound3";
	public string lineEdit8 = "Sound4";
	public string lineEdit9 = "Sound1";
	public string lineEdit10 = "Sound2";
	public string lineEdit11 = "Sound3";
	public string lineEdit12 = "Sound4";
	public string lineEdit13 = "Sound1";
	public string lineEdit14 = "Sound2";
	public string lineEdit15 = "Sound3";
	public string lineEdit16 = "Sound4";

	private int count = 0;

	private int easySound;
	private int midSound;
	private int hardSound;

	private AudioStreamPlayer _nextMomentAudio;
	public override void _Ready()
	{
		_sharedNode = GetNode<SharedNode>("/root/SharedNode");
		_submitResults = GetNode<SubmitResults>("/root/Sound/SubmitResults");
		_submitResultsPopUp = GetNode<Node2D>("/root/Sound/SubmitResults");
		
		_soundSlider = GetNode<SoundSlider>("Moment1");
		_soundSlider2 = GetNode<SoundSlider>("Moment2");
		_soundSlider3 = GetNode<SoundSlider>("Moment3");
		_soundSlider4 = GetNode<SoundSlider>("Moment4");
		_soundSlider5 = GetNode<SoundSlider>("Moment5");
		_soundSlider6 = GetNode<SoundSlider>("Moment6");
		_soundSlider7 = GetNode<SoundSlider>("Moment7");
		_soundSlider8 = GetNode<SoundSlider>("Moment8");
		_soundSlider9 = GetNode<SoundSlider>("Moment9");

		_customTabContainer = GetNode<CustomTabContainer>("/root/Sound/Moment1/CustomTabContainer");
		_customTabContainer2 = GetNode<CustomTabContainer>("/root/Sound/Moment2/CustomTabContainer");
		_customTabContainer3 = GetNode<CustomTabContainer>("/root/Sound/Moment3/CustomTabContainer");
		_customTabContainer4 = GetNode<CustomTabContainer>("/root/Sound/Moment4/CustomTabContainer");
		_customTabContainer5 = GetNode<CustomTabContainer>("/root/Sound/Moment5/CustomTabContainer");
		_customTabContainer6 = GetNode<CustomTabContainer>("/root/Sound/Moment6/CustomTabContainer");
		_customTabContainer7 = GetNode<CustomTabContainer>("/root/Sound/Moment7/CustomTabContainer");
		_customTabContainer8 = GetNode<CustomTabContainer>("/root/Sound/Moment8/CustomTabContainer");
		_customTabContainer9 = GetNode<CustomTabContainer>("/root/Sound/Moment9/CustomTabContainer");
		
		_moment1 = GetNode<Node2D>("Moment1");
		_moment2 = GetNode<Node2D>("Moment2");
		_moment3 = GetNode<Node2D>("Moment3");
		_moment4 = GetNode<Node2D>("Moment4");
		_moment5 = GetNode<Node2D>("Moment5");
		_moment6 = GetNode<Node2D>("Moment6");
		_moment7 = GetNode<Node2D>("Moment7");
		_moment8 = GetNode<Node2D>("Moment8");
		_moment9 = GetNode<Node2D>("Moment9");

		_nextMoment = GetNode<TextureButton>("Right");
		_lastMoment = GetNode<TextureButton>("Left");

		_done = GetNode<TextureButton>("Done");
		_done.Visible = true;

		_nextMoment.Connect("pressed", this, nameof(NextMoment));
		_lastMoment.Connect("pressed", this, nameof(LastMoment));
		_done.Connect("pressed", this, nameof(CloseGame));
		
		array = new Node2D[] { _moment1, _moment2,_moment3,_moment4,_moment5,_moment6,_moment7,_moment8,_moment9 };
		
		_nextMomentAudio = GetNode<AudioStreamPlayer>("SoundFX/ChangeMoment");
	}

	public void CloseGame()
	{
		_soundSlider.CountPoints();
		_soundSlider2.CountPoints();
		_soundSlider3.CountPoints();
		_soundSlider4.CountPoints();
		_soundSlider5.CountPoints();
		_soundSlider6.CountPoints();
		_soundSlider7.CountPoints();
		_soundSlider8.CountPoints();
		_soundSlider9.CountPoints();
		
		
	}

	public void CountPoints(double point, int easy, int mid, int hard)
	{
		easySound += easy;
		midSound += mid;
		hardSound += hard;
		points += point;
		GD.Print(points);
		count++;
		
		if (count == 9) {
			if (points == 45) {
				points += 3;
			}
			GD.Print(easySound);
			GD.Print(midSound);
			GD.Print(hardSound);

			_submitResults.soundEasySounds = easySound;
			_submitResults.soundMediumSounds = midSound;
			_submitResults.soundHardSounds = hardSound;
			_submitResultsPopUp.Visible = true;
			_submitResults.soundPoints = (double) points;
			_submitResults.soundTime = GetNode<CountdownTimer>("/root/Sound/TopBar/Timer").CurrentTime;
			GD.Print(points);
			count = 0;
			points = 0;
		}
		
		/*
		_sharedNode.soundPoints = (int) points;
		_sharedNode.soundTime = GetNode<CountdownTimer>("/root/Sound/Timer").CurrentTime;
		_sharedNode.CompletedTasks.Add(AbilitySpecialization.Sound);
		_sharedNode.SwitchScene("res://scenes/Rooms/SoundArtRoom.tscn");
		*/
	}
	
	public void NextMoment()
	{
		_customTabContainer.UpdateLineEdit();
		_customTabContainer2.UpdateLineEdit();
		_customTabContainer3.UpdateLineEdit();
		_customTabContainer4.UpdateLineEdit();
		_customTabContainer5.UpdateLineEdit();
		_customTabContainer6.UpdateLineEdit();
		_customTabContainer7.UpdateLineEdit();
		_customTabContainer8.UpdateLineEdit();
		_customTabContainer9.UpdateLineEdit();
		
		_nextMomentAudio.Play();
		if (number < 8)
		{
			number++;
			for (int i = 0; i < 9; i++)
			{
				moment = array[i];
				moment.Visible = false;
				GD.Print(moment.ZIndex);
			}

			moment = array[number];
			moment.Visible = true;
			
			GD.Print(moment);
			GD.Print(moment.ZIndex);
		}
		else
		{
			number=0;
			for (int i = 0; i < 9; i++)
			{
				moment = array[i];
				moment.Visible = false;
			}

			moment = array[number];
			moment.Visible = true;
		}
	}

	public void LastMoment()
	{
		_customTabContainer.UpdateLineEdit();
		_customTabContainer2.UpdateLineEdit();
		_customTabContainer3.UpdateLineEdit();
		_customTabContainer4.UpdateLineEdit();
		_customTabContainer5.UpdateLineEdit();
		_customTabContainer6.UpdateLineEdit();
		_customTabContainer7.UpdateLineEdit();
		_customTabContainer8.UpdateLineEdit();
		_customTabContainer9.UpdateLineEdit();
		
		_nextMomentAudio.Play();
		if (number > 0)
		{
			number--;
			for (int i = 0; i < 9; i++)
			{
				moment = array[i];
				moment.Visible = false;
			}
			moment = array[number];
			moment.Visible = true;
		}
		else
		{
			number=8;
			for (int i = 0; i < 9; i++)
			{
				moment = array[i];
				moment.Visible = false;
			}
			moment = array[number];
			moment.Visible = true;
		}


	}
}
