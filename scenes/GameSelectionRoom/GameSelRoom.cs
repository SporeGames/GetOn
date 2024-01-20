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

		private Sprite _hoverGameStudy;
		private Sprite _hoverManagement;
		private Sprite _hoverSound;
		private Sprite _hoverGDAndNarrative;
		private Sprite _hoverProgramming;

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

			_hoverGameStudy = GetNode<Sprite>("HoverHighlights/HoverGameStudy");
			_hoverManagement = GetNode<Sprite>("HoverHighlights/HoverManagement");
			_hoverSound = GetNode<Sprite>("HoverHighlights/HoverSound");
			_hoverGDAndNarrative = GetNode<Sprite>("HoverHighlights/HoverGDAndNarrative");
			_hoverProgramming = GetNode<Sprite>("HoverHighlights/HoverProgramming");
		}

		public void OnGoToProgrammingPressed() {
			GetNode<SharedNode>("/root/SharedNode").PlayGenericClick();
			_DialogueBox.QueueFree();
			
			_sharedNode.SwitchScene("res://scenes/Rooms/ProgrammingRoom.tscn");
		}

		public void OnGoToManagmentPressed() {
			GetNode<SharedNode>("/root/SharedNode").PlayGenericClick();
			_sharedNode.SwitchScene("res://scenes/Rooms/ManagementRoom.tscn");
		}

		public void OnGoToNarrativeAndSoundPressed() {
			GetNode<SharedNode>("/root/SharedNode").PlayGenericClick();
			_sharedNode.SwitchScene("res://scenes/Rooms/GDNarrativeRoom.tscn");//"res://scenes/Narrative/PrePuzzleRoom.tscn"
		}

		public void OnGoToSoundPressed() {
			GetNode<SharedNode>("/root/SharedNode").PlayGenericClick();
			_sharedNode.SwitchScene("res://scenes/Rooms/SoundArtRoom.tscn");
		}

		public void OnPrintPDFPressed() {
			GD.Print("Print pdf jetzt los");
			GetNode<SharedNode>("/root/SharedNode").Print();
		}

		public void OnGoToGameStudyPressed() {
			GetNode<SharedNode>("/root/SharedNode").PlayGenericClick();
			_sharedNode.SwitchScene("res://scenes/Rooms/GameStudyRoom.tscn");
		}

		private void CheckCompletions() {
			var completed = _sharedNode.CompletedTasks.Count;
			GD.Print("Completed: " + completed + " of " + (Enum.GetValues(typeof(AbilitySpecialization)).Length - 1) + "");
			if (completed >= Enum.GetValues(typeof(AbilitySpecialization)).Length - 1) {
				GD.Print("Game completed, switching to ending room.");
				_sharedNode.SwitchScene("res://scenes/Rooms/EndingRoom.tscn");
				return;
			}
			foreach (var game in _sharedNode.CompletedTasks) {
				switch (game) {
					case AbilitySpecialization.Programming:
						
						_programmingDone.Visible = true;
						break;
					case AbilitySpecialization.Management:
						
						_managementDone.Visible = true;
						break;
					case AbilitySpecialization.Narrative_Design:
						_storyDone.Visible = true;
						break;
					case AbilitySpecialization.Sound:
						//_goToSound.Disabled = true;
						//_goToSound.Visible = false;
						//_goToSoundPuzzle.Visible = false;
						
						_soundDone.Visible = true;
						break;
					case AbilitySpecialization.Game_Studies:
						
						_gameStudyDone.Visible = true;
						break;
					case AbilitySpecialization.Game_Design:
						
						_narrativeAndDesignDone.Visible = true;
						break;
					case AbilitySpecialization.Art:
						
						_artDone.Visible = true;
						break;

						
				}
			}
		}
		//Highlight hovered room & show name
		private void _on_GoToManagment_mouse_entered() {
			_sharedNode.MouseHoverText = "Management";
			_hoverManagement.Visible = true;
		}
		private void _on_GoToManagment_mouse_exited() {
			_sharedNode.MouseHoverText = "";
			_hoverManagement.Visible = false;
		}
		private void _on_GoToGameStudy_mouse_entered() {
			_sharedNode.MouseHoverText = "Game Study";
			_hoverGameStudy.Visible = true;
		}
		private void _on_GoToGameStudy_mouse_exited() {
			_sharedNode.MouseHoverText = "";
			_hoverGameStudy.Visible = false;
		}
		private void _on_GoToProgramming_mouse_entered() {
			_sharedNode.MouseHoverText = "Programming";
			_hoverProgramming.Visible = true;
		}
		private void _on_GoToProgramming_mouse_exited() {
			_hoverProgramming.Visible = false;
			_sharedNode.MouseHoverText = "";
		}
		private void _on_GoToNarrativeAndGameDesign_mouse_entered() {
			_sharedNode.MouseHoverText = "Game Design and Story";
			_hoverGDAndNarrative.Visible = true;
		}
		private void _on_GoToNarrativeAndGameDesign_mouse_exited() {
			_hoverGDAndNarrative.Visible = false;
			_sharedNode.MouseHoverText = "";
		}
		private void _on_GoToSoundAndArt_mouse_entered() {
			_sharedNode.MouseHoverText = "Sound and Art";
			_hoverSound.Visible = true;
		}
		private void _on_GoToSoundAndArt_mouse_exited() {
			_hoverSound.Visible = false;
			_sharedNode.MouseHoverText = "";
		}
	}
}

