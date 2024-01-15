using Godot;
using System;
using System.Diagnostics;

public class SnapAreas : Node2D
{
	private DragAndDropConsoles _dragAndDropConsoles;
	private DragAndDropConsoles _dragAndDropConsolesGameBoy;
	private DragAndDropConsoles _dragAndDropConsolesMegaDrive;
	private DragAndDropConsoles _dragAndDropConsolesMagnavox;
	private DragAndDropConsoles _dragAndDropConsolesAtari;
	private DragAndDropConsoles _dragAndDropConsolesC64;
	private DragAndDropConsoles _dragAndDropConsolesNES;
	private DragAndDropConsoles _dragAndDropConsolesSegaStaurn;

	private DragAndDropConsoles _dragTennis;
	private DragAndDropConsoles _dragPong;
	private DragAndDropConsoles _dragMazeWars;
	private DragAndDropConsoles _dragSpaceInvaders;
	private DragAndDropConsoles _dragPacMan;
	private DragAndDropConsoles _dragDonkeyKong;
	private DragAndDropConsoles _dragBioshock;
	private DragAndDropConsoles _dragStarfield;
	private DragAndDropConsoles _dragHorizon;
	private DragAndDropConsoles _dragDetriot;
	private DragAndDropConsoles _dragStray;
	private DragAndDropConsoles _dragCyberpunk;

	private DragAndDropConsoles copy;

	private bool leftClick;
	private bool megaDriveEntered;
	private bool xboxEntered;
	private bool magnavoxEntered;
	private bool gameBoyEntered;
	private bool atariEntered;
	private bool c64Entered;
	private bool nesEntered;
	private bool segaSaturnEntered;
	
	private string megaDriveNameCopy;
	private string xboxNameCopy;
	private string magnavoxCopy;
	private string gameboyNameCopy;
	private string atariNameCopy;
	private string c64NameCopy;
	private string nesNameCopy;
	private string segaSaturnNameCopy;

	private bool tennisEntered;
	private bool pongEntered;
	private bool mazeWarsEntered;
	private bool spaceInvadersEntered;
	private bool pacManEntered;
	private bool donkeyKongEntered;
	private bool bioshockEntered;
	private bool horizonEntered;
	private bool starfieldEntered;
	private bool detriotEntered;
	private bool strayEntered;
	private bool cyberpunkEntered;

	private string tennisNameCopy;
	private string pongNameCopy;
	private string mazeWarsNameCopy;
	private string spaceInvadersNameCopy;
	private string pacManNameCopy;
	private string donkeyKongNameCopy;
	private string bioshockNameCopy;
	private string horizonNameCopy;
	private string starfieldNameCopy;
	private string detriotNameCopy;
	private string strayNameCopy;
	private string cyberpunkNameCopy;

	private Node2D _consoles;
	private bool consolesVisible;
	
