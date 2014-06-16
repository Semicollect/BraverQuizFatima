using UnityEngine;
using System.Collections;

public class Monster {
    public int HP;
    public int Atk;
    public GameObject obj;
    public int getExp;
    public int getMoney;

    public Monster(int hp, int atk, int exp, int money)
    {
        HP = hp;
        Atk = atk;
        getExp = exp;
        getMoney = money;
    }
	
}
