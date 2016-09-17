using UnityEngine;
using System.Collections;

public class StageClear : MonoBehaviour {
	private GameObject stageClearEffect;
	void Start () {
		stageClearEffect = (GameObject)Resources.Load("Stages/StageClearEffect");
	}

	void OnTriggerEnter(Collider col) {
		if (col.gameObject.tag == "Player") {
			  this.GetComponent<Collider>().enabled = false;

			  //クリア時の評価を決める
        StageResult.StageResultInfo result = StageResult.GetStageResult();
        
        //ステージクリアの評価
        GameObject.Find("MainCanvas/StageResultWord").GetComponent<StageResultWord>().ShowResultWord(result);

   		  ScoreManager.AddScore(result); //スコア追加


   		  //次のステージを生成, 自機の速度を0にする,このステージを捜査対象から外す
				//Debug.Log("Clear:"+ StageManager.stageCount);
				GameObject.Find("GameManager").GetComponent<GameManager>().StageClear();   		  
   		  this.GetComponent<ManipulateFloor>().enabled = false;
   		  col.gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;

        //ラインの生成 評価がExcellentでコンボが2つ以上だと処理を行う
        if (GameManager.state == GameManager.GameState.GameMain)
          ConnectSystem.Draw(result, StageManager.prevStage.transform.position, StageManager.nowStage.transform.position);

   		  Instantiate(stageClearEffect, this.transform.position, Quaternion.identity);//ステージクリアのエフェクトの生成

   		  //自機のリプレイポジションを設定,インタバール状態に移行
   	    Player player = col.gameObject.GetComponent<Player>();
   	    player.SetReplayPosition(col.gameObject.transform.position);
          if (GameManager.state != GameManager.GameState.GameClear) //ゲームクリア―でない場合
   	      player.SetIntervalState();

   	    Destroy(this.gameObject, 0.5f);
   	}
	}
}
