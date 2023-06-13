using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RagdollSpawner : MonoBehaviour
{
    public List<GameObject> SpawnedRagdolls { get; }
    public GameObject SelectedRagdoll { get; }

    private void Awake()
    {
        
    }

    public void SpawnRagdoll(GameObject ragdoll)
    {
        GameObject spawnedObject = Instantiate(ragdoll);
    }
}
