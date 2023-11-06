using Godot;
using System;

public class Player : KinematicBody2D {

    [Export]
    private float gravity = 200.0f;
    private Vector2 _velocity;

    
    public override void _PhysicsProcess(float delta) {
        _velocity.y += delta * gravity;
        var motion = _velocity * delta;
        MoveAndCollide(motion);
    }
}
