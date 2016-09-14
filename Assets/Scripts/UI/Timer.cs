using UnityEngine;
using UnityEngine.UI;
using System.Collections;
//時間を図る処理
public class Timer : MonoBehaviour {
	private Text text;
	private static float time = 0;
	private static bool isBegin = false;
	// Use this for initialization
	void Awake () {
		time = 0;
		isBegin = false;
		text = this.GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {
		if (isBegin) {
			time += Time.deltaTime;
			text.text = "Time:"+time;
		}
		else {

		}
	}

  public static void StartTime() {
  	isBegin = true;
  }
  public static void FinishTime() {
  	isBegin = false;
  	time = 0;
  }
  //再スタート
  public static void ReStart() {
  	time = 0;
  }

  //現在の時間をログに表示
  public static void ShowLogNowTime() {
  	Debug.Log("time:"+ time);
  }

  public static float GetCurrentTime() {
  	return time;
  }

  public static bool IsVeryLate(float judgeTime) {
  	if (!isBegin) return false;
  	if (time > judgeTime) return true;
  	return false;
  }
}
