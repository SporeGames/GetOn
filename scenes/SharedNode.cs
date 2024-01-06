using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using Godot;
using Newtonsoft.Json;
using Directory = Godot.Directory;

namespace GetOn.scenes {
	// ReSharper disable once ClassNeverInstantiated.Global
	[JsonObject(MemberSerialization.OptIn)]
	public class SharedNode : Node2D {
		// Debug util stuff
		private Node2D _debugMenu;
		private RichTextLabel _debugText;
		private ItemList _debugMenuList;

		private List<string> _discoveredScenes = new List<string>();
		[Export] public float SpecializationMultiplier = 1.5f;
		
		private Node CurrentScene { get; set; }
		[JsonProperty] public string PlayerName { get; set; } = "No name";

		[JsonProperty] public readonly List<AbilitySpecialization> CompletedTasks = new List<AbilitySpecialization>();
		[JsonProperty] public readonly List<string> SeenDialogues = new List<string>();
		
		[JsonProperty] public int programmingPoints = 0;
		[JsonProperty] public float programmingTime = 0;
		[JsonProperty] public double gameStudyPoints = 0;
		[JsonProperty] public float gameStudyTime = 0;
		[JsonProperty] public int gameDesignPoints = 0;
		[JsonProperty] public float gameDesignTime = 0;
		[JsonProperty] public int narrativePoints = 0;
		[JsonProperty] public float narrativeTime = 0;
		[JsonProperty] public double soundPoints = 0;
		[JsonProperty] public float soundTime = 0;
		[JsonProperty]public int managementPoints = 0;
		[JsonProperty] public int managementColors = 0;
		[JsonProperty] public float managementTime = 0;
		[JsonProperty] public AbilitySpecialization Specialization = AbilitySpecialization.Programming;

		public bool isDragging;
		

		public override void _Ready() {
			var root = GetTree().Root;
			CurrentScene = root.GetChild(root.GetChildCount() - 1);
			isDragging = false;
			_debugMenu = GetNode<Node2D>("DebugMenu");
			_debugText = GetNode<RichTextLabel>("DebugMenu/DebugText");
			_debugMenuList = GetNode<ItemList>("DebugMenu/Levels");
			DiscoverSceneFiles("res://scenes", true);
			GD.Print("Discovered " + _discoveredScenes.Count + " scenes");
			foreach (var scene in _discoveredScenes) {
				_debugMenuList.AddItem(scene.Replace("res://scenes/", ""), null, true);
			}
			_debugMenuList.Connect("item_selected", this, nameof(OnDebugMenuItemSelected));
			GetNode<CountdownTimer>("GlobalTimer").running = true;
		}

		public override void _Process(float delta) {
			if (!_debugMenu.Visible) {
				return;
			}
			_debugText.Text = "Debug \n \n" +
							  "\nFPS: " + Engine.GetFramesPerSecond() +
							  "\nCurrent scene: " + CurrentScene.Name +
							  "\nScene: Objects: " + Performance.GetMonitor(Performance.Monitor.ObjectCount) + 
									" | Nodes: " + Performance.GetMonitor(Performance.Monitor.ObjectNodeCount) + 
									" | Resources: " + Performance.GetMonitor(Performance.Monitor.ObjectResourceCount) +
									" | Orphaned: " + Performance.GetMonitor(Performance.Monitor.ObjectOrphanNodeCount) +
							  "\nProcess: " + Math.Round(Performance.GetMonitor(Performance.Monitor.TimeProcess) * 1000, 3) + " ms | Physics: " + Math.Round(Performance.GetMonitor(Performance.Monitor.TimePhysicsProcess) * 1000, 3) + " ms" +
							  "\nMemory: " + Math.Round(Performance.GetMonitor(Performance.Monitor.MemoryDynamic) / (1024 * 1024), 2) + "/" + Math.Round(Performance.GetMonitor(Performance.Monitor.MemoryDynamicMax) / (1024 * 1024), 2) + 
									" MB | " + Math.Round(Performance.GetMonitor(Performance.Monitor.MemoryStatic) / (1024 * 1024), 2) + "/" + Math.Round(Performance.GetMonitor(Performance.Monitor.MemoryStaticMax) / (1024 * 1024), 2) + " MB" +
							  "\nVideo: Memory: " + Math.Round(Performance.GetMonitor(Performance.Monitor.RenderVideoMemUsed) / (1024 * 1024), 2) + " MB | Draw calls: " + Performance.GetMonitor(Performance.Monitor.Render2dDrawCallsInFrame) +
							  "\nAudio: Device: " + AudioServer.Device + 
									" | Latency: " + Math.Round(AudioServer.GetOutputLatency(), 4) + "ms" +
									" | Mix rate: " + AudioServer.GetMixRate() + 
									" | Last mix: "  + Math.Round(AudioServer.GetTimeSinceLastMix(), 2) + "ms" + 
									" | Next mix: " + Math.Round(AudioServer.GetTimeToNextMix(), 2) + "ms" +
							  "\nScreen: DPI: " + OS.GetScreenDpi() + " | Size: " + OS.GetScreenSize() +
							  "\nUser agent: " + JavaScript.Eval("navigator.userAgent") +
							  "\nSharedNodeContent: " + ToJson();
		}

