using UnityEngine;
using System;
using System.Collections;


public class CharacterFactory {
    public CharacterFactory() { }

    public Character LoadAndCreateCharacter()
    {
        Character character;
        switch (PlayerPrefs.GetString("CharacterType"))
        {
            case "knight":
                character = new Knight();
                break;
            case "archer":
                character = new Archer();
                break;
            case "magician":
                character = new Magician();
                break;
            default:
                throw new Exception("No Character Type.");
        }

        character.HP = PlayerPrefs.GetInt("HP");
        character.Atk = PlayerPrefs.GetInt("Atk");

        return character;
    }
}
