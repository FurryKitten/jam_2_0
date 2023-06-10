using UnityEngine;

public class RagdollMonobeh : MonoBehaviour
{
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
        var lowerLegRObj  = upperLegRObj.transform.Find("LowerLegR").gameObject;
        var lowerLegLObj  = upperLegLObj.transform.Find("LowerLegL").gameObject;
        var lowerHandRObj = upperHandRObj.transform.Find("LowerHandR").gameObject;
        var lowerHandLObj = upperHandLObj.transform.Find("LowerHandL").gameObject;
                                                           
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
    }

    /*
     Добавить метод для фиксации, вызывать его по событию (нажали кнопку играть)
     Action? https://habr.com/ru/companies/otus/articles/725068/
     */
    public void FixateJoints()
    {
        _ragdoll.FixateJoints(1.0f);
    }
}
