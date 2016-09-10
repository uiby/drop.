using UnityEngine;
using System.Collections;

//自機の処理
//自機数が存在.3回までなら場外落ちしても問題ないとする
public class Player : MonoBehaviour {
	public float maxSpeed = 30.0f;
	private Rigidbody myRigidbody;
	private int life; //残機
	private Vector3 replayPosition; //残機が1つ減った時のリプレイ場所
	private bool isInterval; //ステージ間の間かどうか

	// Use this for initialization
	void Start () {
		isInterval = false;
		SetReplayPosition(new Vector3(0, 3, 0));
		life = 3;
		myRigidbody = this.GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
		if (GameManager.state == GameManager.GameState.GameClear || GameManager.state == GameManager.GameState.GameOver) return;
		if (isInterval) return;
		if (!MainCamera.IsOutOfScreen(transform.position)) return;

		DecreaseLife(); //残機を一つ減らす
		Debug.Log(life);
		if (IsGameOver()) { //ライフが0の場合
			GameManager.state = GameManager.GameState.GameOver; //ゲームオーバーの状態に変更
			//***ここにゲームオーバーになった瞬間にやりたい処理を入れる***//
			Debug.Log("No Life No Play.");
			//********************************************//
			return ;
		}

    //自機の位置をリプレイポジションに移動
		transform.position = replayPosition;
		this.GetComponent<Rigidbody>().velocity = Vector3.zero;
		isInterval = true;
	}

	void FixedUpdate () {
    if (myRigidbody.velocity.magnitude > maxSpeed) {
      myRigidbody.velocity = Vector3.ClampMagnitude (myRigidbody.velocity, maxSpeed);
    }
  }

  void OnCollisionEnter(Collision coll) {
  	if (coll.gameObject.tag == "Stage") {
  		isInterval = false;
  		Timer.StartTime();
  	}
  }

  //ライフがなくなってゲームオーバーかどうか判断
  private bool IsGameOver() {
    if(life <= 0) return true;
    return false;
  }

  //ライフを1つ減らす
  private void DecreaseLife() {
  	life--;
  }

  //リプレイポジションを格納
  public void SetReplayPosition(Vector3 pos) {
  	replayPosition = pos;
  }

  //ステージ間のインターバルであると設定
  public void SetIntervalState() {
  	isInterval = true;
  }
}
