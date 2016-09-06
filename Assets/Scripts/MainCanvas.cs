using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MainCanvas : MonoBehaviour {
	protected Text stageCount;
	private GameObject stageClearText;
	protected Text score;
	private StageWord stageWord;
	void Start () {
	  stageCount = GameObject.Find("MainCanvas/StageWord").GetComponent<Text>();
	  stageClearText = (GameObject)Resources.Load("UIs/StageResult");
	  score = this.transform.FindChild("ScoreName/Score").gameObject.GetComponent<Text>();
	  stageWord = this.transform.FindChild("StageWord").gameObject.GetComponent<StageWord>();
	  
	  HideUI();
	}
	
	void Update () {
	
	}

  //メインゲームの時に使うUIを非表示
	public void HideUI() {
		score.enabled = false;
		stageCount.enabled = false;
		this.transform.FindChild("ScoreName").gameObject.GetComponent<Text>().enabled = false;
	}

  //ステージ名の表示
	public void ChangeStageWord() {
		stageWord.ChangeStage();
	}
	//スコアの表示
	public void ShowScore() {
	  this.transform.FindChild("ScoreName").gameObject.GetComponent<Text>().enabled = true;
		score.enabled = true;
		stageCount.enabled = true;
	}

	public void ShowStageClearText() {
		Instantiate(stageClearText);
	}
}
