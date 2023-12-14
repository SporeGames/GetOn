using System.Collections.Generic;
using System.IO;
using Godot;
using Godot.Collections;
using Newtonsoft.Json;
using Directory = Godot.Directory;

namespace GetOn.scenes {
	// ReSharper disable once ClassNeverInstantiated.Global
	public class SharedNode : Node2D {
		// Debug util stuff
		private Node2D _debugMenu;
		private ItemList _debugMenuList;

		private List<string> discoveredScenes = new List<string>();
		
		private Node CurrentScene { get; set; }
		public string PlayerName { get; set; } = "No name";
		
		public readonly List<string> CompletedTasks = new List<string>();
		
		public int programmingPoints = 0;
		public float programmingTime = 0;
		public int gameStudyPoints = 0;
		public int gameDesignPoints = 0;
		public int gameDesignTime = 0;
		public int narrativePoints = 0;
		public int soundPoints = 0;
		public int managementPoints = 0;
		public int managementColors = 0;

		public bool isDragging;

		public override void _Ready() {
			var root = GetTree().Root;
			CurrentScene = root.GetChild(root.GetChildCount() - 1);
			isDragging = false;
			_debugMenu = GetNode<Node2D>("DebugMenu");
			_debugMenuList = GetNode<ItemList>("DebugMenu/Levels");
			DiscoverSceneFiles("res://scenes", true);
			GD.Print("Discovered " + discoveredScenes.Count + " scenes");
			foreach (var scene in discoveredScenes) {
				_debugMenuList.AddItem(scene.Replace("res://scenes/", ""), null, true);
			}
			_debugMenuList.Connect("item_selected", this, nameof(OnDebugMenuItemSelected));
		}

		private void OnDebugMenuItemSelected(int index) {
			GD.Print("Clicked on " + discoveredScenes[index] + " at index " + index + " in the debug menu");
			SwitchScene(discoveredScenes[index]);
		}

		public override void _Input(InputEvent @event) {
			if (@event is InputEventKey key) {
				if (key.Scancode == (int) KeyList.F3 && key.Pressed) {
					_debugMenu.Visible = !_debugMenu.Visible;
					GD.Print("Toggled debug menu");
				}
			}
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

		private void DiscoverSceneFiles(string path, bool recursive) {
			var dir = new Directory();
			dir.Open(path);
			dir.ListDirBegin(true, true);
			var file = dir.GetNext();
			while (file != "") {
				if (dir.CurrentIsDir() && recursive) {
					DiscoverSceneFiles(dir.GetCurrentDir() + "/" + file, true);
				} else if (file.Contains(".tscn")) {
					discoveredScenes.Add(dir.GetCurrentDir() + "/" + file);
					GD.Print("Discovered scene: " + dir.GetCurrentDir() + "/" + file);
				}
				file = dir.GetNext();
			}
		}
	}
}

