using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TimeCountDown : MonoBehaviour {
	private float maxTime = 60.0f;
	private float time;
	private Image timeGauge;
	private Text timeCount;

	void Start () {
		time = maxTime;
		timeGauge = this.GetComponent<Image>();
		timeCount = this.transform.FindChild("TimeCount").gameObject.GetComponent<Text>();

		timeGauge.enabled = false;
		timeCount.enabled = false;
	}
	
	void Update () {
		switch (GameManager.state) {
			case GameManager.GameState.TITLE : break;
			case GameManager.GameState.GAMEMAIN : 
				float sub = Time.deltaTime;
				time -= sub;
				timeGauge.fillAmount = time / maxTime;
				timeCount.text = ""+(int)time;
				if (time < 55) {
			  	SetGaugeColor();
			 		SetNumberColor();
				}
				break;
			case GameManager.GameState.FINISH : break;
		}
	}

	private void SetGaugeColor() {
		Color32 color = new Color32(67,24,160, 255);
		timeGauge.color = color;
	}
	private void SetNumberColor() {
		Color32 color = new Color32(67,24,160, 255);
		timeCount.color = color;
	}

	public void ShowTime() {
		timeGauge.enabled = true;
		timeCount.enabled = true;
	}
}
