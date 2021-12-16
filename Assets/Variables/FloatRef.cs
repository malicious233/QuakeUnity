using System;
using UnityEngine;

[Serializable]
public class FloatRef
{
    
    [SerializeField] protected bool _useSimpleValue;

    [SerializeField] protected  FloatVar _variable;
    [SerializeField] protected float _simpleValue;

    public float Value => _useSimpleValue ? _simpleValue : _variable.Value;

    #if UNITY_EDITOR
    public static string VariableName = nameof(_variable);
    public static string UseSimpleValueName = nameof(_useSimpleValue);
    public static string SimpleValueName = nameof(_simpleValue);
    #endif
}

public class VarRefBase<T>
{

}

