using Godot;
using System;

public class GameStudy : Node2D
{
	private Button _openConsoles;
	private Button _openGames;
	private TextureButton _close;
	private Node2D _consoles;
	private Node2D _games;
	private TextureButton _submit;

	public Consoles _console;

	private bool consolesOpened;
	private bool gamesOpened;

	private AudioStreamPlayer _shelf;
	private AudioStreamPlayer _backButtonSound;
	
	public override void _Ready()
	{
		_openConsoles = GetNode<Button>("OpenConsoles");
		_close= GetNode<TextureButton>("Close");
		_close.Visible = false;
		_consoles = GetNode<Node2D>("Consoles");
		_openConsoles.Connect("pressed", this, nameof(OpenConsoles));
		_close.Connect("pressed", this, nameof(BackToGameStudy));
		_games = GetNode<Node2D>("Games");
		_openGames = GetNode<Button>("OpenGames");
		_openGames.Connect("pressed", this, nameof(OpenGames));
		_submit = GetNode<TextureButton>("Submit");
		_submit.Connect("pressed", this, nameof(SubmitGame));

		_console = GetNode<Consoles>("Consoles");
		_submit.Visible = false;

		_shelf = GetNode<AudioStreamPlayer>("SoundFX/ShelfClicked");
		_backButtonSound = GetNode<AudioStreamPlayer>("SoundFX/Back");
	}

	public void SubmitGame()
	{
		_console.CheckifCorrect();
		
	}
	public void OpenConsoles()
	{
		_shelf.Play();
		_consoles.Visible = true;
		_close.Visible = true;
		_openConsoles.SetMouseFilter(Control.MouseFilterEnum.Ignore);
		_openGames.SetMouseFilter(Control.MouseFilterEnum.Ignore);
		consolesOpened = true;
	}

	public void BackToGameStudy()
	{
		_backButtonSound.Play();
		_openConsoles.SetMouseFilter(Control.MouseFilterEnum.Stop);
		_openGames.SetMouseFilter(Control.MouseFilterEnum.Stop);
		_consoles.Visible = false;
		_close.Visible = false;
		_games.Visible = false;
		if (gamesOpened == true && consolesOpened == true)
			_submit.Visible = true;
	}

	public void OpenGames()
	{
		_shelf.Play();
		gamesOpened = true;
		_games.Visible = true;
		_close.Visible = true;
		_openGames.SetMouseFilter(Control.MouseFilterEnum.Ignore);
		_openConsoles.SetMouseFilter(Control.MouseFilterEnum.Ignore);
	}
}
