using Godot;
using System;

public class SwitchStory : Button
{
	public Button _greaterThan;
	public Button _lessThan;

	public Node2D _story1;
	public Node2D _story2;
	public Node2D _story3;

	public bool _story1Intro = true;
	public bool _story2Intro = false;
	public bool _story3Intro = false;

	public Node2D _introStory1;
	public Node2D _introStory2;
	public Node2D _introStory3;
	public Node2D _introGame;

	public Button _ready1;
	public Button _ready2;
	public Button _ready3;
	public Button _closeIntroGame;

	public bool wrongWay = false;
	
	private float initialTime = 300; // Initial countdown time in seconds
	private float currentTime;
	private Timer countdownTimer;

	private Label timerLabel;
	
	public override void _Ready()
	{
		_greaterThan = GetNode<Button>("/root/Narrative/GreaterThan");
		_lessThan = GetNode<Button>("/root/Narrative/LessThan");
		_greaterThan.Connect("pressed", this, nameof(GreaterThanPressed));
		_lessThan.Connect("pressed", this, nameof(LessThanPressed));

		_story1 = GetNode<Node2D>("/root/Narrative/1");
		_story2 = GetNode<Node2D>("/root/Narrative/2");
		_story3 = GetNode<Node2D>("/root/Narrative/3");

		_introStory1 = GetNode<Node2D>("/root/Narrative/IntroStory1");
		_introStory2 = GetNode<Node2D>("/root/Narrative/IntroStory2");
		_introStory3 = GetNode<Node2D>("/root/Narrative/IntroStory3");
		_introGame = GetNode<Node2D>("/root/Narrative/IntroGame");

		_ready1 = GetNode<Button>("/root/Narrative/IntroStory1/Button");
		_ready2 = GetNode<Button>("/root/Narrative/IntroStory2/Button");
		_ready3 = GetNode<Button>("/root/Narrative/IntroStory3/Button");
		_closeIntroGame = GetNode<Button>("/root/Narrative/IntroGame/Button");
		_ready1.Connect("pressed", this, nameof(ReadyPressed));
		_ready2.Connect("pressed", this, nameof(GreaterThanPressed));
		_ready3.Connect("pressed", this, nameof(GreaterThanPressed));
		_closeIntroGame.Connect("pressed", this, nameof(CloseIntroGame));

		timerLabel = GetNode<Label>("/root/Narrative/timerLabel");
		
		countdownTimer = new Timer();
		AddChild(countdownTimer);
		
		countdownTimer.Connect("timeout", this, "_OnTimeout");

		
		currentTime = initialTime;

		
		countdownTimer.WaitTime = 1; 

		
		//countdownTimer.Start();
		
		timerLabel.Text = $"Time: {Mathf.CeilToInt(currentTime)}s";
	}
	
	public override void _Process(float delta)
	{
		
		if (countdownTimer.IsStopped())
		{
			
		}
		else
		{
			currentTime -= delta;
			UpdateTimerLabel();
		}
	}
	
	private void UpdateTimerLabel()
	{
		
		int minutes = Mathf.FloorToInt(currentTime / 60);
		int seconds = Mathf.CeilToInt(currentTime % 60);
		
		timerLabel.Text = $"Time: {minutes:D2}:{seconds:D2}";
	}
	
	private void _OnTimeout()
	{
		//GD.Print("ohh no Booom");
	}

	public void CloseIntroGame()
	{
		_introGame.Visible = false;
	}

	public void GreaterThanPressed()
	{
		if (_story1.Visible == true)
		{
			if (_story2Intro && wrongWay == false)
			{
				countdownTimer.Stop();
				_story2Intro = false;
				_introStory2.Visible = true;
			}
			else if(wrongWay == false)
			{
				countdownTimer.Start();
				_introStory2.Visible = false;
				_story1.Visible = false;
				_story2.Visible = true;
			}
			else
			{
				
				_introStory3.Visible = false;
				_story1.Visible = false;
				_story3.Visible = true;
			}
		}

		else if (_story2.Visible == true)
		{
			if (_story3Intro && wrongWay == false)
			{
				countdownTimer.Stop();
				_story3Intro = false;
				_introStory3.Visible = true;
			}
			else if(wrongWay == false)
			{
				countdownTimer.Start();
				_story2.Visible = false;
				_story3.Visible = true;
				_introStory3.Visible = false;
			}
			else
			{
				_introStory2.Visible = false;
				_story3.Visible = false;
				_story2.Visible = true;
				_story2Intro = false;
				wrongWay = false;

			}
		}
		
		else if (_story3.Visible == true)
		{
			if (wrongWay == false)
			{
				_story3.Visible = false;
				_story1.Visible = true;
			}
			else
			{
				_introStory3.Visible = false;
				
				
			}
			
		}
	}

	public void LessThanPressed()
	{
		if (_story1.Visible == true)
		{
			if (_story3Intro)
			{
				wrongWay = true;
				_story3Intro = false;
				_introStory3.Visible = true;
				//_story1.Visible = false;
			}
			else
			{
				_story1.Visible = false;
				_introStory3.Visible = false;
				_story3.Visible = true;
			}
		}

		else if (_story3.Visible == true)
		{
			if (wrongWay)
			{
				//_story2Intro = true;
				_story3.Visible = false;
				_story2.Visible = true;
				_introStory2.Visible = true;
			}
			else
			{
				_story3.Visible = false;
				_story2.Visible = true;
			}
			
		}
		
		else if (_story2.Visible == true)
		{
			_story2.Visible = false;
			_story1.Visible = true;
		}
	}

	public void ReadyPressed()
	{
		if (_story1Intro)
		{
			countdownTimer.Start();
			_story2Intro = true;
			_story3Intro = true;
			_story1Intro = false;
			_story1.Visible = true;
			_introStory1.Visible = false;
		}
		
	}
}
