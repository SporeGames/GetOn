using Godot;
using System;
using GetOn.scenes;
using GetOn.scenes.Programming;

public class CountdownTimer : Node2D {
	
	[Export] public float CurrentTime = 300; 
	[Export] public Color FontColor = new Color(0.0f, 0.0f, 0.0f, 1.0f);
	public bool running = false;
	private Timer _timer;
	private RichTextLabel _displayText;
	private AnimatedSprite _icon;
	private AbilitySpecialization _spec = AbilitySpecialization.None;
	
	public float InitialTime = 0;
	private long _startTime = 0;
	
	public override void _Ready() {
		_displayText = GetNode<RichTextLabel>("Display");
		_icon = GetNode<AnimatedSprite>("Icon");
		_timer = new Timer();
		AddChild(_timer);
		_timer.WaitTime = 1; 
		_timer.Connect("timeout", this, nameof(OnTimerTimeout));
		_timer.Start();
		_displayText.AddColorOverride("DefaultColor", FontColor);
		var parent = GetParent();
		if (parent is TopBar bar) {
			_spec = bar.Game;
		}
	}
	
	// Reset the timer to its initial state
	public void ResetTimer() {
		CurrentTime = InitialTime;
		UpdateTimerDisplay();
	}

	public int GetBonusPointsForTime() {
		if (_spec == AbilitySpecialization.Programming) {
			if (CurrentTime < 420) {
				return 2;
			}
			if (CurrentTime < 720) {
				return 1;
			}
			return 0;
		}
		if (CurrentTime < 300) {
			return 2;
		}
		if (CurrentTime < 600) {
			return 1;
		}
		return 0;
	}
	
	private void OnTimerTimeout() {
		if (!running) {
			return;
		}
		if (_startTime == 0) {
			_startTime = DateTime.Now.Second;
		}
		CurrentTime = InitialTime + (DateTime.Now.Second - _startTime);
		
		UpdateTimerDisplay();
	}

	private void UpdateTimerDisplay() {
		
		int minutes = Mathf.FloorToInt(CurrentTime / 60);
		int seconds = Mathf.FloorToInt(CurrentTime % 60);
		_displayText.Text = $"Time: {minutes:00}:{seconds:00}";
		_displayText.AddColorOverride("default_color", GetColorForTime());
		_icon.Modulate = GetColorForTime();
		
	}

	private Color GetColorForTime() {
		if (_spec == AbilitySpecialization.Programming) {
			if (CurrentTime < 420) { 
				return Colors.Green;
			}
			if (CurrentTime < 720) {
				return Colors.Yellow;
			}
			return Colors.Red;
		}
		if (CurrentTime < 300) {
			return Colors.Green;
		}
		if (CurrentTime < 600) {
			return Colors.Yellow;
		}
		return Colors.Red;
	}

	
}
