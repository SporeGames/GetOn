using Godot;
using System;
using GetOn.scenes;

public class Consoles : Node2D
{
	private SharedNode _sharedNode;
	private SubmitResults _submitResults;
	private Node2D _submitResultsPopUp;
	
	public int gameStudyConsoles = 0;
	public int gameStudyClassicGames = 0;
	public int gameStudySciFiGames = 0;
	
	private bool xboxCorrect;
	private bool nesCorrect;
	private bool atariCorrect;
	private bool c64Correct;
	private bool magnavoxCorrect;
	private bool megadrive1Correct;
	private bool segaSaturnCorrect;
	private bool gameBoyCorrect;

	private bool xboxentered;

	private Sprite xboxArea;
	private Sprite gameboyArea;
	private Sprite nesArea;
	private Sprite c64Area;
	private Sprite magnavoxArea;
	private Sprite megaDriveArea;
	private Sprite segaSaturnArea;
	private Sprite AtariArea;

	[Export] public Texture XBOX;
	[Export] public Texture GameBoy;
	[Export] public Texture NES;
	[Export] public Texture C64;
	[Export] public Texture Magnavox;
	[Export] public Texture MegaDrive1;
	[Export] public Texture SegaSaturn;
	[Export] public Texture Atari;

	private bool xboxEntered;
	private bool gameBoyEntered;
	private bool nesEntered;
	private bool c64Entered;
	private bool magnavoxEntered;
	private bool megaDrive1Entered;
	private bool segaSaturnEntered;
	private bool atariEntered;
	
	private string thisEnteredXBOX;
	private string thisEnteredGameBoy;
	private string thisEnteredNES;
	private string thisEnteredC64;
	private string thisEnteredMagnavox;
	private string thisEnteredMegaDrive;
	private string thisEnteredSegaSaturn;
	private string thisEnteredAtari;

	private Sprite tennisArea;
	private Sprite mazeWarsArea;
	private Sprite spaceInvadersArea;
	private Sprite donkeyKongArea;
	private Sprite pongArea;
	private Sprite pacManArea;
	private Sprite bioshockArea;
	private Sprite strayArea;
	private Sprite starfieldArea;
	private Sprite cyberpunkArea;
	private Sprite detriotArea;
	private Sprite horizonArea;

	[Export] public Texture Tennis;
	[Export] public Texture MazeWars;
	[Export] public Texture SpaceInvaders;
	[Export] public Texture DonkeyKong;
	[Export] public Texture Pong;
	[Export] public Texture PacMan;
	[Export] public Texture Bioshock;
	[Export] public Texture Stray;
	[Export] public Texture Starfield;
	[Export] public Texture Cyberpunk;
	[Export] public Texture Detriot;
	[Export] public Texture Horizon;
	

	private bool tennisEntered;
	private bool mazeWarsEntered;
	private bool spaceInvadersEntered;
	private bool donkeyKongEntered;
	private bool pongEntered;
	private bool pacmanEntered;
	private bool bioshockEntered;
	private bool strayEntered;
	private bool starfieldEntered;
	private bool cyberpunkEntered;
	private bool detriotEntered;
	private bool horizonEntered;

	private string thisEnteredTennis;
	private string thisEnteredMazeWars;
	private string thisEnteredSpaceInvaders;
	private string thisEnteredDonkeyKong;
	private string thisEnteredPong;
	private string thisEnteredPacMan;
	private string thisEnteredBioshock;
	private string thisEnteredStray;
	private string thisEnteredStarfield;
	private string thisEnteredCyberpunk;
	private string thisEnteredDetriot;
	private string thisEnteredHorizon;

	private bool tennisCorrect;
	private bool mazeWarsCorrect;
	private bool spaceInvadersCorrect;
	private bool donkeyKongCorrect;
	private bool pongCorrect;
	private bool pacmanCorrect;
	private bool bioshockCorrect;
	private bool strayCorrect;
	private bool starfieldCorrect;
	private bool cyberpunkCorrect;
	private bool detriotCorrect;
	private bool horizonCorrect;

	
	private double points;
	
	public override void _Ready()
	{
		_sharedNode = GetNode<SharedNode>("/root/SharedNode");
		_submitResults = GetNode<SubmitResults>("/root/GameStudy/SubmitResults");
		_submitResultsPopUp = GetNode<Node2D>("/root/GameStudy/SubmitResults");
		
		xboxArea = GetNode<Sprite>("/root/GameStudy/SortedSprites/xboxArea");
		gameboyArea = GetNode<Sprite>("/root/GameStudy/SortedSprites/gameboyArea");
		c64Area = GetNode<Sprite>("/root/GameStudy/SortedSprites/c64Area");
		nesArea = GetNode<Sprite>("/root/GameStudy/SortedSprites/nesArea");
		magnavoxArea = GetNode<Sprite>("/root/GameStudy/SortedSprites/magnavoxArea");
		megaDriveArea = GetNode<Sprite>("/root/GameStudy/SortedSprites/megaDrive1Area");
		segaSaturnArea = GetNode<Sprite>("/root/GameStudy/SortedSprites/segaSaturnArea");
		AtariArea = GetNode<Sprite>("/root/GameStudy/SortedSprites/atariArea");

		tennisArea = GetNode<Sprite>("/root/GameStudy/SortedSprites/tennisArea");
		mazeWarsArea = GetNode<Sprite>("/root/GameStudy/SortedSprites/mazeWarsArea");
		spaceInvadersArea = GetNode<Sprite>("/root/GameStudy/SortedSprites/spaceInvadersArea");
		pongArea = GetNode<Sprite>("/root/GameStudy/SortedSprites/pongArea");
		pacManArea = GetNode<Sprite>("/root/GameStudy/SortedSprites/pacmanArea");
		bioshockArea = GetNode<Sprite>("/root/GameStudy/SortedSprites/egoshooterArea");
		donkeyKongArea = GetNode<Sprite>("/root/GameStudy/SortedSprites/donkeyKongArea");
		starfieldArea = GetNode<Sprite>("/root/GameStudy/SortedSprites/starfieldArea");
		strayArea = GetNode<Sprite>("/root/GameStudy/SortedSprites/strayArea");
		cyberpunkArea = GetNode<Sprite>("/root/GameStudy/SortedSprites/cyberpunkArea");
		detriotArea = GetNode<Sprite>("/root/GameStudy/SortedSprites/detriotArea");
		horizonArea = GetNode<Sprite>("/root/GameStudy/SortedSprites/horizonArea");
	}

	public void CheckifCorrect()
	{
		points = 0;
		if (nesCorrect == true)
		{
			points += 2.5;
			gameStudyConsoles++;
		}

		if (xboxCorrect)
		{
			points += 2.5;
			gameStudyConsoles++;
		}

		if (gameBoyCorrect)
		{
			points += 2.5;
			gameStudyConsoles++;
		}

		if (megadrive1Correct)
		{
			points += 2.5;
			gameStudyConsoles++;
		}

		if (atariCorrect)
		{
			points += 2.5;
			gameStudyConsoles++;
		}

		if (c64Correct)
		{
			points += 2.5;
			gameStudyConsoles++;
		}

		if (segaSaturnCorrect)
		{
			points += 2.5;
			gameStudyConsoles++;
		}

		if (magnavoxCorrect)
		{
			points += 2.5;
			gameStudyConsoles++;
		}
		if (tennisCorrect)
		{
			points += 2.5;
			gameStudyClassicGames++;
		}
		if (mazeWarsCorrect)
		{
			points += 2.5;
			gameStudyClassicGames++;
		}
		if (spaceInvadersCorrect)
		{
			points += 2.5;
			gameStudyClassicGames++;
		}
		if (donkeyKongCorrect)
		{
			points += 2.5;
			gameStudyClassicGames++;
		}
		if (pongCorrect)
		{
			points += 2.5;
			gameStudyClassicGames++;
		}
		if (pacmanCorrect)
		{
			points += 2.5;
			gameStudyClassicGames++;
		}
		if (bioshockCorrect)
		{
			points += 2;
			gameStudySciFiGames++;
		}
		if (strayCorrect)
		{
			points += 2;
			gameStudySciFiGames++;
		}
		if (starfieldCorrect)
		{
			points += 2;
			gameStudySciFiGames++;
		}
		if (cyberpunkCorrect)
		{
			points += 2;
			gameStudySciFiGames++;
		}
		if (horizonCorrect)
		{
			points += 2;
			gameStudySciFiGames++;
		}
		if (detriotCorrect)
		{
			points += 2;
			gameStudySciFiGames++;
		}

		if (atariCorrect && c64Correct && segaSaturnCorrect && magnavoxCorrect && nesCorrect && gameBoyCorrect &&
			megadrive1Correct && xboxCorrect)
		{
			points += 0.5;
		}

		if (tennisCorrect && pongCorrect && mazeWarsCorrect && pacmanCorrect && spaceInvadersCorrect &&
			donkeyKongCorrect && bioshockCorrect && horizonCorrect && starfieldCorrect && detriotCorrect &&
			cyberpunkCorrect && strayCorrect)
		{
			points += 0.5;
		}
		/*
		points += GetNode<CountdownTimer>("/root/GameStudy/TopBar/Timer").GetBonusPointsForTime();
		_sharedNode.gameStudyPoints = points;
		_sharedNode.gameStudyTime = GetNode<CountdownTimer>("/root/GameStudy/TopBar/Timer").CurrentTime;
		_sharedNode.CompletedTasks.Add(AbilitySpecialization.Game_Studies);
		_sharedNode.SwitchScene("res://scenes/Rooms/GameStudyRoom.tscn");
		GD.Print(points);
		*/
		//points += GetNode<CountdownTimer>("/root/GameStudy/TopBar/Timer").GetBonusPointsForTime();
		_submitResults.gameStudySciFiGames = gameStudySciFiGames;
		_submitResults.gameStudyConsoles = gameStudyConsoles;
		_submitResults.gameStudyClassicGames = gameStudyClassicGames;
		_submitResultsPopUp.Visible = true;
		_submitResults.gameStudyPoints = points;
		_submitResults.gameStudyTime = GetNode<CountdownTimer>("/root/GameStudy/TopBar/Timer").CurrentTime;
	}

