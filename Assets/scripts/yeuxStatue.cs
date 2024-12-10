using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class yeuxStatue : MonoBehaviour
{
    /*----- GameObjects ------*/
    public GameObject statueCri;

    /*----- Systeme de particules ------*/
    public ParticleSystem[] yeux; // Les 2 yeux de la statue

    /*----- Booleene ------*/
    bool detectionStatue;

    /*----- Camera -----*/
    public Camera CamJoueur; // La camera (du joueur)


    void Update()
    {
        ActivationYeux(); // La fonction pour activer les yeux est appelee
    }

    /*--------------------------
     * FONCTION SUPPLEMENTAIRES *
     ---------------------------*/
    void ActivationYeux()
    {
        switch (weepingAngel.Nuit)
        {
            // Le JOUR
            case true:
                foreach (var oeil in yeux)
                {
                    oeil.Play();
                    Debug.Log("La nuit, les yeux sont ouverts!");
                }
                break;
            // La NUIT
            case false:
                foreach (var oeil in yeux)
                {
                    oeil.Stop();
                    Debug.Log("Le jour, les yeux sont fermés!");
                }
                break;
        }
    }

}