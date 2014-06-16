using UnityEngine;
using System.Collections;


public abstract class State : MonoBehaviour
{
    public State() { }
    public abstract void Execute(GameController controller);
}

public class BattleStart : State
{
    public override void Execute(GameController controller)
    {
        if (controller.player.transform.localPosition.x < -1.7f)
        {
            controller.player.transform.Translate(0.1f, 0, 0);
        }
        else
        {
            controller.State = new Running();
            controller.Timer = 0;
        }
    }
}

public class Running : State
{

    public override void Execute(GameController controller)
    {
        if (!controller.stageClearAnimationEnd)
        {
            ++controller.Timer;

            if (controller.killMonsterCount <= 0)
            {
                Instantiate(controller.StageClear);
                (Instantiate(controller.GetExp) as GameObject).guiText.text += "  " + controller.getExp;
                controller.data.Exp += controller.getExp;
                if (controller.data.Exp >= Data.needExp[controller.data.Rank])
                {
                    ++controller.data.Rank;
                    Instantiate(controller.Rankup);
                    controller.data.Character.Upgrade();
                    controller.data.Point += 10;
                }
                (Instantiate(controller.GetMoney) as GameObject).guiText.text += "  " + controller.getMoney;
                controller.data.Money += controller.getMoney;
                Instantiate(controller.TouchExit);
                controller.data.Save();
                controller.stageClearAnimationEnd = true;
                PlayerPrefs.SetInt(Question.stageName, 1);
            }

            if (controller.Timer >= 60)
            {
                controller.State = new MonsterAppear();
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

public class MonsterAppear : State
{

    public override void Execute(GameController controller)
    {
        if (controller.nowMonster == null)
        {
            controller.nowMonster = new Monster(100, 30, 100, 10000);
            (controller.nowMonster.obj = (Object.Instantiate(controller.monster) as GameObject)).transform.position = new Vector3(4.45f, 1.40f, 17f);
            controller.nowMonster.obj.renderer.material.color = new Color(Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f));
            controller.planeGround.GetComponent<Animator>().enabled = false;
        }
        else if (controller.nowMonster.obj.transform.position.x > 1.1f)
        {
            controller.nowMonster.obj.transform.position -= new Vector3(0.1f, 0, 0);
        }
        else
        {
            controller.State = new DisplayQuestion();
            controller.questionSelected = false;
        }
    }
}

public class DisplayQuestion : State
{

    public override void Execute(GameController controller)
    {
        if (!controller.questionSelected)
        {
            
            controller.questionNumber = Random.Range(0, Question.questions.Count * 2);
            controller.questionNumber = controller.questionNumber % Question.questions.Count;
            while (Question.questions[controller.questionNumber].answerRight)
            {
                ++controller.questionNumber;
                controller.questionNumber %= Question.questions.Count;
            }

            controller.Q.GetComponentInChildren<GUIText>().text = Question.questions[controller.questionNumber].statement;
            controller.A.GetComponentInChildren<GUIText>().text = Question.questions[controller.questionNumber].a;
            controller.B.GetComponentInChildren<GUIText>().text = Question.questions[controller.questionNumber].b;
            controller.C.GetComponentInChildren<GUIText>().text = Question.questions[controller.questionNumber].c;
            controller.D.GetComponentInChildren<GUIText>().text = Question.questions[controller.questionNumber].d;
            controller.questionSelected = true;
        }

        if (controller.Q.guiTexture.color.a < 1)
        {
            controller.Q.guiTexture.color += new Color(0, 0, 0, 0.05f);
        }
        else if (controller.A.transform.position.x < 0.35)
        {
            controller.A.transform.Translate(0.1f, 0, 0, 0);
            if (controller.A.transform.position.x > 0.35)
            {
                controller.A.transform.position.Set(0.35f, controller.A.transform.position.y, controller.A.transform.position.z);
            }
        }
        else if (controller.B.transform.position.x > 0.66)
        {

            controller.B.transform.Translate(-0.1f, 0, 0, 0);
            if (controller.B.transform.position.x < 0.66)
            {
                controller.B.transform.position.Set(0.66f, controller.B.transform.position.y, controller.B.transform.position.z);
            }
        }
        else if (controller.C.transform.position.x < 0.35)
        {
            controller.C.transform.Translate(0.1f, 0, 0, 0);
            if (controller.C.transform.position.x > 0.35)
            {
                controller.C.transform.position.Set(0.35f, controller.C.transform.position.y, controller.C.transform.position.z);
            }
        }
        else if (controller.D.transform.position.x > 0.66)
        {
            controller.D.transform.Translate(-0.1f, 0, 0, 0);
            if (controller.D.transform.position.x < 0.66)
            {
                controller.D.transform.position.Set(0.66f, controller.D.transform.position.y, controller.D.transform.position.z);
            }
        }
        else
        {
            controller.State = new WaitingRequest();
        }
    }
}

public class WaitingRequest : State
{

    public override void Execute(GameController controller)
    {
        if (Input.GetMouseButtonUp(0) || Input.touchCount > 0)
        {
            GUILayer hit = Camera.main.GetComponent<GUILayer>();
            GUIElement hitObject;
            if (Input.GetMouseButtonUp(0)) hitObject = hit.HitTest(Input.mousePosition);
            else hitObject = hit.HitTest(Input.touches[0].position);

            if (hitObject != null && (hitObject.tag == "A" || hitObject.tag == "B" || hitObject.tag == "C" || hitObject.tag == "D"))
            {
                controller.touchBg = GameObject.Find("battle_" + hitObject.tag);
                if (hitObject.tag[0] - 'A' + 1 == Question.questions[controller.questionNumber].answer)
                {
                    controller.answerRight = true;
                    controller.State = new AnswerRight();
                }
                else
                {
                    controller.answerRight = false;
                    controller.State = new AnswerWrong();
                }
            }
        }
    }
}

public class AnswerRight : State
{

    public override void Execute(GameController controller)
    {
        if (controller.GUIDisppear())
        {
            if (!controller.enemyParticleExec)
            {
                controller.enemyParticle.particleEmitter.Emit();
                controller.enemyParticleExec = true;
                controller.nowMonster.HP -= controller.data.Character.Atk;
            }
            if (controller.nowMonster.HP <= 0)
            {
                if (controller.nowMonster.obj.renderer.material.color.a > 0)
                {
                    controller.nowMonster.obj.renderer.material.color -= new Color(0, 0, 0, 0.1f);
                }
                else
                {
                    controller.Timer = 0;
                    controller.enemyParticleExec = false;
                    Destroy(controller.nowMonster.obj);
                    controller.getExp += controller.nowMonster.getExp;
                    controller.getMoney += controller.nowMonster.getMoney;
                    controller.nowMonster = null;
                    Question.questions[controller.questionNumber].answerRight = true;
                    Question.answerRightProblem++;
                    //Character.score += 1;
                    controller.planeGround.GetComponent<Animator>().enabled = true;
                    --controller.killMonsterCount;

                    controller.State = new Running();
                }
            }
            else
            {
                controller.enemyParticleExec = false;
                Question.questions[controller.questionNumber].answerRight = true;
                Question.answerRightProblem++;
                controller.State = new MonsterAppear();
            }

            if (Question.answerRightProblem >= Question.questions.Count)
            {
                foreach (var question in Question.questions)
                {
                    question.answerRight = false;
                }
                Question.answerRightProblem = 0;
                //Instantiate(controller.StageClear);
                //controller.stageClearAnimationEnd = true;
                //PlayerPrefs.SetInt(Question.stageName, 1);
            }
        }
    }
}

public class AnswerWrong : State
{

    public override void Execute(GameController controller)
    {
        if (controller.GUIDisppear())
        {
            if (!controller.playerParticleExec)
            {
                controller.playerParticle.particleEmitter.Emit();
                controller.lifeValue = (float)controller.nowMonster.Atk / (float)controller.data.Character.HP;
                controller.nowHP -= controller.nowMonster.Atk;
                controller.playerParticleExec = true;
            }
            if (controller.lifeValue > 0)
            {
                controller.lifeBar.transform.Translate(-0.025f, 0, 0);
                controller.lifeValue -= 0.025f;
            }
            else if (controller.nowHP < 0)
            {
                controller.playerParticleExec = false;
                controller.State = new PlayerDead();
            }
            else
            {
                controller.playerParticleExec = false;
                controller.State = new MonsterAppear();
            }
        }
    }
}

public class PlayerDead : State
{

    public override void Execute(GameController controller)
    {
        SpriteRenderer sprite = controller.player.GetComponentInChildren<SpriteRenderer>();
        if (sprite.color.a > 0)
        {
            sprite.color -= new Color(0, 0, 0, 0.1f);
        }
        else if (controller.data.LifePoison > 0)
        {
            controller.State = new SelectToUseLifePoison();
        }
        else{
            controller.State = new PlayerCompleteDead();
        }
    }
}

public class SelectToUseLifePoison : State
{
    GameObject usePoison = null;
    GameObject yes = null, no = null;

    public override void Execute(GameController controller)
    {
        if (usePoison == null)
        {
            usePoison = Instantiate(controller.UsePoison) as GameObject;
            usePoison.guiText.text = "您尚有" + controller.data.LifePoison + "瓶復活藥，要使用嗎？";
            yes = Instantiate(controller.Yes) as GameObject;
            no = Instantiate(controller.No) as GameObject;
        }
        else
        {
            if (Input.GetMouseButtonUp(0) || Input.touchCount > 0)
            {
                GUILayer hit = Camera.main.GetComponent<GUILayer>();
                GUIElement hitObject;
                if (Input.GetMouseButtonUp(0)) hitObject = hit.HitTest(Input.mousePosition);
                else hitObject = hit.HitTest(Input.touches[0].position);

                if (hitObject != null) print(hitObject.name);

                if (hitObject != null && hitObject.name == yes.name)
                {
                    --controller.data.LifePoison;
                    SpriteRenderer sprite = controller.player.GetComponentInChildren<SpriteRenderer>();
                    sprite.color = new Color(sprite.color.r, sprite.color.g, sprite.color.b, 1f);
                    Destroy(usePoison);
                    Destroy(yes);
                    Destroy(no);
                    controller.nowHP = controller.data.Character.HP;
                    controller.lifeBar.transform.position = new Vector3(0.5f, controller.lifeBar.transform.position.y, controller.lifeBar.transform.position.z);
                    controller.State = new MonsterAppear();
                }
                if (hitObject != null && hitObject.name == no.name)
                {
                    Destroy(usePoison);
                    Destroy(yes);
                    Destroy(no);
                    controller.State = new PlayerCompleteDead();
                }
            }
        }
    }
}

public class PlayerCompleteDead : State {

    public override void Execute(GameController controller)
    {
        if (!controller.gameOverAnimationEnd)
        {

            foreach (var question in Question.questions)
            {
                question.answerRight = false;
            }
            Question.answerRightProblem = 0;
            Instantiate(controller.GameOver);
            (Instantiate(controller.GetExp) as GameObject).guiText.text += "  " + controller.getExp;
            controller.data.Exp += controller.getExp;
            if (controller.data.Exp >= Data.needExp[controller.data.Rank])
            {
                ++controller.data.Rank;
                Instantiate(controller.Rankup);
                controller.data.Character.Upgrade();
                controller.data.Point += 10;
            }
            (Instantiate(controller.GetMoney) as GameObject).guiText.text += "  " + controller.getMoney;
            controller.data.Money += controller.getMoney;
            Instantiate(controller.TouchExit);
            controller.data.Save();
            controller.gameOverAnimationEnd = true;
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