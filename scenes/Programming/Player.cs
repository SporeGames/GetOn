using Godot;
using System;
using GetOn.scenes;
using GetOn.scenes.Programming;

public class Player : KinematicBody2D {
	
	private SharedNode _sharedNode;
	private Area2D _flagArea;

	public int Speed = 0;
	[Export] public int JumpSpeed = -400;
	[Export] public int Gravity = 1200;
	Vector2 velocity = new Vector2();
	bool jumping = false;

	public bool JumpingInput;
	public bool MovingRight;
	public override void _Ready() {
		_sharedNode = GetNode<SharedNode>("/root/SharedNode");
		_flagArea = GetNode<Area2D>("FlagArea");
		_flagArea.Connect("area_entered", this, nameof(OnAreaEnter));
	}
	
	
	public void getInput() {
		velocity.x = 0;
		if (JumpingInput && IsOnFloor()) {
			jumping = true;
			velocity.y = JumpSpeed;
		}
		if (MovingRight) {
			velocity.x += Speed;
		}
	}

	public override void _PhysicsProcess(float delta) {
		getInput();
		velocity.y += Gravity * delta;
		if (jumping && IsOnFloor()) {
			jumping = false;
		}
		velocity = MoveAndSlide(velocity, new Vector2(0, -1));
		JumpingInput = false;
		MovingRight = false;
	}

	public void OnAreaEnter(Area2D area) {
		if (area.Name == "HardFlag") {
			GetNode<Checklist>("/root/Programming/Checklist").HardFlag();
		}
		if (area.Name == "EasyFlag") {
			GetNode<Checklist>("/root/Programming/Checklist").EasyFlag();
		}
	}
	
}
