using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sonTriggerPiano : MonoBehaviour
{
    public AudioClip sonPiano;
    public GameObject TriggerPiano;
    public bool Dedans = false;

    private void Start()
    {
        //GetComponent<AudioSource>().Stop();
    }

    private void OnTriggerEnter(Collider collision)
    {
        if(collision.gameObject.tag == "TriggerPiano")
        {
            GetComponent<AudioSource>().PlayOneShot(sonPiano);
            Dedans = true;
        }
    }

    private void OnTriggerExit(Collider collision)
    {
        if (collision.gameObject.tag == "TriggerPiano")
        {
            GetComponent<AudioSource>().Stop();
            Dedans = false;
        }
    }
}
