using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateShit : MonoBehaviour
{
    [SerializeField] private float rotateSpeed = 10f;

    private float _rotateSpeed;

    private void Start()
    {
        _rotateSpeed = Random.Range(-rotateSpeed, rotateSpeed);
    }

    private void Update()
    {
        transform.Rotate(0, 0, _rotateSpeed * Time.unscaledDeltaTime);
    }
}
