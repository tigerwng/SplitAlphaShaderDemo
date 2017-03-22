using UnityEditor;
using UnityEngine;
using tiger.Component;

[CustomEditor(typeof(tiger.Component.SplitAlphaWithUIImage), true)]
[CanEditMultipleObjects]
public class SplitAlphaWithUIImageEditor : Editor
{
    private SerializedObject m_serializedObject;

    private SerializedProperty m_rbgTexture2D;
    private SerializedProperty m_alphaTexture2D;

    private GUIContent m_spriteContent;

    void OnEnable()
    {
        m_serializedObject = new SerializedObject(target);

        m_rbgTexture2D = m_serializedObject.FindProperty("m_RGBSource");
        m_alphaTexture2D = m_serializedObject.FindProperty("m_AlphaSource");
    }

    public override void OnInspectorGUI()
    {
        m_serializedObject.Update();

        EditorGUILayout.PropertyField(m_rbgTexture2D);
        EditorGUILayout.PropertyField(m_alphaTexture2D);

        /*
        让inspector能够调用脚本的set,get方法
         */
        SplitAlphaWithUIImage image = target as SplitAlphaWithUIImage;
        Color c = EditorGUILayout.ColorField("Color", image.color);
        if(image.color != c)
        {
            image.color = c;
        }

        m_serializedObject.ApplyModifiedProperties();
    }

    [MenuItem("GameObject/UI/SplitAlpha/UIImage")]
    public static void NewObjectCreate()
    {
        GameObject obj = new GameObject("SplitAlphaWithUIImage");
        if(Selection.activeTransform != null)
        {
            obj.transform.parent = Selection.activeTransform;
        }
    }

}