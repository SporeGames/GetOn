using Godot;
using System;

namespace GetOn.scenes.GameStudy 
{
	public class CheckArea : Area2D
	{
		private SharedNode _sharedNode;
		
		private bool nESCorrect;
		private bool xBOXCorrect;
		private bool gameBoyCorrect;
		private bool megaDrive1Correct;
		private bool atariCorrect;
		private bool c64Correct;
		private bool segaSaturnCorrect;
		private bool magnavoxCorrect;

		private bool tennisCorrect;
		private bool pongCorrect;
		private bool mazeWarsCorrect;
		private bool spaceInvadersCorrect;
		private bool pacManCorrect;
		private bool donkeyKongCorrect;
		private bool detriotCorrect;
		private bool bioshockCorrect;
		private bool strayCorrect;
		private bool cyberpunkCorrect;
		private bool horizonCorrect;
		private bool starfieldCorrect;
		
		private Button _submitButton;
		private double points;

		// Called when the node enters the scene tree for the first time.
		public override void _Ready()
		{
			_sharedNode = GetNode<SharedNode>("/root/SharedNode");
			nESCorrect = false;
			xBOXCorrect = false;
			gameBoyCorrect = false;
			megaDrive1Correct = false;
			_submitButton = GetNode<Button>("/root/GameStudy/Submit");
			_submitButton.Connect("pressed", this, nameof(CheckifCorrect));
			points = 0;
		}

		private void CheckifCorrect()
		{
			if (nESCorrect == true)
			{
				points += 2.5;
			}

			if (xBOXCorrect)
			{
				points += 2.5;
			}

			if (gameBoyCorrect)
			{
				points += 2.5;
			}

			if (megaDrive1Correct)
			{
				points += 2.5;
			}
			
			if (atariCorrect)
			{
				points += 2.5;
			}
			if (c64Correct)
			{
				points += 2.5;
			}
			if (segaSaturnCorrect)
			{
				points += 2.5;
			}
			if (magnavoxCorrect)
			{
				points += 2.5;
			}
			
			
			
			if (tennisCorrect)
			{
				points += 3;
			}
			if (pongCorrect)
			{
				points += 3;
			}
			if (mazeWarsCorrect)
			{
				points += 3;
			}
			if (spaceInvadersCorrect)
			{
				points += 3;
			}
			if (pacManCorrect)
			{
				points += 3;
			}
			if (donkeyKongCorrect)
			{
				points += 3;
			}
			
			if (detriotCorrect)
			{
				points += 2;
			}
			if (cyberpunkCorrect)
			{
				points += 2;
			}
			if (starfieldCorrect)
			{
				points += 2;
			}
			if (bioshockCorrect)
			{
				points += 2;
			}
			if (horizonCorrect)
			{
				points += 2;
			}
			if (strayCorrect)
			{
				points += 2;
			}
			
			
			GD.Print(points);
			_sharedNode.gameStudyPoints = points;
			_sharedNode.gameStudyTime = GetNode<CountdownTimer>("/root/GameStudy/TopBar/Timer").CurrentTime;
			_sharedNode.CompletedTasks.Add(AbilitySpecialization.GameStudy);
			_sharedNode.SwitchScene("res://scenes/Rooms/GameStudyRoom.tscn");
		}

		private void _on_CheckGameBoy_body_entered(object body)
		{
			if (body is KinematicBody2D kinematicBody)
			{
				if (kinematicBody.Name == "GameBoy")
				{
					GD.Print("GAMEBOY");
					gameBoyCorrect = true;
				}
			}
		}
		private void _on_CheckXBOX_body_entered(object body)
		{
			if (body is KinematicBody2D kinematicBody)
			{
				if (kinematicBody.Name == "XBOX")
				{
					GD.Print("XBOX");
					xBOXCorrect = true;
				}
			}
		}
		private void _on_CheckMegaDrive1_body_entered(object body)
		{
			if (body is KinematicBody2D kinematicBody)
			{
				if (kinematicBody.Name == "MegaDrive1")
				{
					GD.Print("MegaDrive1");
					megaDrive1Correct = true;
				}
			}
		}


		private void _on_CheckNES_body_entered(object body)
		{
			if (body is KinematicBody2D kinematicBody)
			{
				if (kinematicBody.Name == "NES")
				{
					GD.Print("NES");
					nESCorrect = true;
				}
			}
		}
		
		private void _on_CheckAtari_body_entered(object body)
		{
			if (body is KinematicBody2D kinematicBody)
			{
				if (kinematicBody.Name == "Atari")
				{
					GD.Print("Atari");
					atariCorrect = true;
				}
			}
		}


