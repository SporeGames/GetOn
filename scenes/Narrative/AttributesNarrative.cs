using Godot;
using System;

public class AttributesNarrative : Node2D
{
    //Export] public OptionButton1[] DropDownAttribute1;
   // [Export] public OptionButton2[] DropDownAttribute2;
    //[Export] public OptionButton3[] DropDownAttribute3;
    //[Export] public OptionButton4[] DropDownAttribute4;
    //[Export] public OptionButton5[] DropDownAttribute5;
    //[Export] public OptionButton6[] DropDownAttribute6;
    //[Export] public OptionButton7[] DropDownAttribute7;
    //[Export] public OptionButton8[] DropDownAttribute8;
    
    //[Export] public OptionButton9[] DropDownGenre;
    
    [Export] public string[] ValidAttributes;
    
    [Export] public Sprite CharacterIcon1;
    [Export] public Sprite CharacterIcon2;
    
    
    [Export] public string StoryName;
    //[Export] public OptionButton[] DropDownAttribute;

    public override void _Ready()
    
    {
        
        //_OptionButton1 = GetNode<OptionButton>("DropDownAttribute1");
        //_OptionButton2 = GetNode<OptionButton>("DropDownAttribute2");
        //_OptionButton3 = GetNode<OptionButton>("DropDownAttribute3");
        //_OptionButton4 = GetNode<OptionButton>("DropDownAttribute4");
        //_OptionButton5 = GetNode<OptionButton>("DropDownAttribute5");
        //_OptionButton6 = GetNode<OptionButton>("DropDownAttribute6");
        //_OptionButton7 = GetNode<OptionButton>("DropDownAttribute7");
        //_OptionButton8 = GetNode<OptionButton>("DropDownAttribute8");

       // _DropDownGenre = GetNode<OptionButton>("");


    }

//  // Called every frame. 'delta' is the elapsed time since the previous frame.
//  public override void _Process(float delta)
//  {
//      
//  }
}
