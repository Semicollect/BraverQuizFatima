using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

    public enum State { None, BattleStart };
    private State _state = State.BattleStart;

    public GameObject player;


	// Use this for initialization
	void Start () {
		//player.GetComponent<SpriteRenderer>().sprite = knightSprite;
		//player.GetComponent<Animator>().runtimeAnimatorController = knightAnimatorController;
		//player.transform.localEulerAngles = new Vector3 (0, 180, 0);

	}

	// Update is called once per frame
	void Update () {
        BattleStart();
	}

    void BattleStart()
    {
        if (_state == State.BattleStart)
        {
			if( player.transform.localPosition.x < -1.7 ){
				player.transform.Translate(0.1f, 0, 0);
			}
        }
    }
}
