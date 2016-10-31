using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionLabRoot : MonoBehaviour {

    public GameObject[] Objects;
    public GameObject[] Triggers;

    void Awake()
    {

    }

	// Use this for initialization
	void Start () {
        
    }
	
	// Update is called once per frame
	void Update () {
        int i = 0;
        int j = 0;
        foreach(ActionLabBehaviour b in Object.FindObjectsOfType<ActionLabBehaviour>())
        {
            if(b.modeInt == 1)
            {
                Objects[i] = b.obj;
                i++;
            }
            if (b.modeInt == 0)
            {
                Triggers[j] = b.obj;
                j++;
            }
        }
	}

    public string[] getNames(GameObject[] names)
    {
        string[] returns = new string[names.Length];
        int i = 0;
        foreach(GameObject name in names)
        {
            returns[i] = name.name;

        }
        return returns;
    }
}
