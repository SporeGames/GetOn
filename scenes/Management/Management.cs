using System;
using Godot;
using System.Collections.Generic;
using System.Linq;
using GetOn.scenes.Management;

public class Management : Node2D {

    [Export] public List<NoteContent> NoteContents;
    [Export] public PackedScene NoteScene;
    private ManagementNote _currentNote;
    private ManagementNote _connectingNote;
    private Line2D _connectingLine;
    
    public override void _Ready() {
        CreateNotes();
    }

    public override void _Process(float delta) {
        if (_connectingLine != null) {
            if (_connectingLine.Points.Length == 1) {
                _connectingLine.AddPoint(GetGlobalMousePosition());
            }
            _connectingLine.SetPointPosition(1, GetGlobalMousePosition());
        }
        if (_currentNote != null) {
            if (Input.IsMouseButtonPressed((int) ButtonList.Left)) {
                GD.Print("Mouse pressed");
                _currentNote.Position = GetGlobalMousePosition();
                _currentNote.UpdateLineAnchors(); // TODO: Doesn't work properly
            }
        }
    }

    private void CreateNotes() {
        var noteScene = (PackedScene) ResourceLoader.Load("res://scenes/Management/ManagementNote.tscn");
        var rand = new RandomNumberGenerator();
        foreach (var content in NoteContents) {
            var note = (ManagementNote) noteScene.Instance();
            AddChild(note);
            note.NoteText.Text = content.Content;
            note.NoteColor.Color = content.Color;
            note.Position = new Vector2(rand.RandfRange(0, 2000), rand.RandfRange(0, 1000));
        }
    }

    public void MouseEntered(ManagementNote note) {
        GD.Print("Mouse entered");
        _currentNote = note;
    }
    
    public void MouseLeft(ManagementNote note) {
        GD.Print("Mouse left");
        
        _currentNote = null;
    }

    public void ConnectStartLeft(ManagementNote managementNote) {
        if (_connectingLine != null && _connectingNote != managementNote && _connectingNote.ConnectLeft(_connectingLine, _connectingNote)) {
            _connectingLine.AddPoint(managementNote.RightAnchor.GlobalPosition);
            _connectingLine = null;
            _connectingNote = null;
            return;
        }
        var line = new Line2D();
        AddChild(line);
        line.AddPoint(managementNote.RightAnchor.GlobalPosition);
        _connectingLine = line;
        _connectingNote = managementNote;
    }

    public void ConnectStartRight(ManagementNote managementNote) {
        if (_connectingLine != null && _connectingNote != managementNote && _connectingNote.ConnectRight(_connectingLine, _connectingNote)) {
            _connectingLine.AddPoint(managementNote.LeftAnchor.GlobalPosition);
            _connectingLine = null;
            _connectingNote = null;
            return;
        }
        var line = new Line2D();
        AddChild(line);
        line.AddPoint(managementNote.LeftAnchor.GlobalPosition);
        _connectingLine = line;
        _connectingNote = managementNote;
    }
}