	private void AddConsoleToBackground(Sprite area,Texture texture)
	{
		GD.Print(area);
		if (texture == GameBoy || texture == C64 || texture == Magnavox || texture == MegaDrive1 || texture == Atari || texture == SegaSaturn)
		{
			area.Scale = new Vector2(0.1f,0.1f);
			area.Visible = true;
			area.Texture = texture;
		}
		else
		{
			area.Scale = new Vector2(0.3f,0.3f);
			area.Visible = true;
			area.Texture = texture;
		}
	}
	
	
	private void _on_CheckXBOX_body_entered(object body)
	{
		if (body is KinematicBody2D kinematicBody)
		{
			if (kinematicBody.Name == "XBOX" && xboxEntered == false)
			{
				AddConsoleToBackground(xboxArea, XBOX);
				xboxEntered = true;
				thisEnteredXBOX = kinematicBody.Name;
			}
			if (kinematicBody.Name == "GameBoy" && xboxEntered == false)
			{
				AddConsoleToBackground(xboxArea, GameBoy);
				xboxEntered = true;
				thisEnteredXBOX = kinematicBody.Name;
			}
			if (kinematicBody.Name == "NES" && xboxEntered == false)
			{
				AddConsoleToBackground(xboxArea, NES);
				xboxEntered = true;
				thisEnteredXBOX = kinematicBody.Name;
			}
			if (kinematicBody.Name == "C64" && xboxEntered == false)
			{
				AddConsoleToBackground(xboxArea, C64);
				xboxEntered = true;
				thisEnteredXBOX = kinematicBody.Name;
			}
			if (kinematicBody.Name == "SegaSaturn" && xboxEntered == false)
			{
				AddConsoleToBackground(xboxArea, SegaSaturn);
				xboxEntered = true;
				thisEnteredXBOX = kinematicBody.Name;
			}
			if (kinematicBody.Name == "MegaDrive1" && xboxEntered == false)
			{
				AddConsoleToBackground(xboxArea, MegaDrive1);
				xboxEntered = true;
				thisEnteredXBOX = kinematicBody.Name;
			}
			if (kinematicBody.Name == "Magnavox" && xboxEntered == false)
			{
				AddConsoleToBackground(xboxArea, Magnavox);
				xboxEntered = true;
				thisEnteredXBOX = kinematicBody.Name;
			}
			if (kinematicBody.Name == "Atari" && xboxEntered == false)
			{
				AddConsoleToBackground(xboxArea, Atari);
				xboxEntered = true;
				thisEnteredXBOX = kinematicBody.Name;
			}

			if (kinematicBody.Name == "XBOX")
			{
				xboxCorrect = true;
				if (xboxEntered == false)
				{
					AddConsoleToBackground(xboxArea, XBOX);
					xboxEntered = true;
					thisEnteredXBOX = kinematicBody.Name;
				}
			}
		}
	}


	private void _on_CheckXBOX_body_exited(object body)
	{
		if (body is KinematicBody2D kinematicBody)
		{
			if (kinematicBody.Name == "XBOX")
			{
				GD.Print("XBOX left");
				xboxCorrect = false;
				if (thisEnteredXBOX == kinematicBody.Name)
				{
					xboxEntered = false;
					xboxArea.Visible = false;
				}
			}
			if (thisEnteredXBOX == kinematicBody.Name)
			{
				xboxEntered = false;
				xboxArea.Visible = false;
			}

			xboxentered = false;
		}
	}
	private void _on_CheckGameBoy_body_entered(object body)
	{
		if (body is KinematicBody2D kinematicBody)
		{
			if (kinematicBody.Name == "XBOX" && gameBoyEntered == false)
			{
				AddConsoleToBackground(gameboyArea,XBOX);
				gameBoyEntered = true;
				thisEnteredGameBoy = kinematicBody.Name;
			}
			if (kinematicBody.Name == "GameBoy")
			{
				gameBoyCorrect = true;
				if (gameBoyEntered == false)
				{
					AddConsoleToBackground(gameboyArea,GameBoy);
					gameBoyEntered = true;
					thisEnteredGameBoy = kinematicBody.Name;
				}
			}
			if (kinematicBody.Name == "NES" && gameBoyEntered == false)
			{
				AddConsoleToBackground(gameboyArea,NES);
				gameBoyEntered = true;
				thisEnteredGameBoy = kinematicBody.Name;
			}
			if (kinematicBody.Name == "C64" && gameBoyEntered == false)
			{
				AddConsoleToBackground(gameboyArea,C64);
				gameBoyEntered = true;
				thisEnteredGameBoy = kinematicBody.Name;
			}
			if (kinematicBody.Name == "SegaSaturn" && gameBoyEntered == false)
			{
				AddConsoleToBackground(gameboyArea,SegaSaturn);
				gameBoyEntered = true;
				thisEnteredGameBoy = kinematicBody.Name;
			}
			if (kinematicBody.Name == "MegaDrive1" && gameBoyEntered == false)
			{
				AddConsoleToBackground(gameboyArea,MegaDrive1);
				gameBoyEntered = true;
				thisEnteredGameBoy = kinematicBody.Name;
			}
			if (kinematicBody.Name == "Magnavox"&& gameBoyEntered == false )
			{
				AddConsoleToBackground(gameboyArea,Magnavox);
				gameBoyEntered = true;
				thisEnteredGameBoy = kinematicBody.Name;
			}
			if (kinematicBody.Name == "Atari"&& gameBoyEntered == false)
			{
				AddConsoleToBackground(gameboyArea,Atari);
				gameBoyEntered = true;
				thisEnteredGameBoy = kinematicBody.Name;
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
				if (thisEnteredGameBoy == kinematicBody.Name)
				{
					gameBoyEntered = false;
					gameboyArea.Visible = false;
				}
			}
			if (thisEnteredGameBoy == kinematicBody.Name)
			{
				gameBoyEntered = false;
				gameboyArea.Visible = false;
			}
		}
	}

	private void _on_CheckNES_body_entered(object body)
	{
		if (body is KinematicBody2D kinematicBody)
		{
			if (kinematicBody.Name == "XBOX" && nesEntered == false)
			{
				AddConsoleToBackground(nesArea,XBOX);
				nesEntered = true;
				thisEnteredNES = kinematicBody.Name;
			}
			if (kinematicBody.Name == "GameBoy" && nesEntered == false)
			{
				AddConsoleToBackground(nesArea,GameBoy);
				nesEntered = true;
				thisEnteredNES = kinematicBody.Name;
			}
			if (kinematicBody.Name == "NES")
			{
				nesCorrect = true;
				if (nesEntered == false)
				{
					AddConsoleToBackground(nesArea,NES);
					nesEntered = true;
					thisEnteredNES = kinematicBody.Name;
				}
			}
			if (kinematicBody.Name == "C64" && nesEntered == false)
			{
				AddConsoleToBackground(nesArea,C64);
				nesEntered = true;
				thisEnteredNES = kinematicBody.Name;
			}
			if (kinematicBody.Name == "SegaSaturn" && nesEntered == false)
			{
				AddConsoleToBackground(nesArea,SegaSaturn);
				nesEntered = true;
				thisEnteredNES = kinematicBody.Name;
			}
			if (kinematicBody.Name == "MegaDrive1" && nesEntered == false)
			{
				AddConsoleToBackground(nesArea,MegaDrive1);
				nesEntered = true;
				thisEnteredNES = kinematicBody.Name;
			}
			if (kinematicBody.Name == "Magnavox"&& nesEntered == false )
			{
				AddConsoleToBackground(nesArea,Magnavox);
				nesEntered = true;
				thisEnteredNES = kinematicBody.Name;
			}
			if (kinematicBody.Name == "Atari"&& nesEntered == false)
			{
				AddConsoleToBackground(nesArea,Atari);
				nesEntered = true;
				thisEnteredNES = kinematicBody.Name;
			}
		}
	}


	private void _on_CheckNES_body_exited(object body)
	{
		if (body is KinematicBody2D kinematicBody)
		{
			if (kinematicBody.Name == "NES")
			{
				nesCorrect = false;
				if (thisEnteredNES == kinematicBody.Name)
				{
					nesEntered = false;
					nesArea.Visible = false;
				}
			}
			if (thisEnteredNES == kinematicBody.Name)
			{
				nesEntered = false;
				nesArea.Visible = false;
			}
		}
		
	}
	private void _on_CheckC64_body_entered(object body)
	{
		if (body is KinematicBody2D kinematicBody)
		{
			if (kinematicBody.Name == "XBOX" && c64Entered == false)
			{
				AddConsoleToBackground(c64Area,XBOX);
				c64Entered = true;
				thisEnteredC64 = kinematicBody.Name;
			}
			if (kinematicBody.Name == "GameBoy" && c64Entered == false)
			{
				AddConsoleToBackground(c64Area,GameBoy);
				c64Entered = true;
				thisEnteredC64 = kinematicBody.Name;
			}
			if (kinematicBody.Name == "NES" && c64Entered == false)
			{
				AddConsoleToBackground(c64Area,NES);
				c64Entered = true;
				thisEnteredC64 = kinematicBody.Name;
			}
			
			if (kinematicBody.Name == "C64")
			{
				c64Correct = true;
				if (c64Entered == false)
				{
					AddConsoleToBackground(c64Area,C64);
					c64Entered = true;
					thisEnteredC64 = kinematicBody.Name;
				}
			}
			if (kinematicBody.Name == "SegaSaturn" && c64Entered == false)
			{
				AddConsoleToBackground(c64Area,SegaSaturn);
				c64Entered = true;
				thisEnteredC64 = kinematicBody.Name;
			}
			if (kinematicBody.Name == "MegaDrive1" && c64Entered == false)
			{
				AddConsoleToBackground(c64Area,MegaDrive1);
				c64Entered = true;
				thisEnteredC64 = kinematicBody.Name;
			}
			if (kinematicBody.Name == "Magnavox"&& c64Entered == false )
			{
				AddConsoleToBackground(c64Area,Magnavox);
				c64Entered = true;
				thisEnteredC64 = kinematicBody.Name;
			}
			if (kinematicBody.Name == "Atari"&& c64Entered == false)
			{
				AddConsoleToBackground(c64Area,Atari);
				c64Entered = true;
				thisEnteredC64 = kinematicBody.Name;
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
				if (thisEnteredC64 == kinematicBody.Name)
				{
					c64Entered = false;
					c64Area.Visible = false;
				}
			}
			if (thisEnteredC64 == kinematicBody.Name)
			{
				c64Entered = false;
				c64Area.Visible = false;
			}
		}
	}
	
