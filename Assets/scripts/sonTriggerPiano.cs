using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sonTriggerPiano : MonoBehaviour
{
    public AudioClip sonPiano;
    public GameObject TriggerPiano;

    private void OnTriggerEnter(Collider collision)
    {
        if(collision.gameObject == TriggerPiano)
        {
            GetComponent<AudioSource>().PlayOneShot(sonPiano);
        }
    }
}
