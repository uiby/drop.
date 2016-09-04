using UnityEngine;
using System.Collections;
//using System;

public class GameManager : MonoBehaviour {
  private MainCanvas mainCanvas;
  private BackGround backGround;
  
  public enum GameState : int
  {
    Title = 1,  //タイトル画面
    GameFirst = 2, //ゲーム初期画面
    GameMain = 3,  //メインゲーム画面
    Finish = 4  //ゲーム終了画面
  }
  public static GameState state;
  
  void Start () {
  	state = GameState.GameFirst;
  	mainCanvas = GameObject.Find("MainCanvas").GetComponent<MainCanvas>();
    backGround = GameObject.Find("MainCamera").GetComponent<BackGround>();
  	StageManager.nowStage = GameObject.Find("ana");
  	StageManager.stageCount = 0;
	}
	
	void Update () {
	
	}

	//ゲームがスタートする前のステージをクリアーした時の処理
	public void FristStageClear() {
		StageManager.nextStage = (GameObject)Resources.Load("Stages/ana");
		StageManager.CreateState1_1();
   	GameObject.Find("MainCamera").GetComponent<MainCamera>().DownPos();
   	mainCanvas.SlideStageWord();
   	GameObject.Find("MainCanvas/TimeGauge").GetComponent<TimeCountDown>().ShowTime();
   	mainCanvas.ShowScore();
  }

	public void StageClear() {
		StageManager.nextStage = (GameObject)Resources.Load("Stages/ana");
		StageManager.CreateNextStage();
   	GameObject.Find("MainCamera").GetComponent<MainCamera>().DownPos();
   	mainCanvas.RenewStageCount();
   	mainCanvas.ShowStageClearText();
    backGround.ChangeColor(new Color(Random.value, Random.value, Random.value, 1.0f));
	}
}
