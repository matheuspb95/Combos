using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;

public class ObjectController : MonoBehaviour
{
    protected SceneManager scenemanager;

    public Dictionary<string, AudioSource> Sounds;

    public virtual void Start()
    {
        scenemanager = SceneManager.manager;
        Sounds = new Dictionary<string, AudioSource>();

        foreach(AudioSource audio in GetComponents<AudioSource>())
        {
            Debug.Log(audio.clip.name);
            Sounds.Add(audio.clip.name, audio);
        }
    }

    protected void PlaySound(string sound)
    {
        Sounds[sound].Play();
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        scenemanager.ExitCollision(gameObject, collision.gameObject);
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        scenemanager.EnterCollision(gameObject, collision.gameObject);
    }

    public void OnTriggerStay2D(Collider2D collision)
    {
        scenemanager.StayCollision(gameObject, collision.gameObject);
    }

    public void OnCollisionExit2D(Collision2D collision)
    {
        scenemanager.ExitCollision(gameObject, collision.gameObject);
    }

    public virtual void OnCollisionEnter2D(Collision2D collision)
    {
        scenemanager.EnterCollision(gameObject, collision.gameObject);
    }
    public void OnCollisionStay2D(Collision2D collision)
    {
        scenemanager.StayCollision(gameObject, collision.gameObject);
    }

}
