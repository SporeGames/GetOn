using Godot;
using System;

public class ProfileGame : Control {

    public void Game(string name, Texture texture, string description) {
        GetNode<RichTextLabel>("GameName").Text = name;
        GetNode<RichTextLabel>("GameDescription").Text = description;
        GetNode<TextureRect>("GameImage").Texture = texture;
    }
    
}
