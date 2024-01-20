using Godot;
using System;
using GetOn.scenes;

public class SubmitResults : Node2D
{
	private SharedNode _sharedNode;
	private TextureButton _yes;
	private TextureButton _no;
	[Export] private string currentGame;
	public double gameStudyPoints;
	public float gameStudyTime;
	public double managementPoints;
	public float managementTime;
	public int cardsColoredCorrectly;
	public double programmingPoints;
	public float programmingTime;
	public double soundPoints;
	public float soundTime;
	public double narrativePoints;
	public float narrativeTime;
	public double gameDesignPoints;
	public float gameDesignTime;
	
	public override void _Ready() {
		_sharedNode = GetNode<SharedNode>("/root/SharedNode");
		_yes = GetNode<TextureButton>("Yes");
		_no = GetNode<TextureButton>("No");
		_no.Connect("pressed", this, nameof(NoPressed));
		_yes.Connect("pressed",this,nameof(YesPressed),new Godot.Collections.Array {currentGame});
	}
	public void NoPressed() {
		Visible = false;
	}

	public void YesPressed(string currentGame) {
		switch (currentGame) {
			case "GameStudy":
				SubmitGameStudy();
				break;
			case "Management":
				SubmitManagement();
				break;
			case "Sound":
				SubmitSound();
				break;
			case "Narrative":
				SubmitNarrative();
				break;
			case "GameDesign":
				SubmitGameDesign();
				break;
			case "Programming":
				SubmitProgramming();
				break;
		}
	}

	public void SubmitGameStudy() {
		gameStudyPoints += GetNode<CountdownTimer>("/root/GameStudy/TopBar/Timer").GetBonusPointsForTime();
		_sharedNode.gameStudyPoints = (int) gameStudyPoints;
		_sharedNode.gameStudyTime = gameStudyTime;
		_sharedNode.CompletedTasks.Add(AbilitySpecialization.Game_Studies);
		_sharedNode.SwitchScene("res://scenes/Rooms/GameStudyRoom.tscn");
		GD.Print(gameStudyPoints);
	}
	private void SubmitManagement()
	{
		_sharedNode.managementPoints = managementPoints;
		_sharedNode.managementTime = managementTime;
		_sharedNode.managementColors = cardsColoredCorrectly;
		_sharedNode.CompletedTasks.Add(AbilitySpecialization.Management);
		_sharedNode.SwitchScene("res://scenes/Rooms/ManagementRoom.tscn");
		GD.Print(managementPoints);
	}
	private void SubmitProgramming()
	{
		_sharedNode.programmingPoints = programmingPoints;
		_sharedNode.programmingTime = programmingTime;
		_sharedNode.CompletedTasks.Add(AbilitySpecialization.Programming);
		_sharedNode.SwitchScene("res://scenes/Rooms/ProgrammingRoom.tscn");
		GD.Print(programmingPoints);
	}
	private void SubmitSound() {
		soundPoints += GetNode<CountdownTimer>("/root/Sound/TopBar/Timer").GetBonusPointsForTime();
		_sharedNode.soundPoints = (int) soundPoints;
		_sharedNode.soundTime = soundTime;
		_sharedNode.CompletedTasks.Add(AbilitySpecialization.Sound);
		_sharedNode.SwitchScene("res://scenes/Rooms/SoundArtRoom.tscn");
		GD.Print(soundPoints);
	}
	private void SubmitGameDesign() {
		_sharedNode.gameDesignPoints = (int) gameDesignPoints;
		_sharedNode.gameDesignTime = gameDesignTime;
		_sharedNode.CompletedTasks.Add(AbilitySpecialization.Game_Design);
		_sharedNode.SwitchScene("res://scenes/Rooms/GDNarrativeRoom.tscn");
		GD.Print(gameDesignPoints);
	}
	private void SubmitNarrative()
	{
		_sharedNode.narrativePoints = narrativePoints;
		_sharedNode.narrativeTime = narrativeTime;
		_sharedNode.CompletedTasks.Add(AbilitySpecialization.Narrative_Design);
		_sharedNode.SwitchScene("res://scenes/Rooms/GDNarrativeRoom.tscn");
		GD.Print(narrativePoints);
	}
}
