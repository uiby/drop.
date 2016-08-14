using UnityEngine;
using UnityEngine.UI;
using System.Collections;

//ステージをクリアした際の結果の表示
//EXCELLENT > GREAT > NICE の順で評価する
public class StageResult : MonoBehaviour {

	void Awake() {
		this.transform.SetParent(GameObject.Find("MainCanvas").transform);
		this.GetComponent<Text>().enabled = false;
		SetResultWord();
	  SetFristPos();
	  this.GetComponent<Text>().enabled = true;
	}
	// Use this for initialization
	void Start () {
	}

  //ステージクリア結果を文字に格納
	private void SetResultWord() {
		switch (1) {
			case 0: this.GetComponent<Text>().text = "EXCELLENT!!"; break; 
			case 1: this.GetComponent<Text>().text = "GREAT!"; break;
			case 2: this.GetComponent<Text>().text = "NICE!"; break;
		}
	}
	
  //文字の最初の位置を決める
	private void SetFristPos() {
		this.transform.localPosition = new Vector2(100,100);
	}

	//移動(アクション)
	private void Move() {

	}

  //削除
	private void DestroyObj() {
		Destroy(this.gameObject);
	}
}
