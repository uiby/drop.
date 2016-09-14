using UnityEngine;
using System.Collections;

//ゲームリザルト(ゲームオーバー,ゲームクリア―両方含む)の処理
//カメラが既にスタンバっていて, 上から落ちてくる魂を角度だけ見るようにする
//指定位置に落ちて来たら魂が止まる
//数秒後エフェクト共に画面を隠し、生まれ変わる.
//生まれ変わる生き物はスコアによって異なる
public class GameResult : MonoBehaviour {
	public ParticleSystem[] particleSystem; //演出に使うパーティクル
	private static bool canPlay;//リザルトの演出をしていいかどうか
	private float timer;
	private enum eState : int {
  	None,
    First = 1, //ゲーム初期画面
    Second,  //メインゲーム画面
    Third //ゲームクリア―
  }
  private static eState state;

	void Start() {
		state = eState.None;
		canPlay = false;
		timer = 0;
	}

	void Update() {
		if (!canPlay) return;

		//時間で演出を制御
		switch (state) {
			case eState.First: 
			  timer += Time.deltaTime;
			  if (timer >= 1.0f) { //1.0秒経ったら
			  	particleSystem[0].Play();
			  	particleSystem[1].Play();
			  	timer = 0;
			  	state = eState.Second;
			  	HideSoul();
			  }
			break;
			case eState.Second: 
			  timer += Time.deltaTime;
			  if (timer >= 0.6f) {
			  	BornCreature();
			    particleSystem[2].Play();
			    state = eState.Third;
			  }
			break;
			case eState.Third: 
			break;
		}
	}

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
		canPlay = true;
		state = eState.First;
	}

  //魂を隠す
  private void HideSoul() {
  	GameObject.Find("Player").GetComponent<Renderer>().enabled = false;
		GameObject.Find("Player").GetComponent<ParticleSystem>().Stop();
  }
  //生き物の生成
	private void BornCreature() {
		Instantiate(GetCharactor(), GameObject.Find("Player").transform.position, Quaternion.identity);
		
	}

	//スコアによって結果が違う
	public static GameObject GetCharactor() {
		/*float parcent = (float)ScoreManager.GetScore() / MaxScore() * 100;
		Debug.Log(ScoreManager.GetScore() + "%" + MaxScore() +"=" +parcent);
		if (parcent > 40 && parcent <= 60)  return Resources.LoadAll<Sprite>("Sprite/turtle")[0];
		else if (parcent > 60 && parcent <= 80) return Resources.LoadAll<Sprite>("Sprite/pengin")[0];
		else if (parcent > 80)  return Resources.LoadAll<Sprite>("Sprite/tyira")[0];*/
		return (GameObject)Resources.Load("ResultCharactors/hiyoko");
	}

	public static int MaxScore() {
		int n = StageManager.GetMaxStageCount();
		if (n < 8) {
			return 10 * n * n + 90 * n;
		} else 
			return 300 * n - 1040;
	}

}
