using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class weepingAngel : MonoBehaviour
{
    /*============
     * VARIABLES *
     ============*/
    /*----- Game Objects ------*/
    public NavMeshAgent statueAI; // La statue

    /*----- Positions/ Transforms -----*/
    public Transform joueur_Transform; // Le transform du joueur
    Vector3 destination; // destination

    /*----- Caméra -----*/
    public Camera CamJoueur; // La camera (du joueur)

    /*----- Vitesses -----*/
    public float statue_Vitesse; // La vitesse de la statue
    public float vitesseRotation = 5f; // La vitesse de rotation de la statue

    /*----- Bool -----*/
    public static bool Nuit = false;

    private void Update()
    {
        // Calcul de la région visible par la caméra dans l'environnement 3D (Frustrum) 
        Plane[] plane = GeometryUtility.CalculateFrustumPlanes(CamJoueur);

        // Si la statue est dans le frustrum de la caméra ET qu'on est le jour...
        if (GeometryUtility.TestPlanesAABB(plane, this.gameObject.GetComponent<Renderer>().bounds) && !Nuit)
        {
            // La vitesse de la statue est mise à 0 et elle garde sa position actuelle
            statueAI.speed = 0f;
            statueAI.updateRotation = false;
            //statueAI.SetDestination(transform.position);
        }
        // Si la statue n'est pas en vue ET qu'on est le jour...
        else if (!GeometryUtility.TestPlanesAABB(plane, this.gameObject.GetComponent<Renderer>().bounds) && !Nuit)
        {
            // La vitesse de la statue change au nombre entré dans l'inspecteur
               statueAI.speed = statue_Vitesse;
            // La variable destination de la statue devient la position du joueur
            //   destination = joueur_Transform.position;
            // On associe la destination du NavMesh à la variable
            //   statueAI.destination = destination;
            //
            statueAI.updateRotation = true;
            RotationJoueur();
        }
        else if (GeometryUtility.TestPlanesAABB(plane, this.gameObject.GetComponent<Renderer>().bounds) && Nuit)
        {
            statueAI.speed = 0f;
            statueAI.updateRotation = false;
            statueAI.SetDestination(transform.position);
        }
        else if (!GeometryUtility.TestPlanesAABB(plane, this.gameObject.GetComponent<Renderer>().bounds) && Nuit)
        {
            // La vitesse de la statue change au nombre entré dans l'inspecteur
                statueAI.speed = statue_Vitesse;
            // La variable destination de la statue devient la position du joueur
               destination = joueur_Transform.position;
            // On associe la destination du NavMesh à la variable
               statueAI.destination = destination;
            //
                statueAI.updateRotation = true;
                RotationJoueur();
        }
    }   

    /*================================================
     * Fonction d'update de la rotation de la statue *
     ================================================*/
    private void RotationJoueur()
    {
        // On capture la position du joueur en Vecteur3 moins la position de la statue en Vecteur3
        Vector3 directionJoueur = joueur_Transform.position - transform.position;
        directionJoueur.y = 0; // La position Y reste à 0, elle ne doit pas changer

        // Si la direction du joueur change de 0.01f...
        if (directionJoueur.sqrMagnitude > 0.01f)
        {
            // La statue doit se tourner vers le joueur
            Quaternion cibleRotation = Quaternion.LookRotation(directionJoueur);
            statueAI.transform.rotation = Quaternion.Slerp(statueAI.transform.rotation, cibleRotation, vitesseRotation * Time.deltaTime);
        }
    }
}
