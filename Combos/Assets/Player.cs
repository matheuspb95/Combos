using UnityEngine;
using System.Collections;
using System;

public class Player : MonoBehaviour {
	public float Velocity;
	public float JumpForce;
	public float DashVelocity;
	public float ProjectileVelocity;
	public GameObject projectile;

	public enum States {
		Idle,
		Dashing,
		UpperCut,
		DownKick
	};

    public bool up;
    public bool down;

	public bool Jumping;
	public bool Walking;

	public States states;

	private Rigidbody2D body;
	private Movement move;
	// Use this for initialization
	void Start () {
		body = GetComponent<Rigidbody2D>();
		move = GetComponent<Movement>();
		states = States.Idle;
        up = false;
        down = false;
        Jumping = false;
        Walking = false;
	}
	
	// Update is called once per frame
	void Update () {
		if(body.velocity.y > 0.1f){
			if(states != States.Dashing)
				GetComponent<Animator>().SetTrigger("JumpUp");
		}else
		if(body.velocity.y < -0.1f){
			if(states != States.Dashing)
				GetComponent<Animator>().SetTrigger("JumpDown");
        }
        else
        {
            GetComponent<Animator>().SetTrigger("Idle");
        }
	}

	void OnCollisionEnter2D(Collision2D collision){
        switch (collision.gameObject.tag)
        {
            case "Floor":
                if (Jumping)
                {
                    Jumping = false;
                }
                if (Walking)
                {
                    //Walking = false;
                    move.ZeroHorizontal();
                }
                if (states != States.Idle || states != States.Dashing)
                {
                    states = States.Idle;
                }
                GetComponent<Animator>().SetTrigger("Idle");
            break;
        }
		
	}

    void OnTriggerEnter2D(Collider2D collider)
    {
        switch (collider.gameObject.tag)
        {
            case "Enemy" : case "Bullet":
                Debug.Log("Hurt");
                break;
        }
    }

	IEnumerator ChangeState(States newstate, float delay){
		yield return new WaitForSeconds(delay);
		states = newstate;
	}

	public void Jump(){
		if(!Jumping){
			Jumping = true;
			move.Force(0,JumpForce * 100);
		}
	}

    public void WalkLeft()
    {
        Walk(-1);
    }

    public void WalkRight()
    {
        Walk(1);
    }

    public void Stop()
    {
        Walking = false;
        if(states != States.Dashing) move.ZeroHorizontal();
    }

	public void Walk(float direction){
		if(states != States.Dashing){
			move.Move(new Vector2(direction * Velocity,body.velocity.y));
			Walking = true;
            if (direction > 0) FlipRight();
            else if (direction < 0) FlipLeft();
        }
	}

    private void FlipRight()
    {
        Vector3 rot = transform.eulerAngles;        
        transform.eulerAngles = new Vector3(rot.x, 0, rot.z);
    }

    private void FlipLeft()
    {
        Vector3 rot = transform.eulerAngles;
        transform.eulerAngles = new Vector3(rot.x, 180, rot.z);
    }

    public void Up()
    {
        up = true;
    }

    public void ResetUp()
    {
        up = false;
    }

    public void Down()
    {
        down = true;
    }

    public void ResetDown()
    {
        down = false;
    }

    private void FrontDash()
    {
        move.ZeroHorizontal();
        if (transform.eulerAngles.y != 0)
            move.Force(-DashVelocity, 0);
        else
            move.Force( DashVelocity, 0);
        if (Jumping) GetComponent<Animator>().SetTrigger("DiveKick");
        else GetComponent<Animator>().SetTrigger("Dash");
        states = States.Dashing;

        StartCoroutine(ChangeState(States.Idle, 0.5f));
    }

    private void UpperCut()
    {
        GetComponent<Animator>().SetTrigger("UpperCut");
        move.Stop();
        move.Force( 0, DashVelocity);
        states = States.UpperCut;
        Jumping = true;
    }

    private void DownKick()
    {
        GetComponent<Animator>().SetTrigger("DownKick");
        move.Stop();
        move.Force( 0, -DashVelocity);
        states = States.DownKick;
    }

	public void Dash(){        
        if (Walking){//dash atack
            Debug.Log("Dash");
            if (states != States.Dashing){
                FrontDash();
            }
		}else if(up){//up atack
			if(states != States.UpperCut && !Jumping){
                UpperCut();
            }
		}else if(down){//down attack
			if(Jumping){
				if(states != States.DownKick){
                    DownKick();
                }
			}
		}
	}

	public void Shoot(){
		if(Input.GetAxisRaw("Horizontal") != 0 || Input.GetAxisRaw("Vertical") != 0){
			ShootDirection(new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")));
		}else{
			if(GetComponent<SpriteRenderer>().flipX){
				ShootDirection(new Vector2(-1,0));
			}else{
				ShootDirection(new Vector2(1,0));
			}
		}
	}

	public void ShootDirection(Vector2 direction){
		GameObject newproj = Instantiate(projectile, transform.position, Quaternion.identity) as GameObject;
		newproj.GetComponent<Rigidbody2D>().velocity = direction * ProjectileVelocity;
	}
}
