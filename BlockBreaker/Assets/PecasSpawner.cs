using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PecasSpawner : MonoBehaviour {
	public List<GameObject> PecasPrefbs = new List<GameObject>();
	// Use this for initialization
	void Start () {
		AddNewPecas ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void AddNewPecas(){
		
		GameObject novapeca1 = Instantiate (PecasPrefbs [Random.Range (0, PecasPrefbs.Count)], new Vector3(0.75f, -0.75f, 0f), Quaternion.AngleAxis((Random.Range(0, 3) * 90), Vector3.forward)) as GameObject;
		GameObject novapeca2 = Instantiate (PecasPrefbs [Random.Range (0, PecasPrefbs.Count)], new Vector3(0f, -0.75f, 0f), Quaternion.AngleAxis((Random.Range(0, 3) * 90), Vector3.forward)) as GameObject;
		GameObject novapeca3 = Instantiate (PecasPrefbs [Random.Range (0, PecasPrefbs.Count)], new Vector3(-0.75f, -0.75f, 0f), Quaternion.AngleAxis((Random.Range(0, 3) * 90), Vector3.forward)) as GameObject;
	}
}
