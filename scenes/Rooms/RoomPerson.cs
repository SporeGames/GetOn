using Godot;
using System;
using System.Collections.Generic;
using System.Linq;
using GetOn.scenes;
using GetOn.SharedAssets;

public class RoomPerson : Node2D {
	
	private SharedNode _shared;
	
	[Export] public AbilitySpecialization GameSpecialization;
	
	private DialogueBox _welcomeDialogueBox;
	private DialogueBox _epicFailDialogueBox;
	private DialogueBox _talkAgainDialogueBox;
	private List<DialogueBox> _dialogueBoxes = new List<DialogueBox>();
	private TextureButton _interactButton;
	private Sprite _sprite;
	
	public override void _Ready() {
		_shared = GetNode<SharedNode>("/root/SharedNode");
		_welcomeDialogueBox = GetNode<DialogueBox>("WelcomeDialogue");
		_epicFailDialogueBox = GetNode<DialogueBox>("EpicFailDialogue");
		_talkAgainDialogueBox = GetNode<DialogueBox>("TalkAgainDialogue");
		_interactButton = GetNode<TextureButton>("InteractButton");
		_sprite = GetNode<Sprite>("PersonSprite");
		_interactButton.Connect("pressed", this, nameof(OnInteractButtonPressed));
		
		foreach (var node in GetChildren()) {
			if (node is DialogueBox dialogueBox && dialogueBox.Name.Contains("ResultDialogue")) {
				_dialogueBoxes.Add(dialogueBox);
			}
		}
		if (HasCompletedThisTask()) {
			_sprite.Material = null; // remove the glow
			var dialogue = GetResultDialogueForResult();
			if (_shared.SeenDialogues.Contains(dialogue.UniqueID)) { // Don't show the result dialogue if the player enter the room again for whatever reason
				GD.Print("Already seen this dialogue: " + dialogue.Name);
				return;
			}
			dialogue.Visible = true;
			_shared.SeenDialogues.Add(dialogue.UniqueID);
		}
	}
	
	private void OnInteractButtonPressed() {
		if (_shared.HasDialogeBoxOpen) {
			return;
		}
		if (HasCompletedThisTask()) {
			_talkAgainDialogueBox.Visible = true;
			_shared.HasDialogeBoxOpen = true;
			return;
		}
		_welcomeDialogueBox.Visible = true;
		_shared.HasDialogeBoxOpen = true;
	}
	
	private DialogueBox GetResultDialogueForResult() {
		var gameResult = 0;
		switch (GameSpecialization) {
			case AbilitySpecialization.Management:
				gameResult = _shared.managementPoints;
				break;
			case AbilitySpecialization.GameDesign:
				gameResult = _shared.gameDesignPoints;
				break;
			case AbilitySpecialization.Programming:
				gameResult = _shared.programmingPoints;
				break;
			case AbilitySpecialization.GameStudy:
				gameResult = (int) _shared.gameStudyPoints;
				break;
			case AbilitySpecialization.Sound:
				gameResult = (int) _shared.soundPoints;
				break;
			case AbilitySpecialization.Narrative:
				gameResult = (int) _shared.narrativePoints;
				break;
			case AbilitySpecialization.Art:
				gameResult = 50; // We don't have a result for art
				break;
			default:
				GD.Print("This specialization is not implemented: " + GameSpecialization);
				break;
		}
		if (GameSpecialization == _shared.Specialization && gameResult < _epicFailDialogueBox.ResultThreshold) {
			return _epicFailDialogueBox;
		}
		var sortedBoxes = _dialogueBoxes.OrderBy(b => b.ResultThreshold).ToList();
		sortedBoxes.Reverse(); // We want to try the highest threshold first
		foreach (var box in sortedBoxes) {
			if (gameResult >= box.ResultThreshold) {
				return box;
			}
		}
		return null;
	}
	
	private bool HasCompletedThisTask() {
		return _shared.CompletedTasks.Contains(GameSpecialization);
	}
	
}
