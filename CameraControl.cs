using Godot;
using System;


public partial class CameraControl : Node3D
{
	private CharacterBody3D player;
	private Node3D camMount;

	public override void _Ready()
	{
		Input.MouseMode = Input.MouseModeEnum.Captured;
		player = GetNode<CharacterBody3D>("..");
		camMount = GetNode<Node3D>("../CamMount");
	}

    public override void _UnhandledInput(InputEvent @event)
    {
		if (@event is InputEventMouseMotion mouseEvent)
		{
			Vector2 mouseRelative = mouseEvent.Relative;
			GD.Print(camMount.Name);
		}
    }
}
