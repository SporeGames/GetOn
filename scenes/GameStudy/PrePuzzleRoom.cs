using Godot;
using System;

namespace GetOn.scenes.GameStudy
{
	public class PrePuzzleRoom : Button
	{
		[Export] public string sceneToLoad;
		
		private SharedNode _sharedNode;
		private Button _button2;
		
		
		public override void _Ready()
		{
			_sharedNode = GetNode<SharedNode>("/root/SharedNode");
			Connect("pressed", this, nameof(ChangeScene));
			_button2 = GetNode<Button>("/root/PrePuzzleRoom/Button2");

			if (this.Name != "BackButton")
			{
				this.Visible = false;
			}
		}

		public void ChangeScene()
		{
			_sharedNode.SwitchScene(sceneToLoad);
		}

		public void SetButtonVisible()
		{
			
			this.Visible = true;

		}

		public void SetButton2Visibile()
		{
			_button2.Visible = true;
		}
	}
}

