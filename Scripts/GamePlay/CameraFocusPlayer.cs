using Godot;
using System;

public partial class CameraFocusPlayer : Node2D
{
	// FUCK UNITY - GODOT TRILLION TIMES BETTER - OPEN SOURCE ON TOP

	[ExportSubgroup("Instancing")]
	public static CameraFocusPlayer instance;

	[ExportSubgroup("Focusing Positions")]
	[Export] private Vector2 playerOnePosition;
	[Export] private Vector2 playerTwoPosition;
	[Export] private Vector2 bothPlayersPosition;
	[Export] private Vector2 playerDiePosition;

	[ExportSubgroup("Focusing Field of Views")]
	[Export] private Vector2 playerOneFov;
	[Export] private Vector2 playerTwoFov;
	[Export] private Vector2 bothPlayersFov;
	[Export] private Vector2 playerDieFov;

	[ExportSubgroup("Focusing Booleans")]
	[Export] public bool playerOneSinging; // using player one as sometimes there will only be one player and ai
	[Export] public bool bothSinging;

	[ExportSubgroup("Nodes")]
	[Export] private Camera2D camera;

	[ExportSubgroup("Customisable")]
	[Export] private float smoothing = 10.0f;

	private double deltaTime; // due to my unity experience

	public override void _Ready()
	{
		instance = this;
		camera = GetNode<Camera2D>("CameraPanner/CameraShaker/Camera2D");
	}

	public override void _Process(double delta)
	{
		deltaTime = delta;

		FocusCurrentSinger();
	}

	private void FocusCurrentSinger() 
	{
		#region Update Position and FoV to Player Dead Position

		if (GameManager.instance.dead)
		{
			Position = playerDiePosition;
			camera.Zoom = camera.Zoom.Lerp(playerDieFov, smoothing * (float)deltaTime);
		}

		#endregion

		if (GameManager.instance.dead) return;

		#region Update Position of Camera

		Vector2 positionForCurrentSinger = playerOneSinging && !bothSinging ? playerOnePosition : !playerOneSinging && !bothSinging ? playerTwoPosition : bothPlayersPosition;
		Position = positionForCurrentSinger; // lerping is done by the camera which was enabled within the editor

		#endregion

		#region Update FoV of Camera

		Vector2 fovForCurrentSinger = playerOneSinging && !bothSinging ? playerOneFov : !playerOneSinging && !bothSinging ? playerTwoFov: bothPlayersFov;
		camera.Zoom = camera.Zoom.Lerp(fovForCurrentSinger, smoothing * (float)deltaTime);

		#endregion
	}
}
