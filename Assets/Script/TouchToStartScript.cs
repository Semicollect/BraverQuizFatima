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
				if (PlayerPrefs.HasKey("Character"))
				{
					if (PlayerPrefs.GetString("Character") == "Archer")
					{
						Character.PlayerType = Character.Type.Archer;
					}
					else if( PlayerPrefs.GetString("Character") == "Knight" ){
						Character.PlayerType = Character.Type.Knight;
					}
					else if (PlayerPrefs.GetString("Character") == "Magician")
					{
						Character.PlayerType = Character.Type.Magician;
					}
					Application.LoadLevel("MainPage");
				}
				else Application.LoadLevel("SelectCharacter");
			}
		}
		if (Input.GetMouseButtonUp (0)) {
			if( guiTexture.HitTest(Input.mousePosition) ){
				if (PlayerPrefs.HasKey("Character"))
				{
					if (PlayerPrefs.GetString("Character") == "Archer")
					{
						Character.PlayerType = Character.Type.Archer;
					}
					else if( PlayerPrefs.GetString("Character") == "Knight" ){
						Character.PlayerType = Character.Type.Knight;
					}
					else if (PlayerPrefs.GetString("Character") == "Magician")
					{
						Character.PlayerType = Character.Type.Magician;
					}
					Application.LoadLevel("MainPage");
				}
				else Application.LoadLevel("SelectCharacter");
			}
		}
	}
}
