using UnityEngine;
using System.Collections;

public class TouchToStartScript : MonoBehaviour {

    private Data _data;

	// Use this for initialization
	void Start () {
        _data = Data.GetInstance();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.touchCount > 0) {
			Touch touch = Input.touches [0];
			if( touch.phase == TouchPhase.Began && guiTexture.HitTest(touch.position)){
				if (PlayerPrefs.HasKey("CharacterType"))
				{
                    _data.Load();
					Application.LoadLevel("MainPage");
				}
				else Application.LoadLevel("SelectCharacter");
			}
		}
		if (Input.GetMouseButtonUp (0)) {
			if( guiTexture.HitTest(Input.mousePosition) ){
                if (PlayerPrefs.HasKey("CharacterType"))
				{
                    _data.Load();
					Application.LoadLevel("MainPage");
				}
				else Application.LoadLevel("SelectCharacter");
			}
		}
	}
}
