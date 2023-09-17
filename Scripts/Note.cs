using Godot;
using System;

public partial class Note : Area2D
{
	public bool canHit = false;
	public bool shit = false;
	public bool bad = false;
	public bool good = false;
	public bool sick = false;

	private void OnColliderAreaEntered(Area2D area)
	{
		if (area.Name == "Shit") canHit = true;
		if (area.Name == "Shit") shit = true;
		if (area.Name == "Bad") bad = true;
		if (area.Name == "Good") good = true;
		if (area.Name == "Sick") sick = true;
		//GD.Print(shit + " " + bad + " " + good + " " + sick);
	}

	private void OnCollisionAreaExited(Area2D area)
	{
		if (area.Name == "Shit") canHit = false;
		if (area.Name == "Shit") shit = false;
		if (area.Name == "Bad") bad = false;
		if (area.Name == "Good") good = false;
		if (area.Name == "Sick") sick = false;
		//GD.Print(shit + " " + bad + " " + good + " " + sick);
	}
}
