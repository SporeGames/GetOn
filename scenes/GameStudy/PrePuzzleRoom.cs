using Godot;
using System;

namespace GetOn.scenes.GameStudy
{
	public class PrePuzzleRoom : Button
	{
		
		[Export] public string sceneToLoad;

		private SharedNode _sharedNode;
		private Button _button2;

		private Button _backButton;
		private bool soundDone = false;
		private bool mangamentDone = false;
		private bool gameStudyDone = false;
		private bool narrativeDone = false;
		private bool gamedesignDone = false;
		private bool programmingDone = false;

		public override void _Ready()
		{
			
			_sharedNode = GetNode<SharedNode>("/root/SharedNode");
			Connect("pressed", this, nameof(ChangeScene));
			_button2 = GetNode<Button>("/root/PrePuzzleRoom/Button2");
			_button2.Connect("pressed", this, nameof(LoadGameDesign));
			_backButton = GetNode<Button>("/root/PrePuzzleRoom/BackButton");
			_backButton.Connect("pressed", this, nameof(BackToMenu));
			CloseLastPuzzle();
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
			if (soundDone == true && sceneToLoad == "res://scenes/Sound/Sound.tscn")
			{
				GD.Print("Hier button aus");
				this.Visible = false;
			}
			else if(mangamentDone == true && sceneToLoad =="res://scenes/Management/Management.tscn")
			{
				this.Visible = false;
			}
			else if(programmingDone == true && sceneToLoad =="res://scenes/Programming/Programming.tscn")
			{
				this.Visible = false;
			}
			else if(gameStudyDone == true && sceneToLoad =="res://scenes/GameStudy/GameStudy.tscn")
			{
				this.Visible = false;
			}
			
			else if(narrativeDone == true && sceneToLoad =="res://scenes/Narrative/Narrative.tscn")
			{
				this.Visible = false;
			}
			else 
			{
				this.Visible = true;
			}
			
			
			

		}

		public void BackToMenu()
		{
			_sharedNode.SwitchScene("res://scenes/GameSelectionRoom/GameSelectionRoom.tscn");
		}

		public void SetButton2Visibile()
		{
			if(gamedesignDone == true)
			{
				_button2.Visible = false;
			}
			else
			{
				_button2.Visible = true;
			}
			
		}

		public void LoadGameDesign()
		{
			_sharedNode.SwitchScene("res://scenes/GameDesign/GameDesign.tscn");
		}

		public void CloseLastPuzzle()
		{
			foreach (var game in _sharedNode.CompletedTasks)
			{
				switch (game)
				{
					case "sound":
						soundDone = true;
						break;
					case "programming":
						programmingDone = true;
						break;
					case "management":
						mangamentDone = true;
						break;
					case "narrative":
						narrativeDone = true;
						break;
					case "gamestudy":
						gameStudyDone = true;
						break;
					case "gameDesign" :
						gamedesignDone = true;
						break;
				}

			}
		}
	}
}
