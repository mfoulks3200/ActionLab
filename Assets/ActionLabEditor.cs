using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEditor.AnimatedValues;

[CustomEditor(typeof(ActionLabBehaviour))]
public class ActionLabEditor : Editor
{

    public int mode = 0;
    public string[] modes = new string[] {"Trigger","Object"};

    public int triggerMode = 0;
    public string[] triggerModes = new string[] { "Cube", "Sphere", "Capsule", "Mesh" };

    public string[] triggers;
    public int triggerObjIndex = 0;
    public string[] objects;
    public int objectsObjIndex = 0;
    private float editorOpacity;
    protected ActionLabBehaviour myTarget;

    // Use this for initialization
    void Start () {
        myTarget = (ActionLabBehaviour)target;
	}
	
	// Update is called once per frame
	void Update () {
        triggers = GameObject.Find("ActionLabRoot").GetComponent<ActionLabRoot>().getNames(GameObject.Find("ActionLabRoot").GetComponent<ActionLabRoot>().Triggers);
        objects = GameObject.Find("ActionLabRoot").GetComponent<ActionLabRoot>().getNames(GameObject.Find("ActionLabRoot").GetComponent<ActionLabRoot>().Objects);
        myTarget.modeInt = mode;
        myTarget.editorOpacity = editorOpacity;
        Debug.Log(editorOpacity);
    }

    void OnEnable()
    {

    }

    public override void OnInspectorGUI()
    {
        GUILayout.Label(new GUIContent(Resources.Load("ActionLab/ActionLab", typeof(Texture)) as Texture));
        GUILayout.Space(-50);
        GUILayout.Label("Editor Apperence", EditorStyles.boldLabel);
        GUILayout.Label("Editor Opacity");
        editorOpacity = GUILayout.HorizontalSlider(editorOpacity, 0.0f,1.0f);
        GUILayout.Label("Action Mode", EditorStyles.boldLabel);
        mode = EditorGUILayout.Popup(mode, modes);
        //m_ShowExtraFields.target = EditorGUILayout.ToggleLeft("Show extra fields", m_ShowExtraFields.target);

        //Extra block that can be toggled on and off.
        if (mode == 0)
        {
            GUILayout.Label("Trigger Mode");
            triggerMode = EditorGUILayout.Popup(triggerMode, triggerModes);
            //objectsObjIndex = EditorGUILayout.Popup(objectsObjIndex, objects);
        }

        if (mode == 1)
        {
            EditorGUI.indentLevel++;
            GUILayout.Label("Object Mode", EditorStyles.boldLabel);
            EditorGUI.indentLevel--;
        }

        EditorGUILayout.EndFadeGroup();
    }
}
