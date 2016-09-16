using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class BornWord : MonoBehaviour {
	public ParticleSystem[] bornWordEffect;
	public ParticleSystem[] finalEffect;
	//誕生エフェクトの生成 num :0 たん :1 じょう
	public void EmitBornWordEffect(int num) {
		Color color = bornWordEffect[num].startColor;
		for (int i = 0; i < 25; i++) {
  		color = new Color(Random.value, Random.value, Random.value, 1.0f);
	  	bornWordEffect[num].startColor = color;
		  bornWordEffect[num].Emit(4);
		}
	}
	//誕生時に出現する文字の演出の最後を飾るエフェクトをプレイ
	public void PlayFinalEffect() {
		for (int i = 0;i< finalEffect.Length; i++) finalEffect[i].Play();
	}

	//
	public void PlayAnimation(string result) {
		this.GetComponent<Animator>().SetTrigger(result);
		if (result == "Bad") this.transform.FindChild("BornWord_jou").GetComponent<Text>().text = "じ ょ う .";
		else if (result == "Good") this.transform.FindChild("BornWord_jou").GetComponent<Text>().text = "じ ょ う !";
		if (result == "Excellent") this.transform.FindChild("BornWord_jou").GetComponent<Text>().text = "じ ょ う !!";
	}

	public bool IsFinishAnimation() {
		if (this.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).normalizedTime > 1.0f) return true;
		return false;
	}
}
