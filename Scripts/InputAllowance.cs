using Godot;
using System;

public partial class InputAllowance : Area2D
{
	[ExportSubgroup("Settings")]
	[Export] private bool noteWithinArea;
	[Export] private string keyName;
	[Export] private Area2D currentNoteWithinArea;
	
	public override void _Process(double delta)
	{
		ProccessInputUponNoteEntry();
	}
	
	private void ProccessInputUponNoteEntry() 
	{
		if (currentNoteWithinArea == null) return;

		var noteScript = currentNoteWithinArea.GetNode<Note>;

		if (Input.IsActionJustPressed(keyName) && noteWithinArea) 
		{
			currentNoteWithinArea.Hide();
		}
	}
	
	private void NoteEntered(Area2D area)
	{
		noteWithinArea = true;
		currentNoteWithinArea = area;
	}
	
	private void NoteExited(Area2D area)
	{
		noteWithinArea = false;
		currentNoteWithinArea = null;
	}
}
