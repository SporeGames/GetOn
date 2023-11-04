using Godot;
using System;

public class CountdownTimer : Label
{
	private float _currentTime = 240; 
	private Timer _timer;

	public override void _Ready()
	{
		_timer = new Timer();
		AddChild(_timer);
		_timer.WaitTime = 1; 
		_timer.Connect("timeout", this, nameof(OnTimerTimeout));
		_timer.Start();
	}

	private void OnTimerTimeout()
	{
		_currentTime -= 1;

		if (_currentTime <= 0)
		{
			_currentTime = 0;
			_timer.Stop();
		}

		UpdateTimerDisplay();
	}

	private void UpdateTimerDisplay()
	{
		
		int minutes = Mathf.FloorToInt(_currentTime / 60);
		int seconds = Mathf.FloorToInt(_currentTime % 60);
		Text = $"Time: {minutes:00}:{seconds:00}";
	}
}
