using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bebeMarmite : MonoBehaviour
{
    /*----- GameObjects -----*/
    public GameObject marmite;
    public GameObject sacTerre;
    public GameObject foetus;

    /*----- Sons -----*/
    public AudioClip sonActivation;

    /*----- Fonction pour le foetus en sac de terre lorsqu'il est jeté dans la marmite -----*/
    private void OnTriggerEnter(Collider infoTrigger)
    {
        if (infoTrigger.tag == "marmite")
        {
            foetus.GetComponent<MeshRenderer>().enabled = false;
            sacTerre.gameObject.SetActive(true);
            GetComponent<AudioSource>().PlayOneShot(sonActivation);
            Debug.Log("Le foetus touche la marmite");
        }
    }
}
