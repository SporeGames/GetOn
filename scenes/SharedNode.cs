using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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
		private Button _finishButton;

		private List<string> _discoveredScenes = new List<string>();
		[Export] public float SpecializationMultiplier = 1.5f;
		[Export] public Texture MouseCursor;
		[Export] bool _useQueuedSceneLoading = true;
		
		private Node CurrentScene { get; set; }
		[JsonProperty] public string PlayerName { get; set; } = "No name";

		[JsonProperty] public readonly List<AbilitySpecialization> CompletedTasks = new List<AbilitySpecialization>();
		[JsonProperty] public readonly List<string> SeenDialogues = new List<string>();
		[JsonProperty] public readonly List<string> ClickedDecorations = new List<string>();
		[JsonProperty] public readonly Dictionary<AbilitySpecialization, int> HelpButtonPressed = new Dictionary<AbilitySpecialization, int>();
		
		// Programming
		[JsonProperty] public double programmingPoints = 0;
		[JsonProperty] public int DisconnectedNodes = 0;
		[JsonProperty] public int EncounteredErrors = 0;
		[JsonProperty] public int TestsRun = 0;
		[JsonProperty] public float programmingTime = 0;
		// Game Study
		[JsonProperty] public double gameStudyPoints = 0;
		[JsonProperty] public float gameStudyTime = 0;
		[JsonProperty] public int gameStudyConsoles = 0;
		[JsonProperty] public int gameStudyClassicGames = 0;
		[JsonProperty] public int gameStudySciFiGames = 0;
		// Game Design
		[JsonProperty] public int gameDesignPoints = 0;
		[JsonProperty] public float gameDesignTime = 0;
		[JsonProperty] public int gameDesignMotivations = 0;
		// Narrative
		[JsonProperty] public double narrativePoints = 0;
		[JsonProperty] public float narrativeTime = 0;
		[JsonProperty] public int narrativeAttributes = 0;
		[JsonProperty] public int narrativeSettings = 0;
		[JsonProperty] public int narrativeEndings = 0;
		// Sound
		[JsonProperty] public double soundPoints = 0;
		[JsonProperty] public float soundTime = 0;
		[JsonProperty] public int soundEasySounds = 0;
		[JsonProperty] public int soundMediumSounds = 0;
		[JsonProperty] public int soundHardSounds = 0;
		// Management
		[JsonProperty]public double managementPoints = 0;
		[JsonProperty] public int managementColors = 0;
		[JsonProperty] public float managementTime = 0;
		[JsonProperty] public int managementCardsPlaced = 0;
		[JsonProperty] public AbilitySpecialization Specialization = AbilitySpecialization.Programming;
		
		public double TotalPoints = 0;

		public bool isDragging;
		public bool HasDialogeBoxOpen = false;

		public string MouseHoverText = "";
		private Node2D mousefollower;
		
		private ResourceInteractiveLoader _sceneLoader;
		private string _pathCurrentlyLoading = "";
		private bool _isLoadingScene = false;
		private double _loadingProgress = 0;
		private ColorRect _loadingScreen;
		private ProgressBar _loadingBar;
		private List<string> _sceneQueue = new List<string>();
		

		public override void _Ready() {
			foreach (var spec in Enum.GetValues(typeof(AbilitySpecialization))) {
				HelpButtonPressed.Add((AbilitySpecialization) spec, 0);
			}
			var root = GetTree().Root;
			CurrentScene = root.GetChild(root.GetChildCount() - 1);
			mousefollower = GetNode<Node2D>("MouseHoverFollower");
			isDragging = false;
			_debugMenu = GetNode<Node2D>("DebugMenu");
			_debugText = GetNode<RichTextLabel>("DebugMenu/DebugText");
			_debugMenuList = GetNode<ItemList>("DebugMenu/Levels");
			_finishButton = GetNode<Button>("DebugMenu/FinishButton");
			_finishButton.Connect("pressed", this, nameof(OnFinishButtonPressed));
			_debugMenu.Visible = false;
			_loadingBar = GetNode<ProgressBar>("LoadingScreen/ProgressBar");
			_loadingScreen = GetNode<ColorRect>("LoadingScreen");
			_loadingScreen.Visible = false;
			DiscoverSceneFiles("res://scenes", true);
			GD.Print("Discovered " + _discoveredScenes.Count + " scenes");
			foreach (var scene in _discoveredScenes) {
				_debugMenuList.AddItem(scene.Replace("res://scenes/", ""), null, true);
			}
			_debugMenuList.Connect("item_selected", this, nameof(OnDebugMenuItemSelected));
			GetNode<CountdownTimer>("GlobalTimer").running = true;
			Input.SetCustomMouseCursor(MouseCursor);
		}

		public override void _Process(float delta) {
			if (_sceneQueue.Count > 0 && !_isLoadingScene && _sceneLoader == null) {
				SwitchScene(_sceneQueue[0]);
				_sceneQueue.RemoveAt(0);
			}
			if (_isLoadingScene && _sceneLoader != null) {
				var err = _sceneLoader.Poll();
				switch (err) {
					case Error.FileEof: {
						_isLoadingScene = false;
						_pathCurrentlyLoading = "";
						var nextScene = (PackedScene) _sceneLoader.GetResource();
						CurrentScene = nextScene.Instance();
						GetTree().Root.AddChild(CurrentScene);
						GetTree().CurrentScene = CurrentScene;
						_loadingScreen.Visible = false;
						_sceneLoader.Dispose(); // Need to dispose of the loader manually or we get a cyclic reference
						_sceneLoader = null;
						GD.Print("Successfully loaded scene: " + CurrentScene.Name);
						return;
					}
					case Error.Ok:
						_loadingProgress = _sceneLoader.GetStage() / (double) _sceneLoader.GetStageCount();
						_loadingProgress = Math.Round(_loadingProgress, 2);
						_loadingBar.Value = _loadingProgress;
						return;
					default:
						GD.PrintErr("Error loading scene: " + err);
						return;
				}
			}
			if (!MouseHoverText.Equals("")) {
				mousefollower.Visible = true;
				mousefollower.GetNode<RichTextLabel>("Text").Text = MouseHoverText;
				mousefollower.Position = new Vector2(GetGlobalMousePosition().x + 25, GetGlobalMousePosition().y + 5);
			}
			else {
				mousefollower.Visible = false;
			}
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
		
		private void OnFinishButtonPressed() {
			CompletedTasks.Add(AbilitySpecialization.Art);
			CompletedTasks.Add(AbilitySpecialization.Game_Design);
			CompletedTasks.Add(AbilitySpecialization.Game_Studies);
			CompletedTasks.Add(AbilitySpecialization.Management);
			CompletedTasks.Add(AbilitySpecialization.Narrative_Design);
			CompletedTasks.Add(AbilitySpecialization.Programming);
			CompletedTasks.Add(AbilitySpecialization.Sound);
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
			if (_useQueuedSceneLoading) {
				if (_pathCurrentlyLoading.Equals(path)) {
					return;
				}

				if (_isLoadingScene || _sceneLoader != null) {
					_sceneQueue.Add(path);
					return;
				}

				HasDialogeBoxOpen = false;
				MouseHoverText = "";
				GD.Print("Unloading scene: " + CurrentScene.Name);
				CurrentScene.QueueFree();
				_loadingScreen.Visible = true;
				GD.Print("Loading scene: " + path);
				StartLoadingScene(path);
				return;
			}
			CurrentScene.QueueFree();
			var nextScene = (PackedScene) GD.Load(path);
			CurrentScene = nextScene.Instance();
			GetTree().Root.AddChild(CurrentScene);
			GetTree().CurrentScene = CurrentScene;
		}

		private void StartLoadingScene(string path) {
			/*if (ResourceLoader.HasCached(path)) {
				return;
			}*/
			_sceneLoader = ResourceLoader.LoadInteractive(path);
			_isLoadingScene = true;
		}

		public void CalculatePoints() {
			switch (Specialization) {
				case AbilitySpecialization.Management:
					managementPoints *= 2;
					break;
				case AbilitySpecialization.Narrative_Design:
					narrativePoints *= 2;
					break;
				case AbilitySpecialization.Programming:
					programmingPoints *= 2;
					break;
				case AbilitySpecialization.Sound:
					soundPoints *= 2;
					break;
				case AbilitySpecialization.Game_Design:
					gameDesignPoints *= 2;
					break;
				case AbilitySpecialization.Game_Studies:
					gameStudyPoints *= 2;
					break;
			}

			Dictionary<AbilitySpecialization, double> results = new Dictionary<AbilitySpecialization, double>();
			results.Add(AbilitySpecialization.Management, managementPoints);
			results.Add(AbilitySpecialization.Programming, programmingPoints);
			results.Add(AbilitySpecialization.Sound, soundPoints);
			results.Add(AbilitySpecialization.Game_Design, gameDesignPoints);
			results.Add(AbilitySpecialization.Game_Studies, gameStudyPoints);
			results.Add(AbilitySpecialization.Narrative_Design, narrativePoints);
			var sortedList = results.ToList();
			sortedList.Sort((pair1,pair2) => pair1.Value.CompareTo(pair2.Value));
			var best = sortedList[sortedList.Count - 1];
			TotalPoints = sortedList.Sum(pair => pair.Value);
		}

		public void Print() {
			switch (Specialization) {
				case AbilitySpecialization.Management:
					managementPoints *= 2;
					break;
				case AbilitySpecialization.Narrative_Design:
					narrativePoints *= 2;
					break;
				case AbilitySpecialization.Programming:
					programmingPoints *= 2;
					break;
				case AbilitySpecialization.Sound:
					soundPoints *= 2;
					break;
				case AbilitySpecialization.Game_Design:
					gameDesignPoints *= 2;
					break;
				case AbilitySpecialization.Game_Studies:
					gameStudyPoints *= 2;
					break;
			}

			Dictionary<AbilitySpecialization, double> results = new Dictionary<AbilitySpecialization, double>();
			results.Add(AbilitySpecialization.Management, managementPoints);
			results.Add(AbilitySpecialization.Programming, programmingPoints);
			results.Add(AbilitySpecialization.Sound, soundPoints);
			results.Add(AbilitySpecialization.Game_Design, gameDesignPoints);
			results.Add(AbilitySpecialization.Game_Studies, gameStudyPoints);
			results.Add(AbilitySpecialization.Narrative_Design, narrativePoints);
			var sortedList = results.ToList();
			sortedList.Sort((pair1,pair2) => pair1.Value.CompareTo(pair2.Value));
			var best = sortedList[sortedList.Count - 1];
			var totalPoints = sortedList.Sum(pair => pair.Value);
			var result = new GameResult {
				Name = PlayerName,
				SelectedSpecialization = "Specialization: " + Specialization,
				Categories = ToCategories(),
				BestName = best.Key.ToString().Replace("_", " "),
				BestPoints = results[best.Key].ToString(),
				Decorations = ClickedDecorations.Count.ToString(),
				TotalTime = "Time: " + FormatTime(GetNode<CountdownTimer>("GlobalTimer").CurrentTime, true),
				TotalPoints = totalPoints.ToString()
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
						new ResultEntry { Title = "Time", Text = FormatTime(programmingTime) },
						new ResultEntry { Title = "Tests run", Text = TestsRun.ToString() },
						new ResultEntry { Title = "Errors", Text = EncounteredErrors.ToString() },
						new ResultEntry { Title = "Reconnected nodes", Text = DisconnectedNodes.ToString() },
						new ResultEntry { Title = "Help button pressed", Text = HelpButtonPressed[AbilitySpecialization.Programming].ToString() }
					}
				},
				new ResultCategory {
					Title = "Game Study",
					Items = new List<ResultEntry> {
						new ResultEntry { Title = "Points", Text = gameStudyPoints.ToString() },
						new ResultEntry { Title = "Time", Text = FormatTime(gameStudyTime) },
						new ResultEntry { Title = "Help button pressed", Text = HelpButtonPressed[AbilitySpecialization.Game_Studies].ToString() },
						new ResultEntry { Title = "Consoles", Text = gameStudyConsoles.ToString() },
						new ResultEntry { Title = "Classic games", Text = gameStudyClassicGames.ToString() },
						new ResultEntry { Title = "Sci-fi games", Text = gameStudySciFiGames.ToString() }
					}
				},
				new ResultCategory {
					Title = "Game Design",
					Items = new List<ResultEntry> {
						new ResultEntry { Title = "Points", Text = gameDesignPoints.ToString() },
						new ResultEntry { Title = "Time", Text = FormatTime(gameDesignTime) },
						new ResultEntry { Title = "Help button pressed", Text = HelpButtonPressed[AbilitySpecialization.Game_Design].ToString() },
						new ResultEntry { Title = "Motivations", Text = gameDesignMotivations.ToString() }
					}
				},
				new ResultCategory {
					Title = "Narrative",
					Items = new List<ResultEntry> {
						new ResultEntry { Title = "Points", Text = narrativePoints.ToString() },
						new ResultEntry { Title = "Time", Text = FormatTime(narrativeTime) },
						new ResultEntry { Title = "Help button pressed", Text = HelpButtonPressed[AbilitySpecialization.Narrative_Design].ToString() },
						new ResultEntry { Title = "Attributes", Text = narrativeAttributes.ToString() },
						new ResultEntry { Title = "Settings", Text = narrativeSettings.ToString() },
						new ResultEntry { Title = "Endings", Text = narrativeEndings.ToString() }
					}
				},
				new ResultCategory() {
					Title = "Sound",
					Items = new List<ResultEntry> {
						new ResultEntry { Title = "Points", Text = soundPoints.ToString() },
						new ResultEntry { Title = "Time", Text = FormatTime(soundTime) },
						new ResultEntry { Title = "Help button pressed", Text = HelpButtonPressed[AbilitySpecialization.Sound].ToString() },
						new ResultEntry { Title = "Easy sounds", Text = soundEasySounds.ToString() },
						new ResultEntry { Title = "Medium sounds", Text = soundMediumSounds.ToString() },
						new ResultEntry { Title = "Hard sounds", Text = soundHardSounds.ToString() }
					}
				},
				new ResultCategory() {
					Title = "Management",
					Items = new List<ResultEntry> {
						new ResultEntry { Title = "Points", Text = managementPoints.ToString() },
						new ResultEntry { Title = "Time", Text = FormatTime(managementTime) },
						new ResultEntry { Title = "Help button pressed", Text = HelpButtonPressed[AbilitySpecialization.Management].ToString() },
						new ResultEntry { Title = "Cards colored", Text = managementColors.ToString() },
						new ResultEntry { Title = "Cards correctly placed", Text = managementCardsPlaced.ToString() },
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

		public void PlayGenericClick() {
			GetNode<AudioStreamPlayer>("GenericClick").Playing = true;
		}
	}
}

