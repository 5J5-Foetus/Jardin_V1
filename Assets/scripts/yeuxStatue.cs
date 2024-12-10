using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class yeuxStatue : MonoBehaviour
{
    public ParticleSystem[] yeux; // Les 2 yeux de la statue

    bool detectionStatue;

    
    void Update()
    {
        switch (weepingAngel.Nuit)
        {
            // Si c'est la NUIT...
            case true:
                foreach (var oeil in yeux)
                {
                    oeil.Play();
                }
                break;
            // Si c'est le JOUR...
            case false:
                foreach (var oeil in yeux)
                {
                    oeil.Stop();
                }
                break;
        }
    }
}