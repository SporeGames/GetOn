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
		private int points;
		private int count;
		private String lastPuzzle;
		private int maxPoints;
	
		public override void _Ready()
		{
			_sharedNode = GetNode<SharedNode>("/root/SharedNode");
			_text = GetNode<Label>("Label");
			_back = GetNode<Button>("Button");
			_back.Connect("pressed", this, nameof(BackToMenu));
			CheckPuzzle();
			CheckPoints();

			if (feedback == "fine")
			{
				_text.Text = "Thanks for your help! You did a: " +feedback +" job";
			}
			else
			{
				_text.Text = "Thanks for your help! You did an: " +feedback +" job";
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
				feedback = "amazing";
			}
			else if(points <=(maxPoints*0.75) && points >= (maxPoints*0.35))
			{
				feedback = "fine";
			}
			else
			{
				feedback = "okay";
			}
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
					maxPoints = 50;
					break;
				case "sound":
					points = _sharedNode.soundPoints;
					maxPoints = 45;
					break;
				case "gamestudy":
					points = _sharedNode.gameStudyPoints;
					maxPoints = 20;
					break;
				case "gameDesign" :
					points = _sharedNode.gameDesignPoints;
					maxPoints = 40;
					break;
			}
			
		}
	}
}

