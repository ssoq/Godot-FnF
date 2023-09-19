using Godot;
using System;

public partial class GameManager : Node
{
	[ExportSubgroup("Instancing")]
	public static GameManager instance;
	public Node gameManagerNode;

	[ExportSubgroup("Settings")]
	[Export] public int health = 100;
	[Export] public int healthToAdd = 10;
	[Export] public int healthToMinus = 5;
	[Export] public bool dead = false;

	public override void _Ready()
	{
		instance = this;
		gameManagerNode = this.GetParent<Node>();

		AnimateDancer();
		AnimatePlayers();
	}

	public override void _Process(double delta)
	{
		ClampHealth();
		PlayerDead();
	}

	private void ClampHealth()
	{
		health = Mathf.Clamp(health, 0, 100);
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

	private void PlayerDead() 
	{
		if (health <= 0) dead = true;
	}
}
