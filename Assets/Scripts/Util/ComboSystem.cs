using UnityEngine;
using UnityEngine.UI;
using System.Collections;

//コンボ処理
//niceを2連続以上でコンボ発動
public class ComboSystem : MonoBehaviour {
	public ParticleSystem normalParticleSystem;
	public ParticleSystem highParticleSystem;
	private static int comboNum;
	private static GameObject comboCount;
	private static GameObject comboName;
	private static Animator animator;
	private static int maxCombo;

	// Use this for initialization
	void Start () {
		comboCount = GameObject.Find("MainCanvas/ComboName/ComboCount");
		comboName = GameObject.Find("MainCanvas/ComboName");
		animator = this.GetComponent<Animator>();
		Init();
	}
	
  //初期化
	public static void Init() {
		maxCombo = 0;
		comboNum = 0;
		comboCount.GetComponent<Text>().text = "" + comboNum;
		HideCombo();
	}

  //コンボ数を1上げる
  //StageResultWordスクリプトで使用
	public static void AddCombo() {
		comboNum++;
		if (maxCombo < comboNum)  maxCombo = comboNum;
		if (comboNum == 2) {
			ShowCombo();
		}
		//ShowComboCount();
		if (comboNum >= 2) animator.SetTrigger("CountUp");
		//Debug.Log("combo:" + comboNum);
	}

	//コンボのリセット
	public static void ResetCombo() {
		comboNum = 0;
		//Debug.Log("combo:" + comboNum);
		comboCount.GetComponent<Text>().text = "" + comboNum;
		HideCombo();
	}

  //コンボ数の更新.Animationで使用
	public void RenewalComboCount() {
		if (comboNum > 8)  comboCount.GetComponent<Text>().text = "<color=aqua>" + comboNum + "</color>";
		else  comboCount.GetComponent<Text>().text = "" + comboNum;
	}
	private static void ShowComboName() {
		comboName.GetComponent<Text>().enabled = true;
	}
	public static void HideCombo() {
		comboCount.GetComponent<Text>().enabled = false;
		comboName.GetComponent<Text>().enabled = false;
	}
	private static void ShowCombo() {
		comboCount.GetComponent<Text>().enabled = true;
		comboName.GetComponent<Text>().enabled = true;
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

  //エフェクトの演出
	public void PlayEffect() {
		if (comboNum < 8)  highParticleSystem.Emit(100);
		else  normalParticleSystem.Emit(100);
		/*Color color = normalParticleSystem.startColor;
		for (int i = 0; i < 25; i++) {
  		color = new Color(Random.value, Random.value, Random.value, 1.0f);
	  	normalParticleSystem.startColor = color;
		  particleSystem.Emit(4);
		}*/
	}
}
