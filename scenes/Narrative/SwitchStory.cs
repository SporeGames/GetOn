using Godot;
using System;

public class SwitchStory : TextureButton
{
	public TextureButton _greaterThan;
	public TextureButton _lessThan;

	public Node2D _story1;
	public Node2D _story2;
	public Node2D _story3;

	public bool _story1Intro = true;
	public bool _story2Intro = false;
	public bool _story3Intro = false;

	public Node2D _introStory1;
	public Node2D _introStory2;
	public Node2D _introStory3;

	public TextureButton _ready1;
	public TextureButton _ready2;
	public Button _ready3;

	public bool wrongWay = false;
	private TextureButton _submit;
	
	public override void _Ready()
	{
		_greaterThan = GetNode<TextureButton>("/root/Narrative/GreaterThan");
		_lessThan = GetNode<TextureButton>("/root/Narrative/LessThan");
		_greaterThan.Connect("pressed", this, nameof(GreaterThanPressed));
		_lessThan.Connect("pressed", this, nameof(LessThanPressed));

		_story1 = GetNode<Node2D>("/root/Narrative/1");
		_story2 = GetNode<Node2D>("/root/Narrative/2");
		_story3 = GetNode<Node2D>("/root/Narrative/3");

		_introStory1 = GetNode<Node2D>("/root/Narrative/IntroStory1");
		_introStory2 = GetNode<Node2D>("/root/Narrative/IntroStory2");
		_introStory3 = GetNode<Node2D>("/root/Narrative/IntroStory3");

		_ready1 = GetNode<TextureButton>("/root/Narrative/IntroStory1/Button");
		_ready2 = GetNode<TextureButton>("/root/Narrative/IntroStory2/Button");
		_ready3 = GetNode<Button>("/root/Narrative/IntroStory3/Button");
		_ready1.Connect("pressed", this, nameof(ReadyPressed));
		_ready2.Connect("pressed", this, nameof(ReadyPressed));
		_ready3.Connect("pressed", this, nameof(GreaterThanPressed));

		_submit = GetNode<TextureButton>("/root/Narrative/Submit");
		_submit.Visible = false;
	}
	
	public override void _Process(float delta)
	{
		
	}
	
	private void _OnTimeout()
	{
		//GD.Print("ohh no Booom");
	}
	

	public void GreaterThanPressed()
	{
		/*
		if (_story1.Visible == true)
		{
			if (_story2Intro && wrongWay == false)
			{
				GetNode<CountdownTimer>("/root/Narrative/Timer").running = false;
				_story2Intro = false;
				_introStory2.Visible = true;
			}
			else if(wrongWay == false)
			{
				GetNode<CountdownTimer>("/root/Narrative/Timer").running = true;
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
				GetNode<CountdownTimer>("/root/Narrative/Timer").running = false;
				_story3Intro = false;
				_introStory3.Visible = true;
			}
			else if(wrongWay == false)
			{
				GetNode<CountdownTimer>("/root/Narrative/Timer").running = true;
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
		*/
		if (_story1.Visible == true)
		{
			if (wrongWay == false)
			{
				wrongWay = true;
				_introStory2.Visible = true;
				GetNode<CountdownTimer>("/root/Narrative/TopBar/Timer").running = false;
				_submit.Visible = true;
			}
	
			_story1.Visible = false;
			_story2.Visible = true;
			_submit.Visible = true;
		}
		else
		{
			_story1.Visible = true;
			_story2.Visible = false;
		}
		
	}

	public void LessThanPressed()
	{
		if (_story1.Visible == true)
		{
			if (wrongWay == false)
			{
				wrongWay = true;
				_introStory2.Visible = true;
				GetNode<CountdownTimer>("/root/Narrative/TopBar/Timer").running = false;
				_submit.Visible = true;
			}

			_story1.Visible = false;
			_story2.Visible = true;
			_submit.Visible = true;
		}
		else
		{
			_story1.Visible = true;
			_story2.Visible = false;
		}
		
		
		
		
		/*
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
		*/
	}

	public void ReadyPressed()
	{
		if (_story1Intro)
		{
			_story2Intro = true;
			//_story3Intro = true;
			_story1Intro = false;
			_story1.Visible = true;
			_introStory1.Visible = false;
			
			CountdownTimer timer = GetNode<CountdownTimer>("/root/Narrative/TopBar/Timer");
			timer.running = true;
			timer.ResetTimer(); // Reset the timer
		}
		else
		{
			_introStory2.Visible = false;
			GetNode<CountdownTimer>("/root/Narrative/TopBar/Timer").running = true;
		}
		
	}
}
