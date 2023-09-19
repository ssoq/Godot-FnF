using Godot;
using System;

public partial class HealthSlider : HSlider
{
	[ExportSubgroup("Settings")]
	[Export] private float smoothing = 10f;

	private float deltaTime;
	public override void _Process(double delta)
	{
		deltaTime = (float)delta;

		UpdateHealthValue();
	}

	private void UpdateHealthValue() 
	{
		Value = Mathf.Lerp(Value, GameManager.instance.health - 10, smoothing * deltaTime);
	}
}
