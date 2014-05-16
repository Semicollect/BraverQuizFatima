﻿using UnityEngine;
using System.Collections;

public class SelectCharacter : MonoBehaviour {

	public GameObject knightBg, knightPeople, knightFont;
	public GameObject archerBg, archerPeople, archerFont;
	public GameObject magicianBg, magicianPeople, magicianFont;

	private GameObject touchBg;
	private bool fadeOut = false;
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		if (fadeOut) {
			if( touchBg.transform.localScale.y < 20 ){
				touchBg.transform.localScale += new Vector3(0, 0.3f, 0);
			}
		}
		else if ( Input.GetMouseButtonUp(0) || Input.touchCount > 0 ) {
			Ray ray;
			if ( Input.GetMouseButtonUp(0) ) ray = Camera.main.ScreenPointToRay (Input.mousePosition);
			else ray = Camera.main.ScreenPointToRay (Input.touches[0].position);
			RaycastHit hit;
			if (Physics.Raycast (ray, out hit)) {
				switch( hit.collider.gameObject.tag.ToLower() ){
					case "knight":
						Destroy(archerBg); Destroy(archerPeople); Destroy(archerFont);
						Destroy(magicianBg); Destroy(magicianPeople); Destroy(magicianFont);
					break;
					case "archer":
						Destroy(knightBg); Destroy(knightPeople); Destroy(knightFont);
						Destroy(magicianBg); Destroy(magicianPeople); Destroy(magicianFont);
						break;
					case "magician":
						Destroy(archerBg); Destroy(archerPeople); Destroy(archerFont);
						Destroy(knightBg); Destroy(knightPeople); Destroy(knightFont);
						break;
				}
				touchBg = hit.collider.gameObject;
				fadeOut = true;
			}
		}
	}
	
}