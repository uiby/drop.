using UnityEngine;
using System.Collections;
//タイトル画面のステージ
public class TitleStage : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	void OnTriggerEnter(Collider col) {
		if (col.gameObject.tag == "Player") {
   		  //最初のステージクリア時
				Debug.Log("Clear:"+ StageManager.stageCount + "GAME START");
				GameObject.Find("GameManager").GetComponent<GameManager>().FristStageClear();   		  
   		  this.transform.parent.gameObject.GetComponent<ManipulateFloor>().enabled = false;

   	    GameManager.state = GameManager.GameState.GameFirst;
   	}
	}
}
