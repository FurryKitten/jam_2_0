using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityController : MonoBehaviour
{
    private Rigidbody2D _rb;

    private void Awake()
    {
        EventManager.buildingFinish.AddListener(TurnOnGravity);
    }
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    private void TurnOnGravity()
    {
        _rb.simulated = true;
        _rb.isKinematic = false;
        _rb.gravityScale = 1;
    }
}