	private void _on_CheckSegaSaturn_body_entered(object body)
	{
		if (body is KinematicBody2D kinematicBody)
		{
			if (kinematicBody.Name == "XBOX" && segaSaturnEntered == false)
			{
				AddConsoleToBackground(segaSaturnArea,XBOX);
				segaSaturnEntered = true;
				thisEnteredSegaSaturn = kinematicBody.Name;
			}
			if (kinematicBody.Name == "GameBoy" && segaSaturnEntered == false)
			{
				AddConsoleToBackground(segaSaturnArea,GameBoy);
				segaSaturnEntered = true;
				thisEnteredSegaSaturn = kinematicBody.Name;
			}
			if (kinematicBody.Name == "NES" && segaSaturnEntered == false)
			{
				AddConsoleToBackground(segaSaturnArea,NES);
				segaSaturnEntered = true;
				thisEnteredSegaSaturn = kinematicBody.Name;
			}
			
			if (kinematicBody.Name == "C64" && segaSaturnEntered == false)
			{
				AddConsoleToBackground(segaSaturnArea,C64);
				segaSaturnEntered = true;
				thisEnteredSegaSaturn = kinematicBody.Name;
			}
			if (kinematicBody.Name == "SegaSaturn")
			{
				segaSaturnCorrect = true;
				if (segaSaturnEntered == false)
				{
					AddConsoleToBackground(segaSaturnArea,SegaSaturn);
					segaSaturnEntered = true;
					thisEnteredSegaSaturn = kinematicBody.Name;
				}
			}
			if (kinematicBody.Name == "MegaDrive1" && segaSaturnEntered == false)
			{
				AddConsoleToBackground(segaSaturnArea,MegaDrive1);
				segaSaturnEntered = true;
				thisEnteredSegaSaturn = kinematicBody.Name;
			}
			if (kinematicBody.Name == "Magnavox"&& segaSaturnEntered == false )
			{
				AddConsoleToBackground(segaSaturnArea,Magnavox);
				segaSaturnEntered = true;
				thisEnteredSegaSaturn = kinematicBody.Name;
			}
			if (kinematicBody.Name == "Atari"&& segaSaturnEntered == false)
			{
				AddConsoleToBackground(segaSaturnArea,Atari);
				segaSaturnEntered = true;
				thisEnteredSegaSaturn = kinematicBody.Name;
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
				if (thisEnteredSegaSaturn == kinematicBody.Name)
				{
					segaSaturnEntered = false;
					segaSaturnArea.Visible = false;
				}
			}
			if (thisEnteredSegaSaturn == kinematicBody.Name)
			{
				segaSaturnEntered = false;
				segaSaturnArea.Visible = false;
			}
		}
	}
	
	private void _on_CheckMegaDrive1_body_entered(object body)
	{
		if (body is KinematicBody2D kinematicBody)
		{
			if (kinematicBody.Name == "XBOX" && megaDrive1Entered == false)
			{
				AddConsoleToBackground(megaDriveArea,XBOX);
				megaDrive1Entered = true;
				thisEnteredMegaDrive = kinematicBody.Name;
			}
			if (kinematicBody.Name == "GameBoy" && megaDrive1Entered == false)
			{
				AddConsoleToBackground(megaDriveArea,GameBoy);
				megaDrive1Entered = true;
				thisEnteredMegaDrive = kinematicBody.Name;
			}
			if (kinematicBody.Name == "NES" && megaDrive1Entered == false)
			{
				AddConsoleToBackground(megaDriveArea,NES);
				megaDrive1Entered = true;
				thisEnteredMegaDrive = kinematicBody.Name;
			}
			
			if (kinematicBody.Name == "C64" && megaDrive1Entered == false)
			{
				AddConsoleToBackground(megaDriveArea,C64);
				megaDrive1Entered = true;
				thisEnteredMegaDrive = kinematicBody.Name;
			}
			if (kinematicBody.Name == "SegaSaturn" && megaDrive1Entered == false)
			{
				AddConsoleToBackground(megaDriveArea,SegaSaturn);
				megaDrive1Entered = true;
				thisEnteredMegaDrive = kinematicBody.Name;
			}
			if (kinematicBody.Name == "MegaDrive1")
			{
				megadrive1Correct = true;
				if (megaDrive1Entered == false)
				{
					AddConsoleToBackground(megaDriveArea,MegaDrive1);
					megaDrive1Entered = true;
					thisEnteredMegaDrive = kinematicBody.Name;
				}
			}
			if (kinematicBody.Name == "Magnavox"&& megaDrive1Entered == false )
			{
				AddConsoleToBackground(megaDriveArea,Magnavox);
				megaDrive1Entered = true;
				thisEnteredMegaDrive = kinematicBody.Name;
			}
			if (kinematicBody.Name == "Atari"&& megaDrive1Entered == false)
			{
				AddConsoleToBackground(megaDriveArea,Atari);
				megaDrive1Entered = true;
				thisEnteredMegaDrive = kinematicBody.Name;
			}
		}
	}


	private void _on_CheckMegaDrive1_body_exited(object body)
	{
		if (body is KinematicBody2D kinematicBody)
		{
			if (kinematicBody.Name == "MegaDrive1")
			{
				megadrive1Correct = false;
				if (thisEnteredMegaDrive == kinematicBody.Name)
				{
					megaDrive1Entered = false;
					megaDriveArea.Visible = false;
				}
			}
			if (thisEnteredMegaDrive == kinematicBody.Name)
			{
				megaDrive1Entered = false;
				megaDriveArea.Visible = false;
			}
		}
	}

	private void _on_CheckMagnavox_body_entered(object body)
	{
		if (body is KinematicBody2D kinematicBody)
		{
			if (kinematicBody.Name == "XBOX" && magnavoxEntered == false)
			{
				AddConsoleToBackground(magnavoxArea,XBOX);
				magnavoxEntered = true;
				thisEnteredMagnavox = kinematicBody.Name;
			}
			if (kinematicBody.Name == "GameBoy" && magnavoxEntered == false)
			{
				AddConsoleToBackground(magnavoxArea,GameBoy);
				magnavoxEntered = true;
				thisEnteredMagnavox = kinematicBody.Name;
			}
			if (kinematicBody.Name == "NES" && magnavoxEntered == false)
			{
				AddConsoleToBackground(magnavoxArea,NES);
				magnavoxEntered = true;
				thisEnteredMagnavox = kinematicBody.Name;
			}
			
			if (kinematicBody.Name == "C64" && magnavoxEntered == false)
			{
				AddConsoleToBackground(magnavoxArea,C64);
				magnavoxEntered = true;
				thisEnteredMagnavox = kinematicBody.Name;
			}
			if (kinematicBody.Name == "SegaSaturn" && magnavoxEntered == false)
			{
				AddConsoleToBackground(magnavoxArea,SegaSaturn);
				magnavoxEntered = true;
				thisEnteredMagnavox = kinematicBody.Name;
			}
			if (kinematicBody.Name == "MegaDrive1" && magnavoxEntered == false)
			{
				AddConsoleToBackground(magnavoxArea,MegaDrive1);
				magnavoxEntered = true;
				thisEnteredMagnavox = kinematicBody.Name;
			}
			if (kinematicBody.Name == "Magnavox")
			{
				magnavoxCorrect = true;
				if (magnavoxEntered == false)
				{
					AddConsoleToBackground(magnavoxArea,Magnavox);
					magnavoxEntered = true;
					thisEnteredMagnavox = kinematicBody.Name;
				}
			}
			if (kinematicBody.Name == "Atari"&& magnavoxEntered == false)
			{
				AddConsoleToBackground(magnavoxArea,Atari);
				magnavoxEntered = true;
				thisEnteredMagnavox = kinematicBody.Name;
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
				if (thisEnteredMagnavox == kinematicBody.Name)
				{
					magnavoxEntered = false;
					magnavoxArea.Visible = false;
				}
			}
			if (thisEnteredMagnavox == kinematicBody.Name)
			{
				magnavoxEntered = false;
				magnavoxArea.Visible = false;
			}
		}
	}
	private void _on_CheckAtari_body_entered(object body)
	{
		if (body is KinematicBody2D kinematicBody)
		{
			if (kinematicBody.Name == "XBOX" && atariEntered == false)
			{
				AddConsoleToBackground(AtariArea,XBOX);
				atariEntered = true;
				thisEnteredAtari = kinematicBody.Name;
			}
			if (kinematicBody.Name == "GameBoy" && atariEntered == false)
			{
				AddConsoleToBackground(AtariArea,GameBoy);
				atariEntered = true;
				thisEnteredAtari = kinematicBody.Name;
			}
			if (kinematicBody.Name == "NES" && atariEntered == false)
			{
				AddConsoleToBackground(AtariArea,NES);
				atariEntered = true;
				thisEnteredAtari = kinematicBody.Name;
			}
			
			if (kinematicBody.Name == "C64" && atariEntered == false)
			{
				AddConsoleToBackground(AtariArea,C64);
				atariEntered = true;
				thisEnteredAtari = kinematicBody.Name;
			}
			if (kinematicBody.Name == "SegaSaturn" && atariEntered == false)
			{
				AddConsoleToBackground(AtariArea,SegaSaturn);
				atariEntered = true;
				thisEnteredAtari = kinematicBody.Name;
			}
			if (kinematicBody.Name == "MegaDrive1" && atariEntered == false)
			{
				AddConsoleToBackground(AtariArea,MegaDrive1);
				atariEntered = true;
				thisEnteredAtari = kinematicBody.Name;
			}
			if (kinematicBody.Name == "Magnavox"&& atariEntered == false )
			{
				AddConsoleToBackground(AtariArea,Magnavox);
				atariEntered = true;
				thisEnteredAtari = kinematicBody.Name;
			}
			
			if (kinematicBody.Name == "Atari")
			{
				atariCorrect = true;
				if (atariEntered == false)
				{
					AddConsoleToBackground(AtariArea,Atari);
					atariEntered = true;
					thisEnteredAtari = kinematicBody.Name;
				}
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
				if (thisEnteredAtari == kinematicBody.Name)
				{
					atariEntered = false;
					AtariArea.Visible = false;
				}
			}
			if (thisEnteredAtari == kinematicBody.Name)
			{
				atariEntered = false;
				AtariArea.Visible = false;
			}
		}
	}
	
