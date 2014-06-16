using UnityEngine;
using System.Collections;

public class ScoreController : MonoBehaviour {

	public GameObject playerScore;
	public GameObject knightScore;
	public GameObject archerScore;
	public GameObject magicianScore;

	// Use this for initialization
	void Start () {
        /*
		if (!PlayerPrefs.HasKey ("Knight")) {
			PlayerPrefs.SetInt("Knight", 0);
		}
		if (!PlayerPrefs.HasKey ("Archer")) {
			PlayerPrefs.SetInt("Archer", 0);
		}
		if (!PlayerPrefs.HasKey ("Magician")) {
			PlayerPrefs.SetInt("Magician", 0);
		}

		if (Character.score > PlayerPrefs.GetInt (Character.PlayerType.ToString ())) {
			PlayerPrefs.SetInt (Character.PlayerType.ToString (), Character.score);
		}

		PlayerPrefs.Save ();

		playerScore.guiText.text = Character.score.ToString();
		knightScore.guiText.text = PlayerPrefs.GetInt("Knight").ToString();
		archerScore.guiText.text = PlayerPrefs.GetInt("Archer").ToString();
		magicianScore.guiText.text = PlayerPrefs.GetInt ("Magician").ToString();
        */
	}
	
	// Update is called once per frame
	void Update () {
        /*
		if ( Input.GetMouseButtonUp(0) || Input.touchCount > 0 ) {
			GUILayer hit = Camera.main.GetComponent<GUILayer>();
			GUIElement hitObject;
			if ( Input.GetMouseButtonUp(0) ) hitObject = hit.HitTest(Input.mousePosition);
			else hitObject = hit.HitTest(Input.touches[0].position);

			if( hitObject != null && hitObject.tag == "Back" ){
				Application.LoadLevel("SelectCharacter");
			}
		}
         */
	}
}
