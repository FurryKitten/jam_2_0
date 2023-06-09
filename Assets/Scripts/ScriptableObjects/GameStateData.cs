using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "GameStateData", menuName = "ScriptableObjects/GameStateData", order = 1)]
public class GameStateData : ScriptableObject
{
    [SerializeField] private bool _isGameActive;
    [SerializeField] private bool _isBuildFinished;

    public bool IsGameActive
    {
        set { _isGameActive = value; }
        get { return _isGameActive; }   
    }

    public bool IsBuildFinished
    {
        set { _isBuildFinished = value; }
        get { return _isBuildFinished; }
    }
}
