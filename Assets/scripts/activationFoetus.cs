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

    private bool attrape = false;

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
    private void OnCollisionEnter(Collision infoCollision)
    {
        if ((infoCollision.gameObject.name == "foetus") && (infoCollision.gameObject.name == "marmite"))
        {
            foetus.gameObject.SetActive(false);
            sacTerre.gameObject.SetActive(true);
            GetComponent<AudioSource>().PlayOneShot(sonActivation);
        }
    }



    private void OnEnable()
    {
        // If the object is an XR Grab Interactable, hook into the grab events
        XRGrabInteractable grabInteractable = GetComponent<XRGrabInteractable>();
        if (grabInteractable != null)
        {
            grabInteractable.selectEntered.AddListener(OnGrabbed);
            grabInteractable.selectExited.AddListener(OnReleased);
        }
    }
    private void OnDisable()
    {
        // Unsubscribe from events when the object is disabled
        XRGrabInteractable grabInteractable = GetComponent<XRGrabInteractable>();
        if (grabInteractable != null)
        {
            grabInteractable.selectEntered.RemoveListener(OnGrabbed);
            grabInteractable.selectExited.RemoveListener(OnReleased);
        }
    }

    private void OnGrabbed(SelectEnterEventArgs args)
    {
        attrape = true;  // Set flag to true when grabbed
        Debug.Log("Object is being grabbed!");
    }

    // Called when the object is released
    private void OnReleased(SelectExitEventArgs args)
    {
        attrape = false;  // Set flag to false when released
        Debug.Log("Object was released.");
    }
}
