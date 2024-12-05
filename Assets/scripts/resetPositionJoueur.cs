using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class resetPositionJoueur : MonoBehaviour
{
    [SerializeField] GameObject joueur;

    // Start is called before the first frame update
    void Start()
    {
        // Position initiale du joueur avant de commencer le jeu
        joueur.transform.position = new Vector3(0, 0, 0);
        joueur.transform.rotation = new Quaternion(0, 0, 0, 1);
    }
}
