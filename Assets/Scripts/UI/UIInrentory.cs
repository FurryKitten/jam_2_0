using System.Collections;
using System.Collections.Generic;
using TMPro;
using TMPro.Examples;
using UnityEngine;
using UnityEngine.UI;

public class UIInrentory : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _wheelCounter;
    [SerializeField] private TextMeshProUGUI _gasTankCounter;
    [SerializeField] private TextMeshProUGUI _bodyCounter;
    private int _wheelNumber = 2;
    private int _gasTankNumber = 1;
    private int _bodyNumber = 1;

    private void Start()
    {
        _wheelCounter.text = _wheelNumber.ToString();
        _gasTankCounter.text = _gasTankNumber.ToString();
        _bodyCounter.text = _bodyNumber.ToString();
    }

    public void SpawnRagdoll(GameObject ragdoll)
    {
        Instantiate(ragdoll);
    }
    public void SpawnWheel(GameObject ragdoll)
    {
        if (_wheelNumber > 0)
        { 
            Instantiate(ragdoll);
            _wheelNumber--;
            _wheelCounter.text = _wheelNumber.ToString();
        }
    }

    public void SpawnGasTank(GameObject ragdoll)
    {
        if (_gasTankNumber > 0)
        { 
            Instantiate(ragdoll);
            _gasTankNumber--;
            _gasTankCounter.text = _gasTankNumber.ToString();
        }
    }
    public void SpawnBody(GameObject ragdoll)
    {
        if (_bodyNumber > 0)
        {
            Instantiate(ragdoll);
            _bodyNumber--;
            _bodyCounter.text = _bodyNumber.ToString();
        }
    }
}
