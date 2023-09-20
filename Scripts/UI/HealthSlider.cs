using Godot;
using System;

public partial class HealthSlider : HSlider
{
	[ExportSubgroup("Settings")]
	[Export] private float smoothing = 15f;

	private float deltaTime;
	public override void _Process(double delta)
	{
		deltaTime = (float)delta;

		UpdateHealthValue();
	}

	private void UpdateHealthValue() 
	{
		Value = GameManager.instance.health;
	}
}
