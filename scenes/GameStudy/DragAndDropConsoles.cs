using Godot;
using System;

public class DragAndDropConsoles : KinematicBody2D
{
	private bool hovered = false;
	private bool attached;
	private Vector2 offset;
	
	private Vector2 originalPosition;
	private float snapDistance = 100f; 
	private bool isSnapped = false;
	
	private Sprite _popUp;
	private Label _popUpText;

	private Timer delayTimer;
	private bool popUp;
	
	private Button _open;
	private Button _close;
	private bool isOpen = false;

	private Area2D currentArea = null;
	
	private KinematicBody2D _xBOX;
	private KinematicBody2D _nES;
	private KinematicBody2D _gameBoy;
	private KinematicBody2D _megaDrive1;
	private KinematicBody2D _c64;
	private KinematicBody2D _atari;
	private KinematicBody2D _segaSaturn;
	private KinematicBody2D _mganavox;
	
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
	
	private  DragAndDropConsoles currentlyDraggedObject;
	
	public override void _Ready()
	{
		Connect("mouse_entered", this, "OnMouseEntered");
		Connect("mouse_exited", this, "OnMouseLeft");
		originalPosition = Position;
		GD.Print(_xBOX);

		
		_popUpText = GetNode<Label>("/root/GameStudy/Consoles/Label");
		
		
		
		_xBOX = GetNode<KinematicBody2D>("/root/GameStudy/Consoles/XBOX");
		_nES = GetNode<KinematicBody2D>("/root/GameStudy/Consoles/NES");
		_gameBoy = GetNode<KinematicBody2D>("/root/GameStudy/Consoles/GameBoy");
		_megaDrive1 = GetNode<KinematicBody2D>("/root/GameStudy/Consoles/MegaDrive1");
		_c64 = GetNode<KinematicBody2D>("/root/GameStudy/Consoles/C64");
		_atari = GetNode<KinematicBody2D>("/root/GameStudy/Consoles/Atari");
		_segaSaturn = GetNode<KinematicBody2D>("/root/GameStudy/Consoles/SegaSaturn");
		_mganavox = GetNode<KinematicBody2D>("/root/GameStudy/Consoles/Magnavox");
		
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
	}

	public override void _Input(InputEvent @event)
	{
		
		if (Input.IsActionPressed("left_click") && hovered == true )
		{
			InputFalse(false);
			
			
			this.InputPickable = true;
			this.ZIndex = 20;
			currentlyDraggedObject = this; 
			attached = true;
			//offset = GetViewport().GetMousePosition();
		}
		/*
		if (Input.IsActionPressed("left_click") && hovered == true || this.Name == "TennisForTwo" || this.Name == "Pong" || this.Name == "MazeWars" )
		{
			InputFalse(false);


			this.InputPickable = true;
			this.ZIndex = 20;
			currentlyDraggedObject = this;
			attached = true;
			//offset = GetViewport().GetMousePosition();
		}
		*/

		if (!Input.IsActionPressed("left_click"))
		{
			
			attached = false;
			
			this.ZIndex = 0;
			InputTrue(false);
		
			if (currentlyDraggedObject == this)
			{
				currentlyDraggedObject = null; 
			}
		}

		if (@event is InputEventMouseMotion motion)
		{
			offset = GetViewport().GetMousePosition();
		}

	}