	public override void _Ready() {
		_dragAndDropConsoles = GetNode<DragAndDropConsoles>("/root/GameStudy/Consoles/XBOX");
		_dragAndDropConsolesGameBoy = GetNode<DragAndDropConsoles>("/root/GameStudy/Consoles/GameBoy");
		_dragAndDropConsolesMegaDrive = GetNode<DragAndDropConsoles>("/root/GameStudy/Consoles/MegaDrive1");
		_dragAndDropConsolesMagnavox = GetNode<DragAndDropConsoles>("/root/GameStudy/Consoles/Magnavox");
		_dragAndDropConsolesAtari = GetNode<DragAndDropConsoles>("/root/GameStudy/Consoles/Atari");
		_dragAndDropConsolesC64 = GetNode<DragAndDropConsoles>("/root/GameStudy/Consoles/C64");
		_dragAndDropConsolesSegaStaurn = GetNode<DragAndDropConsoles>("/root/GameStudy/Consoles/SegaSaturn");
		_dragAndDropConsolesNES = GetNode<DragAndDropConsoles>("/root/GameStudy/Consoles/NES");
		
		_dragTennis = GetNode<DragAndDropConsoles>("/root/GameStudy/Games/Games/Tennis");
		_dragPong = GetNode<DragAndDropConsoles>("/root/GameStudy/Games/Games/Pong");
		_dragMazeWars = GetNode<DragAndDropConsoles>("/root/GameStudy/Games/Games/MazeWars");
		_dragSpaceInvaders = GetNode<DragAndDropConsoles>("/root/GameStudy/Games/Games/SpaceInvaders");
		_dragPacMan = GetNode<DragAndDropConsoles>("/root/GameStudy/Games/Games/PacMan");
		_dragDonkeyKong = GetNode<DragAndDropConsoles>("/root/GameStudy/Games/Games/DonkeyKong");
		_dragBioshock = GetNode<DragAndDropConsoles>("/root/GameStudy/Games/Games/Bioshock");
		_dragHorizon = GetNode<DragAndDropConsoles>("/root/GameStudy/Games/Games/Horizon");
		_dragStarfield = GetNode<DragAndDropConsoles>("/root/GameStudy/Games/Games/Starfield");
		_dragDetriot = GetNode<DragAndDropConsoles>("/root/GameStudy/Games/Games/Detriot");
		_dragStray = GetNode<DragAndDropConsoles>("/root/GameStudy/Games/Games/Stray");
		_dragCyberpunk = GetNode<DragAndDropConsoles>("/root/GameStudy/Games/Games/Cyberpunk");

		_consoles = GetNode<Node2D>("/root/GameStudy/Consoles");
	}
	public override void _Process(float delta) {
		if (_consoles.Visible == true) {
			consolesVisible = true;
		}
		else {
			consolesVisible = false;
		}
	}

	public override void _Input(InputEvent @event) {
		if (Input.IsActionPressed("left_click")) {
			leftClick = true;
		}
		if (Input.IsActionJustReleased("left_click")) {
			leftClick = false;
			if (megaDriveEntered) {
				Snap(megaDriveNameCopy,new Vector2(297, 191),false);
			}
			if (xboxEntered) {
				Snap(xboxNameCopy,new Vector2(760, 191),false);
			}
			if (magnavoxEntered) {
				Snap(magnavoxCopy,new Vector2(297, 426),false);
			}
			if (gameBoyEntered) {
				Snap(gameboyNameCopy,new Vector2(760, 426),false);
			}
			if (atariEntered) {
				Snap(atariNameCopy,new Vector2(297, 680),false);
			}
			if (c64Entered) {
				Snap(c64NameCopy,new Vector2(760, 680),false);
			}
			if (nesEntered) {
				Snap(nesNameCopy,new Vector2(297, 883),false);
			}
			if (segaSaturnEntered) {
				Snap(segaSaturnNameCopy,new Vector2(760, 883),false);
			}
			//games
			if (tennisEntered) {
				Snap(tennisNameCopy,new Vector2(269, 188),false);
			}
			if (pongEntered) {
				Snap(pongNameCopy,new Vector2(541, 191),false);
			}
			if (mazeWarsEntered) {
				Snap(mazeWarsNameCopy,new Vector2(807, 191),false);
			}
			if (spaceInvadersEntered) {
				Snap(spaceInvadersNameCopy,new Vector2(246, 414),false);
			}
			if (pacManEntered) {
				Snap(pacManNameCopy,new Vector2(541, 414),false);
			}
			if (donkeyKongEntered) {
				Snap(donkeyKongNameCopy,new Vector2(807, 414),false);
			}
			if (bioshockEntered) {
				Snap(bioshockNameCopy,new Vector2(269, 666),false);
			}
			if (horizonEntered) {
				Snap(horizonNameCopy,new Vector2(807, 666),false);
			}
			if (starfieldEntered) {
				Snap(starfieldNameCopy,new Vector2(541, 666),false);
			}
			if (detriotEntered) {
				Snap(detriotNameCopy,new Vector2(269, 876),false);
			}
			if (strayEntered) {
				Snap(strayNameCopy,new Vector2(541, 876),false);
			}
			if (cyberpunkEntered) {
				Snap(cyberpunkNameCopy,new Vector2(807, 876),false);
			}
		}
	}

