using UnityEngine;
using UnityEngine.UI;
using System.Collections;

//生命力ゲージの処理
public class VitalityGauge : MonoBehaviour {
	private Image vitalityGauge;
	
	void Awake () {
		vitalityGauge = this.GetComponent<Image>();
		
		//HideImage();
	}
	
	void Update () {
	}

	public void ChangeAmount(int life) {
		float value = 0.0f;
		switch (life) {
			case 0: value = 0.3f; break;
			case 1: value = 0.7f; break;
			case 2: value = 1.0f; break;
		}
		vitalityGauge.fillAmount = value;
	}

	private void SetGaugeColor(Color32 color) {
		vitalityGauge.color = color;
	}
	
	public void ShowImage() {
		vitalityGauge.enabled = true;
	}
	public void HideImage() {
		vitalityGauge.enabled = false;
	}
}
