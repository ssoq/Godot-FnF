using Godot;
using System;

public partial class NoteCanvasLogic : Node2D
{
	[ExportSubgroup("Settings")]
	[Export] public bool dynamicScroll;
	[Export] private float smoothing = 10f;

	[ExportSubgroup("Positions")]
	[Export] private Vector2 playerOnePos;
	[Export] private Vector2 playerTwoPos;
	[Export] private Vector2 bothPlayerPos;

	private float deltaTime;

	public override void _Process(double delta)
	{
		deltaTime = (float)delta;

		ScrollType();
	}

	private void ScrollType()
	{
		if (dynamicScroll)
		{
			if (CameraFocusPlayer.instance.playerOneSinging && !CameraFocusPlayer.instance.bothSinging) Position = Position.Lerp(playerOnePos, smoothing * deltaTime);
			else if (!CameraFocusPlayer.instance.playerOneSinging && !CameraFocusPlayer.instance.bothSinging) Position = Position.Lerp(playerTwoPos, smoothing * deltaTime);
			else if (!CameraFocusPlayer.instance.playerOneSinging && CameraFocusPlayer.instance.bothSinging) Position = Position.Lerp(bothPlayerPos, smoothing * deltaTime);
			else if (CameraFocusPlayer.instance.playerOneSinging && CameraFocusPlayer.instance.bothSinging) Position = Position.Lerp(bothPlayerPos, smoothing * deltaTime);
		}
		else 
		{
			Position = bothPlayerPos;
		}
	}
}
