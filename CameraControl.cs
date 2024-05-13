using Godot;
using System;


public partial class CameraControl : Node3D
{
	private CharacterBody3D player;

	[Export] private float mouseSens = 0.2f;

	public override void _Ready()
	{
		Input.MouseMode = Input.MouseModeEnum.Captured;
		player = GetNode<CharacterBody3D>("..");
	}

    public override void _UnhandledInput(InputEvent @event)
    {
		//controls the camera whit mouse movement
		if (@event is InputEventMouseMotion mouseEvent)
		{
			Vector2 mouseRelative = mouseEvent.Relative;

			//rota player horizontal
			player.RotateY(Mathf.DegToRad(-mouseRelative.X * mouseSens));
			//rota camMount en vertical
			RotateX(Mathf.DegToRad(-mouseRelative.Y * mouseSens));

			//clamp camMount vertical
			float maxRotation = -60f;
			float minRotation = 20;
			RotationDegrees = new Vector3(
				Mathf.Clamp(RotationDegrees.X, maxRotation, minRotation), 0, 0);
		}
    }
}
