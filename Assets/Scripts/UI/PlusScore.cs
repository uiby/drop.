using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlusScore : MonoBehaviour {
	private static Animator animator;
	private static Text text;
	// Use this for initialization
	void Start () {
		animator = this.GetComponent<Animator>();
		text = this.GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

  //加点アニメーション
	public static void Plus(int value) {
		animator.SetTrigger("Plus");
		text.text = "+"+ value;
	}

  //加点アニメーション : ボーナスバージョン
	public static void BonusPlus(int value) {
		animator.SetTrigger("Plus");
		text.text = "<color=orange>Bonus!</color> "+ value;
	}
}