		private void _on_CheckC64_body_entered(object body)
		{
			if (body is KinematicBody2D kinematicBody)
			{
				if (kinematicBody.Name == "C64")
				{
					GD.Print("C64");
					c64Correct = true;
				}
			}
		}


		private void _on_CheckSegaSaturn_body_entered(object body)
		{
			if (body is KinematicBody2D kinematicBody)
			{
				if (kinematicBody.Name == "SegaSaturn")
				{
					GD.Print("SegaSaturn");
					segaSaturnCorrect = true;
				}
			}
		}


		private void _on_CheckMagnavox_body_entered(object body)
		{
			if (body is KinematicBody2D kinematicBody)
			{
				if (kinematicBody.Name == "Magnavox")
				{
					GD.Print("Magnavox");
					magnavoxCorrect = true;
				}
			}
		}
		
		private void _on_CheckGameBoy_body_exited(object body)
		{
			if (body is KinematicBody2D kinematicBody)
			{
				if (kinematicBody.Name == "GameBoy")
				{
					gameBoyCorrect = false;
					GD.Print("GameBoy: "+gameBoyCorrect);
				}
			}
		}
		private void _on_CheckXBOX_body_exited(object body)
		{
			if (body is KinematicBody2D kinematicBody)
			{
				if (kinematicBody.Name == "XBOX")
				{
					 xBOXCorrect = false;
				}
			}
		}


		private void _on_CheckNES_body_exited(object body)
		{
			if (body is KinematicBody2D kinematicBody)
			{
				if (kinematicBody.Name == "NES")
				{
					nESCorrect = false;
				}
			}
		}
		private void _on_CheckMegaDrive1_body_exited(object body)
		{
			if (body is KinematicBody2D kinematicBody)
			{
				if (kinematicBody.Name == "MegaDrive1")
				{
					megaDrive1Correct = false;
				}
			}
		}
		
		private void _on_CheckAtari_body_exited(object body)
		{
			if (body is KinematicBody2D kinematicBody)
			{
				if (kinematicBody.Name == "Atari")
				{
					atariCorrect = false;
				}
			}
		}


		private void _on_CheckC64_body_exited(object body)
		{
			if (body is KinematicBody2D kinematicBody)
			{
				if (kinematicBody.Name == "C64")
				{
					c64Correct = false;
				}
			}
		}


		private void _on_CheckSegaSaturn_body_exited(object body)
		{
			if (body is KinematicBody2D kinematicBody)
			{
				if (kinematicBody.Name == "SegaSaturn")
				{
					segaSaturnCorrect = false;
				}
			}
		}


		private void _on_CheckMagnavox_body_exited(object body)
		{
			if (body is KinematicBody2D kinematicBody)
			{
				if (kinematicBody.Name == "Magnavox")
				{
					magnavoxCorrect = false;
				}
			}
		}
		
		//Games check 

		private void _on_CheckTennis_body_entered(object body)
		{
			if (body is KinematicBody2D kinematicBody)
			{
				if (kinematicBody.Name == "TennisForTwo")
				{
					GD.Print("TennisForTwo");
					tennisCorrect = true;
				}
			}
			
		}


		private void _on_CheckPong_body_entered(object body)
		{
			if (body is KinematicBody2D kinematicBody)
			{
				if (kinematicBody.Name == "Pong")
				{
					GD.Print("Pong");
					pongCorrect = true;
				}
			}
		}


		private void _on_CheckMazeWars_body_entered(object body)
		{
			if (body is KinematicBody2D kinematicBody)
			{
				if (kinematicBody.Name == "MazeWars")
				{
					GD.Print("MazeWars");
					mazeWarsCorrect = true;
				}
			}
		}


		private void _on_CheckSpaceInvaders_body_entered(object body)
		{
			if (body is KinematicBody2D kinematicBody)
			{
				if (kinematicBody.Name == "SpaceInvaders")
				{
					GD.Print("SpaceInvaders");
					spaceInvadersCorrect = true;
				}
			}
		}


		private void _on_CheckPacMan_body_entered(object body)
		{
			if (body is KinematicBody2D kinematicBody)
			{
				if (kinematicBody.Name == "PacMan")
				{
					GD.Print("PacMan");
					pacManCorrect = true;
				}
			}
		}


		private void _on_CheckDonkeyKong_body_entered(object body)
		{
			if (body is KinematicBody2D kinematicBody)
			{
				if (kinematicBody.Name == "DonkeyKong")
				{
					GD.Print("DonkeyKong");
					donkeyKongCorrect = true;
				}
			}
		}


