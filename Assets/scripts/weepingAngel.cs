using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class weepingAngel : MonoBehaviour
{
    /**
     * ---------------------------------------------------------------------------------------------------------------
     * Le script controle le comportement des statues dans la scene en: 
     * ----------------------------------------------------------------------------------------------------------------
     *      1- Calculant le frustrum de la camera pour determiner si le joueur regarde la statue ou non.
     *      2- Si on est le jour, la statue se tourne vers le joueur et le regarde lorsqu'il ne la regarde pas.
     *      3- Si on est la nuit, la statue se tourne et se dirige lentement vers le joueur lorsqu'il ne la regarde pas.
     * ------------------------------------------------------------------------------------------------------------------
     */
    /*----- Game Objects ------*/
    public NavMeshAgent statueAI; // La statue

    /*----- Positions/ Transforms -----*/
    public Transform joueur_Transform; // Le transform du joueur
    Vector3 destination; // destination

    /*----- Camera -----*/
    public Camera CamJoueur; // La camera (du joueur)

    /*----- Vitesses -----*/
    public float statue_Vitesse; // La vitesse de la statue
    public float vitesseRotation = 5f; // La vitesse de rotation de la statue

    /*----- Bool -----*/
    public static bool Nuit = false;

    private void Update()
    {
        // Calcul de la region visible par la caméra dans l'environnement 3D (Frustrum) 
        Plane[] plane = GeometryUtility.CalculateFrustumPlanes(CamJoueur);

        // Si la statue est dans le frustrum de la camera ET qu'on est le jour...
        if (GeometryUtility.TestPlanesAABB(plane, this.gameObject.GetComponent<Renderer>().bounds) && !Nuit)
        {
            // La vitesse de la statue est mise à 0 et elle garde sa position actuelle
            statueAI.speed = 0f;
            // La statue ne peut pas tourner sur elle-même
            statueAI.updateRotation = false;
        }
        // Si la statue n'est pas en vue ET qu'on est le jour...
        else if (!GeometryUtility.TestPlanesAABB(plane, this.gameObject.GetComponent<Renderer>().bounds) && !Nuit)
        {
            // La vitesse de la statue change au nombre entré dans l'inspecteur
               statueAI.speed = statue_Vitesse;
            // La statue peut tourner et on lance la fonction qui fait se tourner la statue
            statueAI.updateRotation = true;
            RotationJoueur();
        }
        // Si la statue est dans le frustrum de la camera ET qu'on est la nuit...
        else if (GeometryUtility.TestPlanesAABB(plane, this.gameObject.GetComponent<Renderer>().bounds) && Nuit)
        {
            // La vitesse de la statue passe à 0
            statueAI.speed = 0f;
            // La rotation de la statue n'est plus possible
            statueAI.updateRotation = false;
            // La destination de la statue est changée pour sa propre position donc elle ne bougera pas
            statueAI.SetDestination(transform.position);
        }
        // Si la statue n'est pas en vue ET qu'on est la nuit...
        else if (!GeometryUtility.TestPlanesAABB(plane, this.gameObject.GetComponent<Renderer>().bounds) && Nuit)
        {
            // La vitesse de la statue change au nombre entre dans l'inspecteur
                statueAI.speed = statue_Vitesse;
            // La variable destination de la statue devient la position du joueur
               destination = joueur_Transform.position;
            // On associe la destination du NavMesh à la variable
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
