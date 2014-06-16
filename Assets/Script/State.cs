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

            if (Question.answerRightProblem >= Question.questions.Count)
            {
                foreach (var question in Question.questions)
                {
                    question.answerRight = false;
                }
                Question.answerRightProblem = 0;
                Instantiate(controller.StageClear);
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
            (controller.nowMonster = (Object.Instantiate(controller.monster) as GameObject)).transform.position = new Vector3(4.45f, 1.40f, 17f);
            controller.nowMonster.renderer.material.color = new Color(Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f));
            controller.planeGround.GetComponent<Animator>().enabled = false;
        }
        else if (controller.nowMonster.transform.position.x > 1.1f)
        {
            controller.nowMonster.transform.position -= new Vector3(0.1f, 0, 0);
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
            do
            {
                controller.questionNumber = Random.Range(0, Question.questions.Count * 2);
                controller.questionNumber = controller.questionNumber % Question.questions.Count;
            } while (Question.questions[controller.questionNumber].answerRight);
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
            }
            if (controller.nowMonster.renderer.material.color.a > 0)
            {
                controller.nowMonster.renderer.material.color -= new Color(0, 0, 0, 0.1f);
            }
            else
            {
                controller.Timer = 0;
                controller.enemyParticleExec = false;
                Destroy(controller.nowMonster);
                Question.questions[controller.questionNumber].answerRight = true;
                Question.answerRightProblem++;
                //Character.score += 1;
                controller.planeGround.GetComponent<Animator>().enabled = true;
                controller.State = new Running();
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
                controller.lifeValue = 0.4f;
                controller.playerParticleExec = true;
            }
            if (controller.lifeValue > 0)
            {
                controller.lifeBar.transform.Translate(-0.025f, 0, 0);
                controller.lifeValue -= 0.025f;
            }
            else if (controller.lifeBar.transform.position.x < -0.5f)
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
        else if (!controller.gameOverAnimationEnd)
        {
            foreach (var question in Question.questions)
            {
                question.answerRight = false;
            }
            Question.answerRightProblem = 0;
            Instantiate(controller.GameOver);
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