using UnityEngine;
using UnityEngine.UI;
using System.Collections;

//コンボ処理
//niceを2連続以上でコンボ発動
public class ComboSystem : MonoBehaviour {
	private static int comboNum;
	private static GameObject comboText;
	private static int maxCombo;

	// Use this for initialization
	void Start () {
		comboText = GameObject.Find("MainCanvas/ComboName/ComboCount");
		Init();
	}
	
  //初期化
	public static void Init() {
		maxCombo = 0;
		comboNum = 0;
		comboText.GetComponent<Text>().text = "" + comboNum;
	}

  //コンボ数を1上げる
	public static void AddCombo() {
		comboNum++;
		if (maxCombo < comboNum)  maxCombo = comboNum;
		if (comboNum == 1)  return ;
		ShowComboCount();
		//Debug.Log("combo:" + comboNum);
	}

	//コンボのリセット
	public static void ResetCombo() {
		comboNum = 0;
		//Debug.Log("combo:" + comboNum);
		comboText.GetComponent<Text>().text = "" + comboNum;
	}

  //コンボ数の表示
	private static void ShowComboCount() {
		comboText.GetComponent<Text>().text = "" + comboNum;
	}

	//コンボに応じた倍率を返す
	public static float GetRate() {
		float rate = 0;
		if (comboNum >= 2 && comboNum <= 8) {
			rate += (comboNum - 1) * 20; //comboNum / 10.0f - 0.1f;
		} else if (comboNum > 8) {
			rate = 200;
		}

		return rate;
	}

  //現在のコンボ数を返す
	public static int GetCombo() {
		return comboNum;
	}
  
  //最大コンボ数を返す
	public static int GetMaxCombo() {
		return maxCombo;
	}
}
