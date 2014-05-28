using UnityEngine;
using System.Collections;

public class SelectCharacter : MonoBehaviour {

	public GameObject knightBg, knightPeople, knightFont;
	public GameObject archerBg, archerPeople, archerFont;
	public GameObject magicianBg, magicianPeople, magicianFont;

	private GameObject touchBg;
	private bool fadeOut = false;
    private bool startSymbol = false;
    // Use this for initialization
	void Start () {
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
        StartCoroutine(WaitToStart(1f));
	}
	

    IEnumerator WaitToStart (float waitTime) {
		// suspend execution for waitTime seconds
        yield return new WaitForSeconds(waitTime);
        startSymbol = true;
	}
	// Update is called once per frame
	void Update () {
        if (startSymbol)
        {
            if (fadeOut)
            {
                if (touchBg.transform.localScale.y < 20)
                {
                    touchBg.transform.localScale += new Vector3(0, 0.5f, 0);
                }
                else
                {
                    Application.LoadLevel("MainPage");
                }
            }
            else if (Input.GetMouseButtonUp(0) || Input.touchCount > 0)
            {
                Ray ray;
                if (Input.GetMouseButtonUp(0)) ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                else ray = Camera.main.ScreenPointToRay(Input.touches[0].position);
                RaycastHit hit;
                if (Physics.Raycast(ray, out hit))
                {
                    switch (hit.collider.gameObject.tag.ToLower())
                    {
                        case "knight":
                            Destroy(archerBg); Destroy(archerPeople); Destroy(archerFont);
                            Destroy(magicianBg); Destroy(magicianPeople); Destroy(magicianFont);
                            Character.PlayerType = Character.Type.Knight;
                            PlayerPrefs.SetString("Character", "Knight");
                            break;
                        case "archer":
                            Destroy(knightBg); Destroy(knightPeople); Destroy(knightFont);
                            Destroy(magicianBg); Destroy(magicianPeople); Destroy(magicianFont);
                            Character.PlayerType = Character.Type.Archer;
                            PlayerPrefs.SetString("Character", "Archer");
                            break;
                        case "magician":
                            Destroy(archerBg); Destroy(archerPeople); Destroy(archerFont);
                            Destroy(knightBg); Destroy(knightPeople); Destroy(knightFont);
                            Character.PlayerType = Character.Type.Magician;
                            PlayerPrefs.SetString("Character", "Magician");
                            break;
                    }

                    touchBg = hit.collider.gameObject;
                    fadeOut = true;
                }
            }
        }
	}
	
}