		private void OnDebugMenuItemSelected(int index) {
			GD.Print("Clicked on " + _discoveredScenes[index] + " at index " + index + " in the debug menu");
			SwitchScene(_discoveredScenes[index]);
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
			var result = new GameResult {
				Name = PlayerName,
				SelectedSpecialization = "Specialization: " + Specialization,
				Categories = ToCategories(),
				TotalTime = "Time: " + FormatTime(GetNode<CountdownTimer>("GlobalTimer").CurrentTime, true),
			};
			using (var sha256 = SHA256.Create())
			{
				var bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(result.Categories, Formatting.Indented)));
				var builder = new StringBuilder();
				foreach (var t in bytes) {
					builder.Append(t.ToString("x2"));
				}
				result.Hash = builder.ToString();
			}
			var json = JsonConvert.SerializeObject(result, Formatting.Indented);
			GetNode("Printer").Call("_print", json);
		}
		
		public List<ResultCategory> ToCategories() {
			return new List<ResultCategory> {
				new ResultCategory {
					Title = "Programming",
					Items = new List<ResultEntry> {
						new ResultEntry { Title = "Points", Text = programmingPoints.ToString() },
						new ResultEntry { Title = "Time", Text = FormatTime(programmingTime) }
					}
				},
				new ResultCategory {
					Title = "Game Design",
					Items = new List<ResultEntry> {
						new ResultEntry { Title = "Points", Text = gameDesignPoints.ToString() },
						new ResultEntry { Title = "Time", Text = FormatTime(gameDesignTime) }
					}
				},
				new ResultCategory {
					Title = "Game Study",
					Items = new List<ResultEntry> {
						new ResultEntry { Title = "Points", Text = gameStudyPoints.ToString() },
						new ResultEntry { Title = "Time", Text = FormatTime(gameStudyTime) }
					}
				},
				new ResultCategory {
					Title = "Narrative",
					Items = new List<ResultEntry> {
						new ResultEntry { Title = "Points", Text = narrativePoints.ToString() },
						new ResultEntry { Title = "Time", Text = FormatTime(narrativeTime) }
					}
				},
				new ResultCategory() {
					Title = "Sound",
					Items = new List<ResultEntry> {
						new ResultEntry { Title = "Points", Text = soundPoints.ToString() },
						new ResultEntry { Title = "Time", Text = FormatTime(soundTime) }
					}
				},
				new ResultCategory() {
					Title = "Management",
					Items = new List<ResultEntry> {
						new ResultEntry { Title = "Points", Text = managementPoints.ToString() },
						new ResultEntry { Title = "Colors", Text = managementColors.ToString() },
						new ResultEntry { Title = "Time", Text = FormatTime(managementTime) }
					}
				}
			};
		}

		public string ToJson() {
			var serializer = JsonSerializer.Create();
			var writer = new StringWriter();
			var json = new JsonTextWriter(writer);
			serializer.Formatting = Formatting.Indented;
			serializer.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
			serializer.Serialize(json, this);
			return writer.ToString();
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
					_discoveredScenes.Add(dir.GetCurrentDir() + "/" + file);
					GD.Print("Discovered scene: " + dir.GetCurrentDir() + "/" + file);
				}
				file = dir.GetNext();
			}
		}
		
		private string FormatTime(float time, bool showHours = false) {
			var timeSpan = TimeSpan.FromSeconds(time);
			return timeSpan.ToString(showHours ? @"hh\:mm\:ss" : @"mm\:ss");
		}
	}
}