	private void _on_MegaDrive_body_entered(object body)
	{
		if (body is KinematicBody2D kinematicBody && megaDriveEntered == false && consolesVisible == true) {
			megaDriveNameCopy = kinematicBody.Name;
			megaDriveEntered = true;
		}
	}
	private void _on_MegaDrive_body_exited(object body)
	{
		if (body is KinematicBody2D kinematicBody && kinematicBody.Name == megaDriveNameCopy && consolesVisible == true) {
			megaDriveEntered = false;
		}
	}
	
	private void _on_XBOX_body_entered(object body)
	{
		if (body is KinematicBody2D kinematicBody && xboxEntered == false && consolesVisible == true) {
			xboxNameCopy = kinematicBody.Name;
			xboxEntered = true;
		}
	}
	private void _on_XBOX_body_exited(object body)
	{
		if (body is KinematicBody2D kinematicBody && kinematicBody.Name == xboxNameCopy && consolesVisible == true) {
			xboxEntered = false;
		}
	}
	
	public void Snap(string name, Vector2 position, bool empty)
	{
		if (!empty) {
			if (name == "XBOX") {
				copy = _dragAndDropConsoles;
			}
			else if (name == "GameBoy") {
				copy = _dragAndDropConsolesGameBoy;
			}
			else if (name == "NES") {
				copy = _dragAndDropConsolesNES;
			}
			else if (name == "MegaDrive1") {
				copy = _dragAndDropConsolesMegaDrive;
			}
			else if (name == "Atari") {
				copy = _dragAndDropConsolesAtari;
			}
			else if (name == "C64") {
				copy = _dragAndDropConsolesC64;
			}
			else if (name == "SegaSaturn") {
				copy = _dragAndDropConsolesSegaStaurn;
			}
			else if (name == "Magnavox") {
				copy = _dragAndDropConsolesMagnavox;
			}
			else if (name == "Tennis") {
				copy = _dragTennis;
			}
			else if (name == "Pong") {
				copy = _dragPong;
			}
			else if (name == "MazeWars") {
				copy = _dragMazeWars;
			}
			else if (name == "SpaceInvaders") {
				copy = _dragSpaceInvaders;
			}
			else if (name == "PacMan") {
				copy = _dragPacMan;
			}
			else if (name == "DonkeyKong") {
				copy = _dragDonkeyKong;
			}
			else if (name == "Bioshock") {
				copy = _dragBioshock;
			}
			else if (name == "Horizon") {
				copy = _dragHorizon;
			}
			else if (name == "Starfield") {
				copy = _dragStarfield;
			}
			else if (name == "Detriot") {
				copy = _dragDetriot;
			}
			else if (name == "Stray") {
				copy = _dragStray;
			}
			else if (name == "Cyberpunk") {
				copy = _dragCyberpunk;
			}
		
			if (copy != null) {
				copy.ChangePosition(position);
			}
		}
	}
	private void _on_Magnavox_body_entered(object body)
	{
		if (body is KinematicBody2D kinematicBody && magnavoxEntered == false && consolesVisible == true) {
			magnavoxCopy = kinematicBody.Name;
			magnavoxEntered = true;
		}
	}


	private void _on_Magnavox_body_exited(object body)
	{
		if (body is KinematicBody2D kinematicBody && kinematicBody.Name == magnavoxCopy && consolesVisible == true) {
			magnavoxEntered = false;
		}
	}


	private void _on_GameBoy_body_entered(object body)
	{
		if (body is KinematicBody2D kinematicBody && gameBoyEntered == false && consolesVisible == true) {
			gameboyNameCopy = kinematicBody.Name;
			gameBoyEntered = true;
		}
	}


	private void _on_GameBoy_body_exited(object body)
	{
		if (body is KinematicBody2D kinematicBody && kinematicBody.Name == gameboyNameCopy && consolesVisible == true) {
			gameBoyEntered = false;
		}
	}


