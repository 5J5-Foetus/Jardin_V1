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
        // Calcul de la region visible par la caméra dans l'environnement 3D (Frustrum) 
        Plane[] plane = GeometryUtility.CalculateFrustumPlanes(CamJoueur);

        if (GeometryUtility.TestPlanesAABB(plane, this.gameObject.GetComponent<Renderer>().bounds))
        {

        }


    }

    //void 
}