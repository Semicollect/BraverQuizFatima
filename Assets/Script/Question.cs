using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Question {
	public string statement;
	public string a;
	public string b;
	public string c;
	public string d;
	public int answer;

	public static List<Question> questions;

	public Question(string statement, string a, string b, string c, string d, int answer){
		this.statement = statement;
		this.a = a;
		this.b = b;
		this.c = c;
		this.d = d;
		this.answer = answer;
	}

	public static void CreateQuestions(){
		questions = new List<Question>();
		questions.Add(new Question("請問圓周率小數點後第6位是幾?", "1", "2", "5", "9", 2));
		questions.Add(new Question("下列哪個星座屬於十二星座?", "天馬座", "鳳凰座", "天龍座", "白羊座", 4));
		questions.Add(new Question("北斗神拳第57代傳人是?", "拳四郎", "拉歐", "托席", "傑基", 1));
		questions.Add(new Question("被下列那個拳擊中後，不會感到\n痛苦?", "北斗懺悔拳", "北斗百裂拳", "北斗操筋自在拳", "北斗有情拳", 4));
		questions.Add(new Question("請問遭受燙傷的第四個步驟是?", "泡", "蓋", "脫", "沖", 2));
		questions.Add(new Question("請問下列那個不屬於金剛型戰艦?", "金剛", "比叡", "足柄", "榛名", 3));
		questions.Add(new Question("請問哪個國家不在亞洲?", "日本", "台灣", "奈及利亞", "韓國", 3));
		questions.Add(new Question("請問下列哪個大學不在台北地區?", "國立台灣大學", "國立師範大學", "私立文化大學", "國立中央大學", 4));
		questions.Add(new Question("請問哪種蔬果長在樹上?", "西瓜", "鳳梨", "高麗菜", "蘋果", 4));
		questions.Add(new Question("請問東方Project第六作為何者？", "東方紅魔鄉", "東方永夜抄", "東方風神錄", "東方地靈殿", 1));
	}
}
