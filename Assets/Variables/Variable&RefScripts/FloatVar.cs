using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
[CreateAssetMenu(fileName = "new FloatVar", menuName = "SOs/Float Var")]
public class FloatVar : ScriptableObject
{
    [SerializeField] private float _value;

    [TextArea]
    [SerializeField] string _developerDescription;

    private float _currentValue;
    public float Value 
    {
        get { return _currentValue; }
    }

    private void OnEnable()
    {
        _currentValue = _value;
    }
}
*/

[CreateAssetMenu(fileName = "new FloatVar", menuName = "SOs/Float Var")]
public class FloatVar : VarBase<float>
{

}
