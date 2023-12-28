using Godot;
using System;
using iText.Kernel.Pdf.Colorspace;

namespace GetOn.scenes.Sound
{
	public class AfterPuzzleRoom : Node2D
	{
		private Button _back;
		private Label _text;
		private String feedback;
		private SharedNode _sharedNode;
		private double points;
		private int count;
		private String lastPuzzle;
		private int maxPoints;

		private Node2D _dialogueBoxPerfect;
		private Node2D _dialogueBoxMid;
		private Node2D _dialogueBoxFail;
		
	
		public override void _Ready()
		{
			_sharedNode = GetNode<SharedNode>("/root/SharedNode");
			_text = GetNode<Label>("Label");
			_back = GetNode<Button>("Button");
			_back.Connect("pressed", this, nameof(BackToMenu));
			_dialogueBoxPerfect = GetNode<Node2D>("DialogueBox");
			_dialogueBoxMid = GetNode<Node2D>("DialogueBox2");
			_dialogueBoxFail = GetNode<Node2D>("DialogueBox3");
			
			CheckPuzzle();
			CheckPoints();

			if (feedback == "fine")
			{
				_text.Text = feedback;
			}
			else
			{
				_text.Text = feedback;
			}
		}

		public void BackToMenu()
		{
			_sharedNode.SwitchScene("res://scenes/GameSelectionRoom/GameSelectionRoom.tscn");
		}

		public void CheckPoints()
		{
			if (points >= (maxPoints * 0.75))
			{
				_dialogueBoxPerfect.Visible = true;
			}
			else if(points <=(maxPoints*0.75) && points >= (maxPoints*0.35))
			{
				_dialogueBoxMid.Visible = true;
			}
			else
			{
				_dialogueBoxFail.Visible = true;
			}
			
			
			
			
			/*
			if (this.Name == "Sound")
			{
				if (points >= (maxPoints * 0.75))
				{
					feedback = "Inspiring, truly inspiring! Are you a relative of Hans Zimmer perhaps? You can be really proud of your work.";
				}
				else if(points <=(maxPoints*0.75) && points >= (maxPoints*0.35))
				{
					feedback = "Not bad, you just need some more exercise. Good work!";
				}
				else
				{
					feedback = "Um yeah, let's leave it by that. You gave it our all, that’s what matters.";
				}
			}
			else if(this.Name == "Management")
			{
				if (points >= (maxPoints * 0.75))
				{
					feedback = "Excellent work, just as I imagined. You have great potential.";
				}
				else if(points <=(maxPoints*0.75) && points >= (maxPoints*0.35))
				{
					feedback = "Good job, know we can get back to work.";
				}
				else
				{
					feedback = "Oh well, this helps at least a little bit. But don’t feel bad about your result, this is your first time after all.";
				}
			}
			else if (this.Name == "Programming")
			{
				if (points >= (maxPoints * 0.75))
				{
					feedback = "Holy-moly! That worked better than I thought. Perfect work newbie, that would be all for now.";
				}
				else if(points <=(maxPoints*0.75) && points >= (maxPoints*0.35))
				{
					feedback = "Not bad, but not really good either. Well I guess that’s all for now.";
				}
				else
				{
					feedback = "You don’t have any experience with blueprints, have you? Don’t worry about it, I deal with the leftovers myself.";
				}
			}
			else if (this.Name == "Story")
			{
				if (points >= (maxPoints * 0.75))
				{
					feedback = "Fantastic, you perfectly restored my whiteboard!";
				}
				else if(points <=(maxPoints*0.75) && points >= (maxPoints*0.35))
				{
					feedback = "You helped me a lot, I think I can think of the rest myself.";
				}
				else
				{
					feedback = "*Yawn* oh well, let’s just leave it at that. Maybe I can find even better story ideas if I do that task myself.";
				}
			}
			else
			{
				if (points >= (maxPoints * 0.75))
				{
					feedback = "You did an amazing job!";
				}
				else if(points <=(maxPoints*0.75) && points >= (maxPoints*0.35))
				{
					feedback = "Thanks for you help, you did fine.";
				}
				else
				{
					feedback = "Ohh well...I need to double check some of your work here.";
				}
			}
			*/
			
			GD.Print(points);
		}

		public void CheckPuzzle()
		{

			count = _sharedNode.CompletedTasks.Count;
			lastPuzzle = _sharedNode.CompletedTasks[count-1];
			
			switch (lastPuzzle)
			{
				case "programming":
					points = _sharedNode.programmingPoints;
					maxPoints = 105;
					break;
				case "management":
					points = _sharedNode.managementPoints;
					maxPoints = 40; //maybe idk?
					break;
				case "narrative":
					points = _sharedNode.narrativePoints;
					maxPoints = 30;
					break;
				case "sound":
					points = _sharedNode.soundPoints;
					maxPoints = 45;
					break;
				case "gamestudy":
					points = _sharedNode.gameStudyPoints;
					maxPoints = 50;
					break;
				case "gameDesign" :
					points = _sharedNode.gameDesignPoints;
					maxPoints = 40;
					break;
			}
		}
	}
}

