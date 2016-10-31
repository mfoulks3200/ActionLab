using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ActionLabBehaviours { TriggerVolume,Object }
public enum ActionLabColors { Mauve,Orange,Pink }

[ExecuteInEditMode()]
public class ActionLabBehaviour : MonoBehaviour {
    
    public ActionLabColors color;
    public float editorOpacity = 0.5f;
    public ActionLabBehaviours mode;
    public int modeInt;
    public GameObject obj;


    void Awake()
    {
        if (Application.isPlaying)
        {
            gameObject.GetComponent<MeshRenderer>().enabled = false;
        }else
        {
            gameObject.GetComponent<MeshRenderer>().enabled = true;
        }
        obj = gameObject;
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Application.isPlaying)
        {
            gameObject.GetComponent<MeshRenderer>().enabled = false;
        }
        else
        {
            gameObject.GetComponent<MeshRenderer>().enabled = true;
        }

        SetMat(mode, color);

    }

    void SetMat(ActionLabBehaviours behaviour, ActionLabColors color)
    {
        Material mat = new Material(Shader.Find("Standard"));
        mat.SetTexture("_EmissionMap", Resources.Load("ActionLab/GridEmissive") as Texture);
        mat.SetColor("_EmissionColor",new Color(1.0f,1.0f,1.0f,1.0f));
        mat.SetColor("_Color", new Color(1.0f, 1.0f, 1.0f, editorOpacity));
        mat.SetFloat("_Mode", 2);
        mat.SetInt("_SrcBlend", (int)UnityEngine.Rendering.BlendMode.SrcAlpha);
        mat.SetInt("_DstBlend", (int)UnityEngine.Rendering.BlendMode.OneMinusSrcAlpha);
        mat.SetInt("_ZWrite", 0);
        mat.DisableKeyword("_ALPHATEST_ON");
        mat.EnableKeyword("_ALPHABLEND_ON");
        mat.DisableKeyword("_ALPHAPREMULTIPLY_ON");
        mat.renderQueue = 3000;
        if(behaviour == ActionLabBehaviours.TriggerVolume)
        {
            mat.SetTexture("_DetailNormalMap", Resources.Load("ActionLab/trigger", typeof(Texture)) as Texture);
        }
        if(color == ActionLabColors.Mauve)
        {
            mat.SetTexture("_MainTex", Resources.Load("ActionLab/SwatchMauveAlbedo") as Texture);
        }else if (color == ActionLabColors.Orange)
        {
            mat.SetTexture("_MainTex", Resources.Load("ActionLab/SwatchOrangeAlbedo") as Texture);
        }else if (color == ActionLabColors.Pink)
        {
            mat.SetTexture("_MainTex", Resources.Load("ActionLab/SwatchPinkDAlbedo") as Texture);
        }
        gameObject.GetComponent<MeshRenderer>().material = mat;
    }
}
