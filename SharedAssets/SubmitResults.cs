using Godot;
using System;
using GetOn.scenes;

public class SubmitResults : Node2D
{
	private SharedNode _sharedNode;
	private TextureButton _yes;
	private TextureButton _no;
	[Export] private string currentGame;
	//gameStudy
	public double gameStudyPoints;
	public float gameStudyTime;
	public int gameStudyConsoles = 0;
	public int gameStudyClassicGames = 0;
	public int gameStudySciFiGames = 0;
	// Management
	public double managementPoints;
	public float managementTime;
	public int cardsColoredCorrectly;
	public int managementCardsPlaced = 0;
	// Programming
	public double programmingPoints;
	public float programmingTime; // Rest for programming can be counted continuously
	//Sound
	public double soundPoints;
	public float soundTime;
	public int soundEasySounds = 0;
	public int soundMediumSounds = 0;
	public int soundHardSounds = 0;
	//Narrative
	public double narrativePoints;
	public float narrativeTime;
	public int narrativeAttributes = 0;
	public int narrativeSettings = 0;
	public int narrativeEndings = 0;
	// Game Design
	public double gameDesignPoints;
	public float gameDesignTime;
	public int gameDesignMotivations = 0;
	
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
		_sharedNode.gameStudySciFiGames = gameStudySciFiGames;
		_sharedNode.gameStudyConsoles = gameStudyConsoles;
		_sharedNode.gameStudyClassicGames = gameStudyClassicGames;
		_sharedNode.CompletedTasks.Add(AbilitySpecialization.Game_Studies);
		_sharedNode.SwitchScene("res://scenes/Rooms/GameStudyRoom.tscn");
		GD.Print(gameStudyPoints);
	}
	private void SubmitManagement()
	{
		_sharedNode.managementPoints = managementPoints;
		_sharedNode.managementTime = managementTime;
		_sharedNode.managementColors = cardsColoredCorrectly;
		_sharedNode.managementCardsPlaced = managementCardsPlaced;
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
		_sharedNode.soundPoints = (double) soundPoints;
		_sharedNode.soundTime = soundTime;
		_sharedNode.soundEasySounds = soundEasySounds;
		_sharedNode.soundMediumSounds = soundMediumSounds;
		_sharedNode.soundHardSounds = soundHardSounds;
		_sharedNode.CompletedTasks.Add(AbilitySpecialization.Sound);
		_sharedNode.SwitchScene("res://scenes/Rooms/SoundArtRoom.tscn");
		GD.Print(soundPoints);
	}
	private void SubmitGameDesign() {
		_sharedNode.gameDesignPoints = (int) gameDesignPoints;
		_sharedNode.gameDesignTime = gameDesignTime;
		_sharedNode.gameDesignMotivations = gameDesignMotivations;
		_sharedNode.CompletedTasks.Add(AbilitySpecialization.Game_Design);
		_sharedNode.SwitchScene("res://scenes/Rooms/GDNarrativeRoom.tscn");
		GD.Print(gameDesignPoints);
	}
	private void SubmitNarrative()
	{
		_sharedNode.narrativeAttributes = narrativeAttributes;
		_sharedNode.narrativeEndings = narrativeEndings;
		_sharedNode.narrativeSettings = narrativeSettings;
		_sharedNode.narrativePoints = narrativePoints;
		_sharedNode.narrativeTime = narrativeTime;
		_sharedNode.CompletedTasks.Add(AbilitySpecialization.Narrative_Design);
		_sharedNode.SwitchScene("res://scenes/Rooms/GDNarrativeRoom.tscn");
		GD.Print(narrativePoints);
	}
}
