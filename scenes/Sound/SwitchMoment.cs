using Godot;
using System;

public class SwitchMoment : Control
{
	private Node2D _moment1;
	private Node2D _moment2;
	private Node2D _moment3;
	private Node2D _moment4;
	private Node2D _moment5;
	private Node2D _moment6;
	private Node2D _moment7;
	private Node2D _moment8;
	private Node2D _moment9;

	private Button _nextMoment;
	private Button _lastMoment;

	private Node2D[] array; 
	private int number = 0;
	private Node2D moment;

	private Node2D _intro;
	private Button _start;
	
	//private bool 
	
	public override void _Ready()
	{
		_moment1 = GetNode<Node2D>("/root/Sound/Moment1");
		_moment2 = GetNode<Node2D>("/root/Sound/Moment2");
		_moment3 = GetNode<Node2D>("/root/Sound/Moment3");
		_moment4 = GetNode<Node2D>("/root/Sound/Moment4");
		_moment5 = GetNode<Node2D>("/root/Sound/Moment5");
		_moment6 = GetNode<Node2D>("/root/Sound/Moment6");
		_moment7 = GetNode<Node2D>("/root/Sound/Moment7");
		_moment8 = GetNode<Node2D>("/root/Sound/Moment8");
		_moment9 = GetNode<Node2D>("/root/Sound/Moment9");

		_nextMoment = GetNode<Button>("Button");
		_lastMoment = GetNode<Button>("Button2");

		_nextMoment.Connect("pressed", this, nameof(NextMoment));
		_lastMoment.Connect("pressed", this, nameof(LastMoment));
		
		array = new Node2D[] { _moment1, _moment2,_moment3,_moment4,_moment5,_moment6,_moment7,_moment8,_moment9 };

		_intro = GetNode<Node2D>("/root/Sound/Intro");
		_start = GetNode<Button>("/root/Sound/Intro/Button");
		_start.Connect("pressed", this, nameof(CloseIntro));

	}

	public void NextMoment()
	{
		if (number < 8)
		{
			number++;
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

	public void CloseIntro()
	{
		_intro.Visible = false;
		GetNode<CountdownTimer>("/root/Sound/Timer").running = true;
	}
}
