using UnityEngine;
using System.Collections;

public class Data {
    public static Data _singleton = null;
    public static Data GetInstance(){
        if (_singleton == null)
        {
            _singleton = new Data();
        }

        return _singleton;
    }

    public static int[] needExp = { 200, 300, 500, 800, 1200, 1700, 2300, 3000, 3800, 4700, 5700 };

    private Data() {}

    public Character Character { get; set; }
    public int Rank { get; set; }
    public int Exp { get; set; }
    public int Money { get; set; }
    public int Point { get; set; }
    public int LifePoison { get; set; }

    public void Save()
    {
        Character.Save();
        PlayerPrefs.SetInt("Rank", Rank);
        PlayerPrefs.SetInt("Exp", Exp);
        PlayerPrefs.SetInt("Money", Money);
        PlayerPrefs.SetInt("Point", Point);
        PlayerPrefs.SetInt("LifePoison", LifePoison);
    }

    public void Load()
    {
        Character = (new CharacterFactory()).LoadAndCreateCharacter();
        Rank = PlayerPrefs.GetInt("Rank");
        Exp = PlayerPrefs.GetInt("Exp");
        Money = PlayerPrefs.GetInt("Money");
        Point = PlayerPrefs.GetInt("Point");
        LifePoison = PlayerPrefs.GetInt("LifePoison");
    }
}
