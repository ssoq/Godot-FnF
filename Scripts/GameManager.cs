using Godot;
using System;

public partial class GameManager : Node
{
	public override void _Ready()
	{
		AnimateDancer();
		AnimatePlayers();
	}

	private void AnimateDancer()
	{
		var sceneDancer = GetNode<AnimatedSprite2D>("Dancer/AnimatedSprite2D");
		sceneDancer.Play("Idle");
	}
	private void AnimatePlayers()
	{
		var scenePlayerOne = GetNode<AnimatedSprite2D>("PlayerOne/AnimatedSprite2D");
		scenePlayerOne.Play("Idle");
	}

	public override void _Process(double delta)
	{

	}
}
