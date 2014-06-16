using UnityEngine;
using System.Collections;

public abstract class Character {
	public int HP { get; set; }
    public int Atk { get; set; }
	public Character(int hp, int atk){
        HP = hp;
        Atk = atk;
    }

    public abstract void Upgrade();
    public abstract void SaveType();
    public void Save()
    {
        PlayerPrefs.SetInt("HP", HP);
        PlayerPrefs.SetInt("Atk", Atk);
        SaveType();
    }

    public abstract bool IsDestroy(GameObject obj);
}

public class Knight : Character
{
    public Knight() : base(100, 60) { }

    public override bool IsDestroy(GameObject obj)
    {
        if (!obj.name.Contains("knight"))
        {
            return true;
        }

        return false;
    }

    public override void SaveType()
    {
        PlayerPrefs.SetString("CharacterType", "knight");
    }

    public override void Upgrade()
    {
        HP += 30;
        Atk += 10;
    }
}

public class Archer : Character
{
    public Archer() : base(80, 80) { }

    public override bool IsDestroy(GameObject obj)
    {
        if (!obj.name.Contains("archer"))
        {
            return true;
        }

        return false;
    }

    public override void SaveType()
    {
        PlayerPrefs.SetString("CharacterType", "archer");
    }

    public override void Upgrade()
    {
        HP += 20;
        Atk += 20;
    }
}

public class Magician : Character
{
    public Magician() : base(60, 100) { }

    public override bool IsDestroy(GameObject obj)
    {
        if (!obj.name.Contains("magician"))
        {
            return true;
        }

        return false;
    }

    public override void SaveType()
    {
        PlayerPrefs.SetString("CharacterType", "magician");
    }

    public override void Upgrade()
    {
        HP += 10;
        Atk += 30;
    }
}

