using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArroserPlante : MonoBehaviour
{
    public ParticleSystem particulesEau; // Référence au système de particules
    public int goutteEau = 0;            // Compteur de particules touchant le pot
    public int goutteEauComplete = 50;         // Nombre de particules nécessaires pour arroser la fleur
    public AudioClip sonComplete;

    void OnParticleCollision(GameObject other)
    {
        // Vérifier si les particules proviennent du bon système
        if (other.gameObject == particulesEau.gameObject && goutteEau <50)
        {
            goutteEau++;

            // Vérifier si le seuil est atteint
            if (goutteEau >= goutteEauComplete)
            {
                GetComponent<AudioSource>().PlayOneShot(sonComplete);
            }
            Debug.Log("La plante est complètement arrosée !");
        }
    }
}
