using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MainCanvas : MonoBehaviour {
	protected Text stageCount;

	void Start () {
	  stageCount = GameObject.Find("MainCanvas/Stage").GetComponent<Text>();	
	}
	
	void Update () {
	
	}

	public void RenewStageCount() {
		int stage = StageManager.stageCount % 5 + 1;
		int setCount = StageManager.stageCount / 5 + 1;
		stageCount.text = "Stage"+ setCount +"-"+stage;
	}
}
