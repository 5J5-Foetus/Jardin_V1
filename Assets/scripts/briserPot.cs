using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class briserPot : MonoBehaviour
{
    /**
     * ------------------------------------------------------------------------------------------------------------------------------------------------
     * Ce script controle l'etat d'un pot en terre cuite (si il est brise ou non). Pour ce faire:
     * ------------------------------------------------------------------------------------------------------------------------------------------------
     *      1- On associe le layer "Environnement" au sol pour la detection de collision
     *      2- On regarde si le pot touche le layer "Environnement" et a une vitesse plus grande que 1.
     *      3- Si les conditions sont bien remplies, le pot intact est desactive et on active le pot brise.
     *         Les morceaux du pot possedants tous un collider et un rigidbody, il auront une interaction realiste avec l'environnement en s'activant.
     * 
     * ------------------------------------------------------------------------------------------------------------------------------------------------
     */

    /*----- Game Objects ------*/
    [SerializeField] GameObject potBrise; // La version brisee du pot
    [SerializeField] GameObject plancher; // Le plancher/ sol

    /*----- Composants -----*/
    Rigidbody rb; // Le Rigidbody du pot


    private void Start()
    {
        rb = GetComponent<Rigidbody>(); // Le rigidbody
        plancher.layer = 3; // On donne le bon layer au placnher
    }

    private void OnCollisionEnter(Collision infoCollision)
    {   
        // Detection de la velocité et de la collision avec le layer du sol ("Environnement")
        if (this.rb.velocity.magnitude > 0.5 && infoCollision.gameObject.layer == 3)
        {
            // Le pot se brise par activation de l'asset et desactivation de la version par defaut
            potBrise.SetActive(true);
            this.gameObject.GetComponent<MeshRenderer>().enabled = false;
        }
    }
}
