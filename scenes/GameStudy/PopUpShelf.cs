using Godot;
using System;

public class PopUpShelf : Node2D
{
	private Button _open;
	private Button _close;
	private Node2D _popUp;
	 private DragAndDrop _dragAndDrop;
	
	public override void _Ready()
	{
		//_dragAndDrop = GetNode<>()
		
		_open = GetNode<Button>("/root/GameStudy/OpenPopUp");
		_close = GetNode<Button>("/root/GameStudy/PopUp/ClosePopUp");
		_popUp = GetNode<Node2D>("/root/GameStudy/PopUp");

		_open.Connect("pressed", this, nameof(Open));
		_close.Connect("pressed", this, nameof(Close));
	}

	public void Open()
	{
		_popUp.Visible = true;
		_open.Visible = false;
	}

	public void Close()
	{
		_popUp.Visible = false;
		_open.Visible = true;
	}
}
