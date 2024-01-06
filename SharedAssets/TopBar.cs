using Godot;
using System;
using GetOn.scenes;

public class TopBar : Node2D {

	[Export] public AbilitySpecialization Game;
	[Export] public string Title;
	[Export] public string ImageCaption;
	[Export] public Texture LeftImage;
	[Export] public Texture RightImage;
	[Export] public Texture HelpImage;
	[Export(PropertyHint.MultilineText)] public string Description;

	private SharedNode _shared;
	private TextureButton _helpButton;
	private TextureButton _closeButton;
	private Node2D _introduction;
	private Sprite _introImage;
	private Sprite _rightSideImage;
	private Sprite _leftSideImage;
	private ColorRect _backgroundColor;
	private RichTextLabel _introDescription;
	private RichTextLabel _introImageCaption;
	private CountdownTimer _timer;
	
	public override void _Ready() {
		_helpButton = GetNode<TextureButton>("HelpButton");
		_shared = GetNode<SharedNode>("/root/SharedNode");
		_helpButton.Connect("pressed", this, nameof(OnHelpButtonPressed));
		_closeButton = GetNode<TextureButton>("Introduction/CloseButton");
		_closeButton.Connect("pressed", this, nameof(OnCloseButtonPressed));
		_timer = GetNode<CountdownTimer>("Timer");
		_introduction = GetNode<Node2D>("Introduction");
		_introImage = GetNode<Sprite>("Introduction/Image");
		_rightSideImage = GetNode<Sprite>("Introduction/RightSide");
		_leftSideImage = GetNode<Sprite>("Introduction/LeftSide");
		_backgroundColor = GetNode<ColorRect>("Introduction/BackgroundColor");
		_introDescription = GetNode<RichTextLabel>("Introduction/Text");
		_introImageCaption = GetNode<RichTextLabel>("Introduction/ImageCaption");
		_introImage.Texture = HelpImage;
		_introDescription.Text = Description;
		_introImageCaption.Text = ImageCaption;
		_leftSideImage.Texture = LeftImage;
		_rightSideImage.Texture = RightImage;
		GetNode<Node2D>("Introduction").Visible = true; // Do this so we can still see the scene lol
	}

	private void OnHelpButtonPressed() {
		if (_introduction.Visible) {
			_introduction.Visible = false;
			return;
		}
		_introduction.Visible = true;
		_rightSideImage.Visible = false;
		_closeButton.Visible = false;
		_backgroundColor.Modulate = new Color(0.33f, 0.33f, 0.33f, 0.4f);
		if (!_shared.HelpButtonPressed.ContainsKey(Game)) {
			_shared.HelpButtonPressed.Add(Game, 1);
		}
		else {
			_shared.HelpButtonPressed[Game] += 1;
		}
		
	}
	
	private void OnCloseButtonPressed() {
		_introduction.Visible = false;
		_timer.running = true;
		GetViewport().SetInputAsHandled();
	}
}
