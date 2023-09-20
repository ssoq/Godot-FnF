using Godot;
using System;

public partial class AnimatePlayerOnInput : AnimatedSprite2D
{
	[Export] private float leftOffset;
	[Export] private float downOffsetX;
	[Export] private float downOffsetY;
	[Export] private float upOffset;
	[Export] private float rightOffset = 80f;

	public override void _Process(double delta)
	{
		AnimatePlayer();
	}

	private void AnimatePlayer()
	{
		var offset = Offset;

		if (Input.IsActionPressed("left")) { Play("Left"); offset.X = leftOffset; offset.Y = 0; }
		if (Input.IsActionPressed("down")) { Play("Down"); offset.Y = downOffsetY; offset.X = downOffsetX; }
		if (Input.IsActionPressed("up")) { Play("Up"); offset.Y = upOffset; offset.X = 0; }
		if (Input.IsActionPressed("right")) { Play("Right"); offset.X = rightOffset; offset.Y = 0; }
		if (Frame == 4) { Play("Idle"); offset.X = 0f; offset.Y = 0f; }

		Offset = offset;
	}
}
