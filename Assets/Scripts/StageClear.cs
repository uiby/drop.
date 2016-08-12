using UnityEngine;
using System.Collections;

public class StageClear : MonoBehaviour {

	void Update () {
	
	}

	void OnTriggerEnter(Collider col) {
		if (col.gameObject.tag == "Player") {
   		  Debug.Log("Clear:"+ StageManager.stageCount);
   		  StageManager.nextStage = (GameObject)Resources.Load("Stages/ana");
			  StageManager.CreateNextStage();
   		  GameObject.Find("MainCamera").GetComponent<CameraPosition>().DownPos();
   		  GameObject.Find("MainCanvas").GetComponent<MainCanvas>().RenewStageCount();
   		  transform.parent.gameObject.GetComponent<ManipulateFloor>().enabled = false;
   	}
	}
}
