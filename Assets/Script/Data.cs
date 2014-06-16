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

    private Data() {}

    public Character Character { get; set; }
    public int Rank { get; set; }
    public int Exp { get; set; }

    public void Save()
    {
        Character.Save();
        PlayerPrefs.SetInt("Rank", Rank);
        PlayerPrefs.SetInt("Exp", Exp);
    }

    public void Load()
    {
        Character = (new CharacterFactory()).LoadAndCreateCharacter();
        Rank = PlayerPrefs.GetInt("Rank");
        Exp = PlayerPrefs.GetInt("Exp");
    }
}
