using Godot;
using System;

public partial class ChartScroller : Node2D
{
	// this is not finished, just need something that works to test game logic

	[ExportSubgroup("Settings")]
	private double _timeBegin;
	private double _timeDelay;
	[Export] double tempo = 190f;
	[Export] private float bpmMultiplier = 1f;

	public override void _Ready()
	{
		tempo = (tempo / 60d);
	}

	public override void _Process(double delta)
	{
		if (GameManager.instance.dead) return;

		Position -= new Vector2(0, bpmMultiplier * (float)delta);
	}
}
