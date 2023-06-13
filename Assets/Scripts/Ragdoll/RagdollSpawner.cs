using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RagdollSpawner : MonoBehaviour
{
    public List<GameObject> SpawnedRagdolls { get; }

    public void SpawnRagdoll(GameObject ragdoll)
    {
        GameObject spawnedObject = Instantiate(ragdoll);
    }
}
