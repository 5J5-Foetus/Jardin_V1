using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sonTriggerPiano : MonoBehaviour
{
    public AudioSource sonPiano;
    public GameObject TriggerPiano;
    public bool Dedans= false;

    private void Start()
    {
        sonPiano = GetComponent<AudioSource>();
        sonPiano.Stop();
    }

   void OnTriggerEnter(Collider collision)
    {
        if(collision.gameObject == TriggerPiano)
        {
            sonPiano.Play();
            //GetComponent<AudioSource>().PlayOneShot(sonPiano);
            Dedans = true;
        }
    }

    void OnTriggerExit(Collider collision)
    {
        if (collision.gameObject == TriggerPiano)
        {
            GetComponent<AudioSource>().Stop();
            Dedans = false;
        }
    }
}
