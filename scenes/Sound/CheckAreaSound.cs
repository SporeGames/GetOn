using Godot;
using System;
using GetOn.scenes.GameSelectionRoom;

namespace GetOn.scenes.Sound
{
	public class CheckAreaSound : Area2D
	{
		private SharedNode _sharedNode;
		private SubmitResults _submitResults;
		private Node2D _submitResultsPopUp;
		private GameSelRoom _gameSelRoom;

		private bool SoundItem;
		private bool SoundDeath;
		private bool SoundDrunk;
		private bool SoundEnemy;
		private bool SoundLow;
		private bool SoundPerfect;
		private bool SoundSecret;
		private bool SoundSpend;
		private bool SoundStealth;
		private double points = 0;

		private Button _submitPoints;
		
		public override void _Ready()
		{
			_submitPoints = GetNode<Button>("/root/Sound/Control/Button3");
			_submitPoints.Connect("pressed", this, nameof(CountPoints));
			_sharedNode = GetNode<SharedNode>("/root/SharedNode");
			_gameSelRoom = GetNode<GameSelRoom>("/root/scenes/GameSelectionRoom/GameSelectionRoom");
			_submitResults = GetNode<SubmitResults>("/root/GameStudy/SubmitResults");
			_submitResultsPopUp = GetNode<Node2D>("/root/GameStudy/SubmitResults");
		}

		private void _on_CheckArea_body_entered(object body)
		{
			if (body is KinematicBody2D kinematicBody)
			{
				if (kinematicBody.Name == "SoundItem")
				{
					SoundItem = true;
					GD.Print(SoundItem);
				}
				else if(kinematicBody.Name == "SoundDeath")
				{
					SoundDeath = true;
					GD.Print(SoundDeath);
				}
				else if(kinematicBody.Name == "SoundDrunk")
				{
					SoundDrunk = true;
					GD.Print(SoundDrunk);
				}
				else if(kinematicBody.Name == "SoundEnemy")
				{
					SoundEnemy = true;
					GD.Print(SoundEnemy);
				}
				else if(kinematicBody.Name == "SoundLow")
				{
					SoundLow = true;
					GD.Print(SoundLow);
				}
				else if(kinematicBody.Name == "SoundPerfect")
				{
					SoundPerfect = true;
					GD.Print(SoundPerfect);
				}
				else if(kinematicBody.Name == "SoundSecret")
				{
					SoundSecret = true;
					GD.Print(SoundSecret);
				}
				else if(kinematicBody.Name == "SoundSpend")
				{
					SoundSpend = true;
					GD.Print(SoundSpend);
				}
				else if(kinematicBody.Name == "SoundStealth")
				{
					SoundStealth = true;
					GD.Print(SoundStealth);
				}
			}
		}


		private void _on_CheckArea_body_exited(object body)
		{
			if (body is KinematicBody2D kinematicBody)
			{
				if (kinematicBody.Name == "SoundItem")
				{
					SoundDrunk = false;
					GD.Print(SoundDrunk);
				}
				else if(kinematicBody.Name == "SoundDeath")
				{
					SoundDeath = false;
					GD.Print(SoundDeath);
				}
				else if(kinematicBody.Name == "SoundDrunk")
				{
					SoundDrunk = false;
					GD.Print(SoundDrunk);
				}
				else if(kinematicBody.Name == "SoundEnemy")
				{
					SoundEnemy = false;
					GD.Print(SoundEnemy);
				}
				else if(kinematicBody.Name == "SoundLow")
				{
					SoundLow = false;
					GD.Print(SoundLow);
				}
				else if(kinematicBody.Name == "SoundPerfect")
				{
					SoundPerfect = false;
					GD.Print(SoundPerfect);
				}
				else if(kinematicBody.Name == "SoundSecret")
				{
					SoundSecret = false;
					GD.Print(SoundSecret);
				}
				else if(kinematicBody.Name == "SoundSpend")
				{
					SoundSpend = false;
					GD.Print(SoundSpend);
				}
				else if(kinematicBody.Name == "SoundStealth")
				{
					SoundStealth = false;
					GD.Print(SoundStealth);
				}
			}
		}

		public void CountPoints()
		{
			points = 0;
			if (SoundDeath)
			{
				points += 2.5;
			}
			if (SoundSpend)
			{
				points += 2.5;
			}
			if (SoundItem)
			{
				points += 2.5;
			}
			if (SoundEnemy)
			{
				points += 5;
			}
			if (SoundLow)
			{
				points += 5;
			}
			if (SoundSecret)
			{
				points += 5;
			}
			if (SoundDrunk)
			{
				points += 7.5;
			}
			if (SoundPerfect)
			{
				points += 7.5;
			}
			if (SoundStealth)
			{
				points += 7.5;
			}
			/*
			_submitResultsPopUp.Visible = true;
			_submitResults.soundPoints = points;
			_submitResults.soundTime = GetNode<CountdownTimer>("/root/Sound/TopBar/Timer").CurrentTime;
			
			points += GetNode<CountdownTimer>("/root/Sound/TopBar/Timer").GetBonusPointsForTime();
			GD.Print(points);
			_sharedNode.soundPoints = (int) points;
			_sharedNode.soundTime = GetNode<CountdownTimer>("/root/Sound/TopBar/Timer").CurrentTime;
			_sharedNode.CompletedTasks.Add(AbilitySpecialization.Sound);
			_sharedNode.SwitchScene("res://scenes/Rooms/SoundArtRoom.tscn");
			*/
		}
	}
}



