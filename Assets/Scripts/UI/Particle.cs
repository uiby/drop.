using UnityEngine;
using System.Collections;

//パーティクル
public class Particle : MonoBehaviour {
	private ParticleSystem particleSystem;
	private Vector3 start, end;
	public Vector3 EnergyEndPos; //生命力UIのパーティクルの位置
	private bool isLife;
	void Start () {
		particleSystem = this.GetComponent<ParticleSystem>();
  	EnergyEndPos = new Vector3(-1.89f, 2.71f, -4.5f);
		EnergyEndPos = new Vector3(-3.2f, 0, -4.5f);
  	SetEnd();
	}
	
  //スタート地点を格納
  public void SetStart(Vector3 pos) {
  	Vector3 viewPortPos = Camera.main.WorldToViewportPoint(pos); //一旦メインカメラで見たビューポート座標に置き換える
  	start = GameObject.Find("EnergyCamera").GetComponent<Camera>().ViewportToWorldPoint(viewPortPos);
  	//Debug.Log(start);
  	StartCoroutine("EnergyLine");
  	//Emit (end);
  }	
  //最終地点を格納
  private void SetEnd() {
  	end = EnergyEndPos;
  	//Debug.Log("end:" + end);
  }	

  public void PlayEffect(Vector3 startPos, bool isLifeEffect) {
		Vector3 viewPortPos = Camera.main.WorldToViewportPoint(startPos); //一旦メインカメラで見たビューポート座標に置き換える
  	start = GameObject.Find("EnergyCamera").GetComponent<Camera>().ViewportToWorldPoint(viewPortPos);
  	isLife = isLifeEffect;
  	if (isLife) EnergyEndPos = new Vector3(-3.2f, 0, -4.5f);
  	else EnergyEndPos = new Vector3(-1.89f, 2.71f, -4.5f);

  	SetEnd();

  	StartCoroutine("EnergyLine");
	}

	public void Emit (Vector3 point, int num = 1) {
		for (int  i = 0; i < num; i++) {
		  particleSystem.Emit(
            point,
            Random.onUnitSphere * Random.Range(0.1f, 1), //particleSystem.startSpeed,
            Random.Range(0.1f, 1),//particleSystem.startSize
            particleSystem.startLifetime,
            particleSystem.startColor);
	  }
  }

  //エネルギーラインの演出
  IEnumerator EnergyLine() {
  	int frame = 20;
  	Vector3 distancePos = (end - start) / (float)frame;
  	Vector3 transPos = start;
  	float distance = Vector3.Distance(start, end);
  	while (frame > 1) {
  		frame--;
  		transPos += distancePos;
  		Emit (transPos, 20);
  		yield return null;
  		yield return null;
  	}

  	//最後
  	transPos += distancePos;
  	Emit (transPos, 50);
  	if (isLife)
    	GameObject.Find("Player").GetComponent<Player>().IncreaseLife();
;
  }
}
