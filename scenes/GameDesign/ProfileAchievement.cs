using Godot;
using System;

public class ProfileAchievement : Control {

public void Achievement(string name, Texture texture, string description) {
	GetNode<RichTextLabel>("AchievName").RectMinSize = new Vector2(400, 50);
	GetNode<RichTextLabel>("AchievName").BbcodeText = "[center]" + name;
	GetNode<RichTextLabel>("AchievDescription").RectMinSize = new Vector2(400, 50);
	GetNode<RichTextLabel>("AchievDescription").BbcodeText = "[center]" + description;
	GetNode<TextureRect>("AchievImage").Texture = texture;
	HintTooltip = description;
}
	
}
