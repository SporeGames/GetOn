using System;
using Godot;
using System.Collections.Generic;
using System.Linq;
using GetOn.scenes;
using GetOn.scenes.Management;

public class Management : Node2D {
	
	[Export] public PackedScene NoteScene;
	
	private RichTextLabel _colorText;
	private TextureButton _orangeButton;
	private TextureButton _blueButton;
	private TextureButton _purpleButton;
	private TextureButton _yellowButton;
	private TextureButton _greenButton;
	private TextureButton _submitButton;
	private Sprite _mouseFollower;
	
	private ManagementNote _currentNote;
	private NoteBox _currentBox;
	private Vector2 _dragOffset = Vector2.Zero;
	private int _selectedColor = 0;
	private bool isDragging = false;
	private bool _didJustRecolor = false;
	private long _lastRecolorTime = 0;
	
	private List<ManagementNote> _notes = new List<ManagementNote>();
	public Dictionary<NoteBox, ManagementNote> BoxedNotes = new Dictionary<NoteBox, ManagementNote>();
	private static Color _defaultBoxColor = new Color(0.69f, 0.69f, 0.69f, 1);
	
	private Dictionary<int, Texture> _colorTextures = new Dictionary<int, Texture> {
		{0, GD.Load<Texture>("res://scenes/Management/assets/white.png")},
		{1, GD.Load<Texture>("res://scenes/Management/assets/orange.png")},
		{2, GD.Load<Texture>("res://scenes/Management/assets/grün.png")},
		{3, GD.Load<Texture>("res://scenes/Management/assets/blau.png")},
		{4, GD.Load<Texture>("res://scenes/Management/assets/lila.png")},
		{5, GD.Load<Texture>("res://scenes/Management/assets/gelb.png")}
	};

	public Dictionary<Texture, int> TextureToColor;
	
	private SubmitResults _submitResults;
	private Node2D _submitResultsPopUp;
	
	
	public override void _Ready() {
		_submitResults = GetNode<SubmitResults>("/root/Management/SubmitResults");
		_submitResultsPopUp = GetNode<Node2D>("/root/Management/SubmitResults");
		TextureToColor = _colorTextures.ToDictionary(x => x.Value, x => x.Key);
		_mouseFollower = GetNode<Sprite>("MouseFollower");
		_colorText = GetNode<RichTextLabel>("ColorSelector/Text");
		_orangeButton = GetNode<TextureButton>("ColorSelector/Orange");
		_blueButton = GetNode<TextureButton>("ColorSelector/Blue");
		_purpleButton = GetNode<TextureButton>("ColorSelector/Purple");
		_yellowButton = GetNode<TextureButton>("ColorSelector/Yellow");
		_greenButton = GetNode<TextureButton>("ColorSelector/Green");
		_submitButton = GetNode<TextureButton>("SubmitButton");
		_orangeButton.Connect("pressed", this, nameof(OnColorButtonPress), new Godot.Collections.Array {0});
		_greenButton.Connect("pressed", this, nameof(OnColorButtonPress), new Godot.Collections.Array {1});
		_blueButton.Connect("pressed", this, nameof(OnColorButtonPress), new Godot.Collections.Array {2});
		_purpleButton.Connect("pressed", this, nameof(OnColorButtonPress), new Godot.Collections.Array {3});
		_yellowButton.Connect("pressed", this, nameof(OnColorButtonPress), new Godot.Collections.Array {4});
		_submitButton.Connect("pressed", this, nameof(SubmitResult));
		foreach (var note in GetNode("Notes").GetChildren()) {
			if (note is ManagementNote managementNote) {
				_notes.Add(managementNote);
			}
		}
	}

	public void OnColorButtonPress(int id) {
		_mouseFollower.Visible = true;
		Input.MouseMode = Input.MouseModeEnum.Hidden;
		switch (id) {
			case 0:
				_selectedColor = 1;
				_colorText.Text = "Art";
				_mouseFollower.Modulate = Colors.Orange;
				break;
			case 1:
				_selectedColor = 2;
				_colorText.Text = "Narrative";
				_mouseFollower.Modulate = Colors.DarkGreen;
				break;
			case 2:
				_selectedColor = 3;
				_colorText.Text = "Programming";
				_mouseFollower.Modulate = Colors.Blue;
				break;
			case 3:
				_selectedColor = 4;
				_colorText.Text = "Game Design";
				_mouseFollower.Modulate = Colors.Purple;
				break;
			case 4:
				_selectedColor = 5;
				_colorText.Text = "Sound";
				_mouseFollower.Modulate = Colors.Yellow;
				break;
			default:
				return;
		}
	}