	private void _on_C64_body_entered(object body)
	{
		if (body is KinematicBody2D kinematicBody && c64Entered == false && consolesVisible == true) {
			c64NameCopy = kinematicBody.Name;
			c64Entered = true;
		}
	}


	private void _on_C64_body_exited(object body)
	{
		if (body is KinematicBody2D kinematicBody && kinematicBody.Name == c64NameCopy && consolesVisible == true) {
			c64Entered = false;
		}
	}


	private void _on_Atari_body_entered(object body)
	{
		if (body is KinematicBody2D kinematicBody && atariEntered == false && consolesVisible == true) {
			atariNameCopy = kinematicBody.Name;
			atariEntered = true;
		}
	}


	private void _on_Atari_body_exited(object body)
	{
		if (body is KinematicBody2D kinematicBody && kinematicBody.Name == atariNameCopy && consolesVisible == true) {
			atariEntered = false;
		}
	}


	private void _on_SegaSaturn_body_entered(object body)
	{
		if (body is KinematicBody2D kinematicBody && segaSaturnEntered == false && consolesVisible == true) {
			segaSaturnNameCopy = kinematicBody.Name;
			segaSaturnEntered = true;
		}
	}


	private void _on_SegaSaturn_body_exited(object body)
	{
		if (body is KinematicBody2D kinematicBody && kinematicBody.Name == segaSaturnNameCopy && consolesVisible == true) {
			segaSaturnEntered = false;
		}
	}


	private void _on_NES_body_entered(object body)
	{
		if (body is KinematicBody2D kinematicBody && nesEntered == false && consolesVisible == true) {
			nesNameCopy = kinematicBody.Name;
			nesEntered = true;
		}
	}


	private void _on_NES_body_exited(object body)
	{
		if (body is KinematicBody2D kinematicBody && kinematicBody.Name == nesNameCopy && consolesVisible == true) { 
			nesEntered = false;
		}
	}
	
	//Games
	
	private void _on_Tennis_body_entered(object body) {
		if (body is KinematicBody2D kinematicBody && tennisEntered == false && consolesVisible == false) {
			tennisNameCopy = kinematicBody.Name;
			tennisEntered = true;
		}
	}
	
	private void _on_Tennis_body_exited(object body) {
		if (body is KinematicBody2D kinematicBody && kinematicBody.Name == tennisNameCopy && consolesVisible == false) { 
			tennisEntered = false;
		}
	}
	
	private void _on_Pong_body_entered(object body) {
		if (body is KinematicBody2D kinematicBody && pongEntered == false && consolesVisible == false) {
			pongNameCopy = kinematicBody.Name;
			pongEntered = true;
		}
	}
	
	private void _on_Pong_body_exited(object body) {
		if (body is KinematicBody2D kinematicBody && kinematicBody.Name == pongNameCopy && consolesVisible == false) { 
			pongEntered = false;
		}
	}
	
	private void _on_MazeWars_body_entered(object body) {
		if (body is KinematicBody2D kinematicBody && mazeWarsEntered == false && consolesVisible == false) {
			mazeWarsNameCopy = kinematicBody.Name;
			mazeWarsEntered = true;
		}
	}

	private void _on_MazeWars_body_exited(object body) {
		if (body is KinematicBody2D kinematicBody && kinematicBody.Name == mazeWarsNameCopy && consolesVisible == false) { 
			mazeWarsEntered = false;
		}
	}

	private void _on_SpaceInvaders_body_entered(object body) {
		if (body is KinematicBody2D kinematicBody && spaceInvadersEntered == false && consolesVisible == false) {
			spaceInvadersNameCopy = kinematicBody.Name;
			spaceInvadersEntered = true;
		}
	}
	
	private void _on_SpaceInvaders_body_exited(object body) {
		if (body is KinematicBody2D kinematicBody && kinematicBody.Name == spaceInvadersNameCopy && consolesVisible == false) { 
			spaceInvadersEntered = false;
		}
	}
	
