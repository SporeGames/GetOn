using Godot;
using System;
using GetOn.scenes.Programming;

public class CountdownTimer : Label
{
	public float CurrentTime = 300; 
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
		CurrentTime -= 1;

		if (CurrentTime <= 0)
		{
			CurrentTime = 0;
			_timer.Stop();
			GetNode<Checklist>("/root/Programming/Checklist").TimeOut();
		}

		UpdateTimerDisplay();
	}

	private void UpdateTimerDisplay()
	{
		
		int minutes = Mathf.FloorToInt(CurrentTime / 60);
		int seconds = Mathf.FloorToInt(CurrentTime % 60);
		Text = $"Time left: {minutes:00}:{seconds:00}";
	}
}