		private void _on_CheckDystopie_body_entered(object body)
		{
			if (body is KinematicBody2D kinematicBody)
			{
				if (kinematicBody.Name == "Bioshock")
				{
					GD.Print("Bioshock");
					bioshockCorrect = true;
				}
				else if (kinematicBody.Name == "Detroit")
				{
					GD.Print("Detriot");
					detriotCorrect = true;
				}
				else if (kinematicBody.Name == "Stray")
				{
					GD.Print("Stray");
					strayCorrect = true;
				}
			}
		}


		private void _on_CheckCyberpunk_body_entered(object body)
		{
			if (body is KinematicBody2D kinematicBody)
			{
				if (kinematicBody.Name == "Cyberpunk")
				{
					GD.Print("Cyberpunk");
					cyberpunkCorrect = true;
				}
			}
		}


		private void _on_CheckSpace_body_entered(object body)
		{
			if (body is KinematicBody2D kinematicBody)
			{
				if (kinematicBody.Name == "Starfield")
				{
					GD.Print("Starfield");
					starfieldCorrect = true;
				}
			}
		}


		private void _on_CheckPostApocaliptic_body_entered(object body)
		{
			if (body is KinematicBody2D kinematicBody)
			{
				if (kinematicBody.Name == "Horizon")
				{
					GD.Print("Horizon");
					horizonCorrect = true;
				}
			}
		}
		
		private void _on_CheckTennis_body_exited(object body)
		{
			if (body is KinematicBody2D kinematicBody)
			{
				if (kinematicBody.Name == "TennisForTwo")
				{
					tennisCorrect = false;
				}
			}
		}


		private void _on_CheckPong_body_exited(object body)
		{
			if (body is KinematicBody2D kinematicBody)
			{
				if (kinematicBody.Name == "Pong")
				{
					GD.Print("Pong");
					pongCorrect = false;
				}
			}
		}


		private void _on_CheckMazeWars_body_exited(object body)
		{
			if (body is KinematicBody2D kinematicBody)
			{
				if (kinematicBody.Name == "MazeWars")
				{
					GD.Print("MazeWars");
					mazeWarsCorrect = false;
				}
			}
		}


		private void _on_CheckSpaceInvaders_body_exited(object body)
		{
			if (body is KinematicBody2D kinematicBody)
			{
				if (kinematicBody.Name == "SpaceInvaders")
				{
					GD.Print("SpaceInvaders");
					spaceInvadersCorrect = false;
				}
			}
		}


		private void _on_CheckPacMan_body_exited(object body)
		{
			if (body is KinematicBody2D kinematicBody)
			{
				if (kinematicBody.Name == "PacMan")
				{
					GD.Print("PacMan");
					pacManCorrect = false;
				}
			}
		}


		private void _on_CheckDonkeyKong_body_exited(object body)
		{
			if (body is KinematicBody2D kinematicBody)
			{
				if (kinematicBody.Name == "DonkeyKong")
				{
					GD.Print("DonkeyKong");
					donkeyKongCorrect = false;
				}
			}
		}


		private void _on_CheckDystopie_body_exited(object body)
		{
			if (body is KinematicBody2D kinematicBody)
			{
				if (kinematicBody.Name == "Bioshock")
				{
					GD.Print("Bioshock");
					bioshockCorrect = false;
				}
				else if (kinematicBody.Name == "Detroit")
				{
					GD.Print("Detriot");
					detriotCorrect = false;
				}
				else if (kinematicBody.Name == "Stray")
				{
					GD.Print("Stray");
					strayCorrect = false;
				}
			}
		}


		private void _on_CheckCyberpunk_body_exited(object body)
		{
			if (body is KinematicBody2D kinematicBody)
			{
				if (kinematicBody.Name == "Cyberpunk")
				{
					GD.Print("Cyberpunk");
					cyberpunkCorrect = false;
				}
			}
		}
		private void _on_CheckSpace_body_exited(object body)
		{
			if (body is KinematicBody2D kinematicBody)
			{
				if (kinematicBody.Name == "Starfield")
				{
					GD.Print("Starfield");
					starfieldCorrect = false;
				}
			}
		}

		private void _on_CheckPostApocaliptic_body_exited(object body)
		{
			if (body is KinematicBody2D kinematicBody)
			{
				if (kinematicBody.Name == "Horizon")
				{
					GD.Print("Horizon");
					horizonCorrect = false;
				}
			}
		}

	}
}













