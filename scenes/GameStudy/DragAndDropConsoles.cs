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
	private Label _popUpConsoles;
	private Sprite _consoleZoom;

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

	private Texture pacMan = GD.Load<Texture>("res://scenes/GameStudy/assets/Games/PacMan.png");
	private Texture tennis = GD.Load<Texture>("res://scenes/GameStudy/assets/Games/TennisForTwo.PNG");
	private Texture bioshock = GD.Load<Texture>("res://scenes/GameStudy/assets/Games/Bioshock.PNG");
	private Texture cyberpunk = GD.Load<Texture>("res://scenes/GameStudy/assets/Games/Cyberpunk.PNG");
	private Texture detriot = GD.Load<Texture>("res://scenes/GameStudy/assets/Games/DetroitBecomeHuman.PNG");
	private Texture donkeyKong = GD.Load<Texture>("res://scenes/GameStudy/assets/Games/Donkey Kong.PNG");
	private Texture horizon = GD.Load<Texture>("res://scenes/GameStudy/assets/Games/Horizon Zero Daw.PNG");
	private Texture mazeWars = GD.Load<Texture>("res://scenes/GameStudy/assets/Games/MazeWars.PNG");
	private Texture pong = GD.Load<Texture>("res://scenes/GameStudy/assets/Games/Pong.PNG");
	private Texture spaceInvaders = GD.Load<Texture>("res://scenes/GameStudy/assets/Games/SpaceInvaders.png");
	private Texture starfield = GD.Load<Texture>("res://scenes/GameStudy/assets/Games/Starfield.PNG");
	private Texture stray = GD.Load<Texture>("res://scenes/GameStudy/assets/Games/Stray.PNG");

	
	private KinematicBody2D copy;
	private bool megaDriveSnapped;
	private bool isDragged;

	private AudioStreamPlayer _drag;
	private AudioStreamPlayer _drop;
	private AudioStreamPlayer _dropOnShowcase;
	private bool onShowCase = false;

	private DragAndDropConsoles _xboxConsoles;
	private DragAndDropConsoles _nesConsoles;
	private DragAndDropConsoles _megaDriveConsoles;
	private DragAndDropConsoles _atariConsoles;
	private DragAndDropConsoles _c64Consoles;
	private DragAndDropConsoles _segaSaturnConsoles;
	private DragAndDropConsoles _magnavoxConsoles;
	
	private DragAndDropConsoles _tennisGames;
	private DragAndDropConsoles _pacManGames;
	private DragAndDropConsoles _bioshockGames;
	private DragAndDropConsoles _cyberpunkGames;
	private DragAndDropConsoles _detriotGames;
	private DragAndDropConsoles _donkeyKongGames;
	private DragAndDropConsoles _horizonGames;
	private DragAndDropConsoles _mazeWarsGames;
	private DragAndDropConsoles _pongGames;
	private DragAndDropConsoles _spaceInvadersGames;
	private DragAndDropConsoles _starfieldGames;
	private DragAndDropConsoles _strayGames;

	
	public override void _Ready()
	{
		Connect("mouse_entered", this, "OnMouseEntered");
		Connect("mouse_exited", this, "OnMouseLeft");
		originalPosition = Position;
		GD.Print(_xBOX);
		
		_popUpText = GetNode<Label>("/root/GameStudy/Consoles/Label");
		_popUpConsoles = GetNode<Label>("/root/GameStudy/Games/Label");
		_consoleZoom = GetNode<Sprite>("/root/GameStudy/Games/ConsoleZoom");
		
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

		_drag = GetNode<AudioStreamPlayer>("/root/GameStudy/SoundFX/Drag");
		_drop = GetNode<AudioStreamPlayer>("/root/GameStudy/SoundFX/Drop");
		_dropOnShowcase = GetNode<AudioStreamPlayer>("/root/GameStudy/SoundFX/DropOnShowcase");

		_xboxConsoles = GetNode<DragAndDropConsoles>("/root/GameStudy/Consoles/XBOX");
		_nesConsoles = GetNode<DragAndDropConsoles>("/root/GameStudy/Consoles/NES");
		_megaDriveConsoles = GetNode<DragAndDropConsoles>("/root/GameStudy/Consoles/MegaDrive1");
		_atariConsoles = GetNode<DragAndDropConsoles>("/root/GameStudy/Consoles/Atari");
		_c64Consoles = GetNode<DragAndDropConsoles>("/root/GameStudy/Consoles/C64");
		_segaSaturnConsoles = GetNode<DragAndDropConsoles>("/root/GameStudy/Consoles/SegaSaturn");
		_magnavoxConsoles = GetNode<DragAndDropConsoles>("/root/GameStudy/Consoles/Magnavox");
		
		_tennisGames = GetNode<DragAndDropConsoles>("/root/GameStudy/Games/Games/Tennis");
		_pacManGames= GetNode<DragAndDropConsoles>("/root/GameStudy/Games/Games/PacMan");
		_bioshockGames= GetNode<DragAndDropConsoles>("/root/GameStudy/Games/Games/Bioshock");
		_cyberpunkGames= GetNode<DragAndDropConsoles>("/root/GameStudy/Games/Games/Cyberpunk");
		_detriotGames= GetNode<DragAndDropConsoles>("/root/GameStudy/Games/Games/Detriot");
		_donkeyKongGames= GetNode<DragAndDropConsoles>("/root/GameStudy/Games/Games/DonkeyKong");
		_horizonGames= GetNode<DragAndDropConsoles>("/root/GameStudy/Games/Games/Horizon");
		_mazeWarsGames= GetNode<DragAndDropConsoles>("/root/GameStudy/Games/Games/MazeWars");
		_pongGames= GetNode<DragAndDropConsoles>("/root/GameStudy/Games/Games/Pong");
		_spaceInvadersGames= GetNode<DragAndDropConsoles>("/root/GameStudy/Games/Games/SpaceInvaders");
		_starfieldGames= GetNode<DragAndDropConsoles>("/root/GameStudy/Games/Games/Starfield");
		_strayGames= GetNode<DragAndDropConsoles>("/root/GameStudy/Games/Games/Stray");
	}

	public override void _Input(InputEvent @event)
	{
		isDragged = true;
		if (Input.IsActionPressed("left_click") && hovered == true && isDragged == true) 
		{
			InputFalse(false);
			
			this.InputPickable = true;
			this.ZIndex = 20;
			 
			attached = true;
			if (currentlyDraggedObject == null)
			{
				currentlyDraggedObject = this;
				_drag.Play();
			}
		}
		
		if (Input.IsActionJustReleased("left_click"))
		{
			attached = false;
			this.ZIndex = 0;
			InputTrue(false);
			
			if (currentlyDraggedObject == this)
			{
				GD.Print("Hier nochmal: "+onShowCase);
				if (onShowCase == false) {
					_drop.Play();
				}
				else {
					this._dropOnShowcase.Play();
				}
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
			_consoleZoom.Visible = true;
			hovered = true;

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
			
			if (this.Name == "PacMan"&& isOpen == false)
			{
				_popUpConsoles.Text = "PacMan";
				_consoleZoom.Texture = pacMan;

			}
			if (this.Name == "Tennis"&& isOpen == false)
			{
				_popUpConsoles.Text = "Tennis For Two";
				_consoleZoom.Texture = tennis;

			}
			if (this.Name == "Stray"&& isOpen == false)
			{
				_popUpConsoles.Text = "Stray";
				_consoleZoom.Texture = stray;
			}
			if (this.Name == "Starfield"&& isOpen == false)
			{
				_popUpConsoles.Text = "Starfield";
				_consoleZoom.Texture = starfield;
			}
			if (this.Name == "SpaceInvaders"&& isOpen == false)
			{
				_popUpConsoles.Text = "Space Invaders";
				_consoleZoom.Texture = spaceInvaders;
			}
			if (this.Name == "Pong"&& isOpen == false)
			{
				_popUpConsoles.Text = "Pong";
				_consoleZoom.Texture = pong;
			}
			if (this.Name == "MazeWars"&& isOpen == false)
			{
				_popUpConsoles.Text = "Maze Wars";
				_consoleZoom.Texture = mazeWars;
			}
			if (this.Name == "Horizon"&& isOpen == false)
			{
				_popUpConsoles.Text = "Horizon Zero Dawn";
				_consoleZoom.Texture = horizon;
			}
			if (this.Name == "DonkeyKong"&& isOpen == false)
			{
				_popUpConsoles.Text = "Donkey Kong";
				_consoleZoom.Texture = donkeyKong;
			}
			if (this.Name == "Detriot"&& isOpen == false)
			{
				_popUpConsoles.Text = "Detriot: Become Human";
				_consoleZoom.Texture = detriot;
			}
			if (this.Name == "Cyberpunk"&& isOpen == false)
			{
				_popUpConsoles.Text = "Cyberpunk 2077";
				_consoleZoom.Texture = cyberpunk;
			}
			if (this.Name == "Bioshock"&& isOpen == false)
			{
				_popUpConsoles.Text = "Bioshock";
				_consoleZoom.Texture = bioshock;
			}
	}

	public void OnMouseLeft()
	{
		popUp = true;
		hovered = false;
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

	public override void _Process(float delta)
	{
		if (attached == true && currentlyDraggedObject == this)
		{
			Position = new Vector2(offset);
			isDragged = true;
		}
		else
		{
			isDragged = false;
		}
	}

	public void Snap(string name, Vector2 position)
	{
		
		if (name == "XBOX")
		{
			copy = _xBOX;
			copy.InputPickable = false;
		}
		else if (name == "GameBoy")
		{
			copy = _gameBoy;
			copy.InputPickable = false;
		}
		
		if (megaDriveSnapped == false && copy != null)
		{
			//copy.Position = position;
			attached = false;
			isDragged = false;
			copy.Position = position;
			
		}
	}
	private void _on_MegaDrive_body_entered(object body)
	{
		if (body is KinematicBody2D kinematicBody)
		{
			var position = new Vector2(297, 191);
			Snap(kinematicBody.Name,new Vector2(297, 191));
		}
	}

	public void ChangePosition(Vector2 position) {
		attached = false;
		isDragged = false;
		InputPickable = false;
		Position = position;
	}
	private void _on_ChangeSound_body_entered(object body)
	{
		if (body is KinematicBody2D kinematicBody)
		{
			if (kinematicBody.Name == "XBOX")
			{
				_xboxConsoles.onShowCase = true;
			}
			if (kinematicBody.Name == "NES")
			{
				_nesConsoles.onShowCase = true;
			}
			if (kinematicBody.Name == "MegaDrive1")
			{
				_megaDriveConsoles.onShowCase = true;
			}
			if (kinematicBody.Name == "Atari")
			{
				_atariConsoles.onShowCase = true;
			}
			if (kinematicBody.Name == "C64")
			{
				_c64Consoles.onShowCase = true;
			}
			if (kinematicBody.Name == "SegaSaturn")
			{
				_segaSaturnConsoles.onShowCase = true;
			}
			if (kinematicBody.Name == "Magnavox")
			{
				_magnavoxConsoles.onShowCase = true;
			}
			//Games
			if (kinematicBody.Name == "Tennis") {
				_tennisGames.onShowCase = true;
			}
			if (kinematicBody.Name == "PacMan") {
				_pacManGames.onShowCase = true;
			}
			if (kinematicBody.Name == "Pong") {
				_pongGames.onShowCase = true;
			}
			if (kinematicBody.Name == "MazeWars") {
				_mazeWarsGames.onShowCase = true;
			}
			if (kinematicBody.Name == "SpaceInvaders") {
				_spaceInvadersGames.onShowCase = true;
			}
			if (kinematicBody.Name == "DonkeyKong") {
				_donkeyKongGames.onShowCase = true;
			}
			if (kinematicBody.Name == "Bioshock") {
				_bioshockGames.onShowCase = true;
			}
			if (kinematicBody.Name == "Horizon") {
				_horizonGames.onShowCase = true;
			}
			if (kinematicBody.Name == "Starfield") {
				_starfieldGames.onShowCase = true;
			}
			if (kinematicBody.Name == "Cyberpunk") {
				_cyberpunkGames.onShowCase = true;
			}
			if (kinematicBody.Name == "Stray") {
				_strayGames.onShowCase = true;
			}
			if (kinematicBody.Name == "Detriot") {
				_detriotGames.onShowCase = true;
			}
			this.onShowCase = true;
			GD.Print("Drin: "+onShowCase);
		}
	}

	private void _on_ChangeSound_body_exited(object body)
	{
		if (body is KinematicBody2D kinematicBody)
		{
			if (kinematicBody.Name == "XBOX")
			{
				_xboxConsoles.onShowCase = false;
			}
			if (kinematicBody.Name == "NES")
			{
				_nesConsoles.onShowCase = false;
			}
			if (kinematicBody.Name == "MegaDrive1")
			{
				_megaDriveConsoles.onShowCase = false;
			}
			if (kinematicBody.Name == "Atari")
			{
				_atariConsoles.onShowCase = false;
			}
			if (kinematicBody.Name == "C64")
			{
				_c64Consoles.onShowCase = false;
			}
			if (kinematicBody.Name == "SegaSaturn")
			{
				_segaSaturnConsoles.onShowCase = false;
			}
			if (kinematicBody.Name == "Magnavox")
			{
				_magnavoxConsoles.onShowCase = false;
			}
			
			if (kinematicBody.Name == "Tennis") {
				_tennisGames.onShowCase = false;;
			}
			if (kinematicBody.Name == "PacMan") {
				_pacManGames.onShowCase = false;;
			}
			if (kinematicBody.Name == "Pong") {
				_pongGames.onShowCase = false;;
			}
			if (kinematicBody.Name == "MazeWars") {
				_mazeWarsGames.onShowCase = false;;
			}
			if (kinematicBody.Name == "SpaceInvaders") {
				_spaceInvadersGames.onShowCase = false;;
			}
			if (kinematicBody.Name == "DonkeyKong") {
				_donkeyKongGames.onShowCase = false;;
			}
			if (kinematicBody.Name == "Bioshock") {
				_bioshockGames.onShowCase = false;;
			}
			if (kinematicBody.Name == "Horizon") {
				_horizonGames.onShowCase = false;;
			}
			if (kinematicBody.Name == "Starfield") {
				_starfieldGames.onShowCase = false;;
			}
			if (kinematicBody.Name == "Cyberpunk") {
				_cyberpunkGames.onShowCase = false;;
			}
			if (kinematicBody.Name == "Stray") {
				_strayGames.onShowCase = false;;
			}
			if (kinematicBody.Name == "Detriot") {
				_detriotGames.onShowCase = false;;
			}
			this.onShowCase = false;
			GD.Print("raus: "+onShowCase);
		}
	}
}





