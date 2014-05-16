using UnityEngine;
using System.Collections;

public class rotateGUITexture : MonoBehaviour {

    public Texture BGTexture;

    public float initAngle;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        initAngle += 1f;
	}

    void OnGUI()
    {
        int width = Screen.width;
        int height = Screen.height;
        GUIUtility.RotateAroundPivot(initAngle, new Vector2((int)(0.28394f * Screen.width) + width / 2, (int)((-0.06789f + 0.5f) * Screen.height) + height / 2));
        GUI.DrawTexture(new Rect((int)(0.28394f * Screen.width), (int)((-0.06789f + 0.5f) * Screen.height), 500, 500), BGTexture, ScaleMode.StretchToFill, true, 0);
    }
}
