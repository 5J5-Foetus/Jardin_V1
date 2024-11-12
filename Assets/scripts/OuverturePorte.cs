using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OuverturePorte : MonoBehaviour
{
    public GameObject porte;
    public GameObject triggerPorte;
    public Animator porteAnimator;

    // Start is called before the first frame update
    void Start()
    {
        porteAnimator = porte.GetComponent<Animator>();
    }

    private void OnTriggerEnter(Collider collision)
    {
        if(collision.gameObject == triggerPorte)
        {
            Debug.Log("Trigger Entré : Ouverture de la porte");
            porteAnimator.SetBool("Ouvert", true);
        }
    }

    private void OnTriggerExit(Collider collision)
    {
        if (collision.gameObject == triggerPorte)
        {
            Debug.Log("Trigger Sorti : Fermeture de la porte");
            porteAnimator.SetBool("Ouvert", false);
        }
    }
}
