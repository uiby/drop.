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
		//obj.name = "Stage";
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
		//obj.name = "Stage";
		obj.transform.SetParent(GameObject.Find("Stages").transform);
		obj.transform.Rotate(-2,0,0);

		prevStage = nowStage;
		nowStage = obj;
	}

  //ステージの選択
	public static GameObject SelectStage() {
		GameObject stage = null;
		switch (stageCount) {
			case 0: stage = (GameObject)Resources.Load("Stages/Stage00"); break;
			case 1: stage = (GameObject)Resources.Load("Stages/Stage01"); break;
			case 2: stage = (GameObject)Resources.Load("Stages/Stage02"); break;
			case 3: stage = (GameObject)Resources.Load("Stages/Stage03"); break;
			case 4: stage = (GameObject)Resources.Load("Stages/Stage04"); break;
			case 5: stage = (GameObject)Resources.Load("Stages/Stage05"); break;
			case 6: stage = (GameObject)Resources.Load("Stages/Stage06"); break;
			case 7: stage = (GameObject)Resources.Load("Stages/Stage07"); break;
			case 8: stage = (GameObject)Resources.Load("Stages/Stage08"); break;
			case 9: stage = (GameObject)Resources.Load("Stages/Stage09"); break;
			case 10: stage = (GameObject)Resources.Load("Stages/Stage10"); break;
			case 11: stage = (GameObject)Resources.Load("Stages/Stage11"); break;
			case 12: stage = (GameObject)Resources.Load("Stages/Stage12"); break;
		}

		return stage;
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
			case "Stage00(Clone)" : break;
			case "Stage01(Clone)" : break;
			case "Stage02(Clone)" : break;
			case "Stage03(Clone)" : break;
			case "Stage04(Clone)" : break;
			case "Stage05(Clone)" : break;
			case "Stage06(Clone)" : break;
			case "Stage07(Clone)" : break;
			case "Stage08(Clone)" : break;
			case "Stage09(Clone)" : break;
			case "Stage10(Clone)" : break;
			case "Stage11(Clone)" : break;
			case "Stage12(Clone)" : break;
		}

		return idealTime;
	}
}
