using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    public Rigidbody2D Rb { get => _rb; set => _rb = value; }
    public HingeJoint2D Joint { get => _joint; set => _joint = value; }
    public GameObject Obj { get => _obj; set => _obj = value; }
}

public class Ragdoll
{
    #region Parts

    public RagdollPart UpperLegR;
    public RagdollPart UpperLegL;
    public RagdollPart LowerLegR;
    public RagdollPart LowerLegL;

    public RagdollPart UpperHandR;
    public RagdollPart UpperHandL;
    public RagdollPart LowerHandR;
    public RagdollPart LowerHandL;

    public RagdollPart UpperBody;
    public RagdollPart LowerBody;
    public RagdollPart Head;

    #endregion

    public List<RagdollPart> Parts { get; }

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
}
