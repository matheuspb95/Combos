using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}

	void OnEnable(){
		Invoke ("Deactive", 1f);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void Deactive(){
		gameObject.SetActive (false);
	}
}
