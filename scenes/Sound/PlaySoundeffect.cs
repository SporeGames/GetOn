using Godot;
using System;
using iText.IO.Util;

public class PlaySoundeffect : Button
{
	public AudioStreamPlayer _audioStreamPlayer;
	private bool active = false;
	private bool paused = false;

	private Sprite _wave;
	
	public override void _Ready()
	{
		_wave = GetNode<Sprite>("Sprite");
		_audioStreamPlayer = GetNode<AudioStreamPlayer>("AudioStreamPlayer");
		Connect("pressed", this, nameof(PlayPressed));
		_audioStreamPlayer.Connect("finished", this, nameof(AudioFinished));
		_wave.Visible = false;
	}

	public void PlayPressed()
	{
		_wave.Visible = true;
		if (active == false && paused == false)
		{
			_wave.Visible = true;
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
			_wave.Visible = false;
			Resource resource2 = GD.Load("res://scenes/Sound/assets/PlayButton.png");
			if (resource2 is Texture texture2)
			{
				this.Icon = texture2;
			}
		}

		else if (paused)
		{
			_audioStreamPlayer.StreamPaused = false;

			_wave.Visible = true;
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
		_wave.Visible = false;
		GD.Print("done");
		Resource resource2 = GD.Load("res://scenes/Sound/assets/PlayButton.png");
		if (resource2 is Texture texture2)
		{
			this.Icon = texture2;
		}

		active = false;
	}
}






