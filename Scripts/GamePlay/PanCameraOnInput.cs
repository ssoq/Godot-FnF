using Godot;
using System;

public partial class PanCameraOnInput : Node2D
{
	[ExportSubgroup("Positions for Camera to Lerp to")]
	[Export] private Vector2 normal;
	[Export] private Vector2 left;
	[Export] private Vector2 down;
	[Export] private Vector2 up;
	[Export] private Vector2 right;

	private double deltaTime; // due to my unity experience

	public override void _Process(double delta)
	{

		AdjustCameraPositionOnInput();
	}

	private void AdjustCameraPositionOnInput() 
	{
		if (GameManager.instance.dead) return;

		if (Input.IsActionPressed("left")) Position = left;
		if (Input.IsActionPressed("down")) Position = down;
		if (Input.IsActionPressed("up")) Position = up;
		if (Input.IsActionPressed("right")) Position = right;
		if (!Input.IsActionPressed("left") && !Input.IsActionPressed("down") && !Input.IsActionPressed("up") && !Input.IsActionPressed("right")) Position = normal;
	}
}
