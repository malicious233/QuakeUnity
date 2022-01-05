using System;
using UnityEditor;

[Serializable]
public class IntRef : BaseRef<int, IntVar>
{

}

[CustomPropertyDrawer(typeof(IntRef))]
public class IntRefDrawer : BaseRefDrawer<int>
{

}

