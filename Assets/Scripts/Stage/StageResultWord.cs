using UnityEngine;
using UnityEngine.UI;
using System.Collections;

//ステージをクリアした際の結果の表示
//生成された時に文字を決める
//EXCELLENT > Late > Too Late の順で評価する
public class StageResultWord : MonoBehaviour {
	private int frame;

	// Use this for initialization
	void Start () {
		this.transform.SetParent(GameObject.Find("MainCanvas").transform);
		this.GetComponent<Text>().enabled = false;
		SetFristPos();
	  this.GetComponent<Text>().enabled = true;
	  this.transform.localScale = new Vector3(1.5f, 1.5f, 1.5f);
	  frame = 20;
	}

	void Update() {
		frame--;
		if (frame >= 13) {
  		Scale(0.1f);
	 	}
		if (frame == 0) {
			DestroyObj();
		}
	}

  //ステージクリア結果を文字に格納
	public void SetResultWord(StageResult.StageResultInfo result) {
		switch (result) {
			case StageResult.StageResultInfo.Excellent: 
			  int combo = ComboSystem.GetCombo();
  		  if (combo <= 8) SetText("<color=orange>Excellent!!</color>");
  		  else if (combo > 8) SetText("<color=red>Excellent!!</color>");
			  ComboSystem.AddCombo();
			break;
			case StageResult.StageResultInfo.Late: 
			  SetText("<color=teal>Late</color>");
			  ComboSystem.ResetCombo();
			break;
			case StageResult.StageResultInfo.TooLate: 
			  SetText("<color=teal>Too Late</color>");
			  ComboSystem.ResetCombo();
			break;
		}
	}
	
  //文字の最初の位置を決める
	private void SetFristPos() {
		this.transform.localPosition = new Vector2(0,0);
	}

	//移動(アクション)
	private void Move() {

	}

  //削除
	private void DestroyObj() {
		Destroy(this.gameObject);
	}

	private void Scale(float value) {
		this.transform.localScale += new Vector3(value, value, value);
	}

	private void SetText(string sentence) {
  	this.GetComponent<Text>().text = sentence;
  }
}
