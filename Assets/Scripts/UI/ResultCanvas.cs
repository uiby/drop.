using UnityEngine;
using UnityEngine.UI;
using System.Collections;

//結果表示画面の制御
public class ResultCanvas : MonoBehaviour {
	public Text[] bornText; //OO誕生!の部分のテキスト
	public ParticleSystem[] bornEffect; //演出に使うパーティクル
	public static bool canPlay;//リザルトの演出をしていいかどうか
	private float timer;
	public enum eState : int {
  	None,
    First = 1, //ゲーム初期画面
    Second,  //メインゲーム画面
    Third //ゲームクリア―
  }
  public static eState state;

	void Start() {
		state = eState.None;
		canPlay = false;
		timer = 0;
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
			  	state = eState.None;
			  	bornText[0].text = GameResult.GetCharactorName(); //キャラクターの名前を得る
			  	GameObject.Find("ResultCanvas/BornWord").GetComponent<BornWord>().PlayAnimation();
			  	ShowCanvas();
			  }
			break;
		}
	}

	public void HideCanvas() {
		for (int i = 0; i < bornText.Length; i++) bornText[i].enabled = false;
	}

	public void ShowCanvas() {
		for (int i = 0; i < bornText.Length; i++) bornText[i].enabled = true;
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
}
