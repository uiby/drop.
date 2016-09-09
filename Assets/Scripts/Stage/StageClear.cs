using UnityEngine;
using System.Collections;

public class StageClear : MonoBehaviour {
	private GameObject stageClearEffect;
	void Start () {
		stageClearEffect = (GameObject)Resources.Load("Stages/StageClearEffect");
	}

	void OnTriggerEnter(Collider col) {
		if (col.gameObject.tag == "Player") {
   		  //ステージクリア時
				//Debug.Log("Clear:"+ StageManager.stageCount);
				GameObject.Find("GameManager").GetComponent<GameManager>().StageClear();   		  
   		  this.GetComponent<ManipulateFloor>().enabled = false;
   		  col.gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;

   		  Instantiate(stageClearEffect, this.transform.position, Quaternion.identity);//ステージクリアのエフェクトの生成

        //クリア時の評価を決める
        StageResult.StageResultInfo result = StageResult.GetStageResult(this.name);

   		  GameObject word = (GameObject)Instantiate(MainCanvas.stageClearText); //ステージクリアの評価テキストの生成
   		  word.GetComponent<StageResultWord>().SetResultWord(result);

   		  ScoreManager.AddScore(result); //スコア追加
   	}
	}
}
