	using UnityEngine;
using System.Collections;

public class StageManager : MonoBehaviour {
  public static GameObject prevStage;
	public static GameObject nowStage;
  public static GameObject nextStage;
  public static int stageCount;
  public static float stageInterval = 5.0f;


  private static void addStageCount() {
		stageCount++;
	}

	public static void ChangeStage(GameObject next) {
		prevStage = nowStage;
		nowStage = next;
		//Debug.Log("prev:"+prevStage.transform.position + "\nnow:" + nowStage.transform.position);
		addStageCount();
	}

	public static void CreateNextStage() {
		Vector3 pos = (Vector3)GameObject.Find("Player").transform.position;
		Vector3 nextPos = new Vector3(pos.x, StageManager.nowStage.transform.position.y - stageInterval, pos.z);
		//Debug.Log("nextPos:" + nextPos);

		GameObject obj = (GameObject)Instantiate(StageManager.nextStage, nextPos, Quaternion.identity);
		obj.name = "Stage";
		obj.transform.SetParent(GameObject.Find("Stages").transform);
		obj.transform.Rotate(-2,0,0);
		RandomRoll(obj);
		//prevStageとnextStageの更新
		StageManager.ChangeStage(obj);
	}

	public static void CreateState1_1() {
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

	public static void SelectStage() {
	}

	private static void RandomRoll(GameObject obj) {
		int y = Random.Range(0, 360);
		obj.GetComponent<ManipulateFloor>().SetRollY(y);
		obj.transform.Rotate(0, y, 0);
	}
}
