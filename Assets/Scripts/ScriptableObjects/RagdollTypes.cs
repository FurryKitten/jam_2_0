using UnityEngine;

[CreateAssetMenu(fileName = "RagdollTypes", menuName = "ScriptableObjects/RagdollTypes", order = 1)]
public class RagdollTypes : ScriptableObject
{
    [SerializeField] private GameObject _wheelRagdoll;
    [SerializeField] private GameObject _carcassRagdoll;
    [SerializeField] private GameObject _benzobakRagdoll;

    public GameObject WheelRagdoll => _wheelRagdoll;
    public GameObject CarcassRagdoll => _carcassRagdoll;
    public GameObject BenzobakRagdoll => _benzobakRagdoll;
}
