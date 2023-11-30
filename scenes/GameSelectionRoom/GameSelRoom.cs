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

		private ColorRect _soundDone;

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

		public void HideSound()
		{
			_goToSound.Visible = false;
			_soundDone.Visible = true;
		}
	}
}