	private void SubmitResult() {
		double points = 0;
		var cardsColoredCorrectly = 0;
		foreach (var note in _notes) {
			var colorId = TextureToColor[note.NoteColor.Texture];
			if (colorId == note.ValidColorID) {
				points += 2.5;
				cardsColoredCorrectly++;
			}
		}

		foreach (var entry in  BoxedNotes) {
			if (entry.Value.Name.Equals(entry.Key.Name) || entry.Key.ValidIDs.Contains(entry.Value.Name)) {
				points += 2.5;
			}
		}
		points += GetNode<CountdownTimer>("/root/Management/TopBar/Timer").GetBonusPointsForTime();
		/*
		GD.Print("Points: " + points);
		var shared = GetNode<SharedNode>("/root/SharedNode");
		shared.managementPoints = points;
		shared.managementColors = cardsColoredCorrectly; 
		shared.managementTime = GetNode<CountdownTimer>("/root/Management/TopBar/Timer").CurrentTime;
		shared.CompletedTasks.Add(AbilitySpecialization.Management);
		shared.SwitchScene("res://scenes/Rooms/ManagementRoom.tscn");
		*/
		_submitResultsPopUp.Visible = true;
		_submitResults.managementPoints = points;
		_submitResults.cardsColoredCorrectly = cardsColoredCorrectly;
		_submitResults.managementTime = GetNode<CountdownTimer>("/root/Management/TopBar/Timer").CurrentTime;
	}

	public override void _Process(float delta) {
		if (_didJustRecolor && DateTime.Now.Millisecond - _lastRecolorTime > 100) { // Don't allow moving for 100ms after recoloring, otherwise you might accidentally move the note out of the box again
			_didJustRecolor = false;
			GD.Print("Can now move again");
		}
		_mouseFollower.Position = GetGlobalMousePosition();
		if (_currentBox != null && _currentNote != null && isDragging && !_didJustRecolor) {
			if (!Input.IsMouseButtonPressed((int) ButtonList.Left) && !BoxedNotes.ContainsKey(_currentBox)) {
				_currentNote.Position = _currentBox.GlobalPosition;
				_dragOffset = Vector2.Zero;
				BoxedNotes.Add(_currentBox, _currentNote);
				isDragging = false;
				GD.Print("Note " +  _currentNote.Name + " put in box " + _currentBox.Name);
				return;
			}
		}
		if (_selectedColor != 0) {
			if (Input.IsMouseButtonPressed((int) ButtonList.Left) && _currentNote != null) {
				_currentNote.NoteColor.Texture = _colorTextures[_selectedColor];
				var image = _currentNote.NoteColor.Texture.GetData();
				image.Lock();
				var color = image.GetPixel(100, 100);
				_currentNote.ColorRect.Color = color;
				image.Unlock();
				if (_selectedColor == 5 || _selectedColor == 2) {
					_currentNote.GetNode<RichTextLabel>("NoteText").AddColorOverride("default_color", Colors.Black);
				}
				else {
					_currentNote.GetNode<RichTextLabel>("NoteText").RemoveColorOverride("default_color");
				}
				GD.Print("Coloring note " + _currentNote.Name + " with color " + _selectedColor);
				_selectedColor = 0;
				_mouseFollower.Visible = false;
				Input.MouseMode = Input.MouseModeEnum.Visible;
				_colorText.Text = "Select...";
				_didJustRecolor = true;
				_lastRecolorTime = DateTime.Now.Millisecond;
			}
			return;
		}
		if (_currentNote != null && _selectedColor == 0 && !_didJustRecolor) {
			if (Input.IsMouseButtonPressed((int) ButtonList.Left) && _selectedColor == 0) {
				if (_dragOffset == Vector2.Zero) {
					_dragOffset = _currentNote.Position - GetGlobalMousePosition();
				}
				var x = Mathf.Clamp(GetGlobalMousePosition().x + _dragOffset.x, 0, GetViewport().Size.x + 20);
				var y = Mathf.Clamp(GetGlobalMousePosition().y + _dragOffset.y, 0, GetViewport().Size.y + 20);
				_currentNote.Position = new Vector2(x, y);
				if (BoxedNotes.ContainsValue(_currentNote)) { // Not used for now, maybe we allow reordering later
					var box = BoxedNotes.First(n => n.Value == _currentNote).Key;
					box.NoteColor.Color = _defaultBoxColor;
					BoxedNotes.Remove(box);
					GD.Print("Removed note " +  _currentNote.Name + " from box " + box.Name);
				}
				isDragging = true;
			}
			else if (_selectedColor == 0) {
				_dragOffset = Vector2.Zero;
			}
		}

	}

	public void BoxEntered(NoteBox box, ManagementNote note) {
		if (_currentNote != note) {
			return;
		}
		_currentBox = box;
	}

	public void MouseEntered(ManagementNote note) {
		if (_dragOffset != Vector2.Zero) {
			return;
		}
		_currentNote = note;
	}

	public void MouseLeft(ManagementNote note) {
		if (_dragOffset == Vector2.Zero) {
			_currentNote = null;
		}

	}

}

