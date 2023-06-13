using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIRagdollSpawner : MonoBehaviour
{
    [SerializeField] private RagdollSpawner _spawner;
    [SerializeField] private RagdollTypes _ragdollTypes;

    public void SpawnWheel()
    {
        _spawner.SpawnRagdoll(_ragdollTypes.WheelRagdoll);
    }

    public void SpawnCarcass()
    {
        _spawner.SpawnRagdoll(_ragdollTypes.CarcassRagdoll);
    }

    public void SpawnBenzobak()
    {
        _spawner.SpawnRagdoll(_ragdollTypes.BenzobakRagdoll);
    }
}
