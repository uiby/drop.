using UnityEngine;
using System.Collections;

//ゲームリザルト(ゲームオーバー,ゲームクリア―両方含む)の処理
//カメラが既にスタンバっていて, 上から落ちてくる魂を角度だけ見るようにする
//指定位置に落ちて来たら魂が止まる
//数秒後エフェクト共に画面を隠し、生まれ変わる.
//生まれ変わる生き物はスコアによって異なる
public class GameResult : MonoBehaviour {
	private static int resultScore; //プレイ結果の最終スコア
  //カメラと魂を規定の位置にセット
	public static void PreparePosition() {
		GameObject.Find("Goal").GetComponent<Collider>().enabled = true;
		GameObject.Find("MainCamera").transform.position = new Vector3(0, 0, -2);
		GameObject.Find("Player").GetComponent<Rigidbody>().velocity = Vector3.zero;
		GameObject.Find("Player").GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
		GameObject.Find("Player").transform.rotation = Quaternion.Euler(0, 0, 0);
		GameObject.Find("Player").transform.position = new Vector3(0, 10, 0);
		GameObject.Find("MainCanvas").GetComponent<MainCanvas>().HideUI(); //UIを隠す
		MainCamera.SetIsLookPlayer(true);
	}

  //最後を演出する
	public static void PlayFinish() {
		switch (GameManager.state) {
			case GameManager.GameState.GameClear: 
			  Debug.Log("GameClear");
			break;
			case GameManager.GameState.GameOver:
			  Debug.Log("No Life No Play.");
			break;
		}
		ResultCanvas.canPlay = true;
		ResultCanvas.state = ResultCanvas.eState.First;
		GetFinalResult();
	}

  //最終結果をゲット
  //TODO GetCharactor()とGetCharactorName()で同じ計算をしなくてもいいようにする
	private static void GetFinalResult() {
		/*float parcent = (float)ScoreManager.GetScore() / MaxScore() * 100;
		Debug.Log(ScoreManager.GetScore() + "%" + MaxScore() +"=" +parcent);
		if (parcent > 40 && parcent <= 60)  return Resources.LoadAll<Sprite>("Sprite/turtle")[0];
		else if (parcent > 60 && parcent <= 80) return Resources.LoadAll<Sprite>("Sprite/pengin")[0];
		else if (parcent > 80)  return Resources.LoadAll<Sprite>("Sprite/tyira")[0];*/
		resultScore = 100;
	}

	//スコアによって結果が違う 必ずGetFinalResult()の後に行う事
	public static GameObject GetCharactor() {
		/*if (parcent > 40 && parcent <= 60)  return Resources.LoadAll<Sprite>("Sprite/turtle")[0];
		else if (parcent > 60 && parcent <= 80) return Resources.LoadAll<Sprite>("Sprite/pengin")[0];
		else if (parcent > 80)  return Resources.LoadAll<Sprite>("Sprite/tyira")[0];*/
		return (GameObject)Resources.Load("ResultCharactors/hiyoko");
	}

	//キャラクタの名前を返す 必ずGetFinalResult()の後に行う事
	public static string GetCharactorName() {
		/*if (parcent > 40 && parcent <= 60)  return Resources.LoadAll<Sprite>("Sprite/turtle")[0];
		else if (parcent > 60 && parcent <= 80) return Resources.LoadAll<Sprite>("Sprite/pengin")[0];
		else if (parcent > 80)  return Resources.LoadAll<Sprite>("Sprite/tyira")[0];*/
		return "ひよこ";
	}
	//それぞれの評価のアニメーションを行うためのトリガーの名前を返す 必ずGetFinalResult()の後に行う事
	public static string GetAnimationTriggerName() {
		/*if (parcent > 40 && parcent <= 60)  return Resources.LoadAll<Sprite>("Sprite/turtle")[0];
		else if (parcent > 60 && parcent <= 80) return Resources.LoadAll<Sprite>("Sprite/pengin")[0];
		else if (parcent > 80)  return Resources.LoadAll<Sprite>("Sprite/tyira")[0];*/
		return "Bad";
		return "Good";
		return "Excellent";
	}

	public static int MaxScore() {
		int n = StageManager.GetMaxStageCount();
		if (n < 8) {
			return 10 * n * n + 90 * n;
		} else 
			return 300 * n - 1040;
	}
}
