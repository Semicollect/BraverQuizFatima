using UnityEngine;
using System.Collections;

public class MainPageController : MonoBehaviour {

    public GameObject battle;
    public GameObject character;
    public GameObject shop;
    public GameObject setting;

    public GameObject rank;
    public GameObject exp;

    public GameObject archericon;
    public GameObject knighticon;
    public GameObject magicianicon;
    public GameObject hp;
    public GameObject atk;

    public GameObject money;
    public GameObject point;
    public GameObject lifePoison;

    public GameObject hpAdd;
    public GameObject atkAdd;

    private GameObject[] pages;

    private bool move = false;
    private int now = 0;
    private int last = 0;

    private Data _data;
	// Use this for initialization
    void UpdateInformation()
    {
        rank.guiText.text = _data.Rank.ToString();
        exp.guiText.text = _data.Exp.ToString() + " / " + Data.needExp[_data.Rank];
        hp.guiText.text = _data.Character.HP.ToString();
        atk.guiText.text = _data.Character.Atk.ToString();
        money.guiText.text = _data.Money.ToString();
        point.guiText.text = _data.Point.ToString();
        lifePoison.guiText.text = _data.LifePoison.ToString();

        if (_data.Point <= 0)
        {
            hpAdd.guiTexture.color = new Color(hpAdd.guiTexture.color.r, hpAdd.guiTexture.color.g, hpAdd.guiTexture.color.b, 0);
            atkAdd.guiTexture.color = new Color(atkAdd.guiTexture.color.r, atkAdd.guiTexture.color.g, atkAdd.guiTexture.color.b, 0);
        }
        else
        {

            hpAdd.guiTexture.color = new Color(hpAdd.guiTexture.color.r, hpAdd.guiTexture.color.g, hpAdd.guiTexture.color.b, 1);
            atkAdd.guiTexture.color = new Color(atkAdd.guiTexture.color.r, atkAdd.guiTexture.color.g, atkAdd.guiTexture.color.b, 1);
        }
    }

	void Start () {
        _data = Data.GetInstance();
        pages = new GameObject[] { battle, character, shop, setting };
        now = 0;
        last = 0;

        UpdateInformation();

        if (_data.Character.IsDestroy(archericon))
        {
            Destroy(archericon);
        }

        if (_data.Character.IsDestroy(knighticon))
        {
            Destroy(knighticon);
        }

        if (_data.Character.IsDestroy(magicianicon))
        {
            Destroy(magicianicon);
        }
	}
	
	// Update is called once per frame
	void Update () {

        UpdateInformation();

        if (!move)
        {
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

                if (hitObject != null && hitObject.tag == "button")
                {
                    if (hitObject.name == "mainpage_b1")
                    {
                        if (now != 0)
                        {
                            last = now;
                            now = 0;
                            move = true;
                        }
                    }
                    if (hitObject.name == "mainpage_b2")
                    {
                        if (now != 1)
                        {
                            last = now;
                            now = 1;
                            move = true;
                        }
                    }
                    if (hitObject.name == "mainpage_b3")
                    {
                        if (now != 2)
                        {
                            last = now;
                            now = 2;
                            move = true;
                        }
                    }
                    if (hitObject.name == "mainpage_b4")
                    {
                        if (now != 3)
                        {
                            last = now;
                            now = 3;
                            move = true;
                        }
                    }
                }

                if (hitObject != null && hitObject.name == "mainpage_setting_yes")
                {
                    PlayerPrefs.DeleteAll();
                    Application.LoadLevel("StartScreen");
                }

                if (hitObject != null && hitObject.tag == "add" && hitObject.guiTexture.color.a >= 1.0f)
                {
                    if (hitObject.name == "HPAdd")
                    {
                        --_data.Point;
                        ++_data.Character.HP;
                        _data.Save();
                    }
                    if (hitObject.name == "ATKAdd")
                    {
                        --_data.Point;
                        ++_data.Character.Atk;
                        _data.Save();
                    }
                }

                if (hitObject != null && hitObject.name == "mainpage_shop_buy")
                {
                    if (_data.Money >= 10000)
                    {
                        _data.Money -= 10000;
                        _data.LifePoison++;
                        _data.Save();
                    }
                }
            }
        }
        else
        {
            if (pages[last].transform.position.x > -2.0f)
            {
                //print(pages[last].transform.position.x);
                pages[last].transform.position = new Vector3(pages[last].transform.position.x-0.1f, pages[last].transform.position.y, pages[last].transform.position.z);
                //print(pages[last].transform.position.x);
                if (pages[last].transform.position.x < -2.0f)
                {
                    pages[last].transform.position = new Vector3(-2.0f, pages[last].transform.position.y, pages[last].transform.position.z);
                }
            }
            else if (pages[now].transform.position.x < 0)
            {
                pages[now].transform.position = new Vector3(pages[now].transform.position.x + 0.1f, pages[now].transform.position.y, pages[now].transform.position.z);
                if (pages[now].transform.position.x > 0)
                {
                    pages[now].transform.position = new Vector3(0, pages[now].transform.position.y, pages[now].transform.position.z);
                }
            }
            else
            {
                move = false;
            }

        }
	}
}
