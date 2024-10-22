using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class changeSkybox : MonoBehaviour
{
    public Material matNuit;
    public Material matJour;

    bool interagit = false;

    public void changerSky()
    {
        switch (interagit)
        {
            case false:
                RenderSettings.skybox = matNuit;
                interagit = true;
                break;

            case true:
                RenderSettings.skybox = matJour;
                interagit = false;
                break;
        }
    }
}
