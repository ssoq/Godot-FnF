using Godot;
using System;

public partial class CameraFocusPlayer : Node2D
{
	// FUCK UNITY - GODOT TRILLION TIMES BETTER - OPEN SOURCE ON TOP

	[ExportSubgroup("Focusing Positions")]
	[Export] private Vector2 playerOnePosition;
	[Export] private Vector2 playerTwoPosition;
	[Export] private Vector2 bothPlayersPosition;

	[ExportSubgroup("Focusing Field of Views")]
	[Export] private Vector2 playerOneFov;
	[Export] private Vector2 playerTwoFov;
	[Export] private Vector2 bothPlayersFov;

	[ExportSubgroup("Focusing Booleans")]
	[Export] private bool playerOneSinging; // using player one as sometimes there will only be one player and ai
	[Export] private bool bothSinging;

	[ExportSubgroup("Nodes")]
	[Export] private Camera2D camera;

	[ExportSubgroup("Customisable")]
	[Export] private float smoothing = 10f;

	private double deltaTime; // due to my unity experience

	public override void _Ready()
	{
		camera = GetNode<Camera2D>("CameraPanner/Camera2D");
	}

	public override void _Process(double delta)
	{
		deltaTime = delta;

		FocusCurrentSinger();
	}

	private void FocusCurrentSinger() 
	{
		#region Update Position of Camera

		var positionForCurrentSinger = playerOneSinging && !bothSinging ? playerOnePosition : !playerOneSinging && !bothSinging ? playerTwoPosition : bothPlayersPosition;
		Position = positionForCurrentSinger; // lerping is done by the camera which was enabled within the editor

		#endregion

		#region Update FoV of Camera

		var fovForCurrentSinger = playerOneSinging && !bothSinging ? playerOneFov : !playerOneSinging && !bothSinging ? playerTwoFov: bothPlayersFov;
		camera.Zoom.Lerp(fovForCurrentSinger, smoothing * (float)deltaTime);

		#endregion
	}
}
