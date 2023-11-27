using Godot;
using System;

namespace GetOn.scenes.GameStudy
{
	public class PrePuzzleRoom : Button
	{
		[Export] public string sceneToLoad;
		
		private SharedNode _sharedNode;
		
		public override void _Ready()
		{
			_sharedNode = GetNode<SharedNode>("/root/SharedNode");
			Connect("pressed", this, nameof(ChangeScene));
		}

		public void ChangeScene()
		{
			_sharedNode.SwitchScene(sceneToLoad);
		}
	}
}

