using Oculus.Interaction.HandGrab;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class activationFoetus : MonoBehaviour
{
    /*----- Les GameObjects ------*/
    public GameObject pedestalFoetus;
    public GameObject particulesFoetus;
    public GameObject foetus;
    public GameObject marmite; //Lorsque le foetus sera jeté dans la marmite, il se transforme en sac de terre
    public GameObject sacTerre; //Le GameObject du foetus sera désactivé et celui du sac de terre activé

    /*----- Les composantes des GameObjects -----*/
    Animator animator;
    AudioSource audioFoetus;

    public AudioClip sonActivation;

    //private bool attrape = false;

    void Start()
    {
        // References aux composantes
        animator = GetComponent<Animator>();
        audioFoetus = GetComponent<AudioSource>();
    }

    void Update()
    {
        // Ragarde Si la booleenne du script weepingAngel change
        switch (weepingAngel.Nuit)
        {
            // Si c'est le JOUR...
            case false:
                animator.SetBool("actif", false);
                break;

            // Si c'est la NUIT...
            case true:
                foetus.SetActive(true);
                animator.SetBool("actif", true);
                audioFoetus.PlayOneShot(sonActivation, 0.2f);
                Invoke("ActivationParticules", 1f);
                break;
        }
    }

    /*----- Fonction d'activation des particules -----*/
    void ActivationParticules()
    {
        particulesFoetus.SetActive(true);
    }

    /*----- Fonction pour le foetus en sac de terre lorsqu'il est jeté dans la marmite -----*/
    private void OnTriggerEnter(Collider infoTrigger)
    {
        if (infoTrigger.tag == "marmite")
        {
            foetus.gameObject.SetActive(false);
            sacTerre.gameObject.SetActive(true);
            GetComponent<AudioSource>().PlayOneShot(sonActivation);
            Debug.Log("Le foetus touche la marmite");
        }
    }
}
