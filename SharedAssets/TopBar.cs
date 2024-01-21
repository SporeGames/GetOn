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
	private TextureButton _bigCloseButton;
	private Node2D _introduction;
	private Sprite _introImage;
	private Sprite _rightSideImage;
	private Sprite _leftSideImage;
	private ColorRect _backgroundColor;
	private RichTextLabel _introDescription;
	private RichTextLabel _introImageCaption;
	private CountdownTimer _timer;
	private bool _wasHelpButtonPressed = false;
	
	public override void _Ready() {
		_helpButton = GetNode<TextureButton>("HelpButton");
		_shared = GetNode<SharedNode>("/root/SharedNode");
		_helpButton.Connect("pressed", this, nameof(OnHelpButtonPressed));
		_closeButton = GetNode<TextureButton>("Introduction/CloseButton");
		_closeButton.Connect("pressed", this, nameof(OnCloseButtonPressed));
		_bigCloseButton = GetNode<TextureButton>("Introduction/BigCloseButton");
		_bigCloseButton.Connect("pressed", this, nameof(OnBigCloseButtonPressed));
		_timer = GetNode<CountdownTimer>("Timer");
		_introduction = GetNode<Node2D>("Introduction");
		_introImage = GetNode<Sprite>("Introduction/Image");
		_rightSideImage = GetNode<Sprite>("Introduction/RightSide");
		_leftSideImage = GetNode<Sprite>("Introduction/LeftSide");
		_backgroundColor = GetNode<ColorRect>("Introduction/BackgroundColor");
		_introDescription = GetNode<RichTextLabel>("Introduction/Text");
		_introImageCaption = GetNode<RichTextLabel>("Introduction/ImageCaption");
		_introImage.Texture = HelpImage;
		_introDescription.BbcodeText = Description;
		_introImageCaption.Text = ImageCaption;
		_leftSideImage.Texture = LeftImage;
		_rightSideImage.Texture = RightImage;
		_leftSideImage.Visible = false;
		GetNode<Node2D>("Introduction").Visible = true; // Do this so we can still see the scene lol
		_bigCloseButton.Visible = false; // We don't want to see this yet
	}
	
	private void OnBigCloseButtonPressed() {
		_wasHelpButtonPressed = false;
		OnHelpButtonPressed();
	}

	private void OnHelpButtonPressed() {
		if (_introduction.Visible) {
			_introduction.Visible = false;
			_wasHelpButtonPressed = false;
			return;
		}
		_bigCloseButton.Visible = true;
		_wasHelpButtonPressed = true;
		_leftSideImage.Visible = true;
		_introduction.Visible = true;
		_rightSideImage.Visible = false;
		_closeButton.Visible = false;
		_introImage.Visible = false;
		_backgroundColor.Modulate = new Color(0.33f, 0.33f, 0.33f, 0.4f);
		if (!_shared.HelpButtonPressed.ContainsKey(Game)) {
			_shared.HelpButtonPressed.Add(Game, 1);
		}
		else {
			_shared.HelpButtonPressed[Game] += 1;
		}
		GetNode<SharedNode>("/root/SharedNode").PlayGenericClick();
	}
	
	private void OnCloseButtonPressed() {
		_introduction.Visible = false;
		_timer.running = true;
		GetViewport().SetInputAsHandled();
		GetNode<SharedNode>("/root/SharedNode").PlayGenericClick();
	}
}
