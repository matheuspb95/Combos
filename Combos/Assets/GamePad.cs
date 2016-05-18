using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class GamePad : MonoBehaviour {
    
    public List<ActionButton> buttons = new List<ActionButton>();
//    public ActionButton Left;
//    public ActionButton Right;
 //   public ActionButton Up;
   // public ActionButton Down;
    public List<Player> Listeners = new List<Player>();
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        foreach (ActionButton AC in buttons)
        {
            try
            {
                if (Input.GetKeyDown(AC.button))
                {
                    SendAction(AC.pressed);
                }
                else if (Input.GetKey(AC.button))
                {
                    SendAction(AC.hold);
                }
                else if (Input.GetKeyUp(AC.button))
                {
                    SendAction(AC.released);
                }
            }
            catch { }
        }
    }

	public static Vector2 Axis(){
		return new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
	}

    public void SendAction(string action)
    {
        if(action != "" || action != null)
        {
            foreach (Player listener in Listeners)
            {
                try
                {
                    listener.Invoke(action, 0);
                }
                catch { }
            }
        }
        
    }

    public void AddListener(Player listener)
    {
        Listeners.Add(listener);
    }
}

[Serializable]
public struct ActionButton{
    public KeyCode button;
    public string pressed;
    public string hold;
    public string released;
}