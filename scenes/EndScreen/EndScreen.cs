using Godot;
using System;
using GetOn.scenes;

public class EndScreen : Control {
   
	private Button _downloadButton;
	
	public override void _Ready() {
		_downloadButton = GetNode<Button>("DownloadButton");
		_downloadButton.Connect("pressed", this, nameof(OnDownloadButtonPressed));
	}


	public void OnDownloadButtonPressed() {
		GetNode<SharedNode>("/root/SharedNode").Print();
	}
}
