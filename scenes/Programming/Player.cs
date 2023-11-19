using Godot;
using System;
using GetOn.scenes;
using GetOn.scenes.Programming;

public class Player : KinematicBody2D {
	
	private SharedNode _sharedNode;
	[Export]
	private float gravity = 200.0f;
	[Export]
	private float jumpForce = 500.0f;
	private Vector2 _velocity;
	private Area2D _flagArea;
	
	public ulong _lastJump = 0;
	private bool _jumping = false;
	
	public Vector2 VerticalVelocity = new Vector2(0, 0);
	public Vector2 direction = new Vector2(0, 0);

	public override void _Ready() {
		_sharedNode = GetNode<SharedNode>("/root/SharedNode");
		_flagArea = GetNode<Area2D>("FlagArea");
		_flagArea.Connect("area_entered", this, nameof(OnAreaEnter));
	}

	public override void _PhysicsProcess(float delta) {
		if (_jumping && _lastJump + 250 < OS.GetTicksMsec()) {
			_jumping = false;
		}
		VerticalVelocity += gravity * delta * Vector2.Down;
		MoveAndSlide(VerticalVelocity, Vector2.Up);
		if (IsOnFloor() && _jumping) {
			VerticalVelocity = jumpForce * Vector2.Up;
		}
	}

	public void OnAreaEnter(Area2D area) {
		if (area.Name == "HardFlag") {
			GetNode<Checklist>("/root/Programming/Checklist").HardFlag();
		}
		if (area.Name == "EasyFlag") {
			GetNode<Checklist>("/root/Programming/Checklist").EasyFlag();
		}
	}

	public void Jump() {
		if (_lastJump + 500 > OS.GetTicksMsec()) {
			return;
		}
		_jumping = true;
		_lastJump = OS.GetTicksMsec();
	}
}
