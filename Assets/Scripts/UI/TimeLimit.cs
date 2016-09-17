using UnityEngine;
using UnityEngine.UI;
using System.Collections;

//タイムリミットの表示
//1. ステージごとのタイムリミットを格納
//2. カウントダウン
//3. 0になる前にクリアするとよし0過ぎたら－でカウント
//4. 1に戻る
public class TimeLimit : MonoBehaviour {
	private static Text timeText;
	private static float timer = 0;
	private static bool canCountDown = false;
	private static bool isMinus; //timerがマイナスの時かどうか
	private static float maxTimer;
	// Use this for initialization
	void Start () {
		timeText = this.GetComponent<Text>();
		Init();
	}
	
	// Update is called once per frame
	void Update () {
		if (canCountDown) {
			timer -= Time.deltaTime;
			Renewal();
			if (!isMinus && timer < 0) {
				isMinus = true;
				ChangeColor(1, 0, 0);
			}
		}
		else {

		}
	}

	public void Init() {
		timer = 0;
		canCountDown = false;
		isMinus = false;
		maxTimer = 0;
		//Renewal ();
	}

  public static void FinishCountDown() {
  	canCountDown = false;
  	//timer = 0;
  }

  //現在の時間をログに表示
  public static void ShowLogNowTime() {
  	Debug.Log("timer:"+ timer);
  }

  public static float GetCurrentTime() {
  	return timer;
  }

  public static bool IsVeryLate(float judgeTime) {
  	if (!canCountDown) return false;
  	if (timer > judgeTime) return true;
  	return false;
  }

  //制限時間の確認 ステージクリアした時に使う
  public static void SetTimer(float value) {
  	maxTimer = value;
  	timer = maxTimer;
  	isMinus = false;
  	//Debug.Log("set:"+timer);
  }

  //カウントダウンの開始 魂がステージに着地した瞬間に使う
  public static void StartCountDown() {
  	if (GameManager.state == GameManager.GameState.GameFirst) return;
  	canCountDown = true;
  }

  //タイマーの更新
	public static void Renewal() {
		timeText.text = (timer).ToString("F2");  //下二ケタで修正
	}

  //色の変化
	public static void ChangeColor(float r, float g, float b) {
		Color color = new Color(r, g, b, 1.0f);
	  timeText.color = color;
	}

  //カウントダウンの更新(次のタイマーにセット).アニメーションで使用
	public void ChangeTimer() {
		ChangeColor(0, 1, 0);
		Renewal();
	}

	public void Change() {
		this.GetComponent<Animator>().SetTrigger("Change");
	}
}
