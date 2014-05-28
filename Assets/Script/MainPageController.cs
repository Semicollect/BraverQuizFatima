using UnityEngine;
using System.Collections;

public class MainPageController : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonUp(0) || Input.touchCount > 0)
        {
            GUILayer hit = Camera.main.GetComponent<GUILayer>();
            GUIElement hitObject;
            if (Input.GetMouseButtonUp(0)) hitObject = hit.HitTest(Input.mousePosition);
            else hitObject = hit.HitTest(Input.touches[0].position);

            if (hitObject != null && hitObject.tag == "stage")
            {
                Question.CreateQuestions();
                if (hitObject.name == "stage1")
                {
                    Question.questions = Question.stage1;
                    Question.stageName = "stage1";
                }
                else if (hitObject.name == "stage2")
                {
                    Question.questions = Question.stage2;
                    Question.stageName = "stage2";
                }
                else if (hitObject.name == "stage3")
                {
                    Question.questions = Question.stage3;
                    Question.stageName = "stage3";
                }
                Application.LoadLevel("Battle");
            }
        }
	}
}
