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
				Debug.Log("Clear:"+ StageManager.stageCount);
				GameObject.Find("GameManager").GetComponent<GameManager>().StageClear();   		  
   		  this.transform.parent.gameObject.GetComponent<ManipulateFloor>().enabled = false;

   		  Instantiate(stageClearEffect, this.transform.parent.gameObject.transform.position, Quaternion.identity);
   	    //transform.parent.gameObject.GetComponent<ManipulateFloor>().enabled = false;
   	}
	}
}
