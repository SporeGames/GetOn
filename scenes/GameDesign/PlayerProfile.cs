using Godot;
using System;

public class PlayerProfile : Control {
    
    
    private PackedScene _gameScene = (PackedScene) ResourceLoader.Load("res://scenes/GameDesign/ProfileGame.tscn");
    private PackedScene _achievementScene = (PackedScene) ResourceLoader.Load("res://scenes/GameDesign/ProfileAchievement.tscn");
    
    private Control _gameContainer;
    private HFlowContainer _achievementContainer;
    private RichTextLabel _profileName;
    private RichTextLabel _profileText;
    private TextureRect _profilePicture;

    [Export] public string PlayerName = "No name";
    [Export] public string ProfileText = "No text";
    [Export] public Texture ProfilePicture;
    [Export] public Godot.Collections.Dictionary<Texture, string[]> Achievements = new Godot.Collections.Dictionary<Texture, string[]> {
        [(Texture) ResourceLoader.Load("res://icon.png")] = new []{"default", "defaultDescription"}
    };
    [Export] public Texture GameImage;
    [Export] public string GameName;
    [Export] public string GameDescription;
    
    public override void _Ready() {
        _gameContainer = GetNode<Control>("GameContainer");
        _achievementContainer = GetNode<HFlowContainer>("AchievementContainer");
        _profileName = GetNode<RichTextLabel>("ProfileName");
        _profileText = GetNode<RichTextLabel>("ProfileText");
        _profilePicture = GetNode<TextureRect>("ProfilePicture");
        SetupProfile();
        SetupAchievements();
        SetupGame();
    }
    
    private void SetupProfile() {
        _profileName.Text = PlayerName;
        _profileText.Text = ProfileText;
        _profilePicture.Texture = ProfilePicture;
    }

    private void SetupAchievements() {
        foreach (var entry in Achievements) {
            var achievement = (ProfileAchievement) _achievementScene.Instance();
            achievement.Achievement(entry.Value[0], entry.Key, entry.Value[1]);
            achievement.HintTooltip = entry.Value[1];
            _achievementContainer.AddChild(achievement);
        }
        _achievementContainer.RectScale = new Vector2(0.5f, 0.5f);
    }

    private void SetupGame() {
        var game = (ProfileGame) _gameScene.Instance();
        game.Game(GameName, GameImage, GameDescription);
        _gameContainer.AddChild(game);
    }
    
    
}
