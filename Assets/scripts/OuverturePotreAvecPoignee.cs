using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class OuverturePotreAvecPoignee : MonoBehaviour
{
    //Variables pour l'ouverture de la porte avec la poignée
    public GameObject porte;
    public Animator porteAnimator;

    public bool ouverturePorte = false;

    // Start is called before the first frame update
    void Start()
    {
        porteAnimator = porte.GetComponent<Animator>();
    }

    public void OuvrirPorte()
    {
        //Alterner l'état de la porte
        ouverturePorte = !ouverturePorte;

        //Animation de la porte
        porteAnimator.SetBool("Ouvert", ouverturePorte);
        Debug.Log("Animation de la porte déclenchée : " + (ouverturePorte ? "Ouvert" : "Fermé"));
    }
}
