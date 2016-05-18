using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Peca : MonoBehaviour {
	public Vector3 StartPosition;
	public bool Moving;
	public Main main;
	public List<Sprite> colors = new List<Sprite>();
	// Use this for initialization
	void Start () {
		StartPosition = transform.position;
		main = GameObject.Find ("SceneManager").GetComponent<Main>();
		int color = Random.Range (0, colors.Count - 1);
		foreach (SpriteRenderer s in transform.GetComponentsInChildren<SpriteRenderer>()) {
			s.sprite =  colors[color];
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void Encaixar(){
		bool PodeEncaixar = true;
		foreach (Bloco b in transform.GetComponentsInChildren<Bloco>()) {
			if (!b.Encaixado || b.PosicaoEncaixar == null) {
				PodeEncaixar = false;
			}
		}
		if (PodeEncaixar) {			
			foreach (Bloco b in transform.GetComponentsInChildren<Bloco>()) {
				b.Encaixar ();
			}
			main.PecaEncaixada ();
		} else {
			transform.position = StartPosition;
		}
	}
}
