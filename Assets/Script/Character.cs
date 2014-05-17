using UnityEngine;
using System.Collections;

public static class Character {
    public enum Type { Knight, Archer, Magician };
    public static Type PlayerType { get; set; }
	public static int HP = 9000;
	public static int score = 0;
	static Character(){
		PlayerType = Type.Knight;
	}
}
