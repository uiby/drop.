using UnityEngine;
using System.Collections;
using System;

public class GameManager : MonoBehaviour {
  private MainCanvas mainCanvas;
  
  public enum GameState : int
  {
    TITLE = 1,
    GAMEMAIN = 2,
    FINISH = 3
  }
  public static GameState state;
  
  void Start () {
  	state = GameState.TITLE;
  	mainCanvas = GameObject.Find("MainCanvas").GetComponent<MainCanvas>();
  	StageManager.nowStage = GameObject.Find("ana");
  	StageManager.stageCount = 0;
	}
	
	void Update () {
	
	}

	//ゲームがスタートする前のステージをクリアーした時の処理
	public void FristStageClear() {
		StageManager.nextStage = (GameObject)Resources.Load("Stages/ana");
		StageManager.CreateState1_1();
   	GameObject.Find("MainCamera").GetComponent<CameraPosition>().DownPos();
   	mainCanvas.SlideStageWord();
   	GameObject.Find("MainCanvas/TimeGauge").GetComponent<TimeCountDown>().ShowTime();
   	mainCanvas.ShowScore();
  }

	public void StageClear() {
		StageManager.nextStage = (GameObject)Resources.Load("Stages/ana");
		StageManager.CreateNextStage();
   	GameObject.Find("MainCamera").GetComponent<CameraPosition>().DownPos();
   	mainCanvas.RenewStageCount();
   	mainCanvas.ShowStageClearText();
	}
}
