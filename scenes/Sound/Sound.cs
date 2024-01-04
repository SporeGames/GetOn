using Godot;
using System;

public class Sound : Node2D
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
	private Button _done;
	
	private Node2D[] array; 
	private int number = 0;
	private Node2D moment;
	
	public override void _Ready()
	{
		_moment1 = GetNode<Node2D>("Moment1");
		_moment2 = GetNode<Node2D>("Moment2");
		_moment3 = GetNode<Node2D>("Moment3");
		_moment4 = GetNode<Node2D>("Moment4");
		_moment5 = GetNode<Node2D>("Moment5");
		_moment6 = GetNode<Node2D>("Moment6");
		_moment7 = GetNode<Node2D>("Moment7");
		_moment8 = GetNode<Node2D>("Moment8");
		_moment9 = GetNode<Node2D>("Moment9");

		_nextMoment = GetNode<Button>("Button");
		_lastMoment = GetNode<Button>("Button2");

		_done = GetNode<Button>("Done");

		_nextMoment.Connect("pressed", this, nameof(NextMoment));
		_lastMoment.Connect("pressed", this, nameof(LastMoment));
		_done.Connect("pressed", this, nameof(CloseGame));
		
		array = new Node2D[] { _moment1, _moment2,_moment3,_moment4,_moment5,_moment6,_moment7,_moment8,_moment9 };
	}

	public void CloseGame()
	{
		
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
				moment.ZIndex = 0;
				GD.Print(moment.ZIndex);
			}

			moment = array[number];
			moment.Visible = true;
			moment.ZIndex = 21;
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
				moment.ZIndex = 0;
			}

			moment = array[number];
			moment.Visible = true;
			moment.ZIndex = 21;
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
}
