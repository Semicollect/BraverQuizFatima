using UnityEngine;
using System.Collections;

public class SetStageComplete : MonoBehaviour {

	// Use this for initialization
	void Start () {
        if (PlayerPrefs.HasKey(this.name))
        {
            guiTexture.color = new Color(44.0f / 255.0f, 201.0f / 255.0f, 91.0f / 255.0f, 128.0f / 255.0f);
        }
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
