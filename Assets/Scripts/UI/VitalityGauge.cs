using UnityEngine;
using UnityEngine.UI;
using System.Collections;

//生命力ゲージの処理
public class VitalityGauge : MonoBehaviour {
	private Image vitalityGauge;
	private Text vitalityCount;
	private GameObject particle;

	//private float vitalityGauge;
	//private float maxVitalityGauge;

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
		vitalityGauge = this.GetComponent<Image>();
		vitalityCount = this.transform.FindChild("TimeCount").gameObject.GetComponent<Text>();

		vitalityCount.text = "0";

		vitalityGauge.enabled = false;
		vitalityCount.enabled = false;

		SetGaugeColor(new Color32(202, 13, 255, 255));
	  SetNumberColor(new Color32(0, 0, 0, 255));
	}
	
	void Update () {
		switch (GameManager.state) {
			case GameManager.GameState.GameMain : 
			  if (_state == eState.END) return ; 
				//ChangeColor();
				break;
			case GameManager.GameState.Finish : break;
		}
	}

	private void ChangeColor() {
		/*switch (_state) {
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
		}*/
	}

	private void SetGaugeColor(Color32 color) {
		vitalityGauge.color = color;
	}
	private void SetNumberColor(Color32 color) {
		vitalityCount.color = color;
	}

	public void ShowTime() {
		vitalityGauge.enabled = true;
		vitalityCount.enabled = true;
	}
}
