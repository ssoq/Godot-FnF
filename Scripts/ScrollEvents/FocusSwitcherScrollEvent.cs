using Godot;
using System;

public partial class FocusSwitcherScrollEvent : Area2D
{
	[Export] private bool triggerPlayer;
	[Export] private bool triggerBoth;

	private void SwitchFocusOpenCollisionEntry(Area2D area)
	{
		if (area.Name == "ScrollEvents") 
		{
			if (triggerPlayer && !triggerBoth) { CameraFocusPlayer.instance.bothSinging = false; CameraFocusPlayer.instance.playerOneSinging = true; }
			else if (!triggerPlayer && !triggerBoth) { CameraFocusPlayer.instance.bothSinging = false; CameraFocusPlayer.instance.playerOneSinging = false; }
			else if (triggerPlayer && triggerBoth) { CameraFocusPlayer.instance.bothSinging = true; CameraFocusPlayer.instance.playerOneSinging = false; }
			else if (!triggerPlayer && triggerBoth) { CameraFocusPlayer.instance.bothSinging = true; CameraFocusPlayer.instance.playerOneSinging = false; }
		}
	}
}
