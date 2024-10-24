using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class changeSkybox : MonoBehaviour
{
    public Material matNuit; // Materiel pour la nuit
    public Material matJour; // Materiel pour le jour
    public GameObject Switch;

    bool interagit = false; // Booleen pour controler le jour et la nuit


    /* Fonction pour controller le skybox */
    public void changerSky() 
    {
        // Regarde le booleen pour activer/ desactiver la light switch
        switch (interagit)
        {
            // Si faux...
            case false:
                // On change le skybox pour la nuit
                RenderSettings.skybox = matNuit;
                // Le bool passe a true
                interagit = true;
                // On fait jouer l'animation
                Switch.GetComponent<Animator>().SetBool("active", true);
                break;
                // Fin du bloc

            // Si vrai...
            case true:
                // Le skybox passe au jour
                RenderSettings.skybox = matJour;
                // Le bool passe a false
                interagit = false;
                //
                Switch.GetComponent<Animator>().SetBool("active", false);
                break;
                // Fin du bloc
        }
    }
}