	private void _on_CheckTennis_body_entered(object body)
	{ 
		if (body is KinematicBody2D kinematicBody)
		{
			if (kinematicBody.Name == "Tennis" && tennisEntered == false)
			{
				AddConsoleToBackground(tennisArea, Tennis);
				tennisEntered = true;
				thisEnteredTennis = kinematicBody.Name;
			}
			if (kinematicBody.Name == "MazeWars" && tennisEntered == false)
			{
				AddConsoleToBackground(tennisArea, MazeWars);
				tennisEntered = true;
				thisEnteredTennis = kinematicBody.Name;
			}
			if (kinematicBody.Name == "SpaceInvaders" && tennisEntered == false)
			{
				AddConsoleToBackground(tennisArea, SpaceInvaders);
				tennisEntered = true;
				thisEnteredTennis = kinematicBody.Name;
			}
			if (kinematicBody.Name == "DonkeyKong" && tennisEntered == false)
			{
				AddConsoleToBackground(tennisArea, DonkeyKong);
				tennisEntered = true;
				thisEnteredTennis = kinematicBody.Name;
			}
			if (kinematicBody.Name == "Pong" && tennisEntered == false)
			{
				AddConsoleToBackground(tennisArea, Pong);
				tennisEntered = true;
				thisEnteredTennis = kinematicBody.Name;
			}
			if (kinematicBody.Name == "PacMan" && tennisEntered == false)
			{
				AddConsoleToBackground(tennisArea, PacMan);
				tennisEntered = true;
				thisEnteredTennis = kinematicBody.Name;
			}
			if (kinematicBody.Name == "Bioshock" && tennisEntered == false)
			{
				AddConsoleToBackground(tennisArea, Bioshock);
				tennisEntered = true;
				thisEnteredTennis = kinematicBody.Name;
			}
			if (kinematicBody.Name == "Stray" && tennisEntered == false)
			{
				AddConsoleToBackground(tennisArea, Stray);
				tennisEntered = true;
				thisEnteredTennis = kinematicBody.Name;
			}
			if (kinematicBody.Name == "Starfield" && tennisEntered == false)
			{
				AddConsoleToBackground(tennisArea, Starfield);
				tennisEntered = true;
				thisEnteredTennis = kinematicBody.Name;
			}
			if (kinematicBody.Name == "Cyberpunk" && tennisEntered == false)
			{
				AddConsoleToBackground(tennisArea, Cyberpunk);
				tennisEntered = true;
				thisEnteredTennis = kinematicBody.Name;
			}
			if (kinematicBody.Name == "Detriot" && tennisEntered == false)
			{
				AddConsoleToBackground(tennisArea, Detriot);
				tennisEntered = true;
				thisEnteredTennis = kinematicBody.Name;
			}
			if (kinematicBody.Name == "Horizon" && tennisEntered == false)
			{
				AddConsoleToBackground(tennisArea, Horizon);
				tennisEntered = true;
				thisEnteredTennis = kinematicBody.Name;
			}

			if (kinematicBody.Name == "Tennis")
			{
				tennisCorrect = true;
				if (tennisEntered == false)
				{
					AddConsoleToBackground(tennisArea, Tennis);
					tennisEntered = true;
					thisEnteredTennis = kinematicBody.Name;
				}
			}
		}

	}


	private void _on_CheckTennis_body_exited(object body)
	{
		if (body is KinematicBody2D kinematicBody)
		{
			if (kinematicBody.Name == "Tennis")
			{
				tennisCorrect = false;
				if (thisEnteredTennis == kinematicBody.Name)
				{
					tennisEntered = false;
					tennisArea.Visible = false;
				}
			}
			else if (thisEnteredTennis == kinematicBody.Name)
			{
				tennisEntered = false;
				tennisArea.Visible = false;
			}
		}

	}
	private void _on_CheckMazeWars_body_entered(object body)
	{
		if (body is KinematicBody2D kinematicBody)
		{
			if (kinematicBody.Name == "Tennis" && mazeWarsEntered == false)
			{
				AddConsoleToBackground(mazeWarsArea, Tennis);
				mazeWarsEntered = true;
				thisEnteredMazeWars = kinematicBody.Name;
			}
			if (kinematicBody.Name == "MazeWars" && mazeWarsEntered == false)
			{
				AddConsoleToBackground(mazeWarsArea, MazeWars);
				mazeWarsEntered = true;
				thisEnteredMazeWars = kinematicBody.Name;
			}
			if (kinematicBody.Name == "SpaceInvaders" && mazeWarsEntered == false)
			{
				AddConsoleToBackground(mazeWarsArea, SpaceInvaders);
				mazeWarsEntered = true;
				thisEnteredMazeWars = kinematicBody.Name;
			}
			if (kinematicBody.Name == "DonkeyKong" && mazeWarsEntered == false)
			{
				AddConsoleToBackground(mazeWarsArea, DonkeyKong);
				mazeWarsEntered = true;
				thisEnteredMazeWars = kinematicBody.Name;
			}
			if (kinematicBody.Name == "Pong" && mazeWarsEntered == false)
			{
				AddConsoleToBackground(mazeWarsArea, Pong);
				mazeWarsEntered = true;
				thisEnteredMazeWars = kinematicBody.Name;
			}
			if (kinematicBody.Name == "PacMan" && mazeWarsEntered == false)
			{
				AddConsoleToBackground(mazeWarsArea, PacMan);
				mazeWarsEntered = true;
				thisEnteredMazeWars = kinematicBody.Name;
			}
			if (kinematicBody.Name == "Bioshock" && mazeWarsEntered == false)
			{
				AddConsoleToBackground(mazeWarsArea, Bioshock);
				mazeWarsEntered = true;
				thisEnteredMazeWars = kinematicBody.Name;
			}
			if (kinematicBody.Name == "Stray" && mazeWarsEntered == false)
			{
				AddConsoleToBackground(mazeWarsArea, Stray);
				mazeWarsEntered = true;
				thisEnteredMazeWars = kinematicBody.Name;
			}
			if (kinematicBody.Name == "Starfield" && mazeWarsEntered == false)
			{
				AddConsoleToBackground(mazeWarsArea, Starfield);
				mazeWarsEntered = true;
				thisEnteredMazeWars = kinematicBody.Name;
			}
			if (kinematicBody.Name == "Cyberpunk" && mazeWarsEntered == false)
			{
				AddConsoleToBackground(mazeWarsArea, Cyberpunk);
				mazeWarsEntered = true;
				thisEnteredMazeWars = kinematicBody.Name;
			}
			if (kinematicBody.Name == "Detriot" && mazeWarsEntered == false)
			{
				AddConsoleToBackground(mazeWarsArea, Detriot);
				mazeWarsEntered = true;
				thisEnteredMazeWars = kinematicBody.Name;
			}
			if (kinematicBody.Name == "Horizon" && mazeWarsEntered == false)
			{
				AddConsoleToBackground(mazeWarsArea, Horizon);
				mazeWarsEntered = true;
				thisEnteredMazeWars = kinematicBody.Name;
			}

			if (kinematicBody.Name == "MazeWars")
			{
				mazeWarsCorrect = true;
				if (mazeWarsEntered == false)
				{
					AddConsoleToBackground(mazeWarsArea, MazeWars);
					mazeWarsEntered = true;
					thisEnteredMazeWars = kinematicBody.Name;
				}
			}
		}
	}


