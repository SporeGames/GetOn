using Godot;
using System;
using GetOn.scenes.GameStudy;

namespace GetOn.scenes.GameSelectionRoom {
	public class GameSelRoom : Node2D {
		private SharedNode _sharedNode;
		
		
		private Button _goToProgramming;
		private Button _goToManagment;
		private Button _goToNarrativeAndGameDesign;
		private Button _goToSound;
		private Button _goToGameStudy;
		private Button _printPDF;

		private Button _goToSoundPuzzle;

		private bool narrativeAndDesign = false;
		private Sprite _soundDone;
		private Sprite _managementDone;
		private Sprite _narrativeAndDesignDone;
		private Sprite _gameStudyDone;
		private Sprite _programmingDone;
		private Sprite _storyDone;
		

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

			
			//_goToSoundPuzzle = GetNode<Button>("/root/Sound/PrePuzzleRoom/Button");
			

			_soundDone = GetNode<Sprite>("SoundDone");
			_managementDone = GetNode<Sprite>("ManagementDone");
			_narrativeAndDesignDone = GetNode<Sprite>("NarrativeAndDesignDone");
			_gameStudyDone = GetNode<Sprite>("GameStudyDone");
			_programmingDone = GetNode<Sprite>("ProgrammingDone");
			_storyDone = GetNode<Sprite>("StoryDone");
			CheckCompletions();
		}

		public void OnGoToProgrammingPressed() {
			_sharedNode.SwitchScene("res://scenes/Programming/PrePuzzleRoom.tscn");
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
						
						_programmingDone.Visible = true;
						break;
					case "management":
						
						_managementDone.Visible = true;
						break;
					case "narrative":
						_storyDone.Visible = true;
						break;
					case "sound":
						//_goToSound.Disabled = true;
						//_goToSound.Visible = false;
						//_goToSoundPuzzle.Visible = false;
						
						_soundDone.Visible = true;
						break;
					case "gamestudy":
						
						_gameStudyDone.Visible = true;
						break;
					case "gameDesign" :

						_narrativeAndDesignDone.Visible = true;
						break;
				}
			}
		}
	}
}
