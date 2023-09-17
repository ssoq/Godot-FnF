using Godot;
using System;

public partial class ChartScroller : Node2D
{
	[ExportSubgroup("Settings")]
	private double _timeBegin;
	private double _timeDelay;
	[Export] private float bpmMultiplier = 1f;

	public override void _Ready()
	{
		_timeBegin = Time.GetTicksUsec();
		_timeDelay = AudioServer.GetTimeToNextMix() + AudioServer.GetOutputLatency();
	}

	public override void _Process(double delta)
	{
		double time = (Time.GetTicksUsec() - _timeBegin) / 1000000.0d;
		time = Math.Max(0.0d, time - _timeDelay);

		Position -= new Vector2(0, (float)time * bpmMultiplier * (float)delta);
	}
}