	private void _on_CheckMazeWars_body_exited(object body)
	{
		if (body is KinematicBody2D kinematicBody)
		{
			if (kinematicBody.Name == "MazeWars")
			{
				mazeWarsCorrect = false;
				if (thisEnteredMazeWars == kinematicBody.Name)
				{
					mazeWarsEntered = false;
					mazeWarsArea.Visible = false;
				}
			}
			if (thisEnteredMazeWars == kinematicBody.Name)
			{
				mazeWarsEntered = false;
				mazeWarsArea.Visible = false;
			}
		}
	}
	private void _on_CheckSpaceInvaders_body_entered(object body)
	{
		if (body is KinematicBody2D kinematicBody)
		{
			if (kinematicBody.Name == "Tennis" && spaceInvadersEntered == false)
			{
				AddConsoleToBackground(spaceInvadersArea, Tennis);
				spaceInvadersEntered = true;
				thisEnteredSpaceInvaders = kinematicBody.Name;
			}
			if (kinematicBody.Name == "MazeWars" && spaceInvadersEntered == false)
			{
				AddConsoleToBackground(spaceInvadersArea, MazeWars);
				spaceInvadersEntered = true;
				thisEnteredSpaceInvaders = kinematicBody.Name;
			}
			if (kinematicBody.Name == "SpaceInvaders" && spaceInvadersEntered == false)
			{
				AddConsoleToBackground(spaceInvadersArea, SpaceInvaders);
				spaceInvadersEntered = true;
				thisEnteredSpaceInvaders = kinematicBody.Name;
			}
			if (kinematicBody.Name == "DonkeyKong" && spaceInvadersEntered == false)
			{
				AddConsoleToBackground(spaceInvadersArea, DonkeyKong);
				spaceInvadersEntered = true;
				thisEnteredSpaceInvaders = kinematicBody.Name;
			}
			if (kinematicBody.Name == "Pong" && spaceInvadersEntered == false)
			{
				AddConsoleToBackground(spaceInvadersArea, Pong);
				spaceInvadersEntered = true;
				thisEnteredSpaceInvaders = kinematicBody.Name;
			}
			if (kinematicBody.Name == "PacMan" && spaceInvadersEntered == false)
			{
				AddConsoleToBackground(spaceInvadersArea, PacMan);
				spaceInvadersEntered = true;
				thisEnteredSpaceInvaders = kinematicBody.Name;
			}
			if (kinematicBody.Name == "Bioshock" && spaceInvadersEntered == false)
			{
				AddConsoleToBackground(spaceInvadersArea, Bioshock);
				spaceInvadersEntered = true;
				thisEnteredSpaceInvaders = kinematicBody.Name;
			}
			if (kinematicBody.Name == "Stray" && spaceInvadersEntered == false)
			{
				AddConsoleToBackground(spaceInvadersArea, Stray);
				spaceInvadersEntered = true;
				thisEnteredSpaceInvaders = kinematicBody.Name;
			}
			if (kinematicBody.Name == "Starfield" && spaceInvadersEntered == false)
			{
				AddConsoleToBackground(spaceInvadersArea, Starfield);
				spaceInvadersEntered = true;
				thisEnteredSpaceInvaders = kinematicBody.Name;
			}
			if (kinematicBody.Name == "Cyberpunk" && spaceInvadersEntered == false)
			{
				AddConsoleToBackground(spaceInvadersArea, Cyberpunk);
				spaceInvadersEntered = true;
				thisEnteredSpaceInvaders = kinematicBody.Name;
			}
			if (kinematicBody.Name == "Detriot" && spaceInvadersEntered == false)
			{
				AddConsoleToBackground(spaceInvadersArea, Detriot);
				spaceInvadersEntered = true;
				thisEnteredSpaceInvaders = kinematicBody.Name;
			}
			if (kinematicBody.Name == "Horizon" && spaceInvadersEntered == false)
			{
				AddConsoleToBackground(spaceInvadersArea, Horizon);
				spaceInvadersEntered = true;
				thisEnteredSpaceInvaders = kinematicBody.Name;
			}

			if (kinematicBody.Name == "SpaceInvaders")
			{
				spaceInvadersCorrect = true;
				if (spaceInvadersEntered == false)
				{
					AddConsoleToBackground(spaceInvadersArea, SpaceInvaders);
					spaceInvadersEntered = true;
					thisEnteredSpaceInvaders = kinematicBody.Name;
				}
			}
		}
	}
	private void _on_CheckSpaceInvaders_body_exited(object body)
	{
		if (body is KinematicBody2D kinematicBody)
		{
			if (kinematicBody.Name == "SpaceInvaders")
			{
				spaceInvadersCorrect = false;
				if (thisEnteredSpaceInvaders == kinematicBody.Name)
				{
					spaceInvadersEntered = false;
					spaceInvadersArea.Visible = false;
				}
			}
			else if (thisEnteredSpaceInvaders == kinematicBody.Name)
			{
				spaceInvadersEntered = false;
				spaceInvadersArea.Visible = false;
			}
		}

	}
	
	private void _on_CheckDonkeyKong_body_entered(object body)
	{
		if (body is KinematicBody2D kinematicBody)
		{
			if (kinematicBody.Name == "Tennis" && donkeyKongEntered == false)
			{
				AddConsoleToBackground(donkeyKongArea, Tennis);
				donkeyKongEntered = true;
				thisEnteredDonkeyKong = kinematicBody.Name;
			}
			if (kinematicBody.Name == "MazeWars" && donkeyKongEntered == false)
			{
				AddConsoleToBackground(donkeyKongArea, MazeWars);
				donkeyKongEntered = true;
				thisEnteredDonkeyKong = kinematicBody.Name;
			}
			if (kinematicBody.Name == "SpaceInvaders" && donkeyKongEntered == false)
			{
				AddConsoleToBackground(donkeyKongArea, SpaceInvaders);
				donkeyKongEntered = true;
				thisEnteredDonkeyKong = kinematicBody.Name;
			}
			if (kinematicBody.Name == "DonkeyKong" && donkeyKongEntered == false)
			{
				AddConsoleToBackground(donkeyKongArea, DonkeyKong);
				donkeyKongEntered = true;
				thisEnteredDonkeyKong = kinematicBody.Name;
			}
			if (kinematicBody.Name == "Pong" && donkeyKongEntered == false)
			{
				AddConsoleToBackground(donkeyKongArea, Pong);
				donkeyKongEntered = true;
				thisEnteredDonkeyKong = kinematicBody.Name;
			}
			if (kinematicBody.Name == "PacMan" && donkeyKongEntered == false)
			{
				AddConsoleToBackground(donkeyKongArea, PacMan);
				donkeyKongEntered = true;
				thisEnteredDonkeyKong = kinematicBody.Name;
			}
			if (kinematicBody.Name == "Bioshock" && donkeyKongEntered == false)
			{
				AddConsoleToBackground(donkeyKongArea, Bioshock);
				donkeyKongEntered = true;
				thisEnteredDonkeyKong = kinematicBody.Name;
			}
			if (kinematicBody.Name == "Stray" && donkeyKongEntered == false)
			{
				AddConsoleToBackground(donkeyKongArea, Stray);
				donkeyKongEntered = true;
				thisEnteredDonkeyKong = kinematicBody.Name;
			}
			if (kinematicBody.Name == "Starfield" && donkeyKongEntered == false)
			{
				AddConsoleToBackground(donkeyKongArea, Starfield);
				donkeyKongEntered = true;
				thisEnteredDonkeyKong = kinematicBody.Name;
			}
			if (kinematicBody.Name == "Cyberpunk" && donkeyKongEntered == false)
			{
				AddConsoleToBackground(donkeyKongArea, Cyberpunk);
				donkeyKongEntered = true;
				thisEnteredDonkeyKong = kinematicBody.Name;
			}
			if (kinematicBody.Name == "Detriot" && donkeyKongEntered == false)
			{
				AddConsoleToBackground(donkeyKongArea, Detriot);
				donkeyKongEntered = true;
				thisEnteredDonkeyKong = kinematicBody.Name;
			}
			if (kinematicBody.Name == "Horizon" && donkeyKongEntered == false)
			{
				AddConsoleToBackground(donkeyKongArea, Horizon);
				donkeyKongEntered = true;
				thisEnteredDonkeyKong = kinematicBody.Name;
			}

			if (kinematicBody.Name == "DonkeyKong")
			{
				donkeyKongCorrect = true;
				if (donkeyKongEntered == false)
				{
					AddConsoleToBackground(donkeyKongArea, DonkeyKong);
					donkeyKongEntered = true;
					thisEnteredDonkeyKong = kinematicBody.Name;
				}
			}
		}
	}
	private void _on_CheckPong_body_entered(object body)
	{
		if (body is KinematicBody2D kinematicBody)
		{
			if (kinematicBody.Name == "Tennis" && pongEntered == false)
			{
				AddConsoleToBackground(pongArea, Tennis);
				pongEntered = true;
				thisEnteredPong = kinematicBody.Name;
			}
			if (kinematicBody.Name == "MazeWars" && pongEntered == false)
			{
				AddConsoleToBackground(pongArea, MazeWars);
				pongEntered = true;
				thisEnteredPong = kinematicBody.Name;
			}
			if (kinematicBody.Name == "SpaceInvaders" && pongEntered == false)
			{
				AddConsoleToBackground(pongArea, SpaceInvaders);
				pongEntered = true;
				thisEnteredPong = kinematicBody.Name;
			}
			if (kinematicBody.Name == "DonkeyKong" && pongEntered == false)
			{
				AddConsoleToBackground(pongArea, DonkeyKong);
				pongEntered = true;
				thisEnteredPong = kinematicBody.Name;
			}
			if (kinematicBody.Name == "Pong" && pongEntered == false)
			{
				AddConsoleToBackground(pongArea, Pong);
				pongEntered = true;
				thisEnteredPong = kinematicBody.Name;
			}
			if (kinematicBody.Name == "PacMan" && pongEntered == false)
			{
				AddConsoleToBackground(pongArea, PacMan);
				pongEntered = true;
				thisEnteredPong = kinematicBody.Name;
			}
			if (kinematicBody.Name == "Bioshock" && pongEntered == false)
			{
				AddConsoleToBackground(pongArea, Bioshock);
				pongEntered = true;
				thisEnteredPong = kinematicBody.Name;
			}
			if (kinematicBody.Name == "Stray" && pongEntered == false)
			{
				AddConsoleToBackground(pongArea, Stray);
				pongEntered = true;
				thisEnteredPong = kinematicBody.Name;
			}
			if (kinematicBody.Name == "Starfield" && pongEntered == false)
			{
				AddConsoleToBackground(pongArea, Starfield);
				pongEntered = true;
				thisEnteredPong = kinematicBody.Name;
			}
			if (kinematicBody.Name == "Cyberpunk" && pongEntered == false)
			{
				AddConsoleToBackground(pongArea, Cyberpunk);
				pongEntered = true;
				thisEnteredPong = kinematicBody.Name;
			}
			if (kinematicBody.Name == "Detriot" && pongEntered == false)
			{
				AddConsoleToBackground(pongArea, Detriot);
				pongEntered = true;
				thisEnteredPong = kinematicBody.Name;
			}
			if (kinematicBody.Name == "Horizon" && pongEntered == false)
			{
				AddConsoleToBackground(pongArea, Horizon);
				pongEntered = true;
				thisEnteredPong = kinematicBody.Name;
			}

			if (kinematicBody.Name == "Pong")
			{
				pongCorrect = true;
				if (pongEntered == false)
				{
					AddConsoleToBackground(pongArea, Pong);
					pongEntered = true;
					thisEnteredPong = kinematicBody.Name;
				}
			}
		}
	}


