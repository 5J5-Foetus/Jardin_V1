using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class changeSkybox : MonoBehaviour
{
    /**
     * -----------------------------------------------------------------------------------------------------------------------------------------
     * Ce script controle l'ambiance generale de la scene dependemment de l'interaction du joueur avec la switch dans la scene. Pour ce faire il: 
     * -----------------------------------------------------------------------------------------------------------------------------------------
     *      1- Transforme les valeur hexadecimales des couleurs pour les lumieres et particules en RGBA. 
     *      2- Change le skybox pour passer du jour a la nuit et vice-versa.
     *      3- Change la musique et les sons ambiants.
     *      4- Change la couleur des lumieres (systeme de particules compris).
     *      5- Active le booleen qui controle le comportement des statues a partir du script "weepingAngel".
     * -----------------------------------------------------------------------------------------------------------------------------------------
     */
    /*-------------- Les Objets --------------*/
    public GameObject Switch; // L'objet switch

    /*-------------- Les Matériaux --------------*/
    public Material matNuit; // Materiel skybox pour la nuit
    public Material matJour; // Materiel skybox pour le jour

    /*-------------- Lumières --------------*/
    public GameObject jour;
    public GameObject nuit;

    /*-------------- Particules --------------*/
    public GameObject GodraysJour; // Le systeme de particules "Godrays" pour le jour
    public GameObject GodraysNuit; // Le systeme de particules "Godrays" pour la nuit

    public GameObject serre_jour_gorays; // Le systeme de particules "Godrays" pour le jour 
    public GameObject serre_nuit_gorays; // Le systeme de particules "Godrays" pour la nuit

    public GameObject messagePorte;
    public GameObject messageSwitch;
    public GameObject messOuv;
    public GameObject poigneeFoetus;

    /*-------------- Les musiques et sons --------------*/
    // L'AudioSource
    public AudioSource musique;
    public AudioSource sonSwitch;
    // Les Clips
    public AudioClip sonJour;
    public AudioClip sonNuit;
    public AudioSource criquets;

    /*-------------- Variables supplémentaires --------------*/
    bool interagit = false; // Booleen pour controler le jour et la nuit

    private void Start()
    {
        //Les particules du GodRays de nuit sont désactivés au départ du jeu puisque c'est le jour
        GodraysNuit.gameObject.SetActive(false);
    }

    private void Update()
    {
        Debug.Log("La nuit a commencé:" + weepingAngel.Nuit); // Pour voir le changement de la bool contrôllé par le script "weepingAngel"
    }

    /* ===================================
     * Fonction pour controller le skybox *
     =====================================*/
    public void changerSky() 
    {
        // Regarde le booleen pour activer/ desactiver la light switch
        switch (interagit)
        {
            // Si faux... LA NUIT
            case false:
                // On passe à la nuit dans le script des statues
                weepingAngel.Nuit = true;
                // On change le skybox pour la NUIT
                RenderSettings.skybox = matNuit;
                // Le bool passe a true
                interagit = true;
                // On fait jouer l'animation
                Switch.GetComponent<Animator>().SetBool("active", true);
                // On change la musique pour la version de jour
                musique.GetComponent<AudioSource>().clip = sonNuit;
                musique.GetComponent<AudioSource>().Play();
                // On active le son des criquets
                criquets.GetComponent<AudioSource>().enabled = true;
                // Changement de la lumiÈre pour la nuit
                nuit.SetActive(true);
                jour.SetActive(false);
                // Les particules passent a leur couleur de nuit
                GodraysJour.gameObject.SetActive(false);
                GodraysNuit.gameObject.SetActive(true);
                serre_jour_gorays.gameObject.SetActive(false);
                serre_nuit_gorays.gameObject.SetActive(true);
                // Section du contrôle des messages Canvas
                messagePorte.gameObject.SetActive(false);
                messageSwitch.gameObject.SetActive(false);
                messOuv.gameObject.SetActive(true);
                poigneeFoetus.gameObject.SetActive(true);
                // On fait jouer le son de la switch
                sonSwitch.Play();
                break;
                // Fin du bloc

            // Si vrai... LE JOUR
            case true:
                // On passe au jour dans le script des statues
                weepingAngel.Nuit = false;
                // Le skybox passe au JOUR
                RenderSettings.skybox = matJour;
                // Le bool passe a false
                interagit = false;
                // On désactive le bool de l'animation de la switch
                Switch.GetComponent<Animator>().SetBool("active", false);
                // On change la musique pour la version de nuit
                musique.GetComponent<AudioSource>().clip = sonJour;
                musique.GetComponent<AudioSource>().Play();
                // On desactive le son des criquets
                criquets.GetComponent<AudioSource>().enabled = false;
                // Changement de la couleur de la lumière pour le jour
                nuit.SetActive(false);
                jour.SetActive(true);
                // Les particules passent a leur couleur de jour
                GodraysJour.gameObject.SetActive(true);
                GodraysNuit.gameObject.SetActive(false);
                serre_jour_gorays.gameObject.SetActive(true);
                serre_nuit_gorays.gameObject.SetActive(false);
                // Section du contrôle des messages Canvas
                messagePorte.gameObject.SetActive(true);
                messageSwitch.gameObject.SetActive(true);
                messOuv.gameObject.SetActive(false);
                poigneeFoetus.gameObject.SetActive(false);
                // On fait jouer le son de la switch
                sonSwitch.Play();
                break;
                // Fin du bloc
        }
    }
}
