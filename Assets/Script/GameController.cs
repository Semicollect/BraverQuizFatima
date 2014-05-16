using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

    public enum State { None, BattleStart, Running, MonsterAppear };
    private State _state = State.BattleStart;

    public GameObject player;
	public GameObject monster;

	private GameObject _nowMonster = null;
	private int _timer = 0;

	// Use this for initialization
	void Start () {
		//player.GetComponent<SpriteRenderer>().sprite = knightSprite;
		//player.GetComponent<Animator>().runtimeAnimatorController = knightAnimatorController;
		//player.transform.localEulerAngles = new Vector3 (0, 180, 0);

	}

	// Update is called once per frame
	void Update () {
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
			if( _nowMonster == null ) (_nowMonster = (Object.Instantiate(monster) as GameObject)).transform.position = new Vector3(4.45f, 1.40f, 17f);
			if(_nowMonster.transform.position.x > 1.1f){
				_nowMonster.transform.position -= new Vector3(0.1f, 0, 0);
			}
		}
	}
}
