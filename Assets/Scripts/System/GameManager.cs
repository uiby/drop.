using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
//using System;

//メインシーンゲームマネージャ
//デバッグ作業としてGameOver or GameClear の時にEnterキーでリスタート
public class GameManager : MonoBehaviour {
  private MainCanvas mainCanvas;
  private BackGround backGround;
  private int explainOrder;//説明命令順番

  public enum GameState : int
  {
    GameFirst = 1, //ゲーム初期画面
    GameMain,  //メインゲーム画面
    GameClear, //ゲームクリア―
    GameOver //ゲームオーバー
  }
  public static GameState state;
  
  void Start () {
  	state = GameState.GameFirst;
  	mainCanvas = GameObject.Find("MainCanvas").GetComponent<MainCanvas>();
    backGround = GameObject.Find("MainCamera").GetComponent<BackGround>();
  	StageManager.nowStage = GameObject.Find("Stage00");
  	StageManager.stageCount = 0;
    StageManager.SetMaxStageCount(12);
    GameObject.Find("MainCanvas/StageText").GetComponent<StageWord>().RenewStageCount();

    //説明文の処理
    explainOrder = 1;
    Timer.StartTime();
	}
	
	void Update () {
    switch (state) {
      case GameState.GameFirst:
        //説明文が機械的な説明にしかなっていない。ユーザにワクワクさせるような説明文にする必要あり.要修正．
        if (explainOrder == 1 && Timer.GetCurrentTime() > 3.0f) { //3.0秒経ったら
          mainCanvas.SetMassage("<color=red>片手</color>で床を動かして、\n<color=red>魂</color>を移動させます.");
          explainOrder++;
          Timer.ReStart();
        } else if (explainOrder == 2 && Timer.GetCurrentTime() > 3.0f) { //3.0秒経ったら
          mainCanvas.SetMassage("場外に落ちると<color=red>ゲームオーバー</color>です.");
          explainOrder++;
          Timer.ReStart();
        } else if (explainOrder == 3 && Timer.GetCurrentTime() > 3.0f) { //3.0秒経ったら
          mainCanvas.SetMassage("途中でこのような<color=red>アイテム</color>があります.\n慣れて来たら取りに行くと<color=red>いい事</color>があるかも?");
          explainOrder++;
          Timer.ReStart();
          GameObject.Find("Stage00/VitalityItem").GetComponent<Collider>().enabled = true;
          GameObject.Find("Stage00/VitalityItem").GetComponent<Renderer>().enabled = true;
        } else if (explainOrder == 4 && Timer.GetCurrentTime() > 3.0f) { //3.0秒経ったら
          mainCanvas.SetMassage("最後まで穴に入れると<color=red>ゲームクリア―</color>です.\n穴に<color=red>素早く</color>入れましょう.");
          explainOrder++;
          Timer.ReStart();
        } else if (explainOrder == 5 && Timer.GetCurrentTime() > 3.0f) { //3.0秒経ったら
          mainCanvas.SetMassage("では楽しんでいってください!\n穴に入れるとゲームスタートです.");
          explainOrder++;
          Timer.FinishTime();
          GameObject.Find("Player").GetComponent<Rigidbody>().useGravity = true;
        }
      break;
      case GameState.GameClear:
      case GameState.GameOver:
        if (KeyUtil.IsDownEnter()) TitleManager.ChangeMainScene();
      break;
    }
	
	}

	//ゲームがスタートする前のステージをクリアーした時の処理
  //必要なUIを表示する
	public void FristStageClear() {
		StageManager.nextStage = (GameObject)Resources.Load("Stages/Stage00");
		StageManager.CreateFirstStage();
   	GameObject.Find("MainCamera").GetComponent<MainCamera>().DownPos();
   	mainCanvas.ShowUI();
    Timer.FinishTime(); //タイマーのリセット

    mainCanvas.DestroyMassage(); //説明文の消去
  }

	public void StageClear() {
    StageManager.IncreaseStageCount();
    Timer.ShowLogNowTime(); //ステージクリアにかかった時間をログに表示
    Timer.FinishTime(); //タイマーのリセット
    if (StageManager.stageCount == StageManager.GetMaxStageCount()) {
      GameClear();
      return ;
    }
		StageManager.nextStage = StageManager.SelectStage();
		StageManager.CreateNextStage();
   	GameObject.Find("MainCamera").GetComponent<MainCamera>().DownPos();
   	mainCanvas.ChangeStageWord();
   	backGround.ChangeColor(new Color(Random.value, Random.value, Random.value, 1.0f));
	}

  //ゲームクリアーのフラグが経った瞬間に一度だけ呼ばれる
  public void GameClear() {
    state = GameState.GameClear;
  }
}
