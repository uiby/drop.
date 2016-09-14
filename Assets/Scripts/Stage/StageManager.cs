	using UnityEngine;
using System.Collections;

public class StageManager : MonoBehaviour {
  public static GameObject prevStage;
	public static GameObject nowStage;
  public static GameObject nextStage;
  public static int stageCount;
  private static int maxStageCount;
  public static float stageInterval = 7.0f;

  public static int GetMaxStageCount() {
  	return maxStageCount;
  }
  public static void SetMaxStageCount(int value) {
  	maxStageCount = value;
  }


  public static void IncreaseStageCount() {
		stageCount++;
	}

	private static void ChangeStage(GameObject next) {
		prevStage = nowStage;
		nowStage = next;
		//Debug.Log("prev:"+prevStage.transform.position + "\nnow:" + nowStage.transform.position);
	}

	public static void CreateNextStage() {
		Vector3 pos = (Vector3)GameObject.Find("Player").transform.position;
		Vector3 nextPos = new Vector3(pos.x, StageManager.nowStage.transform.position.y - stageInterval, pos.z);
		//Debug.Log("nextPos:" + nextPos);

		GameObject obj = (GameObject)Instantiate(StageManager.nextStage, nextPos, Quaternion.identity);
		obj.name = "Stage";
		obj.transform.SetParent(GameObject.Find("Stages").transform);
		obj.transform.Rotate(-2,0,0);
		//RandomRoll(obj);  穴の位置をランダムにする。あとで実装
		//prevStageとnextStageの更新
		ChangeStage(obj);
	}

	public static void CreateFirstStage() {
		Vector3 pos = (Vector3)GameObject.Find("Player").transform.position;
		Vector3 nextPos = new Vector3(pos.x, StageManager.nowStage.transform.position.y - stageInterval, pos.z);
		Debug.Log("nextPos:" + nextPos);

		GameObject obj = (GameObject)Instantiate(StageManager.nextStage, nextPos, Quaternion.identity);
		obj.name = "Stage";
		obj.transform.SetParent(GameObject.Find("Stages").transform);
		obj.transform.Rotate(-2,0,0);

		prevStage = nowStage;
		nowStage = obj;
	}

	public static GameObject SelectStage() {
		return (GameObject)Resources.Load("Stages/stage_ver0.2");
	}

	private static void RandomRoll(GameObject obj) {
		int y = Random.Range(0, 360);
		obj.GetComponent<ManipulateFloor>().SetRollY(y);
		obj.transform.Rotate(0, y, 0);
	}

  //ステージごとの理想のタイムを返す
  //ステージの名前によって理想のタイムが違う
	public static float GetIdealTime(string name) {
		float idealTime = 2.5f;
		switch (name) {
			case "stage_ver0.2(Clone)" : break;
		}

		return idealTime;
	}
}
