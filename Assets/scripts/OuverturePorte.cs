using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OuverturePorte : MonoBehaviour
{
    public GameObject porte;
    public Animator porteAnimator;

    //Variable bool pour que la porte reste ouverte si le joueur est dans le trigger
    public bool devantPorte= false;

    // Start is called before the first frame update
    void Start()
    {
        porteAnimator = porte.GetComponent<Animator>();
    }

    public void OnTriggerEnter(Collider collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            Debug.Log("Trigger Entré : Ouverture de la porte");
            devantPorte = true;
            porteAnimator.SetBool("Ouvert", true);
        }
    }

   public  void OnTriggerExit(Collider collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("Trigger Sorti : Fermeture de la porte");
            devantPorte = false;
            porteAnimator.SetBool("Ouvert", false);
        }
    }

    private void Update()
    {
        //porteAnimator.SetBool("Ouvert", devantPorte);
    }
}
