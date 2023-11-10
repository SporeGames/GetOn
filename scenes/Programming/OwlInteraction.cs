using Godot;
using System;


namespace GetOn.scenes.Programming
{
	public class OwlInteraction : Control
	{
		private SharedNode _sharedNode;
		
		private Button _interactOwl;
		private Label _owlText;
		private Label _owlText2;
		private Label _owlText3;
		private Button _openIntroduction;
		private Timer _textTime;
		private Timer _textTime2;
		private Timer _textTime3;
		private Sprite _computerOutline;
		private ColorRect _introduction;
		private Button _startPuzzle;
		private bool owlPressed;
	
		public override void _Ready()
		{
			_sharedNode = GetNode<SharedNode>("/root/SharedNode");
			_textTime = GetNode<Timer>("Timer");
			_textTime2 = GetNode<Timer>("Timer2");
			_textTime3 = GetNode<Timer>("Timer3");
			_interactOwl = GetNode<Button>("InteractOwl");
			_openIntroduction = GetNode<Button>("OpenIntroduction");
			_owlText = GetNode<Label>("Label");
			_owlText2 = GetNode<Label>("Label2");
			_owlText3 = GetNode<Label>("Label3");
			_computerOutline = GetNode<Sprite>("ComputerOutline");
			_interactOwl.Connect("pressed", this, nameof(InteractOwlPressed));
			_openIntroduction.Connect("pressed", this, nameof(OpenIntroduction));
			_textTime.Connect("timeout", this, nameof(OnTimerOver));
			_textTime2.Connect("timeout", this, nameof(OnTimerOver2));
			_textTime3.Connect("timeout", this, nameof(OnTimerOver3));
			_introduction = GetNode<ColorRect>("ColorRect");
			_startPuzzle = GetNode<Button>("ColorRect/StartPuzzle");
			_startPuzzle.Connect("pressed",this,nameof(StartPuzzle));
			_owlText.Hide();
			_owlText2.Hide();
			_owlText3.Hide();
			_openIntroduction.Hide();
			_computerOutline.Hide();
			_introduction.Hide();
			owlPressed = false;
		}

		public void InteractOwlPressed()
		{
			_owlText.Show();
			if (owlPressed == false)
			{
				_textTime2.Start(1);
				_textTime3.Start(2);
				_textTime.Start(3);
				owlPressed = true;
			}

		}

		public void StartPuzzle()
		{
			_sharedNode.SwitchScene("res://scenes/Programming/Programming.tscn");
		}
		
		public void OpenIntroduction()
		{
			GD.Print("ShowInto");
			_introduction.Show();
		}

		private void OnTimerOver()
		{
			GD.Print("1");
			_owlText.Hide();
			_owlText2.Hide();
			_owlText3.Hide();
		}
		private void OnTimerOver2()
		{
			GD.Print("2");
			_owlText2.Show();
		}
		
		private void OnTimerOver3()
		{
			GD.Print("3");
			_owlText3.Show();
			_openIntroduction.Show();
			_computerOutline.Show();
			owlPressed = false;
		}
	}
}
/*
public class OwlInteraction : Control
{
	private Button _interActowl;
	//private Label _owlText;
	
	public override void _Ready()
	{
		_interActowl = GetNode<Button>("Owl/InteractOwl");
		
		//_owlText = GetNode<Label>("Owl/Label");
		//_interactowl.Connect("pressed", this, nameof(InteractOwlPressed));
	}

	public void InteractOwlPressed()
	{
		GD.Print("Ayo HuHu");
	}
}
*/
