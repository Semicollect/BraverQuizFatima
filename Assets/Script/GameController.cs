using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {


    public State State = new BattleStart();
    public bool answerRight = false;

    public GameObject player;
	public GameObject knight;
	public GameObject archer;
	public GameObject magician;
	public GameObject monster;
	public GameObject planeGround;

    public GameObject GameOver;
    public bool gameOverAnimationEnd = false;
    public GameObject StageClear;
    public bool stageClearAnimationEnd = false;

    public GameObject enemyParticle;
    public bool enemyParticleExec = false;
    public GameObject playerParticle;
    public bool playerParticleExec = false;
    public float lifeValue;


	public GameObject lifeBar;

	public GameObject Q, A, B, C, D;

	public Monster nowMonster = null;
    public int Timer = 0;
	public bool questionSelected = false;
	public int questionNumber = 0;
	public GameObject touchBg;

    public Data data;
    public int nowHP;
	// Use this for initialization
	void Start () {
        State = new BattleStart();
        data = Data.GetInstance();
        nowHP = data.Character.HP;
		if (Question.stageName == "stage1") {

		}
		else if( Question.stageName == "stage2") {
			planeGround.renderer.material.color = new Color( 14.0f/255.0f, 131.0f/255.0f, 29.0f/255.0f, 255.0f/255.0f );
		}
		else if (Question.stageName == "stage3") {
			planeGround.renderer.material.color = new Color( 234.0f/255.0f, 47.0f/255.0f, 47.0f/255.0f, 255.0f/255.0f );
		}

		// Character.score = 0;
		if (data.Character.IsDestroy(knight)) {
			Destroy(knight);
		}
        if (data.Character.IsDestroy(archer))
        {
			Destroy(archer);
		}
        if (data.Character.IsDestroy(magician))
        {
			Destroy(magician);
		}
		//player.GetComponent<SpriteRenderer>().sprite = knightSprite;
		//player.GetComponent<Animator>().runtimeAnimatorController = knightAnimatorController;
		//player.transform.localEulerAngles = new Vector3 (0, 180, 0);

	}

	// Update is called once per frame
	void Update () {
        this.State.Execute(this);
	}

	public bool GUIDisppear(){
		if (touchBg.guiTexture.color.g < 0.7f && touchBg.guiTexture.color.r < 0.7f) {
            if (answerRight)
            {
				touchBg.guiTexture.color += new Color(0, 0.1f, 0);
			}
			else{
				touchBg.guiTexture.color += new Color(0.1f, 0, 0);
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
			touchBg.guiTexture.color = new Color(0.5f, 0.5f, 0.5f, 0.5f);
			return true;
		}
		return false;
	}
}
