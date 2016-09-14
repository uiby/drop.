using UnityEngine;
using UnityEngine.UI;
using System.Collections;

//タイトル画面の文章の処理
//何もない時は拡大縮小
//文章が変わる時は1回点滅
//現在1秒間隔でしか切り替えできないため、要修正必要あり
public class Sentence : MonoBehaviour {
	private Text text;
	private string sentence; //次の文
	private float timer;
	private float maxTimer; //最大時間
	private bool canBig;  //大きくなるかどうかの判断
	private float changeInterval; //文が切り替わる時の時間

	public enum eState {
    None,   //何もしないとき
    Vanish, //消える
    Appear //現れる
  }
  public eState state;

	void Start () {
		changeInterval = 1.0f;
		state = eState.None;
    text = this.GetComponent<Text>();
    timer = 0;
    canBig = true;
	}
	
	void Update () {
		switch (state) {
			case eState.None:
			  if (canBig)  timer += Time.deltaTime;
			  else timer -= Time.deltaTime;
			  if (timer > 1.0f)  ChangeScale(timer);
			  if ((timer >= 1.1f && canBig) || (timer <= 0 && !canBig)) canBig = !canBig;
			break;
			case eState.Vanish: 
				SetOpacity(timer - Time.deltaTime);
	    	timer -= Time.deltaTime;
	    	if (timer <= 0) {
	    		text.text = sentence;
	    		state = eState.Appear;
	    	}
			break;
			case eState.Appear: 
			  timer += Time.deltaTime;
	    	SetOpacity(timer);
	    	if (timer >= 1.0f) {
	    		state = eState.None;
	    	}
			break;
		}
	}

  //文字列をテキストに格納
  //テキストの切り替え時間はデフォルトは1秒
	public void SetString(string word, float interval = 1.0f) {
		sentence = word;
		maxTimer = 1.0f;
		timer = 1.0f;
		changeInterval = interval;
		state = eState.Vanish;
	}

  //不透明度を決定
	private void SetOpacity(float value) {
		Color color = text.color;
		color.a = value;
		text.color = color;
	}

	//文字の大きさを変える
	private void ChangeScale(float value) {
		this.transform.localScale = new Vector3(value, value, value);
	}
}
