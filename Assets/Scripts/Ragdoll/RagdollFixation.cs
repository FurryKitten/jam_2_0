using UnityEngine;

public class RagdollFixation : MonoBehaviour
{
    private RagdollMonobeh _ragdollMonobeh;
    private RagdollSelection _ragdollSelection;
    private CircleCollider2D _circleCollider;
    private WheelJoint2D _wheelJoint;

    private GameObject _connectedObject;
    private bool _isStayingInTrigger = false;

    private void Awake()
    {
        _ragdollMonobeh = GetComponentInParent<RagdollMonobeh>();
        _ragdollSelection = FindFirstObjectByType<RagdollSelection>();
        _circleCollider = GetComponent<CircleCollider2D>();
        _wheelJoint = GetComponentInParent<WheelJoint2D>();
        
        Debug.Assert(_wheelJoint != null);
        Debug.Assert(_ragdollSelection != null);
        Debug.Assert(_ragdollMonobeh != null);
    }

    private void Update()
    {
        /*if (_ragdollSelection.SelectedRagdoll != _ragdollMonobeh.gameObject)
        {
            return;
        }*/

        //Bounds ragdollBounds = _ragdollMonobeh.Ragdoll.GetBoundsCollider();
        //_circleCollider.radius = Mathf.Min(ragdollBounds.size.x, ragdollBounds.size.y);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject collidedRagdoll = collision.transform?.parent?.parent?.gameObject;
        if (_ragdollSelection.SelectedRagdoll != null 
            && collidedRagdoll != null 
            && _ragdollSelection.SelectedRagdoll != collision.transform.parent.parent.gameObject)
        {
            if (collision.transform.parent.TryGetComponent(out Rigidbody2D rigidbody))
            {
                _wheelJoint.enabled = true;
                _wheelJoint.connectedBody = rigidbody;
                _wheelJoint.connectedAnchor = rigidbody.transform.position;
                Debug.Log($"Connected wheel; {_ragdollSelection.SelectedRagdoll}; {collision.transform.parent.gameObject}");
                _connectedObject = collidedRagdoll;
                _isStayingInTrigger = true;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        _wheelJoint.enabled = false;
        _wheelJoint.connectedBody = null;
    }
}
