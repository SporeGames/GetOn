using System;
using GetOn.scenes;
using Godot;
using Godot.Collections;

namespace GetOn.SharedAssets {
	public class DialogueBox : Node2D {
		[Export] public string Title; // The title of the box
		[Export] public Texture Icon; // The icon shown to the left of the box
		[Export(PropertyHint.MultilineText)] public string[] Texts = new string[1]; // The texts to show in the box
		[Export] public bool LoadSceneAfter = false; // Load a scene after all the text is shown
		[Export] public bool AutoNext = false; // Automatically go to the next text after a certain amount of time
		[Export(PropertyHint.Range, "0, 20")] public float AutoNextTime = 5; // How long to wait before the next text is shown if AutoNext is true
		[Export(PropertyHint.Range, "0.01,1.0")] public float TimePerCharacter = 0.08f; // How long to wait between each character being animated
		[Export(PropertyHint.Range, "0.01, 0.3")] public float ReadTime = 0.2f; // How long to wait after the text is done animating before the next text is shown if AutoNext is true
		[Export] public string SceneToLoad; // If LoadSceneAfter is true, this is the scene to load. Simple name is enough, e.g. "Management" to load "scenes/Management/Management.tscn"
		[Export] public int ResultThreshold = 0; // Result threshold for this dialogue box. If the player has less than this amount of points, the box will not be shown.
		[Export] public bool IsUnique = false; // If true, this box will only be shown once per game
		[Export] public string UniqueID = ""; // The name of this box. Used to check if it has been shown before.

		private RichTextLabel _text;
		private RichTextLabel _title;
		private Sprite _icon;
		private TextureButton _nextButton;
		private Timer _timer;
		private Timer _animationTimer;
		private SharedNode _sharedNode;
		
		private int _currentIndex = 1;
		private string _textToAnimate = "";
		private int _animationIndex = 0;
		private bool _isAnimating = true;
		private bool _makeArrowBlink = false;
		private bool _arrowVisible = true;
		
		public override void _Ready() {
			_text = GetNode<RichTextLabel>("Text");
			_title = GetNode<RichTextLabel>("Title");
			_icon = GetNode<Sprite>("Icon");
			_nextButton = GetNode<TextureButton>("NextButton");
			_timer = GetNode<Timer>("Timer");
			_animationTimer = GetNode<Timer>("AnimationTimer");
			_sharedNode = GetNode<SharedNode>("/root/SharedNode");
			_nextButton.Connect("pressed", this, nameof(OnNextPressed), new Godot.Collections.Array(false));
			_timer.Connect("timeout", this, nameof(OnNextPressed), new Godot.Collections.Array(true));
			_animationTimer.Connect("timeout", this, nameof(AnimateText));
			_animationTimer.WaitTime = Mathf.Clamp(((AutoNextTime / Texts[_currentIndex - 1].Length) * TimePerCharacter) - ReadTime, 0.001f, 10f);
			_title.Text = Title;
			_text.Text = "";
			_icon.Texture = Icon;
			_textToAnimate = Texts[0];
			if (_sharedNode.SeenDialogues.Contains(UniqueID)) {
				Visible = false;
				return;
			}
			if (AutoNext) {
				_timer.WaitTime = AutoNextTime;
				_timer.Start();
			}
		}

		public override void _PhysicsProcess(float delta) {
			if (_makeArrowBlink) {
				var currentModulate = _nextButton.Modulate;
				if (_arrowVisible) {
					_nextButton.Modulate = new Color(currentModulate.r, currentModulate.g, currentModulate.b, currentModulate.a - 0.02f);
					if (currentModulate.a <= 0.33f) {
						_arrowVisible = false;
					}
				}
				else {
					_nextButton.Modulate = new Color(currentModulate.r, currentModulate.g, currentModulate.b, currentModulate.a + 0.02f);
					if (currentModulate.a >= 1f) {
						_arrowVisible = true;
					}
				}
			}
		}

		private void OnNextPressed(bool timerTriggered = false) {
			if (_isAnimating) {
				_text.Text = _textToAnimate;
				_isAnimating = false;
				return;
			}
			if (_currentIndex < Texts.Length) {
				_isAnimating = true;
				_text.Text = "";
				_textToAnimate = Texts[_currentIndex];
				_makeArrowBlink = false;
				_nextButton.Modulate = new Color(1, 1, 1, 1);
				_animationTimer.WaitTime = Mathf.Clamp(((AutoNextTime / Texts[_currentIndex].Length) * TimePerCharacter) - ReadTime, 0.001f, 10f);
				_animationIndex = 0;
				_currentIndex++;
			}
			else if (!timerTriggered) {
				_sharedNode.HasDialogeBoxOpen = false;
				if (IsUnique) {
					_sharedNode.SeenDialogues.Add(UniqueID);
				}
				if (LoadSceneAfter) {
					_sharedNode.SwitchScene("res://scenes/" + SceneToLoad + "/" + SceneToLoad + ".tscn");
				}
				else {
					Visible = false;
				}
			}
		}
		
		private void AnimateText() {
			if (!_isAnimating) {
				return;
			}

			if (_textToAnimate.Length <= 0) return;
			if (_textToAnimate.Length < _animationIndex) {
				return;
			}
			_text.Text += _textToAnimate[_animationIndex];
			_animationIndex++;
			if (_animationIndex >= _textToAnimate.Length) {
				_animationIndex = 0;
				_textToAnimate = "";
				_isAnimating = false;
				_makeArrowBlink = true;
			}
		}

	}
}
