using UnityEngine;
using UnityEditor;

#region Ugly code before setting up abstract class for this
/*

[CustomPropertyDrawer(typeof(IntRef))]
public class IntRefDrawer : UnityEditor.PropertyDrawer
{
    private readonly string[] popupOptions = { "Use Constant", "Use Variable" };
    private GUIStyle popupStyle;

    SerializedProperty useSimpleProperty;
    SerializedProperty variableProperty;
    SerializedProperty simpleValueProperty;

    private void GetProperties(SerializedProperty property)
    {
        useSimpleProperty = property.FindPropertyRelative(IntRef.UseSimpleValueName);
        variableProperty = property.FindPropertyRelative(IntRef.VariableName);
        simpleValueProperty = property.FindPropertyRelative(IntRef.SimpleValueName);
    }
    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        position = EditorGUI.PrefixLabel(position, label);

        //Get Properties
        GetProperties(property);


        //Create style
        popupStyle ??= new GUIStyle(GUI.skin.GetStyle("PaneOptions"))
        {
            imagePosition = ImagePosition.ImageOnly
        };

        //Draw button


        var buttonRect = new Rect(position);
        buttonRect.yMin += popupStyle.margin.top;
        buttonRect.width = popupStyle.fixedWidth + popupStyle.margin.right;

        position.xMin = buttonRect.xMax;



        int selectedIndex = useSimpleProperty.boolValue ? 0 : 1;
        int result = EditorGUI.Popup(buttonRect, selectedIndex, popupOptions, popupStyle);
        useSimpleProperty.boolValue = result == 0;

        //Draw the simple value or variable value if usesimple bool is on
        var propertyToDraw = useSimpleProperty.boolValue ? simpleValueProperty : variableProperty;
        EditorGUI.PropertyField(position, propertyToDraw, GUIContent.none);

    }
}

*/
#endregion

public abstract class BaseRefDrawer<T> : UnityEditor.PropertyDrawer
{
    private readonly string[] popupOptions = { "Use Constant", "Use Variable" };
    private GUIStyle popupStyle;

    SerializedProperty useSimpleProperty;
    SerializedProperty variableProperty;
    SerializedProperty simpleValueProperty;

    private void GetProperties(SerializedProperty property)
    {
        useSimpleProperty = property.FindPropertyRelative(BaseRef<T, VarBase<T>>.UseSimpleValueName);
        variableProperty = property.FindPropertyRelative(BaseRef<T, VarBase<T>>.VariableName);
        simpleValueProperty = property.FindPropertyRelative(BaseRef<T, VarBase<T>>.SimpleValueName);
    }
    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        position = EditorGUI.PrefixLabel(position, label);

        //Get Properties
        GetProperties(property);


        //Create style
        popupStyle ??= new GUIStyle(GUI.skin.GetStyle("PaneOptions"))
        {
            imagePosition = ImagePosition.ImageOnly
        };

        //Draw button


        var buttonRect = new Rect(position);
        buttonRect.yMin += popupStyle.margin.top;
        buttonRect.width = popupStyle.fixedWidth + popupStyle.margin.right;

        position.xMin = buttonRect.xMax;



        int selectedIndex = useSimpleProperty.boolValue ? 0 : 1;
        int result = EditorGUI.Popup(buttonRect, selectedIndex, popupOptions, popupStyle);
        useSimpleProperty.boolValue = result == 0;

        //Draw the simple value or variable value if usesimple bool is on
        var propertyToDraw = useSimpleProperty.boolValue ? simpleValueProperty : variableProperty;
        EditorGUI.PropertyField(position, propertyToDraw, GUIContent.none);

    }
}





