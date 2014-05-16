using UnityEngine;
using System.Collections;

public class GUISizeAdject : MonoBehaviour {

    private float baseW = 720.0f;
    private float baseH = 1080.0f;

    private Vector3 scale;

    void Awake()
    {
        scale = new Vector3(Screen.width / baseW, Screen.height / baseH, 1);
    }

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnGUI()
    {
        GUI.matrix = Matrix4x4.Scale(scale);
    }
}
