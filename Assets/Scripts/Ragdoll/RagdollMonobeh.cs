using UnityEngine;

public abstract class RagdollMonobeh : MonoBehaviour
{
    [SerializeField, Range(0.0f, 5.0f)] private float _looseAngle;

    private Ragdoll _ragdoll;

    private void Awake()
    {
        var headObj       = transform.Find("Head").gameObject;
        var upperBodyObj  = transform.Find("UpperBody").gameObject;
        var lowerBodyObj  = transform.Find("LowerBody").gameObject;
        var upperLegRObj  = transform.Find("UpperLegR").gameObject;
        var upperLegLObj  = transform.Find("UpperLegL").gameObject;
        var upperHandRObj = transform.Find("UpperHandR").gameObject;
        var upperHandLObj = transform.Find("UpperHandL").gameObject;
        var lowerLegRObj  = transform.Find("LowerLegR").gameObject;
        var lowerLegLObj  = transform.Find("LowerLegL").gameObject;
        var lowerHandRObj = transform.Find("LowerHandR").gameObject;
        var lowerHandLObj = transform.Find("LowerHandL").gameObject;
                                                           
        _ragdoll = new Ragdoll(
            head: headObj,
            upperBody: upperBodyObj,
            lowerBody: lowerBodyObj,
            upperLegR: upperLegRObj,
            upperLegL: upperLegLObj,
            lowerLegR: upperHandRObj,
            lowerLegL: upperHandLObj,
            upperHandR: lowerLegRObj,
            upperHandL: lowerLegLObj,
            lowerHandR: lowerHandRObj,
            lowerHandL: lowerHandLObj
        );


        EventManager.buildingFinish.AddListener(() => { _ragdoll.FixateJoints(_looseAngle); _ragdoll.TurnOnGravity(); });
    }

    public void FixateJoints()
    {
        _ragdoll.FixateJoints(_looseAngle);
    }

    /* TODO: Добавить визуал, показывающий ближайшую часть */
    public void AttachRagdollToNearestPart(GameObject selectedRagdoll)
    {
        GameObject nearestPart = FindNearestPart(selectedRagdoll.transform.position);
        selectedRagdoll.transform.parent = nearestPart.transform;
    }


    private GameObject FindNearestPart(Vector2 position)
    {
        GameObject nearestPart = _ragdoll.Parts[0].Obj;
        float distance = float.MaxValue;
        _ragdoll.Parts.ForEach(part => {
            float newDistance = (part.Rb.position - position).sqrMagnitude;
            if (newDistance < distance)
            {
                distance = newDistance;
                nearestPart = part.Obj;
            }
        });
        return nearestPart;
    }

}