	public void OnMouseEntered()
	{
			hovered = true;
			
			GD.Print("entered: "+hovered);

		
			if (this.Name == "XBOX" && isOpen == false)
			{
				_popUpText.Text = "The first console with an integrated hard disk.";
				
			}
			if (this.Name == "GameBoy"&& isOpen == false)
			{
				_popUpText.Text = "Was for a long time the best selling Handheld console. Was sold with the videogame Tetris.";
				
			}
			if (this.Name == "NES"&& isOpen == false)
			{
				_popUpText.Text = "Is also available in a japanese version with the name “Famicom”.";
				
			}
			if (this.Name == "MegaDrive1"&& isOpen == false)
			{
				_popUpText.Text = "Was in big competition with the consoles produced by Nintendo.";
				
			}
			if (this.Name == "Atari"&& isOpen == false)
			{
				_popUpText.Text = "Is one of the most economically and culturally important consoles.";
				
			}
			if (this.Name == "C64"&& isOpen == false)
			{
				_popUpText.Text = "Was the most sold home computer for a long time.";
				
			}
			if (this.Name == "SegaSaturn"&& isOpen == false)
			{
				_popUpText.Text = "They tried to establish themselves as a console producer. However, Sony published their Playstation at the same time and “won”.";
			
			}
			if (this.Name == "Magnavox"&& isOpen == false)
			{
				_popUpText.Text = "First video game console, which was developed by Ralph Bear.";
				
			}
	}

	public void OnMouseLeft()
	{
		popUp = true;
		//delayTimer.WaitTime = 0.5f;
		//delayTimer.Start();
		hovered = false;
		
		GD.Print("left: "+hovered);
		//Delay();
		
		//_popUp.Visible = false;
		

	}
	public void InputTrue(bool popUp)
	{
		if (popUp == false)
		{
			_xBOX.InputPickable = true;
			_nES.InputPickable = true;
			_gameBoy.InputPickable = true;
			_megaDrive1.InputPickable = true;
			_c64.InputPickable = true;
			_atari.InputPickable = true;
			_mganavox.InputPickable = true;
			_segaSaturn.InputPickable = true;
			
			_tennisForTwo.InputPickable = true;
			_pong.InputPickable = true;
			_mazeWars.InputPickable = true;
			_spaceInvaders.InputPickable = true;
			_pacMan.InputPickable = true;
			_donkeyKong.InputPickable = true;
			_detriot.InputPickable = true;
			_cyberpunk.InputPickable = true;
			_starfield.InputPickable = true;
			_bioshock.InputPickable = true;
			_horizon.InputPickable = true;
			_stray.InputPickable = true;

		}
		else
		{
			_xBOX.InputPickable = true;
			_nES.InputPickable = true;
			_gameBoy.InputPickable = true;
			_megaDrive1.InputPickable = true;
			_c64.InputPickable = true;
			_atari.InputPickable = true;
			_mganavox.InputPickable = true;
			_segaSaturn.InputPickable = true;
			

			isOpen = false;
		}
	}

	public void InputFalse(bool popUp)
	{
		if (popUp == false)
		{
			_xBOX.InputPickable = false;
			_nES.InputPickable = false;
			_gameBoy.InputPickable = false;
			_megaDrive1.InputPickable = false;
			_c64.InputPickable = false;
			_atari.InputPickable = false;
			_mganavox.InputPickable = false;
			_segaSaturn.InputPickable = false;
			
			_tennisForTwo.InputPickable = false;
			_pong.InputPickable = false;
			_mazeWars.InputPickable = false;
			_spaceInvaders.InputPickable = false;
			_pacMan.InputPickable = false;
			_donkeyKong.InputPickable = false;
			_detriot.InputPickable = false;
			_cyberpunk.InputPickable = false;
			_starfield.InputPickable = false;
			_bioshock.InputPickable = false;
			_horizon.InputPickable = false;
			_stray.InputPickable = false;
			
		}
		else
		{
			_xBOX.InputPickable = false;
			_nES.InputPickable = false;
			_gameBoy.InputPickable = false;
			_megaDrive1.InputPickable = false;
			_c64.InputPickable = false;
			_atari.InputPickable = false;
			_mganavox.InputPickable = false;
			_segaSaturn.InputPickable = false;

			isOpen = true;
		}
	}
	
	private void _on_CheckTennis_body_entered(object body)
	{
		//snap versuch
	}


	public override void _Process(float delta)
	{
		if (attached == true && currentlyDraggedObject == this)
		{
			Position = new Vector2(offset);
			//CheckSnap();
		}
	}
}
