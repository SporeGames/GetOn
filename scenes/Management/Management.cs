using System;
using Godot;
using System.Collections.Generic;
using System.Linq;
using GetOn.scenes;
using GetOn.scenes.Management;

public class Management : Node2D {
	
	[Export] public PackedScene NoteScene;
	
	private RichTextLabel _colorText;
	private Button _orangeButton;
	private Button _blueButton;
	private Button _purpleButton;
	private Button _yellowButton;
	private Button _greenButton;
	private Button _blackButton;
	private Button _submitButton;

	
	private ManagementNote _currentNote;
	private Vector2 _dragOffset = Vector2.Zero;
	private Color _selectedColor = Colors.White;

	private List<ManagementNote> _notes = new List<ManagementNote>();
	public Dictionary<NoteBox, ManagementNote> BoxedNotes = new Dictionary<NoteBox, ManagementNote>();
	private static Color _defaultBoxColor = new Color(0.69f, 0.69f, 0.69f, 1);
	private bool _hasJustSnapped = false;
	
	private Button _start;
	private Node2D _intro;
	
	
	public override void _Ready() {
		_colorText = GetNode<RichTextLabel>("ColorSelector/Text");
		_orangeButton = GetNode<Button>("ColorSelector/Orange");
		_blueButton = GetNode<Button>("ColorSelector/Blue");
		_purpleButton = GetNode<Button>("ColorSelector/Purple");
		_yellowButton = GetNode<Button>("ColorSelector/Yellow");
		_greenButton = GetNode<Button>("ColorSelector/Green");
		_blackButton = GetNode<Button>("ColorSelector/Black");
		_submitButton = GetNode<Button>("SubmitButton");
		_start = GetNode<Button>("Intro/StartPuzzle");
		_intro = GetNode<Node2D>("Intro");
		_start.Connect("pressed", this, nameof(CloseIntro));
		_orangeButton.Connect("pressed", this, nameof(OnColorButtonPress), new Godot.Collections.Array {0});
		_blueButton.Connect("pressed", this, nameof(OnColorButtonPress), new Godot.Collections.Array {1});
		_purpleButton.Connect("pressed", this, nameof(OnColorButtonPress), new Godot.Collections.Array {2});
		_yellowButton.Connect("pressed", this, nameof(OnColorButtonPress), new Godot.Collections.Array {3});
		_greenButton.Connect("pressed", this, nameof(OnColorButtonPress), new Godot.Collections.Array {4});
		_blackButton.Connect("pressed", this, nameof(OnColorButtonPress), new Godot.Collections.Array {5});
		_submitButton.Connect("pressed", this, nameof(SubmitResult));
		// Apparently modulate isn't exposed to the editor, so we have to do it manually
		_orangeButton.Modulate = Colors.Orange;
		_blueButton.Modulate = Colors.Blue;
		_purpleButton.Modulate = Colors.Purple;
		_yellowButton.Modulate = Colors.Yellow;
		_greenButton.Modulate = Colors.Green;
		foreach (var note in GetNode("Notes").GetChildren()) {
			if (note is ManagementNote managementNote) {
				_notes.Add(managementNote);
			}
		}
	}

	public void OnColorButtonPress(int id) {
		switch (id) {
			case 0:
				_selectedColor = Colors.Orange;
				_colorText.Text = "Art";
				break;
			case 1:
				_selectedColor = Colors.Blue;
				_colorText.Text = "Programming";
				break;
			case 2:
				_selectedColor = Colors.Purple;
				_colorText.Text = "Game Design";
				break;
			case 3:
				_selectedColor = Colors.Yellow;
				_colorText.Text = "Sound";
				break;
			case 4:
				_selectedColor = Colors.Green;
				_colorText.Text = "Narrative";
				break;
			case 5:
				_selectedColor = Colors.Black;
				_colorText.Text = "Management";
				break;
			default:
				return;
		}
	}