	private void _on_PacMan_body_entered(object body) {
		if (body is KinematicBody2D kinematicBody && pacManEntered == false && consolesVisible == false) {
			pacManNameCopy = kinematicBody.Name;
			pacManEntered = true;
		}
	}
	
	private void _on_PacMan_body_exited(object body) {
		if (body is KinematicBody2D kinematicBody && kinematicBody.Name == pacManNameCopy && consolesVisible == false) { 
			pacManEntered = false;
		}
	}
	
	private void _on_DonkeyKong_body_entered(object body) {
		if (body is KinematicBody2D kinematicBody && donkeyKongEntered == false && consolesVisible == false) {
			donkeyKongNameCopy = kinematicBody.Name;
			donkeyKongEntered = true;
		}
	}

	private void _on_DonkeyKong_body_exited(object body) {
		if (body is KinematicBody2D kinematicBody && kinematicBody.Name == donkeyKongNameCopy && consolesVisible == false) { 
			donkeyKongEntered = false;
		}
	}
	
	private void _on_Bioshock_body_entered(object body) {
		if (body is KinematicBody2D kinematicBody && bioshockEntered == false && consolesVisible == false) {
			bioshockNameCopy = kinematicBody.Name;
			bioshockEntered = true;
		}
	}

	private void _on_Bioshock_body_exited(object body) {
		if (body is KinematicBody2D kinematicBody && kinematicBody.Name == bioshockNameCopy && consolesVisible == false) { 
			bioshockEntered = false;
		}
	}

	private void _on_Starfield_body_entered(object body) {
		if (body is KinematicBody2D kinematicBody && starfieldEntered == false && consolesVisible == false) {
			starfieldNameCopy = kinematicBody.Name;
			starfieldEntered = true;
		}
	}
	
	private void _on_Starfield_body_exited(object body) {
		if (body is KinematicBody2D kinematicBody && kinematicBody.Name == starfieldNameCopy && consolesVisible == false) { 
			starfieldEntered = false;
		}
	}

	private void _on_Herizon_body_entered(object body) {
		if (body is KinematicBody2D kinematicBody && horizonEntered == false && consolesVisible == false) {
			horizonNameCopy = kinematicBody.Name;
			horizonEntered = true;
		}
	}

	private void _on_Herizon_body_exited(object body) {
		if (body is KinematicBody2D kinematicBody && kinematicBody.Name == horizonNameCopy && consolesVisible == false) { 
			horizonEntered = false;
		}
	}

	private void _on_Detriot_body_entered(object body) {
		if (body is KinematicBody2D kinematicBody && detriotEntered == false && consolesVisible == false) {
			detriotNameCopy = kinematicBody.Name;
			detriotEntered = true;
		}
	}

	private void _on_Detriot_body_exited(object body) {
		if (body is KinematicBody2D kinematicBody && kinematicBody.Name == detriotNameCopy && consolesVisible == false) { 
			detriotEntered = false;
		}
	}

	private void _on_Stray_body_entered(object body) {
		if (body is KinematicBody2D kinematicBody && strayEntered == false && consolesVisible == false) {
			strayNameCopy = kinematicBody.Name;
			strayEntered = true;
		}
	}

	private void _on_Stray_body_exited(object body) {
		if (body is KinematicBody2D kinematicBody && kinematicBody.Name == strayNameCopy && consolesVisible == false) { 
			strayEntered = false;
		}
	}

	private void _on_Cyberpunk_body_entered(object body) {
		if (body is KinematicBody2D kinematicBody && cyberpunkEntered == false && consolesVisible == false) {
			cyberpunkNameCopy = kinematicBody.Name;
			cyberpunkEntered = true;
		}
	}

	private void _on_Cyberpunk_body_exited(object body) {
		if (body is KinematicBody2D kinematicBody && kinematicBody.Name == cyberpunkNameCopy && consolesVisible == false) { 
			cyberpunkEntered = false;
		}
	}
}








