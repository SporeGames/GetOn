using Godot;
using System;
using GetOn.scenes;

public class Player : KinematicBody2D {
	
	private SharedNode _sharedNode;
	[Export]
	private float gravity = 200.0f;
	[Export]
	private float jumpForce = 300.0f;
	private Vector2 _velocity;
	private Area2D _flagArea;
	
	public ulong _lastJump = 0;
	private bool _jumping = false;
	
	private Vector2 _verticalVelocity = new Vector2(0, 0);
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
		_verticalVelocity += gravity * delta * Vector2.Down;
		MoveAndSlide(_verticalVelocity, Vector2.Up);
		if (IsOnFloor() && _jumping) {
			_verticalVelocity = jumpForce * Vector2.Up;
		}

		direction.Normalized();
		MoveAndSlide(direction);
	}

	public void OnAreaEnter(Area2D area) {
		if (area.Name == "HardFlag") {
			_sharedNode.SwitchScene("res://scenes/EndScreen/EndScreen.tscn");
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
