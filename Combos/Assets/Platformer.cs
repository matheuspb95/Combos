using UnityEngine;
using System.Collections;

public class Platformer : MonoBehaviour {
	public enum States {
		Idle,
		Walking,
		Jumping
	}

	public States state;

	public float JumpForce;
	public float Velocity;

	private Movement move;

	// Use this for initialization
	void Start () {
		state = States.Idle;
		move = GetComponent<Movement>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void Jump(){
		state = States.Jumping;
		move.Force(new Vector2(0,JumpForce * 100));
	}

	public void WalkRight(){
		move.MoveForward(Velocity);
		state = States.Walking;
		GetComponent<SpriteRenderer>().flipX = false;
	}

	public void WalkLeft(){
		move.MoveForward(-Velocity);
		state = States.Walking;
		GetComponent<SpriteRenderer>().flipX = true;
	}
}
