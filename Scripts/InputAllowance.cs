using Godot;
using System;
using System.Linq;

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
	[Export] private Area2D inputArea;
	[Export] private Godot.Collections.Array<Godot.Area2D> allNotesWithinArea;

	public override void _Ready()
	{
		inputArea = this;
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
		if (inputArea.GetOverlappingAreas().Count <= 0) return;

		if (inputArea.GetOverlappingAreas().Count > 0) currentNoteWithinArea = inputArea.GetOverlappingAreas().First();

		if (Input.IsActionJustPressed(keyName))
		{
			GameManager.instance.health += GameManager.instance.healthToAdd;
			GD.Print(GameManager.instance.health);

			inputArea.GetOverlappingAreas().First().QueueFree();

			if ((bool)currentNoteWithinArea.Get("shit") && !(bool)currentNoteWithinArea.Get("bad")) GetTree().Root.AddChild(shitPrefab.Instantiate());
			else if ((bool)currentNoteWithinArea.Get("bad") && !(bool)currentNoteWithinArea.Get("good")) GetTree().Root.AddChild(badPrefab.Instantiate());
			else if ((bool)currentNoteWithinArea.Get("good") && !(bool)currentNoteWithinArea.Get("sick")) GetTree().Root.AddChild(goodPrefab.Instantiate());
			else GetTree().Root.AddChild(sickPrefab.Instantiate());

			//GD.Print((bool)currentNoteWithinArea.Get("shit") + " " + (bool)currentNoteWithinArea.Get("bad") + " " + (bool)currentNoteWithinArea.Get("good") + " " + (bool)currentNoteWithinArea.Get("sick"));
		}
	}
	
	private void NoteEntered(Area2D area)
	{
		
	}
	
	private void NoteExited(Area2D area)
	{
		
	}
}
