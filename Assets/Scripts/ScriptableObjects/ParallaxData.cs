using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ParallaxData", menuName = "ScriptableObjects/ParallaxData", order = 1)]
public class ParallaxData : ScriptableObject
{
    [SerializeField] private float[] _speeds;

    public float[] Speeds => _speeds;
}
