using Godot;
using System;
using System.Collections.Generic;
using GetOn.scenes.GameDesign;

public class GameDesignSlider : Node2D {
	private TextureButton _leftButton;
	private TextureButton _rightButton;
//	private TextureButton _doneButton;
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
	private VBoxContainer _selectedImagesContainer;
//	private int counter = 0;
//	private int maxPressCount = 2;


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
	[Export] public string[] ALittleBitValidPersonas;
	[Export] public Texture CheckboxChecked;
	[Export] public Texture CheckboxUnchecked;


	private int _currentIndex = 0;

	private List<string> _selectedValues = new List<string>();


	public override void _Ready()
	{
		_leftButton = GetNode<TextureButton>("LeftButton");
		_rightButton = GetNode<TextureButton>("RightButton");
//		_doneButton = GetNode<TextureButton>("DoneButton");
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
		_selectedImagesContainer = GetNode<VBoxContainer>("ScrollContainer/SelectedImagesContainer");
		GetNode<TextureButton>("NextButton").Connect("pressed", this, "_OnNextButtonPressed");
		GetNode<TextureButton>("BackButton").Connect("pressed", this, "_OnBackButtonPressed");


		_leftButton.Connect("pressed", this, nameof(TurnLeft));
		_rightButton.Connect("pressed", this, nameof(TurnRight));
//		_doneButton.Connect("pressed", this, nameof(OnDonePressed));
		_selectButton.Connect("pressed", this, nameof(OnSelectPressed));
//		_backButton.Connect("pressed", this, nameof(OnBackPressed));
		_gameName.BbcodeText = "[center]" + CategoryDisplayName;
		_gameDescription.Text = GameDescription;
		_gameImage.Texture = GameImage;
		_selectButton.ToggleMode = true;
		UpdateSlider(); // Update it once to set the initial values so its not empty
	}

//	private void OnDonePressed()
//	{
//		GetParent<GameDesign>().NextSliderPressed(Game, _selectedValues.ToArray());
//	}
//
//	private void OnBackPressed()
//	{
//		GetParent<GameDesign>().PreviousSliderPressed(Game);
//	}

	private void OnSelectPressed()
	{
		if (_selectedValues.Contains(_centerTitle.Text))
		{
			_selectedValues.Remove(_centerTitle.Text);
			_selectButton.TextureNormal = CheckboxUnchecked;
		}
		else
		{
			if (IsSingleSelect)
			{
				_selectedValues.Clear();
			}

			_selectedValues.Add(_centerTitle.Text);
			_selectButton.TextureNormal = CheckboxChecked;
		}

		UpdateSelectedText();
	}

	private void TurnLeft()
	{
		_currentIndex--;
		if (_currentIndex < 0)
		{
			_currentIndex = PersonaNames.Length - 1;
		}

		UpdateSlider();
	}

	private void TurnRight()
	{
		_currentIndex++;
		if (_currentIndex >= PersonaNames.Length)
		{
			_currentIndex = 0;
		}

		UpdateSlider();
	}

	private void UpdateSlider()
	{
		if (_currentIndex < Images.Length && _currentIndex >= 0)
		{
			_centerImage.Texture = Images[_currentIndex];
		}

		_centerTitle.BbcodeText = "[center]" + PersonaNames[_currentIndex];
		_description.Text = Descriptions[_currentIndex];
		_motivation.BbcodeText = "[center]" + PersonaMotivations[_currentIndex];
		var leftIndex = _currentIndex - 1;
		if (leftIndex < 0)
		{
			leftIndex = PersonaNames.Length - 1;
		}

		var rightIndex = _currentIndex + 1;
		if (rightIndex >= PersonaNames.Length)
		{
			rightIndex = 0;
		}

		_selectButton.TextureNormal = _selectedValues.Contains(_centerTitle.Text) ? CheckboxChecked : CheckboxUnchecked;
	}

	// Modify the UpdateSelectedText function
	private void UpdateSelectedText()
	{
		// Get a list of all existing TextureRect nodes in the container
		List<TextureRect> existingImages = new List<TextureRect>();
		foreach (Node child in _selectedImagesContainer.GetChildren())
		{
			if (child is TextureRect textureRect)
			{
				existingImages.Add(textureRect);
			}
		}


		foreach (var selectedValue in _selectedValues)
		{
			// Check if the TextureRect already exists
			TextureRect selectedImage = existingImages.Find(image => image.Name == selectedValue);


			// If TextureRect doesn't exist, create a new one
			if (selectedImage == null)
			{
				selectedImage = new TextureRect();
				selectedImage.Name = selectedValue; // Set the name to identify it later
				selectedImage.Texture =
					Images[Array.IndexOf(PersonaNames, selectedValue)]; // Assuming PersonaNames is unique

				// Set the SizeFlags to expand
				selectedImage.SizeFlagsHorizontal = (int)Control.SizeFlags.Expand;
				selectedImage.SizeFlagsVertical = (int)Control.SizeFlags.Expand;

				// Add the TextureRect to the VBoxContainer
				_selectedImagesContainer.AddChild(selectedImage);
			}

			// Remove the existing TextureRect from the list
			existingImages.Remove(selectedImage);
		}

		// Remove any remaining TextureRect nodes that were not selected
		foreach (var remainingImage in existingImages)
		{
			remainingImage.QueueFree();
		}
	}

	private void _OnNextButtonPressed()
	{
			GetParent<GameDesign>().NextSliderPressed(Game, _selectedValues.ToArray());
	}

	private void _OnBackButtonPressed()
	{
	GetParent<GameDesign>().PreviousSliderPressed(Game);
	}

}
