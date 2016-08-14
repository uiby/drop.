using UnityEngine;
using System.Collections;

public class FristStage : MonoBehaviour {
	private GameObject stageClearEffect;
	void Start () {
		stageClearEffect = (GameObject)Resources.Load("Stages/StageClearEffect");
	}

	void OnTriggerEnter(Collider col) {
		if (col.gameObject.tag == "Player") {
   		  //最初のステージクリア時
				Debug.Log("Clear:"+ StageManager.stageCount + "GAME START");
				GameObject.Find("GameManager").GetComponent<GameManager>().FristStageClear();   		  
   		  this.transform.parent.gameObject.GetComponent<ManipulateFloor>().enabled = false;

   		  Instantiate(stageClearEffect, this.transform.parent.gameObject.transform.position, Quaternion.identity);
   	    //transform.parent.gameObject.GetComponent<ManipulateFloor>().enabled = false;

   	    GameManager.state = GameManager.GameState.GAMEMAIN;
   	}
	}
}
