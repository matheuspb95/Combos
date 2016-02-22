using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AnimatorStatesController : MonoBehaviour {
	public List<string> Animations = new List<string>();
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void SetAnimation(string animation){
		for(int i = 0; i < Animations.Count; i++){
			if(Animations[i] == animation){
				Debug.Log(animation);
				GetComponent<Animator>().SetBool(animation, true);
			}else{
				GetComponent<Animator>().SetBool(animation, false);
			}
		}
	}
}
