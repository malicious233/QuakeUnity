using UnityEngine;

[CreateAssetMenu(fileName = "new Vector3Var", menuName = "SOs/Vector3 Var")]
public class Vector3Var : VarBase<Vector3>
{

}

/*
public class Vector3Var : ScriptableObject
{
    [SerializeField] private Vector3 _value;

    [TextArea]
    [SerializeField] string _developerDescription;

    private Vector3 _currentValue;
    public Vector3 Value
    {
        get { return _currentValue; }
    }

    private void OnEnable()
    {
        _currentValue = _value;
    }
}
*/
