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

    /*----- Cam�ra -----*/
    public Camera CamJoueur; // La camera (du joueur)

    /*----- Vitesses -----*/
    public float statue_Vitesse; // La vitesse de la statue
    public float vitesseRotation = 5f; // La vitesse de rotation de la statue

    /*----- Bool -----*/
    public static bool Nuit = false;

    /**
     * 
     * Dans l'update on regarde � quel moment de la journ�e on est:
     *      1- Si on est le jour, la statue va se touner vers le joueur si il ne la regarde pas sinon elle ne bouge pas.
     *      2- Si on est la nuit, la statue avance vers le joueur si il ne la regarde pas et, sinon, elle ne bouge pas non plus.
     *      
     */
    private void Update()
    {
        // Calcul de la r�gion visible par la cam�ra dans l'environnement 3D (Frustrum) 
        Plane[] plane = GeometryUtility.CalculateFrustumPlanes(CamJoueur);

        // Si la statue est dans le frustrum de la cam�ra ET qu'on est le jour...
        if (GeometryUtility.TestPlanesAABB(plane, this.gameObject.GetComponent<Renderer>().bounds) && !Nuit)
        {
            // La vitesse de la statue est mise � 0 et elle garde sa position actuelle
            statueAI.speed = 0f;
            // La statue ne peut pas tourner sur elle-m�me
            statueAI.updateRotation = false;
        }
        // Si la statue n'est pas en vue ET qu'on est le jour...
        else if (!GeometryUtility.TestPlanesAABB(plane, this.gameObject.GetComponent<Renderer>().bounds) && !Nuit)
        {
            // La vitesse de la statue change au nombre entr� dans l'inspecteur
               statueAI.speed = statue_Vitesse;
            // La statue peut tourner et on lance la fonction qui fait se tourner la statue
            statueAI.updateRotation = true;
            RotationJoueur();
        }
        // Si la statue est dans le frustrum de la cam�ra ET qu'on est la nuit...
        else if (GeometryUtility.TestPlanesAABB(plane, this.gameObject.GetComponent<Renderer>().bounds) && Nuit)
        {
            // La vitesse de la statue passe � 0
            statueAI.speed = 0f;
            // La rotation de la statue n'est plus possible
            statueAI.updateRotation = false;
            // La destination de la statue est chang�e pour sa propre position donc elle ne bougera pas
            statueAI.SetDestination(transform.position);
        }
        // Si la statue n'est pas en vue ET qu'on est la nuit...
        else if (!GeometryUtility.TestPlanesAABB(plane, this.gameObject.GetComponent<Renderer>().bounds) && Nuit)
        {
            // La vitesse de la statue change au nombre entr� dans l'inspecteur
                statueAI.speed = statue_Vitesse;
            // La variable destination de la statue devient la position du joueur
               destination = joueur_Transform.position;
            // On associe la destination du NavMesh � la variable
               statueAI.destination = destination;
            // La statue peut se tourner et on lance la fonction qui permet la rotation
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
        directionJoueur.y = 0; // La position Y reste � 0, elle ne doit pas changer

        // Si la direction du joueur change de 0.01f...
        if (directionJoueur.sqrMagnitude > 0.01f)
        {
            // La statue doit se tourner vers le joueur
            Quaternion cibleRotation = Quaternion.LookRotation(directionJoueur);
            statueAI.transform.rotation = Quaternion.Slerp(statueAI.transform.rotation, cibleRotation, vitesseRotation * Time.deltaTime);
        }
    }
}
