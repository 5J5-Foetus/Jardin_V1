using UnityEngine;

public class SonMouvementVRCameraRig : MonoBehaviour
{
    public AudioClip sonDeMouvement; // Son à jouer lorsqu'un mouvement est détecté
    public float seuilMouvement = 0.01f; // en mètres
    public float delaiEntreSons = 0.5f; // Délai minimum entre deux sons/pas (en secondes)

    private Transform casqueVR; // Référence au Transform du casque VR
    private Vector3 positionPrecedenteCasque; // Position précédente du casque VR
    private AudioSource sourceAudio; // Composant AudioSource pour jouer le son
    private float tempsEcouleSon; // Temps écoulé depuis le dernier son joué

    void Start()
    {
        // Localiser le Transform du casque dans le Camera Rig (souvent nommé "Head" ou similaire)
        casqueVR = transform.Find("TrackingSpace/CenterEyeAnchor");

        if (casqueVR == null)
        {
            Debug.LogError("Impossible de trouver le casque VR dans le Camera Rig. Assurez-vous que le chemin est correct.");
            return;
        }

        // Initialiser la position précédente et configurer l'AudioSource
        positionPrecedenteCasque = casqueVR.localPosition;
        sourceAudio = gameObject.AddComponent<AudioSource>();
        sourceAudio.clip = sonDeMouvement;
        sourceAudio.playOnAwake = false; // Désactiver la lecture automatique
    }

    void Update()
    {
        if (casqueVR == null) return; // Vérifie que le casque est correctement assigné

        // Obtenir la position actuelle du casque VR
        Vector3 positionActuelleCasque = casqueVR.localPosition;

        // Calculer la distance parcourue depuis la dernière frame
        float distanceDeplacee = Vector3.Distance(positionActuelleCasque, positionPrecedenteCasque);

        // Si la distance dépasse le seuil et que le délai entre les sons est respecté
        if (distanceDeplacee > seuilMouvement && Time.time - tempsEcouleSon > delaiEntreSons)
        {
            JouerSonDeMouvement();
            tempsEcouleSon = Time.time; // Mettre à jour le dernier temps où le son a été joué
        }

        // Mettre à jour la position précédente pour la prochaine vérification
        positionPrecedenteCasque = positionActuelleCasque;
    }

    void JouerSonDeMouvement()
    {
        if (sourceAudio != null && sonDeMouvement != null)
        {
            sourceAudio.Play(); // Jouer le son
        }
    }
}
