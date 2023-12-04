using Godot;
using System;
using iText.IO.Util;

public class PlaySoundeffect : Button
{
	public AudioStreamPlayer _audioStreamPlayer;
	private bool active = false;
	private bool paused = false;
	
	public override void _Ready()
	{
		
		_audioStreamPlayer = GetNode<AudioStreamPlayer>("AudioStreamPlayer");
		Connect("pressed", this, nameof(PlayPressed));
		_audioStreamPlayer.Connect("finished", this, nameof(AudioFinished));
	}

	public void PlayPressed()
	{
		if (active == false && paused == false)
		{
			Resource resource = GD.Load("res://scenes/Sound/assets/StopButton.png");
			_audioStreamPlayer.Play();
			if (resource is Texture texture)
			{
				Icon = texture;
			}

			//this.Disabled = true;
		}
		else if (active && paused == false)
		{
			_audioStreamPlayer.StreamPaused = true;
			paused = true;
			Resource resource2 = GD.Load("res://scenes/Sound/assets/PlayButton.png");
			if (resource2 is Texture texture2)
			{
				this.Icon = texture2;
			}
		}

		else if (paused)
		{
			_audioStreamPlayer.StreamPaused = false;

			
			Resource resource = GD.Load("res://scenes/Sound/assets/StopButton.png");
			if (resource is Texture texture)
			{
				Icon = texture;
			}
			
			
			paused = false;
		}
		

		active = true;
	}

	public void AudioFinished()
	{
		GD.Print("done");
		Resource resource2 = GD.Load("res://scenes/Sound/assets/PlayButton.png");
		if (resource2 is Texture texture2)
		{
			this.Icon = texture2;
		}

		active = false;
	}
}






