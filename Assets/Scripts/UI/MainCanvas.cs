﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MainCanvas : MonoBehaviour {
	public static GameObject stageClearText;
	protected Text score;
	private StageWord stageWord;
	public Text[] stageWords; //ステージに関するテキスト集
	public Text[] comboWords; //コンボに関するテキスト集
	public GameObject massage; //ゲーム始まる前の軽い説明文
	void Start () {
	  stageClearText = (GameObject)Resources.Load("UIs/StageResultWord");
	  score = this.transform.FindChild("ScoreName/Score").gameObject.GetComponent<Text>();
	  stageWord = this.transform.FindChild("StageText").gameObject.GetComponent<StageWord>();
	  
	  HideUI();
	}
	
	void Update () {
	
	}

  //メインゲームの時に使うUIを非表示
	public void HideUI() {
		score.enabled = false;
		this.transform.FindChild("ScoreName").gameObject.GetComponent<Text>().enabled = false;
		for (int i = 0; i < stageWords.Length; i++)	stageWords[i].enabled = false;
		for (int i = 0; i < comboWords.Length; i++) comboWords[i].enabled = false;
	}
	public void ShowUI() {
		score.enabled = true;
		this.transform.FindChild("ScoreName").gameObject.GetComponent<Text>().enabled = true;
		for (int i = 0; i < stageWords.Length; i++)	stageWords[i].enabled = true;
		for (int i = 0; i < comboWords.Length; i++) comboWords[i].enabled = true;
	}

  //ステージ名の表示
	public void ChangeStageWord() {
		stageWord.ChangeStage();
	}

  //説明文をセットする(SetStringで表示する)
	public void SetMassage(string sentence) {
		massage.GetComponent<Sentence>().SetString(sentence);
	}
	//説明文を削除
	public void DestroyMassage() {
		Destroy(massage.gameObject);
	}
}