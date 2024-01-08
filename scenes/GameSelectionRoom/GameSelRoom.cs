using Godot;
using System;
using GetOn.SharedAssets;

namespace GetOn.scenes.GameSelectionRoom {
	public class GameSelRoom : Node2D {
		private SharedNode _sharedNode;
		
		private Button _goToProgramming;
		private Button _goToManagment;
		private Button _goToNarrativeAndGameDesign;
		private Button _goToSound;
		private Button _goToGameStudy;
		private Button _printPDF;
		
		private Node2D _DialogueBox;
		

		private bool narrativeAndDesign = false;
		private Sprite _soundDone;
		private Sprite _managementDone;
		private Sprite _narrativeAndDesignDone;
		private Sprite _gameStudyDone;
		private Sprite _programmingDone;
		private Sprite _storyDone;
		private Sprite _artDone;

		// Called when the node enters the scene tree for the first time.
		public override void _Ready() {
			
			_DialogueBox = GetNode<Node2D>("DialogueBox"); 
			
			_sharedNode = GetNode<SharedNode>("/root/SharedNode");
			_goToProgramming = GetNode<Button>("GoToProgramming");
			_goToProgramming.Connect("pressed", this, nameof(OnGoToProgrammingPressed));
			_goToManagment = GetNode<Button>("GoToManagment");
			_goToManagment.Connect("pressed", this, nameof(OnGoToManagmentPressed));
			_goToNarrativeAndGameDesign = GetNode<Button>("GoToNarrativeAndGameDesign");
			_goToNarrativeAndGameDesign.Connect("pressed", this, nameof(OnGoToNarrativeAndSoundPressed));
			_goToSound = GetNode<Button>("GoToSoundAndArt");
			_goToSound.Connect("pressed", this, nameof(OnGoToSoundPressed));
			_printPDF = GetNode<Button>("PrintPDF");
			_printPDF.Connect("pressed", this, nameof(OnPrintPDFPressed));
			_goToGameStudy = GetNode<Button>("GoToGameStudy");
			_goToGameStudy.Connect("pressed", this, nameof(OnGoToGameStudyPressed));

			_soundDone = GetNode<Sprite>("SoundDone");
			_managementDone = GetNode<Sprite>("ManagementDone");
			_narrativeAndDesignDone = GetNode<Sprite>("NarrativeAndDesignDone");
			_gameStudyDone = GetNode<Sprite>("GameStudyDone");
			_programmingDone = GetNode<Sprite>("ProgrammingDone");
			_storyDone = GetNode<Sprite>("StoryDone");
			_artDone = GetNode<Sprite>("ArtDone");
			CheckCompletions();
		}

		public void OnGoToProgrammingPressed() {
			_DialogueBox.QueueFree();
			
			_sharedNode.SwitchScene("res://scenes/Rooms/ProgrammingRoom.tscn");
		}

		public void OnGoToManagmentPressed() {
			_sharedNode.SwitchScene("res://scenes/Rooms/ManagementRoom.tscn");
		}

		public void OnGoToNarrativeAndSoundPressed() {
			_sharedNode.SwitchScene("res://scenes/Rooms/GDNarrativeRoom.tscn");//"res://scenes/Narrative/PrePuzzleRoom.tscn"
		}

		public void OnGoToSoundPressed() {
			_sharedNode.SwitchScene("res://scenes/Rooms/SoundArtRoom.tscn");
		}

		public void OnPrintPDFPressed() {
			GD.Print("Print pdf jetzt los");
			GetNode<SharedNode>("/root/SharedNode").Print();
		}

		public void OnGoToGameStudyPressed() {
			_sharedNode.SwitchScene("res://scenes/Rooms/GameStudyRoom.tscn");
		}

		private void CheckCompletions() {
			var completed = _sharedNode.CompletedTasks.Count;
			GD.Print("Completed: " + completed + " of " + (Enum.GetValues(typeof(AbilitySpecialization)).Length - 1) + "");
			if (completed >= Enum.GetValues(typeof(AbilitySpecialization)).Length - 1) {
				GetNode<DialogueBox>("CompletedGameDialogue").Visible = true;
				GetNode<Button>("PrintPDF").Visible = true;
			}
			foreach (var game in _sharedNode.CompletedTasks) {
				switch (game) {
					case AbilitySpecialization.Programming:
						
						_programmingDone.Visible = true;
						break;
					case AbilitySpecialization.Management:
						
						_managementDone.Visible = true;
						break;
					case AbilitySpecialization.Narrative:
						_storyDone.Visible = true;
						break;
					case AbilitySpecialization.Sound:
						//_goToSound.Disabled = true;
						//_goToSound.Visible = false;
						//_goToSoundPuzzle.Visible = false;
						
						_soundDone.Visible = true;
						break;
					case AbilitySpecialization.GameStudy:
						
						_gameStudyDone.Visible = true;
						break;
					case AbilitySpecialization.GameDesign:
						
						_narrativeAndDesignDone.Visible = true;
						break;
					case AbilitySpecialization.Art:
						
						_artDone.Visible = true;
						break;

						
				}
			}
		}
		
	}
}
