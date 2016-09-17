using UnityEngine;
using System.Collections;

public class FristStage : MonoBehaviour {
	private GameObject stageClearEffect;
	void Start () {
		stageClearEffect = (GameObject)Resources.Load("Stages/StageClearEffect");
	}

	void OnTriggerEnter(Collider col) {
		if (col.gameObject.tag == "Player") {
			  this.GetComponent<Collider>().enabled = false;
   		  //最初のステージクリア時
				Debug.Log("Clear:"+ StageManager.stageCount + "GAME START");
				GameObject.Find("GameManager").GetComponent<GameManager>().FristStageClear();   		  
   		  this.GetComponent<ManipulateFloor>().enabled = false;

   		  Instantiate(stageClearEffect, this.transform.position, Quaternion.identity);
   	    //transform.parent.gameObject.GetComponent<ManipulateFloor>().enabled = false;

   	    GameManager.state = GameManager.GameState.GameMain;
        
        //自機のリプレイポジションを設定,インタバール状態に移行
   	    Player player = col.gameObject.GetComponent<Player>();
   	    player.SetReplayPosition(col.gameObject.transform.position);
   	    player.SetIntervalState();

          //最初のステージのみ次のステージのタイムリミットをここで表示する
          TimeLimit.Renewal();

   	    Destroy(this.gameObject, 0.5f);
   	}
	}
}
