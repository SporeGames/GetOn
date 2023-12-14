using Godot;
using System;
using GetOn.scenes.Programming;

public class CountdownTimer : Node2D {
	
	[Export] public bool countdown = false;
	[Export] public float CurrentTime = 300; 
	private Timer _timer;
	private RichTextLabel _displayText;

	public override void _Ready() {
		_displayText = GetNode<RichTextLabel>("Display");
		_timer = new Timer();
		AddChild(_timer);
		_timer.WaitTime = 1; 
		_timer.Connect("timeout", this, nameof(OnTimerTimeout));
		_timer.Start();
	}

	private void OnTimerTimeout() {
		if (countdown) {
			CurrentTime -= 1;
		} else {
			CurrentTime += 1;
		}
		UpdateTimerDisplay();
	}

	private void UpdateTimerDisplay() {
		
		int minutes = Mathf.FloorToInt(CurrentTime / 60);
		int seconds = Mathf.FloorToInt(CurrentTime % 60);
		_displayText.Text = $"Time: {minutes:00}:{seconds:00}";
	}
}
