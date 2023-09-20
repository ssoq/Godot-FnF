using Godot;
using System;

public partial class HUDAnimationPlayers : AnimationPlayer
{
	public override void _Process(double delta)
	{
		if (GameManager.instance.dead) FadeOut();
	}

	private bool hasPlayed = false;
	public void FadeOut() 
	{
		if (GameManager.instance.dead && !hasPlayed) 
		{
			hasPlayed = true;
			Play("FadeOut"); 
		}
	}
}
