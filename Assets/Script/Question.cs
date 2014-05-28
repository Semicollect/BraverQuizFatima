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
		// questions.Add(new Question("北斗神拳第六十四代傳人是?", "拳四郎", "拉歐", "托席", "傑基", 1));
		// questions.Add(new Question("被下列那個拳擊中後，不會感到\n痛苦?", "北斗懺悔拳", "北斗百裂拳", "北斗操筋自在拳", "北斗有情拳", 4));
		questions.Add(new Question("請問遭受燙傷的第四個步驟是?", "泡", "蓋", "脫", "沖", 2));
		// questions.Add(new Question("請問下列那個不屬於金剛型戰艦?", "金剛", "比叡", "足柄", "榛名", 3));
		questions.Add(new Question("請問哪個國家不在亞洲?", "日本", "台灣", "奈及利亞", "韓國", 3));
		questions.Add(new Question("請問下列哪個大學不在台北地區?", "國立台灣大學", "國立師範大學", "私立文化大學", "國立中央大學", 4));
		questions.Add(new Question("請問哪種蔬果長在樹上?", "西瓜", "鳳梨", "高麗菜", "蘋果", 4));
		// questions.Add(new Question("請問東方Project第六作為何者？", "東方紅魔鄉", "東方永夜抄", "東方風神錄", "東方地靈殿", 1));
		// questions.Add(new Question("請問下列那個屬於高雄型戰艦?", "瑞鶴", "愛宕", "日向", "吹雪", 2));
		questions.Add(new Question("請問下列那種動物屬於哺乳類？", "藍鯨", "青蛙", "百步蛇", "企鵝", 1));
		questions.Add(new Question("請問下列哪個地區不屬於直轄市？", "高雄市", "新北市", "基隆市", "台中市", 3));
		questions.Add(new Question("請問下列那種動物屬於哺乳類？", "藍鯨", "青蛙", "百步蛇", "企鵝", 1));
		questions.Add(new Question("請問下列哪個不是組成夏季大三\n角的星星？", "天琴座的織女星", "室女座的角宿一", "天鷹座的牛郎星", "天鵝座的天津四",  2));
		questions.Add(new Question("請問北斗七星是由哪個星座的\n七顆明亮恆星組成？", "大熊座", "獵戶座", "天鷹座", "雙子座", 1));
		// questions.Add(new Question("請問下列不屬於征龍之路的\n舊16王？", "鐵王", "獸王", "教王", "夜王", 4));
		questions.Add(new Question("請問下列哪個屬於有理數？", "自然對數", "正整數", "圓周率", "根號2", 2));
		questions.Add(new Question("請問何者並非四書之一？", "論語", "孟子", "莊子", "大學", 3));
		questions.Add(new Question("請問下列並非日治時代的台灣\n總督？", "樺山資紀", "兒玉源太郎", "安藤利吉", "近藤勇", 4));
		questions.Add(new Question("請問下列那位人物沒有擔任過\n行政院長？", "李宗仁", "孔祥熙", "張俊雄", "孫科", 1));
		questions.Add(new Question("請問下列那條台灣河川的流域\n面積最大？", "淡水河", "濁水溪", "高屏溪", "基隆河", 3));

	}
}
