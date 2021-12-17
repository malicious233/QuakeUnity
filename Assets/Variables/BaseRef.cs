using System;
using UnityEngine;

public abstract class BaseRef<T, VarBase> where VarBase : VarBase<T>
{

    [SerializeField] protected bool _useSimpleValue;

    [SerializeField] protected VarBase _variable;
    [SerializeField] protected T _simpleValue;

    public T Value
    {
        get
        {
            return _useSimpleValue ? _simpleValue : _variable.Value;
        }
    }

#if UNITY_EDITOR
    public static string VariableName = nameof(_variable);
    public static string UseSimpleValueName = nameof(_useSimpleValue);
    public static string SimpleValueName = nameof(_simpleValue);
#endif
}