	private void _on_CheckPacMan_body_entered(object body)
	{
		if (body is KinematicBody2D kinematicBody)
		{
			if (kinematicBody.Name == "Tennis" && pacmanEntered == false)
			{
				AddConsoleToBackground(pacManArea, Tennis);
				pacmanEntered = true;
				thisEnteredPacMan = kinematicBody.Name;
			}
			if (kinematicBody.Name == "MazeWars" && pacmanEntered == false)
			{
				AddConsoleToBackground(pacManArea, MazeWars);
				pacmanEntered = true;
				thisEnteredPacMan = kinematicBody.Name;
			}
			if (kinematicBody.Name == "SpaceInvaders" && pacmanEntered == false)
			{
				AddConsoleToBackground(pacManArea, SpaceInvaders);
				pacmanEntered = true;
				thisEnteredPacMan = kinematicBody.Name;
			}
			if (kinematicBody.Name == "DonkeyKong" && pacmanEntered == false)
			{
				AddConsoleToBackground(pacManArea, DonkeyKong);
				pacmanEntered = true;
				thisEnteredPacMan = kinematicBody.Name;
			}
			if (kinematicBody.Name == "Pong" && pacmanEntered == false)
			{
				AddConsoleToBackground(pacManArea, Pong);
				pacmanEntered = true;
				thisEnteredPacMan = kinematicBody.Name;
			}
			if (kinematicBody.Name == "PacMan" && pacmanEntered == false)
			{
				AddConsoleToBackground(pacManArea, PacMan);
				pacmanEntered = true;
				thisEnteredPacMan = kinematicBody.Name;
			}
			if (kinematicBody.Name == "Bioshock" && pacmanEntered == false)
			{
				AddConsoleToBackground(pacManArea, Bioshock);
				pacmanEntered = true;
				thisEnteredPacMan = kinematicBody.Name;
			}
			if (kinematicBody.Name == "Stray" && pacmanEntered == false)
			{
				AddConsoleToBackground(pacManArea, Stray);
				pacmanEntered = true;
				thisEnteredPacMan = kinematicBody.Name;
			}
			if (kinematicBody.Name == "Starfield" && pacmanEntered == false)
			{
				AddConsoleToBackground(pacManArea, Starfield);
				pacmanEntered = true;
				thisEnteredPacMan = kinematicBody.Name;
			}
			if (kinematicBody.Name == "Cyberpunk" && pacmanEntered == false)
			{
				AddConsoleToBackground(pacManArea, Cyberpunk);
				pacmanEntered = true;
				thisEnteredPacMan = kinematicBody.Name;
			}
			if (kinematicBody.Name == "Detriot" && pacmanEntered == false)
			{
				AddConsoleToBackground(pacManArea, Detriot);
				pacmanEntered = true;
				thisEnteredPacMan = kinematicBody.Name;
			}
			if (kinematicBody.Name == "Horizon" && pacmanEntered == false)
			{
				AddConsoleToBackground(pacManArea, Horizon);
				pacmanEntered = true;
				thisEnteredPacMan = kinematicBody.Name;
			}

			if (kinematicBody.Name == "PacMan")
			{
				pacmanCorrect = true;
				if (pacmanEntered == false)
				{
					AddConsoleToBackground(pacManArea, PacMan);
					pacmanEntered = true;
					thisEnteredPacMan = kinematicBody.Name;
				}
			}
		}
	}


	private void _on_CheckBioshock_body_entered(object body)
	{
		if (body is KinematicBody2D kinematicBody)
		{
			if (kinematicBody.Name == "Tennis" && bioshockEntered == false)
			{
				AddConsoleToBackground(bioshockArea, Tennis);
				bioshockEntered = true;
				thisEnteredBioshock = kinematicBody.Name;
			}
			if (kinematicBody.Name == "MazeWars" && bioshockEntered == false)
			{
				AddConsoleToBackground(bioshockArea, MazeWars);
				bioshockEntered = true;
				thisEnteredBioshock = kinematicBody.Name;
			}
			if (kinematicBody.Name == "SpaceInvaders" && bioshockEntered == false)
			{
				AddConsoleToBackground(bioshockArea, SpaceInvaders);
				bioshockEntered = true;
				thisEnteredBioshock = kinematicBody.Name;
			}
			if (kinematicBody.Name == "DonkeyKong" && bioshockEntered == false)
			{
				AddConsoleToBackground(bioshockArea, DonkeyKong);
				bioshockEntered = true;
				thisEnteredBioshock = kinematicBody.Name;
			}
			if (kinematicBody.Name == "Pong" && bioshockEntered == false)
			{
				AddConsoleToBackground(bioshockArea, Pong);
				bioshockEntered = true;
				thisEnteredBioshock = kinematicBody.Name;
			}
			if (kinematicBody.Name == "PacMan" && bioshockEntered == false)
			{
				AddConsoleToBackground(bioshockArea, PacMan);
				bioshockEntered = true;
				thisEnteredBioshock = kinematicBody.Name;
			}
			if (kinematicBody.Name == "Bioshock" && bioshockEntered == false)
			{
				AddConsoleToBackground(bioshockArea, Bioshock);
				bioshockEntered = true;
				thisEnteredBioshock = kinematicBody.Name;
			}
			if (kinematicBody.Name == "Stray" && bioshockEntered == false)
			{
				AddConsoleToBackground(bioshockArea, Stray);
				bioshockEntered = true;
				thisEnteredBioshock = kinematicBody.Name;
			}
			if (kinematicBody.Name == "Starfield" && bioshockEntered == false)
			{
				AddConsoleToBackground(bioshockArea, Starfield);
				bioshockEntered = true;
				thisEnteredBioshock = kinematicBody.Name;
			}
			if (kinematicBody.Name == "Cyberpunk" && bioshockEntered == false)
			{
				AddConsoleToBackground(bioshockArea, Cyberpunk);
				bioshockEntered = true;
				thisEnteredBioshock = kinematicBody.Name;
			}
			if (kinematicBody.Name == "Detriot" && bioshockEntered == false)
			{
				AddConsoleToBackground(bioshockArea, Detriot);
				bioshockEntered = true;
				thisEnteredBioshock = kinematicBody.Name;
			}
			if (kinematicBody.Name == "Horizon" && bioshockEntered == false)
			{
				AddConsoleToBackground(bioshockArea, Horizon);
				bioshockEntered = true;
				thisEnteredBioshock = kinematicBody.Name;
			}

			if (kinematicBody.Name == "Bioshock")
			{
				bioshockCorrect = true;
				if (bioshockEntered == false)
				{
					AddConsoleToBackground(bioshockArea, Bioshock);
					bioshockEntered = true;
					thisEnteredBioshock = kinematicBody.Name;
				}
			}
		}
	}
	private void _on_CheckStray_body_entered(object body)
	{
		if (body is KinematicBody2D kinematicBody)
		{
			if (kinematicBody.Name == "Tennis" && strayEntered == false)
			{
				AddConsoleToBackground(strayArea, Tennis);
				strayEntered = true;
				thisEnteredStray = kinematicBody.Name;
			}
			if (kinematicBody.Name == "MazeWars" && strayEntered == false)
			{
				AddConsoleToBackground(strayArea, MazeWars);
				strayEntered = true;
				thisEnteredStray = kinematicBody.Name;
			}
			if (kinematicBody.Name == "SpaceInvaders" && strayEntered == false)
			{
				AddConsoleToBackground(strayArea, SpaceInvaders);
				strayEntered = true;
				thisEnteredStray = kinematicBody.Name;
			}
			if (kinematicBody.Name == "DonkeyKong" && strayEntered == false)
			{
				AddConsoleToBackground(strayArea, DonkeyKong);
				strayEntered = true;
				thisEnteredStray = kinematicBody.Name;
			}
			if (kinematicBody.Name == "Pong" && strayEntered == false)
			{
				AddConsoleToBackground(strayArea, Pong);
				strayEntered = true;
				thisEnteredStray = kinematicBody.Name;
			}
			if (kinematicBody.Name == "PacMan" && strayEntered == false)
			{
				AddConsoleToBackground(strayArea, PacMan);
				strayEntered = true;
				thisEnteredStray = kinematicBody.Name;
			}
			if (kinematicBody.Name == "Bioshock" && strayEntered == false)
			{
				AddConsoleToBackground(strayArea, Bioshock);
				strayEntered = true;
				thisEnteredStray = kinematicBody.Name;
			}
			if (kinematicBody.Name == "Stray" && strayEntered == false)
			{
				AddConsoleToBackground(strayArea, Stray);
				strayEntered = true;
				thisEnteredStray = kinematicBody.Name;
			}
			if (kinematicBody.Name == "Starfield" && strayEntered == false)
			{
				AddConsoleToBackground(strayArea, Starfield);
				strayEntered = true;
				thisEnteredStray = kinematicBody.Name;
			}
			if (kinematicBody.Name == "Cyberpunk" && strayEntered == false)
			{
				AddConsoleToBackground(strayArea, Cyberpunk);
				strayEntered = true;
				thisEnteredStray = kinematicBody.Name;
			}
			if (kinematicBody.Name == "Detriot" && strayEntered == false)
			{
				AddConsoleToBackground(strayArea, Detriot);
				strayEntered = true;
				thisEnteredStray = kinematicBody.Name;
			}
			if (kinematicBody.Name == "Horizon" && strayEntered == false)
			{
				AddConsoleToBackground(strayArea, Horizon);
				strayEntered = true;
				thisEnteredStray = kinematicBody.Name;
			}

			if (kinematicBody.Name == "Stray")
			{
				strayCorrect = true;
				if (strayEntered == false)
				{
					AddConsoleToBackground(strayArea, Stray);
					strayEntered = true;
					thisEnteredStray = kinematicBody.Name;
				}
			}
		}
	}


