using Godot;
using System;

public class GameDesignSlider : Control {

    private Button _leftButton;
    private Button _rightButton;
    private TextureRect _leftImage;
    private RichTextLabel _leftText;
    private TextureRect _rightImage;
    private RichTextLabel _rightText;
    private TextureRect _centerImage;
    private RichTextLabel _centerTitle;
    private RichTextLabel _description;

    [Export] public Texture[] Images;
    [Export] public string[] Titles;
    [Export] public string[] Descriptions;
    
    private int _currentIndex = 0;
    
    
    public override void _Ready() {
        _leftButton = GetNode<Button>("LeftButton");
        _rightButton = GetNode<Button>("RightButton");
        _leftImage = GetNode<TextureRect>("LeftImage");
        _leftText = GetNode<RichTextLabel>("LeftText");
        _rightImage = GetNode<TextureRect>("RightImage");
        _rightText = GetNode<RichTextLabel>("RightText");
        _centerImage = GetNode<TextureRect>("CenterImage");
        _centerTitle = GetNode<RichTextLabel>("SliderTitle");
        _description = GetNode<RichTextLabel>("DescriptionText");
        _leftButton.Connect("pressed", this, nameof(TurnLeft));
        _rightButton.Connect("pressed", this, nameof(TurnRight));
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
    }
    
}
