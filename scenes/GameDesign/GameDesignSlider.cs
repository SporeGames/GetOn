using Godot;
using System;
using System.Collections.Generic;
using GetOn.scenes.GameDesign;

public class GameDesignSlider : Control {

	private Button _leftButton;
	private Button _rightButton;
	private Button _doneButton;
	private Button _selectButton;
	private TextureRect _leftImage;
	private RichTextLabel _leftText;
	private TextureRect _rightImage;
	private RichTextLabel _rightText;
	private TextureRect _centerImage;
	private RichTextLabel _centerTitle;
	private RichTextLabel _description;
	private RichTextLabel _categoryTitle;

	[Export] public Texture[] Images;
	[Export] public string[] Titles;
	[Export] public string[] Descriptions;
	[Export] public GameDesignCategory Category;
	[Export] public string CategoryDisplayName;
	[Export] public bool IsSingleSelect = false;
	
	private int _currentIndex = 0;
	
	private List<string> _selectedValues = new List<string>();
	
	 
	public override void _Ready() {
		_leftButton = GetNode<Button>("LeftButton");
		_rightButton = GetNode<Button>("RightButton");
		_doneButton = GetNode<Button>("DoneButton");
		_selectButton = GetNode<Button>("SelectButton");
		_leftImage = GetNode<TextureRect>("LeftImage");
		_leftText = GetNode<RichTextLabel>("LeftText");
		_rightImage = GetNode<TextureRect>("RightImage");
		_rightText = GetNode<RichTextLabel>("RightText");
		_centerImage = GetNode<TextureRect>("CenterImage");
		_centerTitle = GetNode<RichTextLabel>("SliderTitle");
		_description = GetNode<RichTextLabel>("DescriptionText");
		_categoryTitle = GetNode<RichTextLabel>("CategoryTitle");
		_leftButton.Connect("pressed", this, nameof(TurnLeft));
		_rightButton.Connect("pressed", this, nameof(TurnRight));
		_doneButton.Connect("pressed", this, nameof(OnDonePressed));
		_selectButton.Connect("pressed", this, nameof(OnSelectPressed));
		_categoryTitle.Text = CategoryDisplayName;
		UpdateSlider(); // Update it once to set the initial values so its not empty
	}
	
	private void OnDonePressed() {
		GetParent<GameDesign>().NextSliderPressed(Category, _selectedValues.ToArray());
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
		_centerTitle.Text = Titles[_currentIndex];
		_description.Text = Descriptions[_currentIndex];
		var leftIndex = _currentIndex - 1;
		if (leftIndex < 0) {
			leftIndex = Images.Length - 1;
		}
		_leftImage.Texture = Images[leftIndex];
		_leftText.Text = Titles[leftIndex];
		var rightIndex = _currentIndex + 1;
		if (rightIndex >= Images.Length) {
			rightIndex = 0;
		}
		_rightImage.Texture = Images[rightIndex];
		_rightText.Text = Titles[rightIndex];
		if (_selectedValues.Contains(_centerTitle.Text)) {
			_selectButton.Text = "Deselect";
		} else {
			_selectButton.Text = "Select";
		} 
	}
	
}
