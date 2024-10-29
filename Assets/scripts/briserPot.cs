using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class briserPot : MonoBehaviour
{
    [SerializeField] GameObject potBrise;
    

    private void OnCollisionEnter(Collision infoCollision)
    {
        if (infoCollision.gameObject.tag == "environnement")
        {
            potBrise.SetActive(true);
            this.gameObject.GetComponent<MeshRenderer>().enabled = false;
        }
    }
}
