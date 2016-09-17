using UnityEngine;
using System.Collections;

//自機の処理
//自機数が存在.3回までなら場外落ちしても問題ないとする
public class Player : MonoBehaviour {
	public float maxSpeed = 30.0f;
	private Rigidbody myRigidbody;
	private int life; //残機
  private int maxLife;
	private Vector3 replayPosition; //残機が1つ減った時のリプレイ場所
	private bool isInterval; //ステージ間の間かどうか

	// Use this for initialization
	void Start () {
		isInterval = true;
		SetReplayPosition(new Vector3(0, 5, 0));
    maxLife = 3;
		life = 2;
		myRigidbody = this.GetComponent<Rigidbody>();
    GameObject.Find("Effect/VitalityEffect").GetComponent<VitalityParticle>().ChangeUI(life);
	}
	
	// Update is called once per frame
	void Update () {
		//transform.position = new Vector3(transform.position.x, Mathf.PingPong(Time.time,1), transform.position.z);
    if (GameManager.state == GameManager.GameState.GameOver) return;
		if (isInterval) return;
		if (!MainCamera.IsOutOfScreen(transform.position)) return;
    
    //~~~自機がフレームアウトした場合の処理~~~//
    if (GameManager.state == GameManager.GameState.GameClear) {//ゲームクリア―の場合
    	GameResult.PreparePosition();
    	return ;
    }

 		DecreaseLife(); //残機を一つ減らす
		Debug.Log(life);
		if (IsGameOver()) { //ライフが0の場合
			GameManager.state = GameManager.GameState.GameOver; //ゲームオーバーの状態に変更
			//***ここにゲームオーバーになった瞬間にやりたい処理を入れる***//
			GameResult.PreparePosition();
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
  		TimeLimit.StartCountDown();
  	}
  }

  //アイテムを取った時の処理
  //ライフが満タンでない場合はライフを1回復
  //満タンの場合、スコアに返還
  public void GetItem(Vector3 pos) {
    if (life + 1 == maxLife) {
      //TODO スコアに返還
      GameObject.Find("Energy").GetComponent<Energy>().PlayEffect(pos, false);
      return;
    }

    //ライフ回復
    GameObject.Find("Energy").GetComponent<Energy>().PlayEffect(pos, true);
  }

  //ライフがなくなってゲームオーバーかどうか判断
  private bool IsGameOver() {
    if(life < 0) return true;
    return false;
  }

  //ライフを1つ減らす
  private void DecreaseLife() {
  	life--;
    if (life < 0) {
      life = -1;
      //TODO 残機が0の時のエフェクト処理
      return;
    }
    GameObject.Find("Effect/VitalityEffect").GetComponent<VitalityParticle>().ChangeUI(life);
    GameObject.Find("MainCanvas/VitalityGauge").GetComponent<VitalityGauge>().ChangeAmount(life);
  }
  //ライフを1つ増やす
  public void IncreaseLife() {
    life++;
    if (life >= maxLife) life = maxLife - 1;
    GameObject.Find("Effect/VitalityEffect").GetComponent<VitalityParticle>().ChangeUI(life);
    GameObject.Find("MainCanvas/VitalityGauge").GetComponent<VitalityGauge>().ChangeAmount(life);

  }

  //リプレイポジションを格納
  public void SetReplayPosition(Vector3 pos) {
  	replayPosition = pos;
  }

  //ステージ間のインターバルであると設定
  public void SetIntervalState() {
  	isInterval = true;
  }

  public void ChangeColor(Gradient gradient) {
    var color = this.GetComponent<ParticleSystem>().colorOverLifetime;
    color.color = new ParticleSystem.MinMaxGradient(gradient);
  }
}
