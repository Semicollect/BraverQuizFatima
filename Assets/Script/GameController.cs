using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

    public enum State { None, BattleStart, Running, MonsterAppear, 
		DisplayQuestion, WaitingRequest, AnswerRight, AnswerWrong, PlayerDead };
    private State _state = State.BattleStart;

    public GameObject player;
	public GameObject knight;
	public GameObject archer;
	public GameObject magician;
	public GameObject monster;
	public GameObject planeGround;

    public GameObject GameOver;
    private bool gameOverAnimationEnd = false;
    public GameObject StageClear;
    private bool stageClearAnimationEnd = false;

    public GameObject enemyParticle;
    private bool enemyParticleExec = false;
    public GameObject playerParticle;
    private bool playerParticleExec = false;
    private float lifeValue;


	public GameObject lifeBar;

	public GameObject Q, A, B, C, D;

	private GameObject _nowMonster = null;
	private int _timer = 0;
	private bool _questionSelected = false;
	private int _questionNumber = 0;
	private GameObject _touchBg;

    private Data _data;
	// Use this for initialization
	void Start () {
        _data = Data.GetInstance();
		if (Question.stageName == "stage1") {

		}
		else if( Question.stageName == "stage2") {
			planeGround.renderer.material.color = new Color( 14.0f/255.0f, 131.0f/255.0f, 29.0f/255.0f, 255.0f/255.0f );
		}
		else if (Question.stageName == "stage3") {
			planeGround.renderer.material.color = new Color( 234.0f/255.0f, 47.0f/255.0f, 47.0f/255.0f, 255.0f/255.0f );
		}

		// Character.score = 0;
		if (_data.Character.IsDestroy(knight)) {
			Destroy(knight);
		}
        if (_data.Character.IsDestroy(archer))
        {
			Destroy(archer);
		}
        if (_data.Character.IsDestroy(magician))
        {
			Destroy(magician);
		}
		//player.GetComponent<SpriteRenderer>().sprite = knightSprite;
		//player.GetComponent<Animator>().runtimeAnimatorController = knightAnimatorController;
		//player.transform.localEulerAngles = new Vector3 (0, 180, 0);

	}

	// Update is called once per frame
	void Update () {
		PlayerDead ();
		AnswerRight ();
		AnswerWrong ();
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
            if (!stageClearAnimationEnd)
            {
                ++_timer;

                if (Question.answerRightProblem >= Question.questions.Count)
                {
                    foreach (var question in Question.questions)
                    {
                        question.answerRight = false;
                    }
                    Question.answerRightProblem = 0;
                    Instantiate(StageClear);
                    stageClearAnimationEnd = true;
                    PlayerPrefs.SetInt(Question.stageName, 1);
                }

                if (_timer >= 60)
                {
                    _state = State.MonsterAppear;
                }
            }
            else
            {
                if (Input.touchCount > 0)
                {
                    Touch touch = Input.touches[0];
                    if (touch.phase == TouchPhase.Began)
                    {
                        Application.LoadLevel("MainPage");
                    }
                }
                if (Input.GetMouseButtonUp(0))
                {
                    Application.LoadLevel("MainPage");
                }
            }
		}
	}

	void MonsterAppear(){
		if( _state == State.MonsterAppear ){
			if( _nowMonster == null ){
				(_nowMonster = (Object.Instantiate(monster) as GameObject)).transform.position = new Vector3(4.45f, 1.40f, 17f);
				_nowMonster.renderer.material.color = new Color( Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f) );
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
                do {
				    _questionNumber = Random.Range (0, Question.questions.Count*2);
                    _questionNumber = _questionNumber % Question.questions.Count;
                } while (Question.questions[_questionNumber].answerRight);
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

				if( hitObject != null && (hitObject.tag == "A" || hitObject.tag == "B" || hitObject.tag == "C" || hitObject.tag == "D") ){
					_touchBg = GameObject.Find("battle_" + hitObject.tag);
					if( hitObject.tag[0]-'A'+1 == Question.questions[_questionNumber].answer ){
						_state = State.AnswerRight;
					}
					else{
						_state = State.AnswerWrong;
					}
				}
			}
		}
	}

	bool GUIDisppear(){
		if (_touchBg.guiTexture.color.g < 0.7f && _touchBg.guiTexture.color.r < 0.7f) {
			if( _state == State.AnswerRight ){
				_touchBg.guiTexture.color += new Color(0, 0.1f, 0);
			}
			else{
				_touchBg.guiTexture.color += new Color(0.1f, 0, 0);
			}
		}
		else if( Q.guiTexture.color.a > 0 ){
			Q.guiTexture.color -= new Color( 0, 0, 0, 0.05f );
		}
		else if( A.transform.position.x > -2 ){
			A.transform.Translate(-0.1f, 0, 0, 0);
		}
		else if( B.transform.position.x < 2 ){			
			B.transform.Translate(0.1f, 0, 0, 0);
		}
		else if( C.transform.position.x > -2 ){
			C.transform.Translate(-0.1f, 0, 0, 0);
		}
		else if( D.transform.position.x < 2 ){
			D.transform.Translate(0.1f, 0, 0, 0);
		}
		else {
			_touchBg.guiTexture.color = new Color(0.5f, 0.5f, 0.5f, 0.5f);
			return true;
		}
		return false;
	}

	void AnswerWrong(){
		if( _state == State.AnswerWrong ){
			if( GUIDisppear()){
                if (!playerParticleExec)
                {
                    playerParticle.particleEmitter.Emit();
                    lifeValue = 0.4f;
                    playerParticleExec = true;
                }
                if (lifeValue > 0)
                {
                    lifeBar.transform.Translate(-0.025f, 0, 0);
                    lifeValue -= 0.025f;
                }
				else if( lifeBar.transform.position.x < -0.5f ){
                    playerParticleExec = false;
					_state = State.PlayerDead;
				}
				else{
                    playerParticleExec = false;
					_state = State.MonsterAppear;
				}
			}
		}
	}

	void AnswerRight(){
		if( _state == State.AnswerRight ){
			if( GUIDisppear()){
                if (!enemyParticleExec)
                {
                    enemyParticle.particleEmitter.Emit();
                    enemyParticleExec = true;
                }
				if( _nowMonster.renderer.material.color.a > 0){
					_nowMonster.renderer.material.color -= new Color(0, 0, 0, 0.1f);
				}
				else{
					_timer = 0;
                    enemyParticleExec = false;
					Destroy( _nowMonster );
                    Question.questions[_questionNumber].answerRight = true;
                    Question.answerRightProblem++;
					//Character.score += 1;
					planeGround.GetComponent<Animator>().enabled = true;
					_state = State.Running;
				}
			}
		}
	}

	void PlayerDead(){
		if (_state == State.PlayerDead) {
			SpriteRenderer sprite = player.GetComponentInChildren<SpriteRenderer>();
			if( sprite.color.a > 0 ){
				sprite.color -= new Color(0, 0, 0, 0.1f);
			}
            else if (!gameOverAnimationEnd)
            {
                foreach (var question in Question.questions)
                {
                    question.answerRight = false;
                }
                Question.answerRightProblem = 0;
                Instantiate(GameOver);
                gameOverAnimationEnd = true;
            }
            else
            {
                if (Input.touchCount > 0)
                {
                    Touch touch = Input.touches[0];
                    if (touch.phase == TouchPhase.Began)
                    {
                        Application.LoadLevel("MainPage");
                    }
                }
                if (Input.GetMouseButtonUp(0))
                {
                    Application.LoadLevel("MainPage");
                }
            }
		}
	}
}
