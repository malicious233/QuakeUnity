using System;
using UnityEngine;
using UnityEditor;

[Serializable]
public class Vector3Ref : BaseRef<Vector3, Vector3Var>
{

}

[CustomPropertyDrawer(typeof(Vector3Ref))]
public class Vector3RefDrawer : BaseRefDrawer<Vector3>
{

}

