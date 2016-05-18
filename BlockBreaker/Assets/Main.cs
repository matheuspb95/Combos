using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class Main : MonoBehaviour {
	public int tamanho;
	public List<GameObject> linhas;
	public List<GameObject> colunas;
	public GameObject espaco;
	public int Pontos;
	public int pecaslivres;
	public Text scoretext;
	// Use this for initialization
	void Start () {
		Pontos = 0;
		GameObject l = GameObject.Find ("Linhas");
		GameObject c = GameObject.Find ("Colunas");
		for (int i = 0; i < tamanho; i++) {
			GameObject temp = new GameObject ("Linha");
			temp.transform.parent = l.transform;
			temp.transform.localPosition = new Vector3(0, ((i+1) * 0.15f), 0);
			linhas.Add(temp);
			temp = new GameObject ("Coluna");
			temp.transform.parent = c.transform;
			temp.transform.localPosition = new Vector3(((i+1) * 0.15f), 0, 0) ;
			colunas.Add(temp);
		}
		pecaslivres = 3;

		GameObject quadro = GameObject.Find ("Quadro");
		quadro.transform.position = new Vector3 (-1 * ((tamanho * 0.15f) + 0.15f)/2, (6 - tamanho)*0.15f);

		GameObject espacoTemp;
		for (int i = 0; i < tamanho; i++) {
			for (int j = 0; j < tamanho; j++) {
				espacoTemp = Instantiate (espaco);
				espacoTemp.transform.parent = quadro.transform;
				espacoTemp.transform.localPosition = new Vector3(((i+1) * 0.15f), ((j+1) * 0.15f), 0) ;
			}
		}

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void Reload(){
		SceneManager.LoadScene (SceneManager.GetActiveScene ().name);
	}

	public void PecaEncaixada(){
		int multiplicador = 1;
		int pontosAdicionar = 0;
		List<GameObject> Destruir = new List<GameObject> ();
		foreach (GameObject l in linhas) {
			Vector3 init = l.transform.position;
			List<GameObject> blocos = new List<GameObject>();
			foreach (RaycastHit2D g in Physics2D.RaycastAll (init, Vector2.right)) {
				if (g.collider.gameObject.tag == "Bloco") {
					if (g.collider.gameObject.GetComponent<Bloco> ().Bloqueado) {
						blocos.Add (g.collider.gameObject);
					}
				}
				if (blocos.Count == tamanho) {
					foreach (GameObject b in blocos) {
						pontosAdicionar = multiplicador * tamanho;
						Destruir.Add (b);
					}
					multiplicador++;
				}
			}
		}
		foreach (GameObject c in colunas) {
			Vector3 init = c.transform.position;
			List<GameObject> blocos = new List<GameObject>();
			foreach (RaycastHit2D g in Physics2D.RaycastAll (init, Vector2.up)) {
				if (g.collider.gameObject.tag == "Bloco") {
					if (g.collider.gameObject.GetComponent<Bloco> ().Bloqueado) {
						blocos.Add (g.collider.gameObject);
					}
				}
				if (blocos.Count == tamanho) {
					foreach (GameObject b in blocos) {
						pontosAdicionar = multiplicador * tamanho;
						Destruir.Add (b);
					}
					multiplicador++;
				}
			}
		}
		Pontos += pontosAdicionar;
		scoretext.text = "" + Pontos;
		foreach (GameObject b in Destruir) {
			b.GetComponent<Bloco> ().PosicaoEncaixar.SetActive (true);
			b.SetActive (false);
		}
		pecaslivres--;
		if (pecaslivres == 0) {
			GetComponent<PecasSpawner> ().AddNewPecas ();
			pecaslivres = 3;
		}
	}
}
