using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MainCanvas : MonoBehaviour {
	protected Text stageCount;
	private GameObject stageClearText;
	protected Text score;
	private SlideStageWord slideStageWord;
	void Start () {
	  stageCount = GameObject.Find("MainCanvas/Stage").GetComponent<Text>();
	  stageClearText = (GameObject)Resources.Load("UIs/StageResult");
	  score = this.transform.FindChild("ScoreName/Score").gameObject.GetComponent<Text>();
	  slideStageWord = this.transform.FindChild("Stage").gameObject.GetComponent<SlideStageWord>();
	  
	  HideUI();
	}
	
	void Update () {
	
	}

  //メインゲームの時に使うUIを非表示
	public void HideUI() {
		score.enabled = false;
		this.transform.FindChild("ScoreName").gameObject.GetComponent<Text>().enabled = false;
	}

  //ステージ名の表示
	public void SlideStageWord() {
		slideStageWord.Begin();
	}
	//スコアの表示
	public void ShowScore() {
	  this.transform.FindChild("ScoreName").gameObject.GetComponent<Text>().enabled = true;
		score.enabled = true;
	}

	public void RenewStageCount() {
		int stage = StageManager.stageCount % 5 + 1;
		int setCount = StageManager.stageCount / 5 + 1;
		stageCount.text = "Stage"+ setCount +"-"+stage;
		SlideStageWord();
	}

	public void ShowStageClearText() {
		Instantiate(stageClearText);
	}
}
