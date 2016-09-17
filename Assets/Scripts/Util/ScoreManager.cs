using UnityEngine;
using UnityEngine.UI;
using System.Collections;

//スコアの処理
public class ScoreManager : MonoBehaviour {
	private static int score;
	private static int idealScore; //本来のスコア
	private static GameObject scoreText;
	//private static GameObject addScore;

	enum eState {
		None, //何もない
		CountUp,  //スコアカウント
	}
	private static eState state;
	
	// Use this for initialization
	void Start () {
		state = eState.None;
		scoreText = GameObject.Find("MainCanvas/ScoreName/Score");
		//addScore = (GameObject)Resources.Load("UI/AddScore");
		Init();
	}

	void Update() {
		if (state == eState.None) return ;
		
		score += 2;
		if (score > idealScore) score = idealScore;
		ShowScore();
		if (score == idealScore) {
			state = eState.None;
  	}
	}
	
	public static void Init() {
		score = 0;
		idealScore = 0;
		scoreText.GetComponent<Text>().text = "" + score;
	}

	public static void AddScore(StageResult.StageResultInfo result) {
		int value = 0;
		switch (result) {
			case StageResult.StageResultInfo.Excellent:  
			  value = (int)(100 + ComboSystem.GetRate());
			break;
			case StageResult.StageResultInfo.Late:  
			  value = 50; break;
			case StageResult.StageResultInfo.TooLate:  
			  value = 50; break;
		}
		idealScore += value;

		state = eState.CountUp;

		//PlusScoreにアニメーションをするように設定
		PlusScore.Plus(value);
		/*GameObject temp = (GameObject)Instantiate(addScore, new Vector2(0, 0), Quaternion.identity);
		temp.transform.SetParent(GameObject.Find("MainCanvas").transform);
		temp.GetComponent<AddScore>().SetValue(value);*/
	}

	public static void AddScore(int value) {
		idealScore += value;

		state = eState.CountUp;

		//PlusScoreにアニメーションをするように設定(ボーナスバージョン)
		PlusScore.BonusPlus(value);
	}

	private static void ShowScore() {
		scoreText.GetComponent<Text>().text = "" + score;
	}

	public static int GetScore() {
		return score;
	}
}
