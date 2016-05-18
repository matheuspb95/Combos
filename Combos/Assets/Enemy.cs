using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Enemy : MonoBehaviour {
	public GameObject Projectile;
	private GameObject Target;
	public List<GameObject> ProjectilePool = new List<GameObject> ();

	public float ProjectileVelocity;
	// Use this for initialization
	void Start () {
		Target = GameObject.Find ("player");
		InvokeRepeating ("Shoot", 1f, 1f);
		GetComponent<Rigidbody2D> ().velocity = Vector3.left;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter2D(Collider2D collider)
    {
        switch (collider.gameObject.tag)
        {
			case "Punch":
				Debug.Log ("Enemy Kill");
				Destroy (this.gameObject);
			break;
        }
    }

	void Shoot(){
		Vector2 direction = Target.transform.position - transform.position;
		GameObject newproj = null;

		if (ProjectilePool.Count == 0) {
			newproj = Instantiate (Projectile, transform.position, Quaternion.identity) as GameObject;
			ProjectilePool.Add (newproj);
		} else {
			foreach (GameObject bullet in ProjectilePool) {
				if (!bullet.activeSelf) {
					newproj = bullet;
					newproj.transform.position = transform.position;
					newproj.SetActive (true);
					break;
				}
			}
			if (newproj == null) {
				newproj = Instantiate (Projectile, transform.position, Quaternion.identity) as GameObject;
				ProjectilePool.Add (newproj);
			}
		}
		newproj.GetComponent<Rigidbody2D>().velocity = direction.normalized * ProjectileVelocity;
	}
}
