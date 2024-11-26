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
    public Light environnement; // La lumière
    private string HexColor1 = "#FFF4D6"; // Couleur de la lumière le jour
    private string HexColor2 = "#327CFF"; // Couleur de la lumière la nuit
    private Color lightColor; // Couleur RGBA le jour
    private Color darkColor; // Couleur RGBA la nuit

   // public ParticleSystem Godrays; // Le systeme de particules "Godrays"
   // public ParticleSystem GodraysScene; // Le systeme de particule plus gros sur la scene
    //private string HexGodrays1 = "#FFE9AC"; // Couleur 1 pour les godsrays
    //private string HexGodrays2 = "#328AFF"; // Couleur 2 pour les godrays
   // private Color GodraysNuit; // Couleur RGBA des godrays la nuit
   // private Color GodraysJour; // Couleur RGBA des godrays le jour

    /*-------------- Les musiques et sons --------------*/
    // L'AudioSource
    public AudioSource musique;
    // Les Clips
    public AudioClip sonJour;
    public AudioClip sonNuit;
    public AudioSource criquets;

    /*-------------- Variables supplémentaires --------------*/
    bool interagit = false; // Booleen pour controler le jour et la nuit

    private void Start()
    {
        // Transformation des valeurs hexadecimales des couleurs en RGBA
        lightColor = HexToColor(HexColor1); // Couleur de la lumière du jour
        darkColor = HexToColor(HexColor2); // Couleur de la lumière la nuit
     //   GodraysJour = HexToColor(HexGodrays1); // Couleur des Godrays le jour
      //  GodraysNuit = HexToColor(HexGodrays2); // Couleur des Godrays la nuit
    }

    private void Update()
    {
        Debug.Log("La nuit a commencé:" + weepingAngel.Nuit); // Pour voir le changement de la bool contrôllé par le script "weepingAngel"
    }

    /* ======================================================
     * Fontion pour le passage de Hex à RGB pour la couleur *
     =======================================================*/
    Color HexToColor(string hex)
    {
        // Enlève le "#" si il y en a un
        hex = hex.Replace("#", "");

        // Parse la string Hex en RGB
        float r = Mathf.Clamp01(int.Parse(hex.Substring(0, 2), System.Globalization.NumberStyles.HexNumber) / 255f);
        float g = Mathf.Clamp01(int.Parse(hex.Substring(2, 2), System.Globalization.NumberStyles.HexNumber) / 255f);
        float b = Mathf.Clamp01(int.Parse(hex.Substring(4, 2), System.Globalization.NumberStyles.HexNumber) / 255f);

        // Renvoie la couleur RGB
        return new Color(r, g, b);
    }

    /* ===================================
     * Fonction pour controller le skybox *
     =====================================*/
    public void changerSky() 
    {
        // Acces au main du systeme de particules dans une variable 
        //var particulesGod = Godrays.main;
        //var particulesScene = GodraysScene.main;

        // Regarde le booleen pour activer/ desactiver la light switch
        switch (interagit)
        {
            // Si faux...
            case false:
                // On change le skybox pour la NUIT
                RenderSettings.skybox = matNuit;
                DynamicGI.UpdateEnvironment();
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
                environnement.color = darkColor;
                // Les particules passent a leur couleur de nuit
          //      particulesGod.startColor = GodraysNuit;
           //     particulesScene.startColor = GodraysNuit;
                // On passe à la nuit dans le script des statues
                weepingAngel.Nuit = true;
                break;
                // Fin du bloc

            // Si vrai...
            case true:
                // Le skybox passe au JOUR
                RenderSettings.skybox = matJour;
                DynamicGI.UpdateEnvironment();
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
                environnement.color = lightColor;
                // Les particules passent a leur couleur de jour
          //      particulesGod.startColor = GodraysJour;
          //      particulesScene.startColor = GodraysJour;
                // On passe au jour dans le script des statues
                weepingAngel.Nuit = false;
                break;
                // Fin du bloc
        }
    }
}
