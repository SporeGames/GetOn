using Godot;
using System.Collections.Generic;
using System.Linq;
using GetOn.scenes;
using GetOn.scenes.GameDesign;

public class GameDesign : Control {
    
    private PlayerProfile _selectedProfile;
    private Button _selectFirst;
    private Button _selectSecond;
    private Button _selectThird;
    [Export] private Node2D _smallProfileAnchor;
    private Button _expandSmallProfileButton;
    private Button _startGameCreationButton;
    private List<PlayerProfile> _profiles = new List<PlayerProfile>();
    
    private GameDesignSlider _genreSlider;
    private GameDesignSlider _mechanicSlider;
    private GameDesignSlider _featureSlider;
    private GameDesignSlider _gameplayExperienceSlider;

    private Color _defaultBackgroundColor;
    private bool _isExpanded = false;
    private GameDesignCategory _currentCategory;
    private Godot.Collections.Dictionary<GameDesignCategory, string[]> _selectedValues = new Godot.Collections.Dictionary<GameDesignCategory, string[]>();
    
    public override void _Ready() {
        foreach (var child in GetNode("PersonaHolder").GetChildren()) {
            if (child is PlayerProfile profile) {
                _profiles.Add(profile);
            }
        }
        _defaultBackgroundColor = _profiles[0].Background.Color;
        _selectFirst = GetNode<Button>("PersonaHolder/SelectFirst");
        _selectSecond = GetNode<Button>("PersonaHolder/SelectSecond");
        _selectThird = GetNode<Button>("PersonaHolder/SelectThird");
        _selectFirst.Connect("pressed", this, nameof(OnSelectButtonPressed), new Godot.Collections.Array {0});
        _selectSecond.Connect("pressed", this, nameof(OnSelectButtonPressed), new Godot.Collections.Array {1});
        _selectThird.Connect("pressed", this, nameof(OnSelectButtonPressed), new Godot.Collections.Array {2});
        _expandSmallProfileButton = GetNode<Button>("ExpandSmallProfileButton");
        _expandSmallProfileButton.Connect("pressed", this, nameof(OnExpandSmallProfileButtonPressed));
        _smallProfileAnchor = GetNode<Node2D>("SmallProfileAnchor");
        _startGameCreationButton = GetNode<Button>("PersonaHolder/StartGameCreationButton");
        _startGameCreationButton.Connect("pressed", this, nameof(OnStartGameCreationButtonPressed));
        _genreSlider = GetNode<GameDesignSlider>("GenreSlider");
        _mechanicSlider = GetNode<GameDesignSlider>("MechanicSlider");
        _featureSlider = GetNode<GameDesignSlider>("FeatureSlider");
        _gameplayExperienceSlider = GetNode<GameDesignSlider>("GExpSlider");
    }

    private void OnStartGameCreationButtonPressed() {
        foreach (var node in GetNode("PersonaHolder").GetChildren()) {
            if (node is Control control) {
                control.Visible = false;
            }
        }
        _genreSlider.Visible = true;
        _currentCategory = GameDesignCategory.GENRE;
        _expandSmallProfileButton.Visible = true;
    }

    private void OnExpandSmallProfileButtonPressed() {
        if (!_isExpanded) {
            _selectedProfile.Visible = true;
            _selectedProfile.RectGlobalPosition = _smallProfileAnchor.GlobalPosition;
            _selectedProfile.RectScale = new Vector2(0.3f, 0.3f);
            _selectedProfile.Background.Color = _defaultBackgroundColor; // Color is carried over from selection earlier
            _expandSmallProfileButton.Text = "Collapse Persona";
            _isExpanded = true;
        }
        else {
            _selectedProfile.Visible = false;
            _expandSmallProfileButton.Text = "Expand Persona";
            _isExpanded = false;
        }
    }
    
    public void OnSelectButtonPressed(int index) {
        _selectedProfile = _profiles[index];
        //GetNode<Control>("PersonaHolder").Visible = false;
        foreach (var profile in _profiles) {
            profile.Background.Color = _defaultBackgroundColor;
        }
        _selectedProfile.Background.Color = new Color(0.5f, 0.5f, 0.5f);
        _startGameCreationButton.Disabled = false;
    }

    public void NextSliderPressed(GameDesignCategory category, string[] values) {
        _selectedValues[category] = values;
        switch (category) {
            case GameDesignCategory.GENRE:
                _genreSlider.Visible = false;
                _mechanicSlider.Visible = true;
                _currentCategory = GameDesignCategory.MECHANIC;
                break;
            case GameDesignCategory.MECHANIC:
                _mechanicSlider.Visible = false;
                _featureSlider.Visible = true;
                _currentCategory = GameDesignCategory.FEATURE;
                break;
            case GameDesignCategory.FEATURE:
                _featureSlider.Visible = false;
                _gameplayExperienceSlider.Visible = true;
                _currentCategory = GameDesignCategory.GAMEPLAY_EXPERIENCE;
                break;
            case GameDesignCategory.GAMEPLAY_EXPERIENCE:
                _gameplayExperienceSlider.Visible = false;
                GoBackAndCalculateResults();
                break;
        }
    }

    public void GoBackAndCalculateResults() {
        var points = 0;
        if (_selectedProfile.ValidGenres.Intersect(_selectedValues[GameDesignCategory.GENRE]).Any()) {
            points += 10;
        }
        if (_selectedProfile.ValidMechanics.Intersect(_selectedValues[GameDesignCategory.MECHANIC]).Any()) {
            points += 10;
        }
        if (_selectedProfile.ValidFeatures.Intersect(_selectedValues[GameDesignCategory.FEATURE]).Any()) {
            points += 10;
        }
        if (_selectedProfile.ValidGameplayExperiences.Intersect(_selectedValues[GameDesignCategory.GAMEPLAY_EXPERIENCE]).Any()) {
            points += 10;
        }
        GetNode<SharedNode>("/root/SharedNode").gameDesignPoints = points;
        GetNode<SharedNode>("/root/SharedNode").SwitchScene("res://scenes/GameSelectionRoom/GameSelectionRoom.tscn");
    }
}
