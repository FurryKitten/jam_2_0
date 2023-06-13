using Unity.VisualScripting;
using UnityEngine;

public class RagdollDragging : MonoBehaviour
{
    [SerializeField] private float distance = 10f;
    [SerializeField] private float speed = 5f;
    [SerializeField] private GameStateData _gameStateData;
    
    private RagdollSelection _ragdollSelection;
    private Transform _transform;
    private Rigidbody2D _rb2D;
    /*private Vector2 _forcePosition;
    private bool _isDragging;*/

    void Start()
    {
        _ragdollSelection = FindFirstObjectByType<RagdollSelection>();
        _transform = GetComponent<Transform>();
        _rb2D = GetComponent<Rigidbody2D>();
    }

    private void OnMouseDown()
    {
        //if (_ragdollSelection.SelectedRagdoll == null)
        _ragdollSelection.SelectedRagdoll = transform.parent.gameObject;
        Debug.Log($"OnMouseDown: {transform.parent.gameObject}");
    }

    private void OnMouseUp()
    {
        _ragdollSelection.SelectedRagdoll = null;
    }

    // TODO: в FixedUpdate!
    private void OnMouseDrag()
    {
        if(!_gameStateData.IsBuildFinished)
        {
            Vector3 mousePosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, distance);
            Vector3 objPosition = Camera.main.ScreenToWorldPoint(mousePosition);

            _rb2D.velocity = (objPosition - _transform.position).normalized * speed;
            /*
             TODO: Вместо скорости к центру объекта лучше применять силу к точке на объекте, куда кликнула мышь
             https://forum.unity.com/threads/understanding-addforceatposition.458268/
            //_rb2D.AddForceAtPosition((objPosition - _transform.position).normalized * speed, objPosition, ForceMode2D.Impulse);
             */
        }
    }

}
