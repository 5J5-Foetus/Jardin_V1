using Meta.XR.MRUtilityKit;
using System.Collections.Generic;
using UnityEngine;

public class FindSpawnPositions : MonoBehaviour
{
    /**
     * 
     * CECI EST UN SCRIPT PROTOTYPE DE SPAWN POUR MULTIPLES OBJETS DANS UNE SCENE VR. 
     * INCOMPLET ET BUGGE, NE PAS UTILISER
     * 
     */
    public MRUK.RoomFilter SpawnOnStart = MRUK.RoomFilter.CurrentRoomOnly;
    public GameObject[] SpawnObjects; // Array for multiple prefabs
    public MRUKAnchor.SceneLabels Labels = ~(MRUKAnchor.SceneLabels)0; // Label filter for mapped objects

    private void Start()
    {
        if (MRUK.Instance && SpawnOnStart != MRUK.RoomFilter.None)
        {
            MRUK.Instance.RegisterSceneLoadedCallback(() =>
            {
                if (SpawnOnStart == MRUK.RoomFilter.CurrentRoomOnly)
                {
                    StartSpawn(MRUK.Instance.GetCurrentRoom());
                }
            });
        }
    }

    public void StartSpawn(MRUKRoom room)
    {
        // Store which labels have been spawned
        var spawnedLabels = new HashSet<MRUKAnchor.SceneLabels>();

        for (int i = 0; i < SpawnObjects.Length; i++)
        {
            for (int j = 0; j < 1000; j++) // Max iterations
            {
                // Generate a random position on a valid surface
                if (room.GenerateRandomPositionOnSurface(MRUK.SurfaceType.FACING_UP, 0, LabelFilter.Included(Labels), out var pos, out var normal))
                {
                    // Get the current label to spawn
                    var currentLabel = (MRUKAnchor.SceneLabels)(1 << i); // Assuming labels are ordered

                    // Check if this label has already been spawned
                    if (!spawnedLabels.Contains(currentLabel) && IsLabelAvailable(pos, currentLabel))
                    {
                        Quaternion spawnRotation = Quaternion.FromToRotation(Vector3.up, normal);
                        Instantiate(SpawnObjects[i], pos, spawnRotation, transform);
                        spawnedLabels.Add(currentLabel); // Mark this label as spawned
                        break; // Exit loop after successful spawn
                    }
                }
            }
        }
    }

    private bool IsLabelAvailable(Vector3 position, MRUKAnchor.SceneLabels label)
    {
        // Check for any existing objects in the vicinity with the specified label
        Collider[] colliders = Physics.OverlapSphere(position, 0.1f); // Adjust the radius as needed

        foreach (Collider collider in colliders)
        {
            var anchorComponent = collider.GetComponent<MRUKAnchor>();
            if (anchorComponent != null && anchorComponent.Label == label)
            {
                return false; // A matching label was found, so the position is not available
            }
        }

        return true; // No matching label found
    }
}
