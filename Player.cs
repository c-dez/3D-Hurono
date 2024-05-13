using Godot;
using System;

public partial class Player : CharacterBody3D
{
	[Export] public float speed = 5.0f;
	[Export] public float jumpVelocity = 4.5f;

	public Vector2 inputVector = Vector2.Zero;

	// Get the gravity from the project settings to be synced with RigidBody nodes.
	public float gravity = ProjectSettings.GetSetting("physics/3d/default_gravity").AsSingle();

	public override void _PhysicsProcess(double delta)
	{
		GetInput();
		PlayerMove(delta);
	}


	private void GetInput()
	{
		inputVector = Input.GetVector("left", "right", "up", "down");
	}

	private void PlayerMove(double delta)
	{
		Vector3 velocity = Velocity;

		// Add the gravity.
		if (!IsOnFloor())
			velocity.Y -= gravity * (float)delta;

		// Handle Jump.
		if (Input.IsActionJustPressed("space") && IsOnFloor())
			velocity.Y = jumpVelocity;

		Vector3 direction = (Transform.Basis * new Vector3(inputVector.X, 0, inputVector.Y)).Normalized();
		if (direction != Vector3.Zero)
		{
			velocity.X = direction.X * speed;
			velocity.Z = direction.Z * speed;
		}
		else
		{
			velocity.X = Mathf.MoveToward(Velocity.X, 0, speed);
			velocity.Z = Mathf.MoveToward(Velocity.Z, 0, speed);
		}

		Velocity = velocity;
		MoveAndSlide();
	}
}
