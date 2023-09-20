using Godot;
using System;

public partial class NoteMisser : Area2D
{
	private void NoteMiss(Area2D area) 
	{
		GameManager.instance.health -= GameManager.instance.healthToMinus;
		GD.Print(GameManager.instance.health);
		area.QueueFree();
	}
}
