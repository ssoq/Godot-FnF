using Godot;
using System;

public partial class Rating : AnimationPlayer
{
	public override void _Ready()
	{
		Play("ratingJump");
	}

	public override void _Process(double delta)
	{
		if (!IsPlaying()) 
		{
			QueueFree();
		}
	}
}
