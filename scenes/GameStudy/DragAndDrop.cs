using Godot;
using System;
using System.Threading.Tasks;

public class DragAndDrop : KinematicBody2D
{
	private bool hovered = false;
	private bool attached;
	private Vector2 offset;
	
	private Vector2 originalPosition;
	private float snapDistance = 100f; 
	private bool isSnapped = false;

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
	
	private Node2D _introGameStudy;
	private Button _introReady;
	
	private static DragAndDrop currentlyDraggedObject;

	private Sprite _popUp;
	private Label _popUpText;

	private Timer delayTimer;
	private bool popUp;
	
	private Button _open;
	private Button _close;
	private bool isOpen = false;
	

	public override void _Ready()
	{
		_introGameStudy = GetNode<Node2D>("/root/GameStudy/Intro");
		_introReady = GetNode<Button>("/root/GameStudy/Intro/Button");
		_xBOX = GetNode<KinematicBody2D>("/root/GameStudy/XBOX");
		_nES = GetNode<KinematicBody2D>("/root/GameStudy/NES");
		_gameBoy = GetNode<KinematicBody2D>("/root/GameStudy/GameBoy");
		_megaDrive1 = GetNode<KinematicBody2D>("/root/GameStudy/MegaDrive1");
		_c64 = GetNode<KinematicBody2D>("/root/GameStudy/C64");
		_atari = GetNode<KinematicBody2D>("/root/GameStudy/Atari");
		_segaSaturn = GetNode<KinematicBody2D>("/root/GameStudy/SegaSaturn");
		_mganavox = GetNode<KinematicBody2D>("/root/GameStudy/Magnavox");
		
		_tennisForTwo = GetNode<KinematicBody2D>("/root/GameStudy/PopUp/Games/TennisForTwo");	
		_pong = GetNode<KinematicBody2D>("/root/GameStudy/PopUp/Games/Pong");
		_mazeWars = GetNode<KinematicBody2D>("/root/GameStudy/PopUp/Games/MazeWars");
		_spaceInvaders = GetNode<KinematicBody2D>("/root/GameStudy/PopUp/Games/SpaceInvaders");
		_pacMan= GetNode<KinematicBody2D>("/root/GameStudy/PopUp/Games/PacMan");
		_donkeyKong = GetNode<KinematicBody2D>("/root/GameStudy/PopUp/Games/DonkeyKong");
		_detriot = GetNode<KinematicBody2D>("/root/GameStudy/PopUp/Games/Detroit");
		_cyberpunk = GetNode<KinematicBody2D>("/root/GameStudy/PopUp/Games/Cyberpunk");
		_starfield = GetNode<KinematicBody2D>("/root/GameStudy/PopUp/Games/Starfield");
		_bioshock = GetNode<KinematicBody2D>("/root/GameStudy/PopUp/Games/Bioshock");
		_horizon= GetNode<KinematicBody2D>("/root/GameStudy/PopUp/Games/Horizon");
		_stray= GetNode<KinematicBody2D>("/root/GameStudy/PopUp/Games/Stray");
		
		
		
		
		Connect("mouse_entered", this, "OnMouseEntered");
		Connect("mouse_exited", this, "OnMouseLeft");
		_introReady.Connect("pressed",this, nameof(OnIntroReadyPressed));
		originalPosition = Position;
		GD.Print(_xBOX);

		_popUp = GetNode<Sprite>("/root/GameStudy/Sprite");
		_popUpText = GetNode<Label>("/root/GameStudy/Sprite/Label");
		_popUp.Visible = false;
		
		_open = GetNode<Button>("/root/GameStudy/OpenPopUp");
		_close = GetNode<Button>("/root/GameStudy/PopUp/ClosePopUp");
		
		//_open.Connect("pressed", this, nameof(InputFalse(true)));
		//_close.Connect("pressed", this, nameof(InputTrue(true)));
		_open.Connect("pressed", this, "InputFalse", new Godot.Collections.Array { true });
		_close.Connect("pressed", this, "InputTrue", new Godot.Collections.Array { true });
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
				_popUp.Visible = true;
			}
			if (this.Name == "GameBoy"&& isOpen == false)
			{
				_popUpText.Text = "Was for a long time the best selling Handheld console. Was sold with the videogame Tetris.";
				_popUp.Visible = true;
			}
			if (this.Name == "NES"&& isOpen == false)
			{
				_popUpText.Text = "Is also available in a japanese version with the name “Famicom”.";
				_popUp.Visible = true;
			}
			if (this.Name == "MegaDrive1"&& isOpen == false)
			{
				_popUpText.Text = "Was in big competition with the consoles produced by Nintendo.";
				_popUp.Visible = true;
			}
			if (this.Name == "Atari"&& isOpen == false)
			{
				_popUpText.Text = "Is one of the most economically and culturally important consoles.";
				_popUp.Visible = true;
			}
			if (this.Name == "C64"&& isOpen == false)
			{
				_popUpText.Text = "Was the most sold home computer for a long time.";
				_popUp.Visible = true;
			}
			if (this.Name == "SegaSaturn"&& isOpen == false)
			{
				_popUpText.Text = "They tried to establish themselves as a console producer. However, Sony published their Playstation at the same time and “won”.";
				_popUp.Visible = true;
			}
			if (this.Name == "Magnavox"&& isOpen == false)
			{
				_popUpText.Text = "First video game console, which was developed by Ralph Bear.";
				_popUp.Visible = true;
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
		Useless();

	}
	
	private void _on_DelayTimer_timeout()
	{
		/*
		GD.Print("Delay hovered: "+hovered);
		if (hovered == false)
		{
			GD.Print("HEllo here is delay Methode");
			//hovered = false;
			_popUp.Visible = false;
		
		}
		*/
		
	}

	public async void Useless()
	{
		
		
		GD.Print("Delay hovered: "+hovered);
		if (hovered == false)
		{
			GD.Print("HEllo here is delay Methode");
			//hovered = false;
			_popUp.Visible = false;
			
		}
		
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

			isOpen = true;
		}
	}

	public override void _Process(float delta)
	{
		if (attached == true && currentlyDraggedObject == this)
		{
			Position = new Vector2(offset);
			CheckSnap();
		}
	}
	
	public void OnIntroReadyPressed()
	{
		_introGameStudy.Visible = false;
		GetNode<CountdownTimer>("/root/GameStudy/Timer").running = true;
	}
	
	private void CheckSnap()
	{
		foreach (Node2D node in GetTree().GetNodesInGroup("DragAndDropGroup"))
		{
			//if (node != this && Mathf.Abs(node.Position.y - Position.y) < snapDistance && node.Position.y < Position.y && Mathf.Abs(node.Position.y - Position.y) < snapDistance)
			if (node != this && Position.x > node.Position.x && Mathf.Abs(node.Position.y - Position.y) < snapDistance && Mathf.Abs(Position.x - (node.Position.x + node.GetNode<Sprite>("Sprite").Texture.GetSize().x)) < 40f)
			{
				Position = new Vector2(node.Position.x + 80f, node.Position.y);
				//hovered = false;
				break;
			}
		}
	}
}





