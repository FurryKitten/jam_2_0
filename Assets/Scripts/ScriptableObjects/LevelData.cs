using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "LevelData", menuName = "ScriptableObjects/LevelData", order = 1)]
public class LevelData : ScriptableObject
{
    [SerializeField] private bool _isStarted = false;
    [SerializeField] private GameObject _backgroundPrefab;
    [SerializeField] private GameObject _groundPrefab;

    public bool IsStarted => _isStarted;
    public GameObject BackgroundPrefab => _backgroundPrefab;
    public GameObject GroundPrefab => _groundPrefab;
}
