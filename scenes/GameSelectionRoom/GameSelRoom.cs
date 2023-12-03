using Godot;
using System;

namespace GetOn.scenes.GameSelectionRoom {
	public class GameSelRoom : Node2D {
		private SharedNode _sharedNode;
		
		private Button _goToProgramming;
		private Button _goToManagment;
		private Button _goToNarrativeAndGameDesign;
		private Button _goToSound;
		private Button _goToGameStudy;
		private Button _printPDF;

		private bool narrativeAndDesign = false;
		private ColorRect _soundDone;
		private ColorRect _managementDone;
		private ColorRect _narrativeAndDesignDone;
		private ColorRect _gameStudyDone;
		private ColorRect _programmingDone;
		

		// Called when the node enters the scene tree for the first time.
		public override void _Ready() {
			
			_sharedNode = GetNode<SharedNode>("/root/SharedNode");
			_goToProgramming = GetNode<Button>("GoToProgramming");
			_goToProgramming.Connect("pressed", this, nameof(OnGoToProgrammingPressed));
			_goToManagment = GetNode<Button>("GoToManagment");
			_goToManagment.Connect("pressed", this, nameof(OnGoToManagmentPressed));
			_goToNarrativeAndGameDesign = GetNode<Button>("GoToNarrativeAndGameDesign");
			_goToNarrativeAndGameDesign.Connect("pressed", this, nameof(OnGoToNarrativeAndSoundPressed));
			_goToSound = GetNode<Button>("GoToSound");
			_goToSound.Connect("pressed", this, nameof(OnGoToSoundPressed));
			_printPDF = GetNode<Button>("PrintPDF");
			_printPDF.Connect("pressed", this, nameof(OnPrintPDFPressed));
			_goToGameStudy = GetNode<Button>("GoToGameStudy");
			_goToGameStudy.Connect("pressed", this, nameof(OnGoToGameStudyPressed));

			_soundDone = GetNode<ColorRect>("SoundDone");
			_managementDone = GetNode<ColorRect>("ManagementDone");
			_narrativeAndDesignDone = GetNode<ColorRect>("NarrativeAndDesignDone");
			_gameStudyDone = GetNode<ColorRect>("GameStudyDone");
			_programmingDone = GetNode<ColorRect>("ProgrammingDone");
			CheckCompletions();
		}

		public void OnGoToProgrammingPressed() {
			_sharedNode.SwitchScene("res://scenes/Programming/ProgrammingRoom.tscn");
		}

		public void OnGoToManagmentPressed() {
			_sharedNode.SwitchScene("res://scenes/Management/PrePuzzleRoom.tscn");
		}

		public void OnGoToNarrativeAndSoundPressed() {
			_sharedNode.SwitchScene("res://scenes/Narrative/PrePuzzleRoom.tscn");//"res://scenes/Narrative/PrePuzzleRoom.tscn"
		}

		public void OnGoToSoundPressed() {
			_sharedNode.SwitchScene("res://scenes/Sound/PrePuzzleRoom.tscn");
		}

		public void OnPrintPDFPressed() {
			GD.Print("Print pdf jetzt los");
			GetNode<SharedNode>("/root/SharedNode").Print();
		}

		public void OnGoToGameStudyPressed() {
			_sharedNode.SwitchScene("res://scenes/GameStudy/PrePuzzleRoom.tscn");
		}

		private void CheckCompletions() {
			foreach (var game in _sharedNode.CompletedTasks) {
				switch (game) {
					case "programming":
						_goToProgramming.Disabled = true;
						_goToProgramming.Visible = false;
						_programmingDone.Visible = true;
						break;
					case "management":
						_goToManagment.Disabled = true;
						_goToManagment.Visible = false;
						_managementDone.Visible = true;
						break;
					case "narrative":
						if (narrativeAndDesign)
						{
							_goToNarrativeAndGameDesign.Disabled = true;
							_goToNarrativeAndGameDesign.Visible = false;
							_narrativeAndDesignDone.Visible = true;
						}
						else
						{
							narrativeAndDesign = true;
						}
						break;
					case "sound":
						_goToSound.Disabled = true;
						_goToSound.Visible = false;
						_soundDone.Visible = true;
						break;
					case "gamestudy":
						_goToGameStudy.Disabled = true;
						_goToGameStudy.Visible = false;
						_gameStudyDone.Visible = true;
						break;
					case "gameDesign" :
						if (narrativeAndDesign)
						{
							_goToNarrativeAndGameDesign.Disabled = true;
							_goToNarrativeAndGameDesign.Visible = false;
							_narrativeAndDesignDone.Visible = true;
						}
						else
						{
							narrativeAndDesign = true;
						}
						break;
				}
			}
		}
	}
}
