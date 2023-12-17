using Godot;
using System;
using System.Collections.Generic;
using GetOn.scenes.GameDesign;

public class GameDesignSlider : Control {

	private TextureButton _leftButton;
	private TextureButton _rightButton;
	private TextureButton _doneButton;
	private TextureButton _backButton;
	private TextureButton _selectButton;
	private TextureRect _centerImage;
	private RichTextLabel _centerTitle;
	private RichTextLabel _description;
	private RichTextLabel _motivation;
	private RichTextLabel _gameName;
	private RichTextLabel _gameDescription;
	private TextureRect _gameImage;
	private RichTextLabel _selectedText;

	[Export] public Texture[] Images;
	[Export] public string[] PersonaNames;
	[Export] public string[] Descriptions;
	[Export] public string[] PersonaMotivations;
	[Export] public GameDesignGame Game;
	[Export] public string CategoryDisplayName;
	[Export] public bool IsSingleSelect = false;
	[Export(PropertyHint.MultilineText)] public string GameDescription;
	[Export] public Texture GameImage;
	[Export] public string[] ValidPersonas;
	[Export] public Texture CheckboxChecked;
	[Export] public Texture CheckboxUnchecked;
	
	private int _currentIndex = 0;
	
	private List<string> _selectedValues = new List<string>();
	
	 
	public override void _Ready() {
		_leftButton = GetNode<TextureButton>("LeftButton");
		_rightButton = GetNode<TextureButton>("RightButton");
		_doneButton = GetNode<TextureButton>("DoneButton");
		_backButton = GetNode<TextureButton>("BackButton");
		_selectButton = GetNode<TextureButton>("SelectButton");
		_centerImage = GetNode<TextureRect>("CenterImage");
		_centerTitle = GetNode<RichTextLabel>("SliderTitle");
		_description = GetNode<RichTextLabel>("DescriptionText");
		_motivation = GetNode<RichTextLabel>("MotivationsText");
		_gameName = GetNode<RichTextLabel>("GameName");
		_gameDescription = GetNode<RichTextLabel>("GameDescription");
		_gameImage = GetNode<TextureRect>("GameImage");
		_selectedText = GetNode<RichTextLabel>("Selected");
		_leftButton.Connect("pressed", this, nameof(TurnLeft));
		_rightButton.Connect("pressed", this, nameof(TurnRight));
		_doneButton.Connect("pressed", this, nameof(OnDonePressed));
		_selectButton.Connect("pressed", this, nameof(OnSelectPressed));
		_backButton.Connect("pressed", this, nameof(OnBackPressed));
		_gameName.Text = CategoryDisplayName;
		_gameDescription.Text = GameDescription;
		_gameImage.Texture = GameImage;
		_selectButton.ToggleMode = true;
		UpdateSlider(); // Update it once to set the initial values so its not empty
	}

	private void OnDonePressed() {
		GetParent<GameDesign>().NextSliderPressed(Game, _selectedValues.ToArray());
	}
	
	private void OnBackPressed() {
		GetParent<GameDesign>().PreviousSliderPressed(Game);
	}

	private void OnSelectPressed() {
		if (_selectedValues.Contains(_centerTitle.Text)) {
			_selectedValues.Remove(_centerTitle.Text);
			_selectButton.TextureNormal = CheckboxUnchecked;
		} else {
			if (IsSingleSelect) {
				_selectedValues.Clear();
			}
			_selectedValues.Add(_centerTitle.Text);
			_selectButton.TextureNormal = CheckboxChecked;
		} 
		UpdateSelectedText(); 
	}
	
	private void TurnLeft() {
		_currentIndex--;
		if (_currentIndex < 0) {
			_currentIndex = PersonaNames.Length - 1;
		}
		UpdateSlider();
	}
	
	private void TurnRight() {
		_currentIndex++;
		if (_currentIndex >= PersonaNames.Length) {
			_currentIndex = 0;
		}
		UpdateSlider();
	}

	private void UpdateSlider() {
		if (_currentIndex < Images.Length && _currentIndex >= 0) {
			_centerImage.Texture = Images[_currentIndex];
		}

		_centerTitle.Text = PersonaNames[_currentIndex];
		_description.Text = Descriptions[_currentIndex];
		_motivation.Text = PersonaMotivations[_currentIndex];
		var leftIndex = _currentIndex - 1;
		if (leftIndex < 0) {
			leftIndex = PersonaNames.Length - 1;
		}
		var rightIndex = _currentIndex + 1;
		if (rightIndex >= PersonaNames.Length) {
			rightIndex = 0;
		}
		_selectButton.TextureNormal = _selectedValues.Contains(_centerTitle.Text) ? CheckboxChecked : CheckboxUnchecked; 
	}

	private void UpdateSelectedText() {
		var text = "";
		foreach (var str in _selectedValues) {
			text += "- " + str + "\n";
		}
		_selectedText.Text = text;
	}
	
}
