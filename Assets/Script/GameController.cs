using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

    public enum State { None, BattleStart, Running, MonsterAppear, DisplayQuestion };
    private State _state = State.BattleStart;

    public GameObject player;
	public GameObject monster;
	public GameObject planeGround;

	public GameObject Q, A, B, C, D;

	private GameObject _nowMonster = null;
	private int _timer = 0;
	private bool _questionSelected = false;

	// Use this for initialization
	void Start () {
		//player.GetComponent<SpriteRenderer>().sprite = knightSprite;
		//player.GetComponent<Animator>().runtimeAnimatorController = knightAnimatorController;
		//player.transform.localEulerAngles = new Vector3 (0, 180, 0);

	}

	// Update is called once per frame
	void Update () {
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
				Q.GetComponentInChildren<GUIText>().text = "今年是幾年？";
				A.GetComponentInChildren<GUIText>().text = "2012";
				B.GetComponentInChildren<GUIText>().text = "2013";
				C.GetComponentInChildren<GUIText>().text = "2014";
				D.GetComponentInChildren<GUIText>().text = "2015";
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
		}

	}
}
