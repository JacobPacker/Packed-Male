using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PelletScript : MonoBehaviour
{
    public new AudioSource audio;

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.name == "Player")
        {
            audio.Play();
            Destroy(gameObject);
        }
    }
}
