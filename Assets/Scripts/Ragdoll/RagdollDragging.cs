using UnityEngine;

public class RagdollDragging : MonoBehaviour
{
  //  [SerializeField] private RagdollSelection _ragdollSelection;
    [SerializeField] private float distance = 10f;
    [SerializeField] private float speed = 5f;
    [SerializeField] private GameStateData _gameStateData;
    
    private Transform _transform;
    private Rigidbody2D _rb2D;

    void Start()
    {
        _transform = GetComponent<Transform>();
        _rb2D = GetComponent<Rigidbody2D>();
    }

    private void OnMouseDrag()
    {
        if(!_gameStateData.IsBuildFinished)
        {
          //  if (_ragdollSelection.SelectedRagdoll != transform.parent.gameObject)
            //    _ragdollSelection.SelectedRagdoll = transform.parent.gameObject;
            Vector3 mousePosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, distance);
            Vector3 objPosition = Camera.main.ScreenToWorldPoint(mousePosition);

            _rb2D.velocity = (objPosition - _transform.position).normalized * speed;
        }
    }
}
