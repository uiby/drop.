using UnityEngine;
using UnityEngine.UI;
using System.Collections;

//結果表示画面の制御
//UIと演出などリザルトすべての管理を行う
public class ResultCanvas : MonoBehaviour {
	public Text[] sentences; //残りの表示する文章達
	public Text[] bornText; //OO誕生!の部分のテキスト
	public ParticleSystem[] bornEffect; //演出に使うパーティクル
	public static bool canPlay;//リザルトの演出をしていいかどうか
	private float timer; //たまにフレームとして使う
	private int count;//文字列とかオブジェクト数とか数える時に使う
	private Text massage; //最後のメッセージ
	private string thankyou = "Thank you for playing";
	public enum eState : int {
  	None,
    First = 1, 
    Second,  
    Third,   
    Third_2, 
    Four,
    Five,
    Last //最後
  }
  public static eState state;

	void Start() {
		state = eState.None;
		canPlay = false;
		timer = 0;
		count = 0;
		massage = this.transform.FindChild("Massage").GetComponent<Text>();
		HideCanvas();
	}

	void Update() {
		if (!canPlay) return;

		//時間で演出を制御
		switch (state) {
			case eState.First: 
			  timer += Time.deltaTime;
			  if (timer >= 1.0f) { //1.0秒経ったら
			  	bornEffect[0].Play();
			  	bornEffect[1].Play();
			  	timer = 0;
			  	state = eState.Second;
			  	HideSoul();
			  }
			break;
			case eState.Second: 
			  timer += Time.deltaTime;
			  if (timer >= 0.6f) {
			  	BornCreature();
			    bornEffect[2].Play();
			    state = eState.Third;
			  }
			break;
			case eState.Third: 
			  if(bornEffect[0].isStopped) {
			  	state = eState.Third_2;
			  	bornText[0].text = GameResult.GetCharactorName(); //キャラクターの名前を得る
			  	GameObject.Find("ResultCanvas/BornWord").GetComponent<BornWord>().PlayAnimation(GameResult.GetAnimationTriggerName());
			  	ShowCanvas();
			  	timer = 0;
			  }
			break;
			case eState.Third_2: //1フレーム以上おきたいため
			  timer++;
			  if (timer > 5)  {
			  	state = eState.Four;
			  }
			break;
			case eState.Four:
			  if (GameObject.Find("ResultCanvas/BornWord").GetComponent<BornWord>().IsFinishAnimation()) {
			  	state = eState.Five;
			    timer = 0;
			    SetNum(); //テキストの確定
			  }
			break;
			case eState.Five:
  			timer++;
			  if (timer == 20) {
			  	sentences[count++].enabled = true;
			  	timer = 0;

			  	if (sentences.Length == count) {
			  	  state = eState.Last;
			  	  count = 0;
			  	}
			  }
			break;
			case eState.Last:
			timer++;

			if (timer == 3) {
				timer = 0;
				massage.text += thankyou[count++];
			}
			
			if (count == thankyou.Length)
  			state = eState.None;
			break;
		}
	}

	public void HideCanvas() {
		for (int i = 0; i < bornText.Length; i++)  bornText[i].enabled = false;
		for (int i = 0; i< sentences.Length; i++) sentences[i].enabled = false;
		massage.text = "";
		massage.enabled = false;
		this.GetComponent<Canvas>().enabled = false;
	}

	public void ShowCanvas() {
		for (int i = 0; i < bornText.Length; i++) bornText[i].enabled = true;
		massage.enabled = true;
		this.GetComponent<Canvas>().enabled = true;
	}

	//魂を隠す
  private void HideSoul() {
  	GameObject.Find("Player").GetComponent<Renderer>().enabled = false;
		GameObject.Find("Player").GetComponent<ParticleSystem>().Stop();
  }
  //生き物の生成
	private void BornCreature() {
		Instantiate(GameResult.GetCharactor(), GameObject.Find("Player").transform.position, Quaternion.identity);
	}

  //各スコアをテキストにセット
	private void SetNum() {
		sentences[1].text = "" + ComboSystem.GetMaxCombo();
		sentences[3].text = "" + ScoreManager.GetScore();
	}
}
