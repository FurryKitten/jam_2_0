using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;

public class RagdollDragging : MonoBehaviour
{
    public float distance = 10f;
    public float speed = 5f;
    private Transform _transform;
    private Rigidbody2D _rb2D;
    // Start is called before the first frame update
    void Start()
    {
        _transform = GetComponent<Transform>();
        _rb2D = GetComponent<Rigidbody2D>();
    }

    private void OnMouseDrag()
    {
        Vector3 mousePosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, distance);
        Vector3 objPosition = Camera.main.ScreenToWorldPoint(mousePosition); 
        //transform.position = objPosition; 
        _rb2D.velocity = (objPosition - _transform.position).normalized * speed;
    }
}
