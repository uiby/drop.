using UnityEngine;
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
	public void PlayAnimation() {
		this.GetComponent<Animator>().SetTrigger("Show");
	}
}
