using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sonTriggerPiano : MonoBehaviour
{
    public AudioClip sonPiano;
    public GameObject TriggerPiano;
    public bool PianoAjouer;

    private void OnTriggerEnter(Collider trigger)
    {
        if(trigger.gameObject == TriggerPiano)
        {
            GetComponent<AudioSource>().PlayOneShot(sonPiano);
            PianoAjouer = true;
        }
    }

    private void OnTriggerExit(Collider collision)
    {
        if (collision.gameObject == TriggerPiano)
        {
            GetComponent<AudioSource>().Play();
        }
    }
}
