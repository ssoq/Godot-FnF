using Godot;
using System;

public partial class Scroller : AnimationPlayer
{
	public override void _Ready()
	{
		Play("Scroller");
	}
}
