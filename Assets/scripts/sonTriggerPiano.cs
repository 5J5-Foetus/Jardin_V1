using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sonTriggerPiano : MonoBehaviour
{
    public AudioClip sonPiano;
    public AudioSource audioPiano;
    public GameObject TriggerPiano;
    public bool PianoAjouer;

    private void Start()
    {
        audioPiano = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider trigger)
    {
        if(trigger.gameObject == TriggerPiano)
        {
            audioPiano.PlayOneShot(sonPiano);
            PianoAjouer = true;
        }
    }

    void OnTriggerExit(Collider collision)
    {
        if (collision.gameObject == TriggerPiano)
        {
            GetComponent<AudioSource>().Stop();
            audioPiano.Stop();
        }
    }
}
