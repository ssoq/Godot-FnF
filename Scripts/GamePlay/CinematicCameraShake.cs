using Godot;
using System;
using System.Threading.Tasks;

public partial class CinematicCameraShake : Node2D
{
	[ExportSubgroup("Settings")]
	[Export] private float fromAndTo = 5f;
	[Export] private int delay = 500;

	public override void _Ready()
	{
		RecallFunction();
	}

	private void RecallFunction() 
	{
		RandomCameraPosition();
	}

	async private void RandomCameraPosition() 
	{
		Position = new Vector2((float)GD.RandRange(-fromAndTo, fromAndTo), (float)GD.RandRange(-fromAndTo, fromAndTo));

		await Task.Delay(delay);

		RecallFunction();
	}
}
