using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {
  private MainCanvas mainCanvas;
  
  void Start () {
  	mainCanvas = GameObject.Find("MainCanvas").GetComponent<MainCanvas>();
  	StageManager.nowStage = GameObject.Find("ana");
  	StageManager.stageCount = 0;
	}
	
	void Update () {
	
	}

}
