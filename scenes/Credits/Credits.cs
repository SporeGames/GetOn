using Godot;
using System;
using GetOn.scenes;

public class Credits : Node2D {
    
    private TextureButton _printButton;
    private TextureButton _creditsButton;
    
    public override void _Ready() {
        _printButton = GetNode<TextureButton>("PrintButton");
        _creditsButton = GetNode<TextureButton>("CreditsButton");
        _printButton.Connect("pressed", this, nameof(OnPrintButtonPressed));
        _creditsButton.Connect("pressed", this, nameof(OnCreditsButtonPressed));
        
    }
    
    private void OnPrintButtonPressed() {
        GetNode<SharedNode>("/root/SharedNode").Print();
    }
    
    private void OnCreditsButtonPressed() {
        GetNode<SharedNode>("/root/SharedNode").SwitchScene("res://scenes/Credits/ScrollingCredits.tscn");
    }


}
