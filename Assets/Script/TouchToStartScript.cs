using UnityEngine;
using System.Collections;

public class TouchToStartScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.touchCount > 0) {
			Touch touch = Input.touches [0];
			if( touch.phase == TouchPhase.Began && guiTexture.HitTest(touch.position)){
				Application.LoadLevel("SelectCharacter");
			}
		}
		if (Input.GetMouseButtonUp (0)) {
			if( guiTexture.HitTest(Input.mousePosition) ){
				Application.LoadLevel("SelectCharacter");
			}
		}
	}
}
