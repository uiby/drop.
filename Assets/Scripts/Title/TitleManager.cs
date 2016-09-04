using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

//タイトル画面の処理
public class TitleManager : MonoBehaviour {
	private GameObject boll;
	private Sentence sentence;
	public GameObject createObj;
	private ParticleSystem particleSystem;

	public enum titleState {
    None,   //何もしないとき
    Hand01, //手の動作01
    Hand02, //手の動作02
    Hand03  //手の動作03
  }
  public titleState state;

	void Start () {
	  state = titleState.None;
	  sentence = GameObject.Find("TitleCanvas/Sentence").GetComponent<Sentence>();	
	  particleSystem = GameObject.Find("CreateBollEffect").GetComponent<ParticleSystem>();
	}
	
	void Update () {
    if (KeyControllor.IsEnter()) ChangeMainScene();
		switch (state) {
      case titleState.None : 
        if (IsStandby()) {
        	state = titleState.Hand01;
        	sentence.SetString("手を握ってください.");
        }
      break;
      case titleState.Hand01 : //手を握る
        if (!IsStandby()) {
        	state = titleState.None;
        	sentence.SetString("センサーの上に手を置いてください.");
        }
        if (IsChangeHand02()) {
        	state = titleState.Hand02;
        	sentence.SetString("手を目一杯開いてください.");
        	CreateBoll();
        	particleSystem.Play();
        }
      break;
      case titleState.Hand02 : //手を開く
        ChangeScale();
        if (!IsStandby()) {
        	state = titleState.None;
        	Destroy(boll.gameObject);
        	sentence.SetString("センサーの上に手を置いてください.");
        }
        else if (IsChangeHand03()) {
        	state = titleState.Hand03;
        	sentence.SetString("レッツ ・ プレイ!");
        	SeparateBoll();
        }
      break;
      case titleState.Hand03 : 
      break;
		}
	}

	public void ShowCanvas() {
		this.GetComponent<Canvas>().enabled = true;
	}
	public void HideCanvas() {
		this.GetComponent<Canvas>().enabled = false;
	}

  //スタンバイできてるか(手が認識されてるかどうか)の判断
	private bool IsStandby() {
		if (!LeapUtil.IsValid()) return false;
		
		return true;
	}

  //次のジェスチャーに移行できるかどうかの判断
	private bool IsChangeHand02() {
		if (LeapUtil.IsHandGrab()) return true;

		return false;
	}

	//次のジェスチャーに移行できるかどうかの判断
	private bool IsChangeHand03() {
		if (LeapUtil.GetGrabStrength() <= 0) return true;

		return false;
	}

  //ボールの生成
	private void CreateBoll() {
		GameObject temp = (GameObject)Resources.Load("Others/Boll");
		boll = (GameObject)Instantiate(temp, new Vector3(0, 0, 0), Quaternion.identity);
		boll.transform.localScale = new Vector3(0, 0, 0);
	}
  
  //ボールの大きさを変える
	private void ChangeScale() {
		float value = (1 - LeapUtil.GetGrabStrength()) * 3 + 0.1f;
		boll.transform.localScale = new Vector3(value, value, value);
	}

  //ボールを離す
	private void SeparateBoll() {
		boll.GetComponent<Rigidbody>().useGravity = true;
	}

  //メインゲームシーンに移行
	private void ChangeMainScene() {
		ScreenFadeManager fadeManager = ScreenFadeManager.Instance;
		fadeManager.FadeOut(1.0f, Color.white, ()=> {// フェードイン
		  SceneManager.LoadScene ("Main");
		});
	}
}
