using Godot;
using System;
using System.Collections.Generic;

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

	private List<string> gamesList = new List<string> {"TennisForTwo","Pong","MazeWars","SpaceInvaders","PacMan","DonkeyKong","Detroit", "Cyberpunk","Starfield","Bioshock","Horizon","Stray"  };
	//private KinematicBody2D _tennisForTwo;	//private List<KinematicBody2D> gamesListe = new List<KinematicBody2D> {_xBOX,_nES,_gameBoy  };
	private List<KinematicBody2D> gamesListe;
	
	private string copyGame = "TennisForTwo";
	private int number =0;
	
	public override void _Ready()
	{	
		_xBOX = GetNode<KinematicBody2D>("/root/GameStudy/XBOX");
		_nES = GetNode<KinematicBody2D>("/root/GameStudy/NES");
		_gameBoy = GetNode<KinematicBody2D>("/root/GameStudy/GameBoy");
		_megaDrive1 = GetNode<KinematicBody2D>("/root/GameStudy/MegaDrive1");
		
		_tennisForTwo = GetNode<KinematicBody2D>("/root/GameStudy/Games/TennisForTwo");
		_pong = GetNode<KinematicBody2D>("/root/GameStudy/Games/Pong");
		_mazeWars = GetNode<KinematicBody2D>("/root/GameStudy/Games/MazeWars");
		_spaceInvaders = GetNode<KinematicBody2D>("/root/GameStudy/Games/SpaceInvaders");
		_pacMan= GetNode<KinematicBody2D>("/root/GameStudy/Games/PacMan");
		_donkeyKong = GetNode<KinematicBody2D>("/root/GameStudy/Games/DonkeyKong");
		_detriot = GetNode<KinematicBody2D>("/root/GameStudy/Games/Detroit");
		_cyberpunk = GetNode<KinematicBody2D>("/root/GameStudy/Games/Cyberpunk");
		_starfield = GetNode<KinematicBody2D>("/root/GameStudy/Games/Starfield");
		_bioshock = GetNode<KinematicBody2D>("/root/GameStudy/Games/Bioshock");
		_horizon= GetNode<KinematicBody2D>("/root/GameStudy/Games/Horizon");
		_stray= GetNode<KinematicBody2D>("/root/GameStudy/Games/Stray");
		
		gamesListe = new List<KinematicBody2D> { _tennisForTwo, _pong, _mazeWars, _spaceInvaders, _pacMan, _donkeyKong, _detriot, _cyberpunk, _starfield, _bioshock, _horizon, _stray};
		//_tennisForTwo = GetNode<KinematicBody2D>("/root/GameStudy/Games/TennisForTwo");
		//_pong = GetNode<KinematicBody2D>("/root/GameStudy/Games/Pong");
		//_spaceWars = GetNode<KinematicBody2D>("/root/GameStudy/Games/SpaceWars");
		
	}
	
	private void _on_Area2D_body_exited(object body)
	{
		GD.Print("exited");
		if (body is KinematicBody2D kinematicBody)
		{
			if (kinematicBody.Name == copyGame)
			{
				if (number < gamesListe.Count-1)
				{
					number += 1;
					copyGame = gamesList[number];
					gamesListe[number].Visible = true;
				}
				
			}
		}
	}

	
}


