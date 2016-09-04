using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TimeCountDown : MonoBehaviour {
	private float maxTime = 60.0f;
	private float time;
	private Image timeGauge;
	private Text timeCount;

	//状態定数
	enum eState {
		EARLY, //序盤
		MIDDLE,   //中盤
		LATE, //終盤
		END, //おしまい
	}
	//状態
	eState _state = eState.EARLY;

	void Start () {
		time = maxTime;
		timeGauge = this.GetComponent<Image>();
		timeCount = this.transform.FindChild("TimeCount").gameObject.GetComponent<Text>();

		timeGauge.enabled = false;
		timeCount.enabled = false;

		SetGaugeColor(new Color32(202, 13, 255, 255));
	  SetNumberColor(new Color32(0, 0, 0, 255));
	}
	
	void Update () {
		switch (GameManager.state) {
			case GameManager.GameState.Title : break;
			case GameManager.GameState.GameMain : 
			  if (_state == eState.END) return ; 
				float sub = Time.deltaTime;
				time -= sub;
				timeGauge.fillAmount = time / maxTime;
				timeCount.text = ""+(int)time;
				ChangeColor();
				break;
			case GameManager.GameState.Finish : break;
		}
	}

	private void ChangeColor() {
		switch (_state) {
			case eState.EARLY:
			  if (time <= 30) {
			    _state = eState.MIDDLE;
			    SetGaugeColor(new Color32(102, 13, 255, 255));
			  }
			  break;
			case eState.MIDDLE:
			  if (time <= 10) {
			    _state = eState.MIDDLE;
			    SetGaugeColor(new Color32(202, 13, 255, 255));
			  }
			  break;
			case eState.LATE:
			  if (time < 0) {
			  	_state = eState.END;
			  }
			  break;
			case eState.END:
			  break;
		}
	}

	private void SetGaugeColor(Color32 color) {
		timeGauge.color = color;
	}
	private void SetNumberColor(Color32 color) {
		timeCount.color = color;
	}

	public void ShowTime() {
		timeGauge.enabled = true;
		timeCount.enabled = true;
	}
}
