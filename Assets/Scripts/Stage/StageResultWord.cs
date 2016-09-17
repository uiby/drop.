using UnityEngine;
using UnityEngine.UI;
using System.Collections;

//ステージをクリアした際の結果の表示
//生成された時に文字を決める
//EXCELLENT > Late > Too Late の順で評価する
public class StageResultWord : MonoBehaviour {
	private Animator animator;
	private TimeLimit timeLimit; 
	private int frame;

	// Use this for initialization
	void Start () {
		animator = this.GetComponent<Animator>();
		timeLimit = GameObject.Find("MainCanvas/TimeLimit").GetComponent<TimeLimit>();
		this.GetComponent<Text>().enabled = false;
	}

	void Update() {
	}

  //結果の文章を表示
	public void ShowResultWord(StageResult.StageResultInfo result) {
		SetResultWord(result);
		PlayAnimation();
	}

  //ステージクリア結果を文字に格納
	private void SetResultWord(StageResult.StageResultInfo result) {
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

	private void PlayAnimation() {
		animator.SetTrigger("Play");
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

	private void SetText(string sentence) {
  	this.GetComponent<Text>().text = sentence;
  }

  //次のステージのタイムリミットを表示
  public void ShowNextIdealTime() {
  	timeLimit.Change();
  }
}
