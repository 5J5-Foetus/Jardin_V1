using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class activationFoetus : MonoBehaviour
{
    /*----- Les GameObjects ------*/
    public GameObject pedestalFoetus;
    public GameObject particulesFoetus;
    public GameObject foetus;
    public GameObject marmite; //Lorsque le foetus sera jet� dans la marmite, il se transforme en sac de terre
    public GameObject sacTerre; //Le GameObject du foetus sera d�sactiv� et celui du sac de terre activ�

    /*----- Les composantes des GameObjects -----*/
    Animator animator;
    AudioSource audioFoetus;

    public AudioClip sonActivation;

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

    /*----- Fonction pour transformer le foetus en sac de fertilisant -----*/


}
