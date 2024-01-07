using Godot;
using System;

public class GameStudy : Node2D
{
	private Button _openConsoles;
	private Button _openGames;
	private TextureButton _close;
	private Node2D _consoles;
	private Node2D _games;
	private Button _submit;

	public Consoles _console;
	
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
		_submit = GetNode<Button>("Submit");
		_submit.Connect("pressed", this, nameof(SubmitGame));

		_console = GetNode<Consoles>("Consoles");
	}

	public void SubmitGame()
	{
		_console.CheckifCorrect();
		
	}
	public void OpenConsoles()
	{
		_consoles.Visible = true;
		_close.Visible = true;
		_openConsoles.SetMouseFilter(Control.MouseFilterEnum.Ignore);
		_openGames.SetMouseFilter(Control.MouseFilterEnum.Ignore);
	}

	public void BackToGameStudy()
	{
		_openConsoles.SetMouseFilter(Control.MouseFilterEnum.Stop);
		_openGames.SetMouseFilter(Control.MouseFilterEnum.Stop);
		_consoles.Visible = false;
		_close.Visible = false;
		_games.Visible = false;
		
	}

	public void OpenGames()
	{
		_games.Visible = true;
		_close.Visible = true;
		_openGames.SetMouseFilter(Control.MouseFilterEnum.Ignore);
		_openConsoles.SetMouseFilter(Control.MouseFilterEnum.Ignore);
	}
}
