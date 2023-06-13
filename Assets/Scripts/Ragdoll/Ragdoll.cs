using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class RagdollPart
{
    private Rigidbody2D _rb;
    private HingeJoint2D _joint;
    private GameObject _obj;

    public RagdollPart(Rigidbody2D rb, HingeJoint2D joint, GameObject obj)
    {
        this._rb = rb;
        this._joint = joint;
        this._obj = obj;
    }

    public RagdollPart(GameObject obj)
    {
        _obj = obj;
        _rb = _obj.GetComponent<Rigidbody2D>();
        _joint = _obj.GetComponent<HingeJoint2D>();
    }

    public Rigidbody2D Rb => _rb;
    public HingeJoint2D Joint => _joint;
    public GameObject Obj => _obj;
}

public class Ragdoll
{
    #region Parts

    public RagdollPart UpperLegR { get; }
    public RagdollPart UpperLegL { get; }
    public RagdollPart LowerLegR { get; }
    public RagdollPart LowerLegL { get; }

    public RagdollPart UpperHandR { get; }
    public RagdollPart UpperHandL { get; }
    public RagdollPart LowerHandR { get; }
    public RagdollPart LowerHandL { get; }

    public RagdollPart UpperBody { get; }
    public RagdollPart LowerBody { get; }
    public RagdollPart Head { get; }

    public List<RagdollPart> Parts { get; }

    #endregion

    private List<Renderer> _renderers = new List<Renderer>();
    private List<Collider2D> _colliders = new List<Collider2D>();

    #region Parts constructors

    public Ragdoll(RagdollPart head,
                   RagdollPart upperBody,
                   RagdollPart lowerBody, 
                   RagdollPart upperLegR,
                   RagdollPart upperLegL, 
                   RagdollPart lowerLegR, 
                   RagdollPart lowerLegL, 
                   RagdollPart upperHandR, 
                   RagdollPart upperHandL, 
                   RagdollPart lowerHandR, 
                   RagdollPart lowerHandL)
    {
        Head       = head;
        UpperBody  = upperBody;
        LowerBody  = lowerBody;
        UpperLegR  = upperLegR;
        UpperLegL  = upperLegL;
        LowerLegR  = lowerLegR;
        LowerLegL  = lowerLegL;
        UpperHandR = upperHandR;
        UpperHandL = upperHandL;
        LowerHandR = lowerHandR;
        LowerHandL = lowerHandL;

        Parts = new List<RagdollPart>
        {
            UpperLegR,
            UpperLegL,
            LowerLegR,
            LowerLegL,
            UpperHandR,
            UpperHandL,
            LowerHandR,
            LowerHandL,
            UpperBody,
            LowerBody,
            Head
        };

        GetRenderers();
        GetColliders();
    }

    public Ragdoll(GameObject head,
                   GameObject upperBody,
                   GameObject lowerBody,
                   GameObject upperLegR,
                   GameObject upperLegL,
                   GameObject lowerLegR,
                   GameObject lowerLegL,
                   GameObject upperHandR,
                   GameObject upperHandL,
                   GameObject lowerHandR,
                   GameObject lowerHandL)
    {
        Head       = new RagdollPart(head);
        UpperBody  = new RagdollPart(upperBody);
        LowerBody  = new RagdollPart(lowerBody);
        UpperLegR  = new RagdollPart(upperLegR);
        UpperLegL  = new RagdollPart(upperLegL);
        LowerLegR  = new RagdollPart(lowerLegR);
        LowerLegL  = new RagdollPart(lowerLegL);
        UpperHandR = new RagdollPart(upperHandR);
        UpperHandL = new RagdollPart(upperHandL);
        LowerHandR = new RagdollPart(lowerHandR);
        LowerHandL = new RagdollPart(lowerHandL);

        Parts = new List<RagdollPart>
        {
            UpperLegR,
            UpperLegL,
            LowerLegR,
            LowerLegL,
            UpperHandR,
            UpperHandL,
            LowerHandR,
            LowerHandL,
            UpperBody,
            LowerBody,
            Head
        };

        GetRenderers();
        GetColliders();
    }

    #endregion

    public void FixateJoints(float looseAngle)
    {
        Parts.ForEach(part => {
            if (part.Joint == null) return;

            var limits = part.Joint.limits;
            limits.min = part.Joint.jointAngle - looseAngle;
            limits.max = part.Joint.jointAngle + looseAngle;
            part.Joint.limits = limits;
        });
    }

    public Bounds GetBounds()
    {
        Bounds bounds = new Bounds(Parts[0].Rb.position, Vector3.zero);

        _renderers.ForEach(renderer => {
            bounds.Encapsulate(renderer.bounds);
        });

        return bounds;
    }
    
    public Bounds GetBoundsCollider()
    {
        Bounds bounds = new Bounds(Parts[0].Rb.position, Vector3.zero);

        _colliders.ForEach(collider => {
            bounds.Encapsulate(collider.bounds);
        });

        return bounds;
    }

    public void TurnOnGravity()
    {
         Parts.ForEach(part => {
           part.Rb.gravityScale = 1;
         });
        UpperBody.Rb.isKinematic = true;
        LowerBody.Rb.isKinematic = true;
    }

    private void GetRenderers()
    {
        if (_renderers.Any())
            return;

        Parts.ForEach(part => {
            foreach (var renderer in part.Obj.GetComponentsInChildren<Renderer>())
            {
                if (_renderers.Contains(renderer)) continue;
                _renderers.Add(renderer);
            }
        });
    }

    private void GetColliders()
    {
        if (_colliders.Any())
            return;

        Parts.ForEach(part => {
            foreach (var collider in part.Obj.GetComponentsInChildren<Collider2D>())
            {
                if (_colliders.Contains(collider)) continue;
                _colliders.Add(collider);
            }
        });
    }

}
