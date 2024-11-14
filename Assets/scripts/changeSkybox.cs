using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class changeSkybox : MonoBehaviour
{
    /*-------------- Les Objets --------------*/
    public GameObject Switch; // L'objet switch

    /*-------------- Les Matériaux --------------*/
    public Material matNuit; // Materiel pour la nuit
    public Material matJour; // Materiel pour le jour
    

    /*-------------- Lumières --------------*/
    public Light environnement; // La lumière
    private string HexColor1 = "#FFF4D6";
    private string HexColor2 = "#327CFF";
    private Color lightColor;
    private Color darkColor;

    /*-------------- Les musiques et sons --------------*/
    public AudioSource musique;
    public AudioClip sonJour;
    public AudioClip sonNuit;
    public AudioSource criquets;

    /*-------------- Variables supplémentaires --------------*/
    bool interagit = false; // Booleen pour controler le jour et la nuit

    private void Start()
    {
        lightColor = HexToColor(HexColor1); // Couleur de la lumière du jour
        darkColor = HexToColor(HexColor2); // Couleur de la lumière la nuit
    }

    private void Update()
    {
        Debug.Log("La nuit a commencé:" + weepingAngel.Nuit);
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
                // On passe au jour dans le script des statues
                weepingAngel.Nuit = false;
                break;
                // Fin du bloc
        }
    }
}
