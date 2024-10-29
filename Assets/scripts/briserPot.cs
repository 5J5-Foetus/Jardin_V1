using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class briserPot : MonoBehaviour
{
    [SerializeField] GameObject potBrise; // La version brisee du pot
    [SerializeField] GameObject plancher; // Le plancher/ sol

    Rigidbody rb;
    

    private void Start()
    {
        rb = GetComponent<Rigidbody>(); // Le rigidbody

        plancher = GameObject.Find("FLOOR_EffectMesh"); // Le sol
        plancher.layer = 3; // On donne le bon layer au placnher
    }


    private void OnCollisionEnter(Collision infoCollision)
    {   
        // Detection de la velocité et de la collision avec le layer du sol ("Environnement")
        if (this.rb.velocity.magnitude > 1 && infoCollision.gameObject.layer == 3)
        {
            // Le pot se brise par activation de l'asset et desactivation de la version par defaut
            potBrise.SetActive(true);
            this.gameObject.GetComponent<MeshRenderer>().enabled = false;
        }
    }
}
