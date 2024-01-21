using Godot;
using System.Collections.Generic;
using System.Linq;
using GetOn.scenes;
using GetOn.scenes.GameDesign;

public class GameDesign : Node2D {

	private CountdownTimer _timer;
	private SubmitResults _submitResults;
	private Node2D _submitResultsPopUp;
	
	private GameDesignSlider _apexSlider;
	private GameDesignSlider _detroitSlider;
	private GameDesignSlider _deadSpaceSlider;
	private TextureButton doneButton;
	private int counter = 0;
	private int maxPressCount = 2;
	
	private GameDesignGame _currentGame;
	private Godot.Collections.Dictionary<GameDesignGame, string[]> _selectedValues = new Godot.Collections.Dictionary<GameDesignGame, string[]>();
	
	
	public override void _Ready() {
		_submitResults = GetNode<SubmitResults>("/root/GameDesign/SubmitResults");
		_submitResultsPopUp = GetNode<Node2D>("/root/GameDesign/SubmitResults");
		_timer = GetNode<CountdownTimer>("/root/GameDesign/TopBar/Timer");
		_apexSlider = GetNode<GameDesignSlider>("ApexSlider");
		_detroitSlider = GetNode<GameDesignSlider>("DetroitSlider");
		_deadSpaceSlider = GetNode<GameDesignSlider>("DeadSpaceSlider");
		
		doneButton = GetNode<TextureButton>("DoneButton");
		doneButton.Connect("pressed", this, nameof(OnDonePressed));

		
	}
	
	private void OnDonePressed() {
		GoBackAndCalculateResults();
		GetNode<SharedNode>("/root/SharedNode").PlayGenericClick();
	}

		public void NextSliderPressed(GameDesignGame game, string[] values) {
			counter++;

			// Check if the counter has reached the desired limit
			if (counter >= maxPressCount)
			{
				// Show the "Done" button or perform any other action
				GetNode<TextureButton>("DoneButton").Show();

				// Reset the counter to 0
				counter = 0;
			}

			_selectedValues[game] = values;
			switch (game) {
				case GameDesignGame.Apex:
					_apexSlider.Visible = false;
					_detroitSlider.Visible = true;
					_currentGame = GameDesignGame.Detroit;
					break;
				case GameDesignGame.Detroit:
					_detroitSlider.Visible = false;
					_deadSpaceSlider.Visible = true;
					_currentGame = GameDesignGame.DeadSpace;
					break;
				case GameDesignGame.DeadSpace:
					_deadSpaceSlider.Visible = false;
					_apexSlider.Visible = true;
					_currentGame = GameDesignGame.Apex;
					break;
			}
		}

	
	public void PreviousSliderPressed(GameDesignGame game) {
		switch (game) {
			case GameDesignGame.Apex: // First game, no back here
				_deadSpaceSlider.Visible = true;
				_currentGame = GameDesignGame.DeadSpace;
				_apexSlider.Visible = false;
				break;
			case GameDesignGame.Detroit:
				_detroitSlider.Visible = false;
				_apexSlider.Visible = true;
				_currentGame = GameDesignGame.Apex;
				break;
			case GameDesignGame.DeadSpace:
				_deadSpaceSlider.Visible = false;
				_detroitSlider.Visible = true;
				_currentGame = GameDesignGame.Detroit;
				break;
		}
	}

	private void GoBackAndCalculateResults() {
		var points = 0;
		var motivationsCorrect = 0;
		foreach (var entry in  _selectedValues) {
			if (entry.Key == GameDesignGame.Apex) {
				foreach (var selected in entry.Value) {
					if (_apexSlider.ValidPersonas.Contains(selected)) {
						motivationsCorrect++;
						points += 3;
					}
					if (!_apexSlider.ValidPersonas.Contains(selected) && !_detroitSlider.ALittleBitValidPersonas.Contains(selected)) {
						points -= 3;
					}
				}
			}
			if (entry.Key == GameDesignGame.Detroit) {
				foreach (var selected in entry.Value) {
					if (_detroitSlider.ValidPersonas.Contains(selected)) {
						motivationsCorrect++;
						points += 3;
					}
					if (!_detroitSlider.ValidPersonas.Contains(selected) && !_detroitSlider.ALittleBitValidPersonas.Contains(selected)) {
						points -= 3;
					}
				}
			}
			if (entry.Key == GameDesignGame.DeadSpace) {
				foreach (var selected in entry.Value) {
					if (_deadSpaceSlider.ValidPersonas.Contains(selected)) {
						motivationsCorrect++;
						points += 3;
					}
					if (!_deadSpaceSlider.ValidPersonas.Contains(selected) && !_detroitSlider.ALittleBitValidPersonas.Contains(selected)) {
						points -= 3;
					}
				}
			}
		}
		if (points < 0) {
			points = 0;
		}
		points += _timer.GetBonusPointsForTime();
		var node = GetNode<SharedNode>("/root/SharedNode");
		/*
		node.gameDesignPoints = points;
		node.gameDesignTime = (int) _timer.CurrentTime;
		node.CompletedTasks.Add(AbilitySpecialization.Game_Design);
		node.SwitchScene("res://scenes/Rooms/GDNarrativeRoom.tscn");
		*/
		_submitResultsPopUp.Visible = true;
		_submitResults.gameDesignPoints = points;
		_submitResults.gameDesignMotivations = motivationsCorrect;
		_submitResults.gameDesignTime = (int) _timer.CurrentTime;
	}
}
