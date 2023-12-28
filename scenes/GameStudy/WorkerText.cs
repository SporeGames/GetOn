using Godot;
using System;
using GetOn.scenes.GameStudy;

public class WorkerText : Sprite
{
	public Button _interact;
	
	public Label _text1;
	public Label _text2;
	public Label _text3;

	public Timer _timer1;
	public Timer _timer2;
	public Timer _timer3;

	private PrePuzzleRoom _prePuzzleRoom;
//	private Button _startPuzzle;
	private Node2D _dialogueBox;

	[Export] public bool worker2;
	
	
	public override void _Ready()
	{
		_prePuzzleRoom = GetNode<PrePuzzleRoom>("/root/PrePuzzleRoom/Button");
		
		_interact = GetNode<Button>("Button");
		
		_text1 = GetNode<Label>("Label");
		_text2 = GetNode<Label>("Label2");
		_text3 = GetNode<Label>("Label3");
		
		_timer1 = GetNode<Timer>("Timer");
		_timer2 = GetNode<Timer>("Timer2");
		_timer3 = GetNode<Timer>("Timer3");

		_text1.Visible = false;
		_text2.Visible = false;
		_text3.Visible = false;

		_dialogueBox = GetNode<Node2D>("DialogueBox");
		_dialogueBox.Visible = false;
		
		_interact.Connect("pressed", this, nameof(WorkerPressed));
		//		_startPuzzle = GetNode<Button>("ColorRect/StartPuzzle");
		//		_startPuzzle.Connect("pressed",this,nameof(StartPuzzle));
	}

	public void WorkerPressed()
	{
		_dialogueBox.Visible = true;
	}

	public void OnInteractPressed()
	{
		_text1.Visible = true;
		_interact.Visible = false;
		_timer1.Start(1);
	}

	private void _on_Timer_timeout()
	{
		_text2.Visible = true;
		_timer2.Start(1);
	}

	private void _on_Timer2_timeout()
	{
		_text3.Visible = true;
		_timer3.Start(1);
		
		if (this.Name == "Worker")
		{
			_prePuzzleRoom.SetButtonVisible();
		}
		else
		{
			_prePuzzleRoom.SetButton2Visibile();
		}
	}
	
	private void _on_Timer3_timeout()
	{
		//_text1.Visible = false;
		//_text2.Visible = false;
		//_text3.Visible = false;
		//_interact.Visible = true;

		if (this.Name == "Worker")
		{
			_prePuzzleRoom.SetButtonVisible();
		}
		else
		{
			_prePuzzleRoom.SetButton2Visibile();
		}
	}
	
//			public void StartPuzzle()
//		{
//			_sharedNode.SwitchScene("res://scenes/Sound/PrePuzzleRoom.tscn");
//		}
}







