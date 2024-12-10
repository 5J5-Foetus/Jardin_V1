using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class inclinaisonArrosoir : MonoBehaviour
{
    public ParticleSystem eauArrosoir;
    public float angleInclinaison = 45f; //en degrés
    public Transform arrosoir;
    public Vector3 bonneDirection = Vector3.forward; // Direction dans laquelle l'eau peut couler
    public AudioSource sonEau;


    void Start()
    {
        sonEau = GetComponent<AudioSource>();
    }


    // Update is called once per frame
    void Update()
    {

        // Calculer l'angle entre l'arrosoir et la verticale
        float angle = Vector3.Angle(arrosoir.up, Vector3.up);

        // Vérifier si l'arrosoir est orienté vers le bas
        bool versSol = Vector3.Dot(arrosoir.forward, Vector3.up) < 0;

        // Vérifier si l'entonnoir est incliné dans la bonne direction
        bool bonneInclinaison = Vector3.Dot(arrosoir.forward, bonneDirection) > 0;

        // Activer ou désactiver le système de particules selon l'inclinaison
        if (angle > angleInclinaison && versSol )
        {
            if (!eauArrosoir.isPlaying)
            {
                eauArrosoir.Play();
                sonEau.Play();
            }
        }
        else
        {
            if (eauArrosoir.isPlaying)
            {
                eauArrosoir.Stop();
                sonEau.Stop();

            }

        }

    }
}