	private void SubmitResult() {
		var points = 0;
		var cardsColoredCorrectly = 0;
		foreach (var note in _notes) {
			var ColorID = note.NoteColor.Color == Colors.Orange ? 0 :
				note.NoteColor.Color == Colors.Blue ? 1 :
				note.NoteColor.Color == Colors.Purple ? 2 :
				note.NoteColor.Color == Colors.Yellow ? 3 :
				note.NoteColor.Color == Colors.Green ? 4 :
				note.NoteColor.Color == Colors.Black ? 5 : -1;
			if (ColorID == note.ValidColorID) {
				points += 3;
				cardsColoredCorrectly++;
			}
			else if (ColorID != -1) {
				points += 1;
			}
		}

		foreach (var entry in  BoxedNotes) {
			if (entry.Value.Name.Equals(entry.Key.Name)) {
				points += 3;
			}
			else {
				points += 1;
			}
		}
		GD.Print("Points: " + points);
		var shared = GetNode<SharedNode>("/root/SharedNode");
		shared.managementPoints = points;
		shared.managementColors = cardsColoredCorrectly; 
		shared.managementTime = GetNode<CountdownTimer>("/root/Management/Timer").CurrentTime;
		shared.CompletedTasks.Add("management");
		shared.SwitchScene("res://scenes/Management/AfterPuzzleRoom.tscn");
	}

	public override void _Process(float delta) {
		if (!Input.IsMouseButtonPressed((int) ButtonList.Left)) {
			_hasJustSnapped = false;
		}
		if (_selectedColor != Colors.White) {
			if (Input.IsMouseButtonPressed((int) ButtonList.Left) && _currentNote != null) {
				_currentNote.NoteColor.Color = _selectedColor;
				// Black text is a bit hard to read on black background
				if (_selectedColor == Colors.Black) {
					_currentNote.GetNode<RichTextLabel>("NoteText").AddColorOverride("default_color", Colors.White);
				}
				if (_selectedColor == Colors.Yellow || _selectedColor == Colors.Green) {
					_currentNote.GetNode<RichTextLabel>("NoteText").AddColorOverride("default_color", Colors.Black);
				}
				else {
					_currentNote.GetNode<RichTextLabel>("NoteText").RemoveColorOverride("default_color");
				}
				_selectedColor = Colors.White;
				_colorText.Text = "Select...";
			}
		}
		if (_currentNote != null && !_hasJustSnapped) {
			if (Input.IsMouseButtonPressed((int) ButtonList.Left) && _selectedColor == Colors.White) {
				if (_dragOffset == Vector2.Zero) {
					_dragOffset = _currentNote.Position - GetGlobalMousePosition();
				}
				var x = Mathf.Clamp(GetGlobalMousePosition().x + _dragOffset.x, 0, GetViewport().Size.x);
				var y = Mathf.Clamp(GetGlobalMousePosition().y + _dragOffset.y, 0, GetViewport().Size.y);
				_currentNote.Position = new Vector2(x, y);
				if (BoxedNotes.ContainsValue(_currentNote)) { // Not used for now, maybe we allow reordering later
					var box = BoxedNotes.First(n => n.Value == _currentNote).Key;
					box.NoteColor.Color = _defaultBoxColor;
					BoxedNotes.Remove(box);
					GD.Print("Removed note " +  _currentNote.Name + " from box " + box.Name);
				}
			}
			else if (_selectedColor == Colors.White) {
				_dragOffset = Vector2.Zero;
			}
		}

	}

	public void BoxEntered(NoteBox box, ManagementNote note) {
		if (_currentNote != note) {
			return;
		}

		_currentNote.Position = box.GlobalPosition;
		_currentNote = null;
		_dragOffset = Vector2.Zero;
		GD.Print("Note put in box");
		box.NoteColor.Color = Colors.White;
		BoxedNotes.Add(box, note);

		_hasJustSnapped = true;
	}
	
	public void BoxLeft(NoteBox box, ManagementNote note) {
		
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

	public void CloseIntro() {
		_intro.Visible = false;
		GetNode<CountdownTimer>("/root/Management/Timer").running = true;

	}
	
}

