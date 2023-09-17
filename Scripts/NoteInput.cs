using Godot;
using System;

public partial class NoteInput : AnimatedSprite2D
{
	[Export] private string keyName;

	public override void _Ready()
	{

	}

	public override void _Process(double delta)
	{
		AnimateOnInput();
	}

	private void AnimateOnInput() 
	{
		if (Input.IsActionPressed(keyName))
		{
			if (Frame != 5) Play("Press");
			else Frame = 5;
		}
		else 
		{
			Play("Idle");
		}
	}
}
