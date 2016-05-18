using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour {
	Rigidbody2D body;
	// Use this for initialization
	void Start () {
		body = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void Move(Vector2 direction){
		body.velocity = direction;
	}

    public void Move(Vector2 direction,float velocity)
    {
        body.velocity = direction * velocity;
    }

    public void Move(float x, float y)
    {
        body.velocity = new Vector2(x, y);
    }

    public void Move(float x, float y, float velocity)
    {
        body.velocity = new Vector2(x, y) * velocity;
    }

    public void ZeroHorizontal()
    {
        body.velocity = new Vector2(0, body.velocity.y);
    }

    public void ZeroVertical()
    {
        body.velocity = new Vector2(body.velocity.x, 0);
    }

	public void Force(Vector2 direction){
		body.AddForce(direction);
	}

    public void Force(Vector2 direction, float velocity)
    {
        body.AddForce(direction * velocity);
    }

    public void Force(float x, float y)
    {
        body.AddForce(new Vector2(x,y));
    }

    public void Force(float x, float y, float velocity)
    {
        body.AddForce(new Vector2(x, y) * velocity);
    }

    public void Stop(){
		body.velocity = Vector2.zero;
	}

	public void MoveForward(float velocity){
		float dirx = Mathf.Cos(body.rotation * Mathf.Deg2Rad);
		float diry = Mathf.Sin(body.rotation * Mathf.Deg2Rad);
		body.velocity = velocity * new Vector2(dirx,diry);
	}

	public void MoveForward(float velocity, float angleOffset){
		float angle = body.rotation + angleOffset;
		float dirx = Mathf.Cos(angle * Mathf.Deg2Rad);
		float diry = Mathf.Sin(angle * Mathf.Deg2Rad);
		body.velocity = velocity * new Vector2(dirx,diry);
	}

	public void ForceForward(float force){
		float dirx = Mathf.Cos(body.rotation * Mathf.Deg2Rad);
		float diry = Mathf.Sin(body.rotation * Mathf.Deg2Rad);
		body.AddForce(new Vector2(dirx,diry) * force);
	}

	public void ForceForward(float force, float angleOffset){
		float angle = body.rotation + angleOffset;
		float dirx = Mathf.Cos(angle * Mathf.Deg2Rad);
		float diry = Mathf.Sin(angle * Mathf.Deg2Rad);
		body.AddForce(new Vector2(dirx,diry) * force);
	}

	public void LookTo(Vector2 target, float angleOffset){
		target = target - (Vector2)transform.position;
		float angle = angleOffset + Mathf.Atan2(target.y, target.x) * Mathf.Rad2Deg;
		transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
	}


}
