using Godot;
using System;
using System.Collections.Generic;
using iText.IO.Util;

public class SpawningConsoles : Node2D
{
	private KinematicBody2D _xBOX;
	private KinematicBody2D _nES;
	private KinematicBody2D _gameBoy;
	private KinematicBody2D _megaDrive1;
	private KinematicBody2D _c64;
	private KinematicBody2D _atari;
	private KinematicBody2D _segaSaturn;
	private KinematicBody2D _mganavox;

	private List<string> gamesList = new List<string> {"XBOX", "NES", "GameBoy","MegaDrive1","C64","Atari","SegaSaturn","Magnavox" };
	//private KinematicBody2D _tennisForTwo;	//private List<KinematicBody2D> gamesListe = new List<KinematicBody2D> {_xBOX,_nES,_gameBoy  };
	private List<KinematicBody2D> gamesListe;
	
	private string copyGame = "XBOX";
	private int number =0;
	

	public override void _Ready()
	{	
		_xBOX = GetNode<KinematicBody2D>("/root/GameStudy/Consoles/XBOX");
		_nES = GetNode<KinematicBody2D>("/root/GameStudy/Consoles/NES");
		_gameBoy = GetNode<KinematicBody2D>("/root/GameStudy/Consoles/GameBoy");
		_megaDrive1 = GetNode<KinematicBody2D>("/root/GameStudy/Consoles/MegaDrive1");
		_c64 = GetNode<KinematicBody2D>("/root/GameStudy/Consoles/C64");
		_atari = GetNode<KinematicBody2D>("/root/GameStudy/Consoles/Atari");
		_segaSaturn = GetNode<KinematicBody2D>("/root/GameStudy/Consoles/SegaSaturn");
		_mganavox = GetNode<KinematicBody2D>("/root/GameStudy/Consoles/Magnavox");
		
		gamesListe = new List<KinematicBody2D> { _xBOX , _nES, _gameBoy, _megaDrive1, _c64, _atari, _segaSaturn, _mganavox};

		

	}
	
	private void _on_Area2D_body_exited(object body)
	{
		
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

				if (number == 8)
				{
					
				}
			}
		}
	}

	
}
