using UnityEngine;
using System.Collections;

//goalの演出処理
public class Goal : MonoBehaviour {

  //最後の演出を行うよう伝える
	private void PlayGoal() {
  	GameResult.PlayFinish();
	}

	void OnCollisionEnter(Collision coll) {
		if (coll.gameObject.tag == "Player") {
  		PlayGoal();
  	}
  }
}
