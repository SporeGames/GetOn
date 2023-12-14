using Godot;
using System;
using System.Collections.Generic;
using GetOn.scenes.GameDesign;

public class GameDesignSlider : Control {

	private Button _leftButton;
	private Button _rightButton;
	private Button _doneButton;
	private Button _selectButton;
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
	[Export] public string GameDescription;
	[Export] public Texture GameImage;
	[Export] public string[] ValidPersonas;
	
	private int _currentIndex = 0;
	
	private List<string> _selectedValues = new List<string>();
	
	 
	public override void _Ready() {
		_leftButton = GetNode<Button>("LeftButton");
		_rightButton = GetNode<Button>("RightButton");
		_doneButton = GetNode<Button>("DoneButton");
		_selectButton = GetNode<Button>("SelectButton");
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
		_gameName.Text = CategoryDisplayName;
		_gameDescription.Text = GameDescription;
		_gameImage.Texture = GameImage;
		_selectButton.ToggleMode = true;
		UpdateSlider(); // Update it once to set the initial values so its not empty
	}
	
	private void OnDonePressed() {
		GetParent<GameDesign>().NextSliderPressed(Game, _selectedValues.ToArray());
	}

	private void OnSelectPressed() {
		if (_selectedValues.Contains(_centerTitle.Text)) {
			_selectedValues.Remove(_centerTitle.Text);
			_selectButton.Text = "Select";
		} else {
			if (IsSingleSelect) {
				_selectedValues.Clear();
			}
			_selectedValues.Add(_centerTitle.Text);
			_selectButton.Text = "Deselect";
		} 
		UpdateSelectedText(); 
	}
	
	private void TurnLeft() {
		_currentIndex--;
		if (_currentIndex < 0) {
			_currentIndex = Images.Length - 1;
		}
		UpdateSlider();
	}
	
	private void TurnRight() {
		_currentIndex++;
		if (_currentIndex >= Images.Length) {
			_currentIndex = 0;
		}
		UpdateSlider();
	}

	private void UpdateSlider() {
		_centerImage.Texture = Images[_currentIndex];
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
		if (_selectedValues.Contains(_centerTitle.Text)) {
			_selectButton.Text = "Deselect";
			_selectButton.Pressed = true;
		} else {
			_selectButton.Text = "Select";
			_selectButton.Pressed = false;
		} 
	}

	private void UpdateSelectedText() {
		var text = "";
		foreach (var str in _selectedValues) {
			text += "- " + str + "\n";
		}
		_selectedText.Text = text;
	}
	
}
