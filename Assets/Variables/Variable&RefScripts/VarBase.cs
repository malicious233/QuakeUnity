using UnityEngine;


public abstract class VarBase<T> : ScriptableObject
{
    [SerializeField] private T _value;

    [TextArea]
    [SerializeField] string _developerDescription;

    private T _currentValue;
    public T Value
    {
        get { return _currentValue; }
        set { _currentValue = value; }
    }

    private void OnEnable()
    {
        _currentValue = _value;
    }
}

