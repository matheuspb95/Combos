using UnityEngine;
using System.Collections;
using Prime31.ZestKit;

public class TweenLoopPosition : MonoBehaviour {
	public Vector2 Range;
	public EaseType ease;
	private float posX;
	private float posY;
	private Vector2 InitialPosition;
	private delegate void UpdateTween();
	private UpdateTween update;
	public float PositionX {
		get { return posX;}
		set { posX = value;}
	}
	public float PositionY {
		get { return posY;}
		set { posY = value;}
	}
	public float duration;
	// Use this for initialization
	void Start () {
		InitialPosition = transform.position;
		PropertyTweens.floatPropertyTo (this, "PositionY", Range.y, duration).setEaseType (ease).setLoops (LoopType.PingPong, 100).start ();
	}
	
	// Update is called once per frame
	void Update () {
		//update ();
	}
}