	private void _on_CheckStarfield_body_entered(object body)
	{
		if (body is KinematicBody2D kinematicBody)
		{
			if (kinematicBody.Name == "Tennis" && starfieldEntered == false)
			{
				AddConsoleToBackground(starfieldArea, Tennis);
				starfieldEntered = true;
				thisEnteredStarfield = kinematicBody.Name;
			}

			if (kinematicBody.Name == "MazeWars" && starfieldEntered == false)
			{
				AddConsoleToBackground(starfieldArea, MazeWars);
				starfieldEntered = true;
				thisEnteredStarfield = kinematicBody.Name;
			}

			if (kinematicBody.Name == "SpaceInvaders" && starfieldEntered == false)
			{
				AddConsoleToBackground(starfieldArea, SpaceInvaders);
				starfieldEntered = true;
				thisEnteredStarfield = kinematicBody.Name;
			}

			if (kinematicBody.Name == "DonkeyKong" && starfieldEntered == false)
			{
				AddConsoleToBackground(starfieldArea, DonkeyKong);
				starfieldEntered = true;
				thisEnteredStarfield = kinematicBody.Name;
			}

			if (kinematicBody.Name == "Pong" && starfieldEntered == false)
			{
				AddConsoleToBackground(starfieldArea, Pong);
				starfieldEntered = true;
				thisEnteredStarfield = kinematicBody.Name;
			}

			if (kinematicBody.Name == "PacMan" && starfieldEntered == false)
			{
				AddConsoleToBackground(starfieldArea, PacMan);
				starfieldEntered = true;
				thisEnteredStarfield = kinematicBody.Name;
			}

			if (kinematicBody.Name == "Bioshock" && starfieldEntered == false)
			{
				AddConsoleToBackground(starfieldArea, Bioshock);
				starfieldEntered = true;
				thisEnteredStarfield = kinematicBody.Name;
			}

			if (kinematicBody.Name == "Stray" && starfieldEntered == false)
			{
				AddConsoleToBackground(starfieldArea, Stray);
				starfieldEntered = true;
				thisEnteredStarfield = kinematicBody.Name;
			}

			if (kinematicBody.Name == "Starfield" && starfieldEntered == false)
			{
				AddConsoleToBackground(starfieldArea, Starfield);
				starfieldEntered = true;
				thisEnteredStarfield = kinematicBody.Name;
			}

			if (kinematicBody.Name == "Cyberpunk" && starfieldEntered == false)
			{
				AddConsoleToBackground(starfieldArea, Cyberpunk);
				starfieldEntered = true;
				thisEnteredStarfield = kinematicBody.Name;
			}

			if (kinematicBody.Name == "Detriot" && starfieldEntered == false)
			{
				AddConsoleToBackground(starfieldArea, Detriot);
				starfieldEntered = true;
				thisEnteredStarfield = kinematicBody.Name;
			}

			if (kinematicBody.Name == "Horizon" && starfieldEntered == false)
			{
				AddConsoleToBackground(starfieldArea, Horizon);
				starfieldEntered = true;
				thisEnteredStarfield = kinematicBody.Name;
			}

			if (kinematicBody.Name == "Starfield")
			{
				starfieldCorrect = true;
				if (starfieldEntered == false)
				{
					AddConsoleToBackground(starfieldArea, Starfield);
					starfieldEntered = true;
					thisEnteredStarfield = kinematicBody.Name;
				}
			}
		}
	}

	private void _on_CheckCyberpunk_body_entered(object body)
	{
		if (body is KinematicBody2D kinematicBody)
		{
			if (kinematicBody.Name == "Tennis" && cyberpunkEntered == false)
			{
				AddConsoleToBackground(cyberpunkArea, Tennis);
				cyberpunkEntered = true;
				thisEnteredCyberpunk = kinematicBody.Name;
			}
			if (kinematicBody.Name == "MazeWars" && cyberpunkEntered == false)
			{
				AddConsoleToBackground(cyberpunkArea, MazeWars);
				cyberpunkEntered = true;
				thisEnteredCyberpunk = kinematicBody.Name;
			}
			if (kinematicBody.Name == "SpaceInvaders" && cyberpunkEntered == false)
			{
				AddConsoleToBackground(cyberpunkArea, SpaceInvaders);
				cyberpunkEntered = true;
				thisEnteredCyberpunk = kinematicBody.Name;
			}
			if (kinematicBody.Name == "DonkeyKong" && cyberpunkEntered == false)
			{
				AddConsoleToBackground(cyberpunkArea, DonkeyKong);
				cyberpunkEntered = true;
				thisEnteredCyberpunk = kinematicBody.Name;
			}
			if (kinematicBody.Name == "Pong" && cyberpunkEntered == false)
			{
				AddConsoleToBackground(cyberpunkArea, Pong);
				cyberpunkEntered = true;
				thisEnteredCyberpunk = kinematicBody.Name;
			}
			if (kinematicBody.Name == "PacMan" && cyberpunkEntered == false)
			{
				AddConsoleToBackground(cyberpunkArea, PacMan);
				cyberpunkEntered = true;
				thisEnteredCyberpunk = kinematicBody.Name;
			}
			if (kinematicBody.Name == "Bioshock" && cyberpunkEntered == false)
			{
				AddConsoleToBackground(cyberpunkArea, Bioshock);
				cyberpunkEntered = true;
				thisEnteredCyberpunk = kinematicBody.Name;
			}
			if (kinematicBody.Name == "Stray" && cyberpunkEntered == false)
			{
				AddConsoleToBackground(cyberpunkArea, Stray);
				cyberpunkEntered = true;
				thisEnteredCyberpunk = kinematicBody.Name;
			}
			if (kinematicBody.Name == "Starfield" && cyberpunkEntered == false)
			{
				AddConsoleToBackground(cyberpunkArea, Starfield);
				cyberpunkEntered = true;
				thisEnteredCyberpunk = kinematicBody.Name;
			}
			if (kinematicBody.Name == "Cyberpunk" && cyberpunkEntered == false)
			{
				AddConsoleToBackground(cyberpunkArea, Cyberpunk);
				cyberpunkEntered = true;
				thisEnteredCyberpunk = kinematicBody.Name;
			}
			if (kinematicBody.Name == "Detriot" && cyberpunkEntered == false)
			{
				AddConsoleToBackground(cyberpunkArea, Detriot);
				cyberpunkEntered = true;
				thisEnteredCyberpunk = kinematicBody.Name;
			}
			if (kinematicBody.Name == "Horizon" && cyberpunkEntered == false)
			{
				AddConsoleToBackground(cyberpunkArea, Horizon);
				cyberpunkEntered = true;
				thisEnteredCyberpunk = kinematicBody.Name;
			}

			if (kinematicBody.Name == "Cyberpunk")
			{
				cyberpunkCorrect = true;
				if (cyberpunkEntered == false)
				{
					AddConsoleToBackground(cyberpunkArea, Cyberpunk);
					cyberpunkEntered = true;
					thisEnteredCyberpunk = kinematicBody.Name;
				}
			}
		}
	}


	private void _on_CheckHorizon_body_entered(object body)
	{ 
		if (body is KinematicBody2D kinematicBody)
		{
			if (kinematicBody.Name == "Tennis" && horizonEntered == false)
			{
				AddConsoleToBackground(horizonArea, Tennis);
				horizonEntered = true;
				thisEnteredHorizon = kinematicBody.Name;
			}
			if (kinematicBody.Name == "MazeWars" && horizonEntered == false)
			{
				AddConsoleToBackground(horizonArea, MazeWars);
				horizonEntered = true;
				thisEnteredHorizon = kinematicBody.Name;
			}
			if (kinematicBody.Name == "SpaceInvaders" && horizonEntered == false)
			{
				AddConsoleToBackground(horizonArea, SpaceInvaders);
				horizonEntered = true;
				thisEnteredHorizon = kinematicBody.Name;
			}
			if (kinematicBody.Name == "DonkeyKong" && horizonEntered == false)
			{
				AddConsoleToBackground(horizonArea, DonkeyKong);
				horizonEntered = true;
				thisEnteredHorizon = kinematicBody.Name;
			}
			if (kinematicBody.Name == "Pong" && horizonEntered == false)
			{
				AddConsoleToBackground(horizonArea, Pong);
				horizonEntered = true;
				thisEnteredHorizon = kinematicBody.Name;
			}
			if (kinematicBody.Name == "PacMan" && horizonEntered == false)
			{
				AddConsoleToBackground(horizonArea, PacMan);
				horizonEntered = true;
				thisEnteredHorizon = kinematicBody.Name;
			}
			if (kinematicBody.Name == "Bioshock" && horizonEntered == false)
			{
				AddConsoleToBackground(horizonArea, Bioshock);
				horizonEntered = true;
				thisEnteredHorizon = kinematicBody.Name;
			}
			if (kinematicBody.Name == "Stray" && horizonEntered == false)
			{
				AddConsoleToBackground(horizonArea, Stray);
				horizonEntered = true;
				thisEnteredHorizon = kinematicBody.Name;
			}
			if (kinematicBody.Name == "Starfield" && horizonEntered == false)
			{
				AddConsoleToBackground(horizonArea, Starfield);
				horizonEntered = true;
				thisEnteredHorizon = kinematicBody.Name;
			}
			if (kinematicBody.Name == "Cyberpunk" && horizonEntered == false)
			{
				AddConsoleToBackground(horizonArea, Cyberpunk);
				horizonEntered = true;
				thisEnteredHorizon = kinematicBody.Name;
			}
			if (kinematicBody.Name == "Detriot" && horizonEntered == false)
			{
				AddConsoleToBackground(horizonArea, Detriot);
				horizonEntered = true;
				thisEnteredHorizon = kinematicBody.Name;
			}
			if (kinematicBody.Name == "Horizon" && horizonEntered == false)
			{
				AddConsoleToBackground(horizonArea, Horizon);
				horizonEntered = true;
				thisEnteredHorizon = kinematicBody.Name;
			}

			if (kinematicBody.Name == "Horizon")
			{
				horizonCorrect = true;
				if (horizonEntered == false)
				{
					AddConsoleToBackground(horizonArea, Horizon);
					horizonEntered = true;
					thisEnteredHorizon = kinematicBody.Name;
				}
			}
		}
	}


