using Godot;
using System.Collections.Generic;
using System.Linq;
using GetOn.scenes;
using GetOn.scenes.GameDesign;

public class GameDesign : Control {

	private CountdownTimer _timer;
	
	private GameDesignSlider _apexSlider;
	private GameDesignSlider _detroitSlider;
	private GameDesignSlider _deadSpaceSlider;
	
	private GameDesignGame _currentGame;
	private Godot.Collections.Dictionary<GameDesignGame, string[]> _selectedValues = new Godot.Collections.Dictionary<GameDesignGame, string[]>();

	private Button _introReady;
	private Node2D _introGameStudy;
	
	public override void _Ready() {
		_timer = GetNode<CountdownTimer>("Timer");
		_apexSlider = GetNode<GameDesignSlider>("ApexSlider");
		_detroitSlider = GetNode<GameDesignSlider>("DetroitSlider");
		_deadSpaceSlider = GetNode<GameDesignSlider>("DeadSpaceSlider");

		_introReady = GetNode<Button>("Intro/Button");
		_introGameStudy = GetNode<Node2D>("Intro");
		_introReady.Connect("pressed", this, nameof(OnIntroReadyPressed));
	}

	public void NextSliderPressed(GameDesignGame game, string[] values) {
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
				GoBackAndCalculateResults();
				break;
		}
	}
	
	public void PreviousSliderPressed(GameDesignGame game) {
		switch (game) {
			case GameDesignGame.Apex: // First game, no back here
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
		foreach (var entry in  _selectedValues) {
			if (entry.Key == GameDesignGame.Apex) {
				foreach (var selected in entry.Value) {
					if (_apexSlider.ValidPersonas.Contains(selected)) {
						points += 2;
					}
					if (!_apexSlider.ValidPersonas.Contains(selected)) {
						points -= 1;
					}
				}
			}
			if (entry.Key == GameDesignGame.Detroit) {
				foreach (var selected in entry.Value) {
					if (_detroitSlider.ValidPersonas.Contains(selected)) {
						points += 2;
					}
					if (!_detroitSlider.ValidPersonas.Contains(selected)) {
						points -= 1;
					}
				}
			}
			if (entry.Key == GameDesignGame.DeadSpace) {
				foreach (var selected in entry.Value) {
					if (_deadSpaceSlider.ValidPersonas.Contains(selected)) {
						points += 2;
					}
					if (!_deadSpaceSlider.ValidPersonas.Contains(selected)) {
						points -= 1;
					}
				}
			}
		}
		if (points < 0) {
			points = 0;
		}
		if (_timer.CurrentTime < 240) {
			points += 10;
		}
		var node = GetNode<SharedNode>("/root/SharedNode");
		node.gameDesignPoints = points;
		node.gameDesignTime = (int) _timer.CurrentTime;
		node.CompletedTasks.Add(AbilitySpecialization.GameDesign);
		node.SwitchScene("res://scenes/Rooms/GDNarrativeRoom.tscn");
	}

	public void OnIntroReadyPressed() {
		_introGameStudy.Visible = false;
		_timer.running = true;
	}
	
}
