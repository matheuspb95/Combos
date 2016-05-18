using UnityEngine;
using System.Collections;

public class Bloco : MonoBehaviour {
	public bool Encaixado;
	public bool Bloqueado;
	public GameObject PosicaoEncaixar;

	// Use this for initialization
	void Start () {
		Encaixado = false;
		Bloqueado = false;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnMouseDown(){
		transform.parent.GetComponent<Peca> ().Moving = true;
	}

	void OnMouseUp(){
		if (!Bloqueado) {
			transform.parent.GetComponent<Peca> ().Moving = false;
			transform.parent.GetComponent<Peca> ().Encaixar ();
		}
	}

	void OnMouseDrag(){
		if (!Bloqueado) {
			transform.parent.position = Camera.main.ScreenToWorldPoint (Input.mousePosition + Vector3.forward * 9);
		}
	}

	void OnTriggerStay2D(Collider2D col){
		if (col.gameObject.tag == "Espaco") {
			Encaixado = true;
			PosicaoEncaixar = col.gameObject;
		}
	}

	void OnTriggerEnter2D(Collider2D col){
		if (col.gameObject.tag == "Espaco") {
			Encaixado = true;
			PosicaoEncaixar = col.gameObject;
		}
	}

	public void Encaixar(){
		transform.position = PosicaoEncaixar.transform.position;
		PosicaoEncaixar.SetActive (false);
		Bloqueado = true;
	}

	void OnTriggerExit2D(Collider2D col){
		if (col.gameObject.tag == "Espaco") {
			Encaixado = false;
		}
	}
}