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
    public bool answerRight;

	public static List<Question> questions;
    public static List<Question> stage1, stage2, stage3;
    public static string stageName;
    public static int answerRightProblem = 0;
	public Question(string statement, string a, string b, string c, string d, int answer){
		this.statement = statement;
		this.a = a;
		this.b = b;
		this.c = c;
		this.d = d;
		this.answer = answer;
        this.answerRight = false;
	}

	public static void CreateQuestions(){

        stage1 = new List<Question>();

        stage1.Add(new Question("請問圓周率小數點後第6位是幾?", "1", "2", "5", "9", 2));
        stage1.Add(new Question("下列哪個星座屬於十二星座?", "天馬座", "鳳凰座", "天龍座", "白羊座", 4));
        // stage1.Add(new Question("北斗神拳第57代傳人是?", "拳四郎", "拉歐", "托席", "傑基", 1));
        // stage1.Add(new Question("被下列那個拳擊中後，不會感到\n痛苦?", "北斗懺悔拳", "北斗百裂拳", "北斗操筋自在拳", "北斗有情拳", 4));
        stage1.Add(new Question("請問遭受燙傷的第四個步驟是?", "泡", "蓋", "脫", "沖", 2));
        // stage1.Add(new Question("請問下列那個不屬於金剛型戰艦?", "金剛", "比叡", "足柄", "榛名", 3));
        stage1.Add(new Question("請問哪個國家不在亞洲?", "日本", "台灣", "奈及利亞", "韓國", 3));
        stage1.Add(new Question("請問下列哪個大學不在台北地區?", "國立台灣大學", "國立師範大學", "私立文化大學", "國立中央大學", 4));
        stage1.Add(new Question("請問哪種蔬果長在樹上?", "西瓜", "鳳梨", "高麗菜", "蘋果", 4));
        // stage1.Add(new Question("請問東方Project第六作為何者？", "東方紅魔鄉", "東方永夜抄", "東方風神錄", "東方地靈殿", 1));
        // stage1.Add(new Question("請問下列那個屬於高雄型戰艦?", "瑞鶴", "愛宕", "日向", "吹雪", 2));
        stage1.Add(new Question("請問下列那種動物屬於哺乳類？", "藍鯨", "青蛙", "百步蛇", "企鵝", 1));
        stage1.Add(new Question("請問下列哪個地區不屬於直轄市？", "高雄市", "新北市", "基隆市", "台中市", 3));
        stage1.Add(new Question("請問下列哪個不是組成夏季大三角的星星？", "天琴座的織女星", "室女座的角宿一", "天鷹座的牛郎星", "天鵝座的天津四", 2));
        // stage1.Add(new Question("請問北斗七星是由哪個星座的七顆明亮恆星組成？", "大熊座", "獵戶座", "天鷹座", "雙子座", 1));
        // stage1.Add(new Question("請問下列不屬於征龍之路的舊16王？", "鐵王", "獸王", "教王", "夜王", 4));
        stage1.Add(new Question("請問下列哪個屬於有理數？", "自然對數", "正整數", "圓周率", "根號2", 2));
        stage1.Add(new Question("請問何者並非四書之一？", "論語", "孟子", "莊子", "大學", 3));
        stage1.Add(new Question("請問下列並非日治時代的台灣總督？", "樺山資紀", "兒玉源太郎", "安藤利吉", "近藤勇", 4));
        stage1.Add(new Question("請問下列那位人物沒有擔任過行政院長？", "李宗仁", "孔祥熙", "張俊雄", "孫科", 1));
        stage1.Add(new Question("請問下列那條台灣河川的流域面積最大？", "淡水河", "濁水溪", "高屏溪", "基隆河", 3));

        stage2 = new List<Question>();

        stage2.Add(new Question("Lost and scared, the little dog ______ along \nthe streets, looking for its master.", "dismissed", "glided", "wandered", "marched", 3));
        stage2.Add(new Question("On a sunny afternoon last month, we all took \noff our shoes and walked on the grass \nwith _____ feet.", "bare", "raw", "tough", "slippery", 1));
        stage2.Add(new Question("It is both legally and _______ wrong to \nspread rumors about other people on the \nInternet.", "morally", "physically", "literarily", "commercially", 1));
        stage2.Add(new Question("These warm-up exercises are designed to help \npeople _____ their muscles and prevent \ninjuries.", "produce", "connect", "broaden", "loosen", 4));
        stage2.Add(new Question("Mei-ling has a very close relationship with her \nparents. She always ______ them before \nshe makes important decisions.", "impresses", "advises", "consults", "motivates", 3));

        stage3 = new List<Question>();

        stage3.Add(new Question("座標平面上，若點(3, b)在方程式3y=2x-9的\n圖形上，則b值為何？", "-1", "2", "3", "9", 1));
        stage3.Add(new Question("化簡5(2x-3)-4(3-2x)之後，可得下列哪一個\n結果？", "2x-27", "8x-15", "12x-15", "18x-27", 4));
        stage3.Add(new Question("若△ABC中，2（∠A＋∠C）＝3∠B，則∠B的\n外角度數為何？", "36", "72", "108", "144", 3));
        stage3.Add(new Question("若(a－1)：7＝4：5，則10a＋8之值為何？", "54", "66", "74", "80", 3));
        stage3.Add(new Question("解不等式－x/5－3＞2，得其解的範圍為何？", "x＜－25", "x＞－25", "x＜5", "x＞5", 1));
        /*
		questions = new List<Question>();
        
        questions.Add(new Question("請問2008年1月19日寫的是\n什麼的到來？", "寒假", "暑假", "春假", "周休", 1));
        questions.Add(new Question("請問2008年1月31日成功電研社\n發生什麼的追逐戰？", "洛克", "風台", "幽靈", "慶喵", 2));
        questions.Add(new Question("請問2008年5月19日我教了同學什麼？", "CSS", "C++", "HTML", "Javascript", 3));
        questions.Add(new Question("請問2008年2月16日在FF中沒有買下列\n何樣商品？", "東方夢詠宴", "誓約", "Fate/Chronicle", "東方夢月魂", 4));
        questions.Add(new Question("請問2008年4月13日我被奸商強迫\n穿上什麼裝？", "公主裝", "女僕裝", "軍裝", "制服裝", 1));
        questions.Add(new Question("請問2008年6月8日我去看了納尼亞哪部\n電影？", "獅子女巫魔衣櫥", "賈斯潘王子", "奇幻馬和他的男孩", "銀椅", 2));
        questions.Add(new Question("在07年寫的廣播劇中，與我對話的是？", "Yung", "藍白", "塔米", "哎呀", 3));
        questions.Add(new Question("在楓翼城幻想日誌中，1st和2nd的主角\n為哪種關係？", "死對頭", "無關係", "單純朋友", "青梅竹馬", 4));
        questions.Add(new Question("惡搞翼世界的主角是誰？", "暴風Furiata", "河水大神", "惡搞天使", "小姿", 1));
        questions.Add(new Question("作曲部分的第五首歌曲為？", "Title", "Underground", "Cave(Night)", "Road(Night)", 2));
        questions.Add(new Question("請問目前公布我的Sonic CD在\nMetallic Madness Zone3的破關時間為？", "02:41:55", "00:57:48", "01:49:96", "01:38:56", 3));
        
        questions.Add(new Question("這個遊戲是在哪次事件做出來的？", "微軟社群之星", "阿勃勒大賽", "微軟學生大使", "微軟黑客松", 4));
        questions.Add(new Question("我第一次去女僕咖啡廳是什麼時候？", "2007/11/17", "2008/01/28", "2008/01/27", "2008/02/16", 1));
        questions.Add(new Question("我們所舉辦的成功電研茶會在何時？", "2008/06/01", "2008/04/19", "2008/05/31", "2008/04/26", 2));
        questions.Add(new Question("我在2008/04/10買了哪本漫畫回家？", "少年偵探", "魔法老師", "女王騎士物語", "咕嚕咕嚕魔法陣", 3));
        questions.Add(new Question("2008/03/30錄了英文歌唱比賽\n的歌，請問是哪首曲目？", "Still Alive", "Can you feel the \nsunshine?", "Living in the city", "Proud of You", 4));
        questions.Add(new Question("2008/05/17校慶那天，\n忘了拿哪間教室的鑰匙？", "二樓電教", "三樓電教", "管樂社辦", "電研社辦", 1));
        questions.Add(new Question("2008/01/27不怪星網聚，\n我跟誰輪流溜冰？", "SAYA", "我不怪", "狐", "風之律動", 2));
        questions.Add(new Question("2008/02/22附近，有空的時候我會翻\n哪一年寒訓的講義？", "2005年", "2006年", "2007年", "2008年", 3));
        questions.Add(new Question("三月四號常有三四的詛咒發生(取自\n寒蟬)，我曾被怎麼樣？", "血壓飆高", "感冒", "四肢無力", "拉肚子", 4));
        */

        /*
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
<<<<<<< HEAD
		questions.Add(new Question("請問下列並非日治時代的台灣\n總督？", "樺山資紀", "兒玉源太郎", "安藤利吉", "近藤勇", 4));
		questions.Add(new Question("請問下列那位人物沒有擔任過\n行政院長？", "李宗仁", "孔祥熙", "張俊雄", "孫科", 1));
		questions.Add(new Question("請問下列那條台灣河川的流域\n面積最大？", "淡水河", "濁水溪", "高屏溪", "基隆河", 3));
=======
		questions.Add(new Question("請問下列並非日治時代的台灣總督？", "樺山資紀", "兒玉源太郎", "安藤利吉", "近藤勇", 4));
		questions.Add(new Question("請問下列那位人物沒有擔任過行政院長？", "李宗仁", "孔祥熙", "張俊雄", "孫科", 1));
		questions.Add(new Question("請問下列那條台灣河川的流域面積最大？", "淡水河", "濁水溪", "高屏溪", "基隆河", 3));
        */

>>>>>>> afbbd3cfdc65c7e293a9cf6b3afbbf61512c9d62

	}
}
