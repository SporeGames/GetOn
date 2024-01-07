using Godot;
using System;
using System.Collections.Generic;
using iText.IO.Util;

public class SpawningGames : Node2D
{
	
	private KinematicBody2D _spaceWars;
	
	private KinematicBody2D _xBOX;
	private KinematicBody2D _nES;
	private KinematicBody2D _gameBoy;
	private KinematicBody2D _megaDrive1;
	
	private KinematicBody2D _tennisForTwo;
	private KinematicBody2D _pong;
	private KinematicBody2D _mazeWars;
	private KinematicBody2D _spaceInvaders;
	private KinematicBody2D _pacMan;
	private KinematicBody2D _donkeyKong;
	private KinematicBody2D _detriot;
	private KinematicBody2D _cyberpunk;
	private KinematicBody2D _starfield;
	private KinematicBody2D _bioshock;
	private KinematicBody2D _horizon;
	private KinematicBody2D _stray;

	private List<string> gamesList = new List<string> {"PacMan", "Bioshock", "Tennis","Pong","Horizon","MazeWars","Stray","Starfield","SpaceInvaders","DonkeyKong","Detriot", "Cyberpunk"  };
	//private KinematicBody2D _tennisForTwo;	//private List<KinematicBody2D> gamesListe = new List<KinematicBody2D> {_xBOX,_nES,_gameBoy  };
	private List<KinematicBody2D> gamesListe;
	
	private string copyGame = "PacMan";
	private int number =0;

	private Sprite _background;
	private Sprite _backgroundWithGames;
	
	public override void _Ready()
	{	
		_tennisForTwo = GetNode<KinematicBody2D>("/root/GameStudy/Games/Games/Tennis");	
		_pong = GetNode<KinematicBody2D>("/root/GameStudy/Games/Games/Pong");
		_mazeWars = GetNode<KinematicBody2D>("/root/GameStudy/Games/Games/MazeWars");
		_spaceInvaders = GetNode<KinematicBody2D>("/root/GameStudy/Games/Games/SpaceInvaders");
		_pacMan= GetNode<KinematicBody2D>("/root/GameStudy/Games/Games/PacMan");
		_donkeyKong = GetNode<KinematicBody2D>("/root/GameStudy/Games/Games/DonkeyKong");
		_detriot = GetNode<KinematicBody2D>("/root/GameStudy/Games/Games/Detriot");
		_cyberpunk = GetNode<KinematicBody2D>("/root/GameStudy/Games/Games/Cyberpunk");
		_starfield = GetNode<KinematicBody2D>("/root/GameStudy/Games/Games/Starfield");
		_bioshock = GetNode<KinematicBody2D>("/root/GameStudy/Games/Games/Bioshock");
		_horizon= GetNode<KinematicBody2D>("/root/GameStudy/Games/Games/Horizon");
		_stray= GetNode<KinematicBody2D>("/root/GameStudy/Games/Games/Stray");
		
		gamesListe = new List<KinematicBody2D> { _pacMan,  _bioshock, _tennisForTwo, _pong, _horizon, _mazeWars, _stray, _starfield, _spaceInvaders, _donkeyKong, _detriot, _cyberpunk  };

		_background = GetNode<Sprite>("/root/GameStudy/Background");
		_backgroundWithGames = GetNode<Sprite>("/root/GameStudy/BackgroundWithGames");

	}
	
	private void _on_Area2D_body_exited(object body)
	{
		
		if (body is KinematicBody2D kinematicBody)
		{
			if (kinematicBody.Name == copyGame)
			{
				GD.Print("exited");
				if (number < gamesListe.Count-1)
				{
					number += 1;
					copyGame = gamesList[number];
					gamesListe[number].Visible = true;
				}

				if (number == 12)
				{
					_background.Visible = false;
					_backgroundWithGames.Visible = true;
				}
			}
		}
	}

	
}


