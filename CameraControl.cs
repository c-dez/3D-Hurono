using Godot;
using System;


public partial class CameraControl : Node3D
{
	private CharacterBody3D player;
	private  Node3D visuals;


	[Export] private float mouseSensX = 0.1f;
	[Export] private float mouseSensY = 0.1f;

	public override void _Ready()
	{
		Input.MouseMode = Input.MouseModeEnum.Captured;
		player = GetNode<CharacterBody3D>("..");
		visuals = GetNode<Node3D>("../Visuals");
	}

    public override void _UnhandledInput(InputEvent @event)
    {
		//controls the camera whit mouse movement
		if (@event is InputEventMouseMotion mouseEvent)
		{
			Vector2 mouseRelative = mouseEvent.Relative;

			//rota player horizontal
			player.RotateY(Mathf.DegToRad(-mouseRelative.X * mouseSensX));
			//rota camMount en vertical
			RotateX(Mathf.DegToRad(-mouseRelative.Y * mouseSensY));

			//clamp camMount vertical
			float maxRotation = -60f;
			float minRotation = 20;
			RotationDegrees = new Vector3(
				Mathf.Clamp(RotationDegrees.X, maxRotation, minRotation), 0, 0);

			//rotate visuals 
			visuals.RotateY(Mathf.DegToRad(-mouseRelative.X * mouseSensX));	
		}
    }
}
