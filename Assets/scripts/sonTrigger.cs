using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sonTrigger : MonoBehaviour
{
    /**
 * -----------------------------------------------------------------------------------------------------------------------------------------
 * Ce script controle les différentes intéractions de sons dans la scène. Pour ce faire, il: 
 * -----------------------------------------------------------------------------------------------------------------------------------------
 *      1- Transforme les valeur hexadecimales des couleurs pour les lumieres et particules en RGBA. 
 *      2- Change le skybox pour passer du jour a la nuit et vice-versa.
 *      3- Change la musique et les sons ambiants.
 *      4- Change la couleur des lumieres (systeme de particules compris).
 *      5- Active le booleen qui controle le comportement des statues a partir du script "weepingAngel".
 * -----------------------------------------------------------------------------------------------------------------------------------------
 */

    // L'AudioSource

    public AudioSource b;
    public AudioSource v;
    public AudioSource c;


    // Les Clips

    public AudioClip x;
    public AudioClip y;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
