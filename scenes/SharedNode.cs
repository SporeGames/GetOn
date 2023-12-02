using System.Collections.Generic;
using System.IO;
using Godot;
using Newtonsoft.Json;

namespace GetOn.scenes {
	// ReSharper disable once ClassNeverInstantiated.Global
	public class SharedNode : Node2D {
		private Node CurrentScene { get; set; }
		public string PlayerName { get; set; } = "No name";
		
		public readonly List<string> CompletedTasks = new List<string>();
		
		public int programmingPoints = 0;
		public float programmingTime = 0;
		public int gameStudyPoints = 0;
		public int gameDesignPoints = 0;
		public int narrativePoints = 0;
		public int soundPoints = 0;
		public int managementPoints = 0;
		public int managementColors = 0;

		public bool isDragging;

		public override void _Ready() {
			var root = GetTree().Root;
			CurrentScene = root.GetChild(root.GetChildCount() - 1);
			isDragging = false;
		}
		public void SwitchScene(string path) {
			CallDeferred(nameof(DeferredGotoScene), path);
		}

		public void DeferredGotoScene(string path) {
			CurrentScene.Free();
			var nextScene = (PackedScene) GD.Load(path);
			CurrentScene = nextScene.Instance();
			GetTree().Root.AddChild(CurrentScene);
			GetTree().CurrentScene = CurrentScene;
		}

		public void Print() {
			var minutes = Mathf.FloorToInt(programmingTime / 60);
			var seconds = Mathf.FloorToInt(programmingTime % 60);
			var timeFormatted = $"{minutes:00}:{seconds:00}";
			GetNode("Printer").Call("_print", PlayerName, programmingPoints, timeFormatted, gameStudyPoints, gameDesignPoints, soundPoints, managementPoints, managementColors, narrativePoints);
		}

		public string ToJson() {
			var serializer = JsonSerializer.CreateDefault();
			var json = new StringWriter();
			serializer.Serialize(new JsonTextWriter(json), this);
			return json.ToString();
		}
	}
}

