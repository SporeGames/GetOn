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
	private Dictionary<NoteBox, ManagementNote> _boxedNotes = new Dictionary<NoteBox, ManagementNote>();
	private static Color _defaultBoxColor = new Color(0.41f, 0.41f, 0.41f, 1);
	
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
		_submitButton = GetNode<Button>("ColorSelector/SubmitButton");
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
				_colorText.Text = "Orange";
				break;
			case 1:
				_selectedColor = Colors.Blue;
				_colorText.Text = "Blue";
				break;
			case 2:
				_selectedColor = Colors.Purple;
				_colorText.Text = "Purple";
				break;
			case 3:
				_selectedColor = Colors.Yellow;
				_colorText.Text = "Yellow";
				break;
			case 4:
				_selectedColor = Colors.Green;
				_colorText.Text = "Green";
				break;
			case 5:
				_selectedColor = Colors.Black;
				_colorText.Text = "Black";
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
				points = +3;
				cardsColoredCorrectly++;
			}
			else if (ColorID != -1) {
				points = +1;
			}
		}
		points += _boxedNotes.Count * 2;
		GD.Print("Points: " + points);
		var shared = GetNode<SharedNode>("/root/SharedNode");
		shared.managementPoints = points;
		shared.managementColors = cardsColoredCorrectly;
		//shared.SwitchScene("res://scenes/GameSelRoom/GameSelectionRoom.tscn");
		shared.SwitchScene("res://scenes/GameSelectionRoom/GameSelectionRoom.tscn");
	}

	public override void _Process(float delta) {
		if (_selectedColor != Colors.White) {
			if (Input.IsMouseButtonPressed((int) ButtonList.Left) && _currentNote != null) {
				_currentNote.NoteColor.Color = _selectedColor;
				_selectedColor = Colors.White;
				_colorText.Text = "Select...";
			}
		}
		if (_currentNote != null && !_boxedNotes.ContainsValue(_currentNote)) {
			if (Input.IsMouseButtonPressed((int) ButtonList.Left) && _selectedColor == Colors.White) {
				if (_dragOffset == Vector2.Zero) {
					_dragOffset = _currentNote.Position - GetGlobalMousePosition();
				}
				var x = Mathf.Clamp(GetGlobalMousePosition().x + _dragOffset.x, 0, GetViewport().Size.x);
				var y = Mathf.Clamp(GetGlobalMousePosition().y + _dragOffset.y, 0, GetViewport().Size.y);
				_currentNote.Position = new Vector2(x, y);
			}
			else if (_selectedColor == Colors.White) {
				_dragOffset = Vector2.Zero;
			}

			if (_boxedNotes.ContainsValue(_currentNote)) { // Not used for now, maybe we allow reordering later
				var box = _boxedNotes.First(x => x.Value == _currentNote).Key;
				box.NoteColor.Color = _defaultBoxColor;
				_boxedNotes.Remove(box);
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
		box.NoteColor.Color = Colors.Green;
		_boxedNotes.Add(box, note);
		if (_boxedNotes.Count == _notes.Count) {
			_submitButton.Disabled = false;
		}
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

	public void CloseIntro()
	{
		_intro.Visible = false;
	}
	
}

