using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

    public enum State { None, BattleStart, Running, MonsterAppear, 
		DisplayQuestion, WaitingRequest, AnswerRight, AnswerWrong };
    private State _state = State.BattleStart;

    public GameObject player;
	public GameObject knight;
	public GameObject archer;
	public GameObject magician;
	public GameObject monster;
	public GameObject planeGround;

	public GameObject Q, A, B, C, D;

	private GameObject _nowMonster = null;
	private int _timer = 0;
	private bool _questionSelected = false;
	private int _questionNumber = 0;
	private GameObject _touchBg;

	// Use this for initialization
	void Start () {
		Question.CreateQuestions ();
		print (Character.PlayerType);
		if (Character.PlayerType != Character.Type.Knight) {
			Destroy(knight);
		}
		if (Character.PlayerType != Character.Type.Archer) {
			Destroy(archer);
		}
		if (Character.PlayerType != Character.Type.Magician) {
			Destroy(magician);
		}
		//player.GetComponent<SpriteRenderer>().sprite = knightSprite;
		//player.GetComponent<Animator>().runtimeAnimatorController = knightAnimatorController;
		//player.transform.localEulerAngles = new Vector3 (0, 180, 0);

	}

	// Update is called once per frame
	void Update () {
		WaitingRequest ();
		DisplayQuestion ();
		MonsterAppear ();
		Running ();
        BattleStart();
	}

    void BattleStart()
    {
        if (_state == State.BattleStart)
        {
			if( player.transform.localPosition.x < -1.7f ){
				player.transform.Translate(0.1f, 0, 0);
			}
			else{
				_state = State.Running;
				_timer = 0;
			}
        }
    }

	void Running(){
		if (_state == State.Running) {
			++_timer;

			if( _timer >= 60 ){
				_state = State.MonsterAppear;
			}
		}
	}

	void MonsterAppear(){
		if( _state == State.MonsterAppear ){
			if( _nowMonster == null ){
				(_nowMonster = (Object.Instantiate(monster) as GameObject)).transform.position = new Vector3(4.45f, 1.40f, 17f);
				planeGround.GetComponent<Animator>().enabled = false;
			}
			else if(_nowMonster.transform.position.x > 1.1f){
				_nowMonster.transform.position -= new Vector3(0.1f, 0, 0);
			}
			else {
				_state = State.DisplayQuestion;
				_questionSelected = false;
			}
		}
	}

	void DisplayQuestion(){
		if (_state == State.DisplayQuestion) {
			if( !_questionSelected ){
				_questionNumber = Random.Range (0, Question.questions.Count-1);
				Q.GetComponentInChildren<GUIText>().text = Question.questions[_questionNumber].statement;
				A.GetComponentInChildren<GUIText>().text = Question.questions[_questionNumber].a;
				B.GetComponentInChildren<GUIText>().text = Question.questions[_questionNumber].b;
				C.GetComponentInChildren<GUIText>().text = Question.questions[_questionNumber].c;
				D.GetComponentInChildren<GUIText>().text = Question.questions[_questionNumber].d;
				_questionSelected = true;
			}

			if( Q.guiTexture.color.a < 1 ){
				Q.guiTexture.color += new Color( 0, 0, 0, 0.05f );
			}
			else if( A.transform.position.x < 0.35 ){
				A.transform.Translate(0.1f, 0, 0, 0);
                if (A.transform.position.x > 0.35)
                {
                    A.transform.position.Set(0.35f, A.transform.position.y, A.transform.position.z);
                }
			}
			else if( B.transform.position.x > 0.66 ){
                
				B.transform.Translate(-0.1f, 0, 0, 0);
                if (B.transform.position.x < 0.66)
                {
                    B.transform.position.Set(0.66f, B.transform.position.y, B.transform.position.z);
                }
			}
			else if( C.transform.position.x < 0.35 ){
				C.transform.Translate(0.1f, 0, 0, 0);
                if (C.transform.position.x > 0.35)
                {
                    C.transform.position.Set(0.35f, C.transform.position.y, C.transform.position.z);
                }
			}
			else if( D.transform.position.x > 0.66 ){
				D.transform.Translate(-0.1f, 0, 0, 0);
                if (D.transform.position.x < 0.66)
                {
                    D.transform.position.Set(0.66f, D.transform.position.y, D.transform.position.z);
                }
			}
			else {
				_state = State.WaitingRequest;
			}
		}

	}

	void WaitingRequest(){
		if (_state == State.WaitingRequest) {
			if ( Input.GetMouseButtonUp(0) || Input.touchCount > 0 ) {
				GUILayer hit = Camera.main.GetComponent<GUILayer>();
				GUIElement hitObject;
				if ( Input.GetMouseButtonUp(0) ) hitObject = hit.HitTest(Input.mousePosition);
				else hitObject = hit.HitTest(Input.touches[0].position);

				print( hitObject );
				if( hitObject != null && (hitObject.tag == "A" || hitObject.tag == "B" || hitObject.tag == "C" || hitObject.tag == "D") ){
					if( hitObject.tag[0]-'A'+1 == Question.questions[_questionNumber].answer ){
						_state = State.AnswerRight;
					}
					else{
						_state = State.AnswerWrong;
					}

					print (_state);
				}
			}
		}
	}
}
