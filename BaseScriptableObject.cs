using UnityEngine;


#if UNITY_EDITOR
using UnityEditor;
#endif


[ClassSummary("Base class for all ScriptableObject", "Useful to add custom features")]
public abstract class BaseScriptableObject : ScriptableObject
{
#if UNITY_EDITOR
    /// <summary> Add comments inside inspector for any script instance </summary>
    [SerializeField, TextArea(0, 10)] private string comment;


    /// <summary> Display class summary inside dialog box through ContextMenu </summary>
    [ContextMenu("Class Summary")]
    private void DisplayClassSummary()
    {
        EditorUtility.DisplayDialog(this.GetType().Name + " Summary", ClassSummaryAttribute.GetClassSummary(this.GetType()), "OK");
    }
#endif
}