	private void _on_CheckDetriot_body_entered(object body)
	{
		if (body is KinematicBody2D kinematicBody)
		{
			if (kinematicBody.Name == "Tennis" && detriotEntered == false)
			{
				AddConsoleToBackground(detriotArea, Tennis);
				detriotEntered = true;
				thisEnteredDetriot = kinematicBody.Name;
			}
			if (kinematicBody.Name == "MazeWars" && detriotEntered == false)
			{
				AddConsoleToBackground(detriotArea, MazeWars);
				detriotEntered = true;
				thisEnteredDetriot = kinematicBody.Name;
			}
			if (kinematicBody.Name == "SpaceInvaders" && detriotEntered == false)
			{
				AddConsoleToBackground(detriotArea, SpaceInvaders);
				detriotEntered = true;
				thisEnteredDetriot = kinematicBody.Name;
			}
			if (kinematicBody.Name == "DonkeyKong" && detriotEntered == false)
			{
				AddConsoleToBackground(detriotArea, DonkeyKong);
				detriotEntered = true;
				thisEnteredDetriot = kinematicBody.Name;
			}
			if (kinematicBody.Name == "Pong" && detriotEntered == false)
			{
				AddConsoleToBackground(detriotArea, Pong);
				detriotEntered = true;
				thisEnteredDetriot = kinematicBody.Name;
			}
			if (kinematicBody.Name == "PacMan" && detriotEntered == false)
			{
				AddConsoleToBackground(detriotArea, PacMan);
				detriotEntered = true;
				thisEnteredDetriot = kinematicBody.Name;
			}
			if (kinematicBody.Name == "Bioshock" && detriotEntered == false)
			{
				AddConsoleToBackground(detriotArea, Bioshock);
				detriotEntered = true;
				thisEnteredDetriot = kinematicBody.Name;
			}
			if (kinematicBody.Name == "Stray" && detriotEntered == false)
			{
				AddConsoleToBackground(detriotArea, Stray);
				detriotEntered = true;
				thisEnteredDetriot = kinematicBody.Name;
			}
			if (kinematicBody.Name == "Starfield" && detriotEntered == false)
			{
				starfieldCorrect = true;
				if (detriotEntered == false)
				{
					AddConsoleToBackground(detriotArea, Starfield);
					detriotEntered = true;
					thisEnteredDetriot = kinematicBody.Name;
				}
			}
			if (kinematicBody.Name == "Cyberpunk" && detriotEntered == false)
			{
				AddConsoleToBackground(detriotArea, Cyberpunk);
				detriotEntered = true;
				thisEnteredDetriot = kinematicBody.Name;
			}
			if (kinematicBody.Name == "Detriot" && detriotEntered == false)
			{
				AddConsoleToBackground(detriotArea, Detriot);
				detriotEntered = true;
				thisEnteredDetriot = kinematicBody.Name;
			}

			if (kinematicBody.Name == "Detriot")
			{
				detriotCorrect = true;
				if (detriotEntered == false)
				{
					AddConsoleToBackground(detriotArea, Detriot);
					detriotEntered = true;
					thisEnteredDetriot = kinematicBody.Name;
				}
			}
		}
	}
	private void _on_CheckDonkeyKong_body_exited(object body)
	{
		if (body is KinematicBody2D kinematicBody)
		{
			if (kinematicBody.Name == "DonkeyKong")
			{
				donkeyKongCorrect = false;
				if (thisEnteredDonkeyKong == kinematicBody.Name)
				{
					donkeyKongEntered = false;
					donkeyKongArea.Visible = false;
				}
			}
			else if (thisEnteredDonkeyKong == kinematicBody.Name)
			{
				donkeyKongEntered = false;
				donkeyKongArea.Visible = false;
			}
		}

	}


	private void _on_CheckPong_body_exited(object body)
	{
		if (body is KinematicBody2D kinematicBody)
		{
			if (kinematicBody.Name == "Pong")
			{
				pongCorrect = false;
				if (thisEnteredPong == kinematicBody.Name)
				{
					pongEntered = false;
					pongArea.Visible = false;
				}
			}
			else if (thisEnteredPong == kinematicBody.Name)
			{
				pongEntered = false;
				pongArea.Visible = false;
			}
		}

	}


	private void _on_CheckBioshock_body_exited(object body)
	{
		if (body is KinematicBody2D kinematicBody)
		{
			if (kinematicBody.Name == "Bioshock")
			{
				bioshockCorrect = false;
				if (thisEnteredBioshock == kinematicBody.Name)
				{
					bioshockEntered = false;
					bioshockArea.Visible = false;
				}
			}
			else if (thisEnteredBioshock == kinematicBody.Name)
			{
				bioshockEntered = false;
				bioshockArea.Visible = false;
			}
		}

	}


	private void _on_CheckStray_body_exited(object body)
	{
		if (body is KinematicBody2D kinematicBody)
		{
			if (kinematicBody.Name == "Stray")
			{
				strayCorrect = false;
				if (thisEnteredStray == kinematicBody.Name)
				{
					strayEntered = false;
					strayArea.Visible = false;
				}
			}
			else if (thisEnteredStray == kinematicBody.Name)
			{
				strayEntered = false;
				strayArea.Visible = false;
			}
		}

	}


	private void _on_CheckStarfield_body_exited(object body)
	{
		if (body is KinematicBody2D kinematicBody)
		{
			if (kinematicBody.Name == "Starfield")
			{
				starfieldCorrect = false;
				if (thisEnteredStarfield == kinematicBody.Name)
				{
					starfieldEntered = false;
					starfieldArea.Visible = false;
				}
			}
			else if (thisEnteredStarfield == kinematicBody.Name)
			{
				starfieldEntered = false;
				starfieldArea.Visible = false;
			}
		}

	}


	private void _on_CheckCyberpunk_body_exited(object body)
	{
		if (body is KinematicBody2D kinematicBody)
		{
			if (kinematicBody.Name == "Cyberpunk")
			{
				cyberpunkCorrect = false;
				if (thisEnteredCyberpunk == kinematicBody.Name)
				{
					cyberpunkEntered = false;
					cyberpunkArea.Visible = false;
				}
			}
			else if (thisEnteredCyberpunk == kinematicBody.Name)
			{
				cyberpunkEntered = false;
				cyberpunkArea.Visible = false;
			}
		}

	}


	private void _on_CheckHorizon_body_exited(object body)
	{
		if (body is KinematicBody2D kinematicBody)
		{
			if (kinematicBody.Name == "Horizon")
			{
				horizonCorrect = false;
				if (thisEnteredHorizon == kinematicBody.Name)
				{
					horizonEntered = false;
					horizonArea.Visible = false;
				}
			}
			else if (thisEnteredHorizon == kinematicBody.Name)
			{
				horizonEntered = false;
				horizonArea.Visible = false;
			}
		}

	}


	private void _on_CheckDetriot_body_exited(object body)
	{
		if (body is KinematicBody2D kinematicBody)
		{
			if (kinematicBody.Name == "Detriot")
			{
				detriotCorrect = false;
				if (thisEnteredDetriot == kinematicBody.Name)
				{
					detriotEntered = false;
					detriotArea.Visible = false;
				}
			}
			else if (thisEnteredDetriot == kinematicBody.Name)
			{
				detriotEntered = false;
				detriotArea.Visible = false;
			}
		}

	}


	private void _on_CheckPacMan_body_exited(object body)
	{
		if (body is KinematicBody2D kinematicBody)
		{
			if (kinematicBody.Name == "PacMan")
			{
				pacmanCorrect = false;
				if (thisEnteredPacMan == kinematicBody.Name)
				{
					pacmanEntered = false;
					pacManArea.Visible = false;
				}
			}
			else if (thisEnteredPacMan == kinematicBody.Name)
			{
				pacmanEntered = false;
				pacManArea.Visible = false;
			}
		}

	}
	
	private void _on_ActionRPG_body_entered(object body)
	{
		/*
		if (body is KinematicBody2D kinematicBody)
		{
			if (kinematicBody.Name == "Starfield")
			{
				starfieldCorrect = true;
			}
			if (kinematicBody.Name == "Horizon")
			{
				horizonCorrect = true;
			}
		}
		*/
	}


	private void _on_ActionAdventure_body_entered(object body)
	{
		/*
		if (body is KinematicBody2D kinematicBody)
		{
			if (kinematicBody.Name == "Cyberpunk")
			{
				cyberpunkCorrect = true;
			}
			else if (kinematicBody.Name == "Detriot")
			{
				detriotCorrect = true;
			}
			else if (kinematicBody.Name == "Stray")
			{
				strayCorrect = true;
			}
		}
		*/
	
	}


	private void _on_ActionRPG_body_exited(object body)
	{
		/*
		if (body is KinematicBody2D kinematicBody)
		{
			if (kinematicBody.Name == "Starfield")
			{
				starfieldCorrect = false;
			}
			if (kinematicBody.Name == "Horizon")
			{
				horizonCorrect = false;
			}
		}
		*/
	}


	private void _on_ActionAdventure_body_exited(object body)
	{
		/*
		if (body is KinematicBody2D kinematicBody)
		{
			if (kinematicBody.Name == "Cyberpunk")
			{
				cyberpunkCorrect = false;
			}
			if (kinematicBody.Name == "Detriot")
			{
				detriotCorrect = false;
			}
			if (kinematicBody.Name == "Stray")
			{
				strayCorrect = false;
			}
		}
		*/
	}

}








