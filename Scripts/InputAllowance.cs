using Godot;
using System;

public partial class InputAllowance : Area2D
{
	[ExportSubgroup("Ratings for Instancing")]
	[Export] private Node ratingPosition;
	[Export] private PackedScene shitPrefab { get; set; }
	[Export] private PackedScene badPrefab { get; set; }
	[Export] private PackedScene goodPrefab { get; set; }
	[Export] private PackedScene sickPrefab { get; set; }

	[ExportSubgroup("Settings")]
	[Export] private bool noteWithinArea;
	[Export] private string keyName;
	[Export] private Area2D currentNoteWithinArea;

	public override void _Ready()
	{
		shitPrefab = ResourceLoader.Load("res://Scenes/ShitRating.tscn") as PackedScene;
		badPrefab = ResourceLoader.Load("res://Scenes/BadRating.tscn") as PackedScene;
		goodPrefab = ResourceLoader.Load("res://Scenes/GoodRating.tscn") as PackedScene;
		sickPrefab = ResourceLoader.Load("res://Scenes/SickRating.tscn") as PackedScene;
	}

	public override void _Process(double delta)
	{
		ProccessInputUponNoteEntry();
	}

	private void ProccessInputUponNoteEntry() 
	{
		if (currentNoteWithinArea == null) return;

		if (Input.IsActionJustPressed(keyName) && noteWithinArea)
		{
			if ((bool)currentNoteWithinArea.Get("shit") && !(bool)currentNoteWithinArea.Get("bad")) GetTree().Root.AddChild(shitPrefab.Instantiate());
			else if ((bool)currentNoteWithinArea.Get("bad") && !(bool)currentNoteWithinArea.Get("good")) GetTree().Root.AddChild(badPrefab.Instantiate());
			else if ((bool)currentNoteWithinArea.Get("good") && !(bool)currentNoteWithinArea.Get("sick")) GetTree().Root.AddChild(goodPrefab.Instantiate());
			else GetTree().Root.AddChild(sickPrefab.Instantiate());

			currentNoteWithinArea.Hide();

			//GD.Print((bool)currentNoteWithinArea.Get("shit") + " " + (bool)currentNoteWithinArea.Get("bad") + " " + (bool)currentNoteWithinArea.Get("good") + " " + (bool)currentNoteWithinArea.Get("sick"));
		}
	}
	
	private void NoteEntered(Area2D area)
	{
		if (area.Name != "Sick" && area.Name != "Good" && area.Name != "Bad" && area.Name != "Shit") 
		{
			noteWithinArea = true;
			currentNoteWithinArea = area;
		}
	}
	
	private void NoteExited(Area2D area)
	{
		if (area.Name != "Sick" && area.Name != "Good" && area.Name != "Bad" && area.Name != "Shit")
		{
			noteWithinArea = false;
			currentNoteWithinArea = null;
		}
	}
}
