using UnityEngine;
using System.Collections;

public class SelectCharacter : MonoBehaviour {

	public GameObject knightBg, knightPeople, knightFont;
	public GameObject archerBg, archerPeople, archerFont;
	public GameObject magicianBg, magicianPeople, magicianFont;

	private GameObject touchBg;
	private bool fadeOut = false;
    private bool startSymbol = false;
    private Data _data;
    // Use this for initialization
	void Start () {
        _data = Data.GetInstance();
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
                            _data.Character = new Knight();
                            _data.Rank = 0;
                            _data.Exp = 0;
                            _data.Save();
                            break;
                        case "archer":
                            Destroy(knightBg); Destroy(knightPeople); Destroy(knightFont);
                            Destroy(magicianBg); Destroy(magicianPeople); Destroy(magicianFont);
                            _data.Character = new Archer();
                            _data.Rank = 0;
                            _data.Exp = 0;
                            _data.Save();
                            break;
                        case "magician":
                            Destroy(archerBg); Destroy(archerPeople); Destroy(archerFont);
                            Destroy(knightBg); Destroy(knightPeople); Destroy(knightFont);
                            _data.Character = new Magician();
                            _data.Rank = 0;
                            _data.Exp = 0;
                            _data.Save();
                            break;
                    }

                    touchBg = hit.collider.gameObject;
                    fadeOut = true;
                }
            }
        }
	}
	
}
