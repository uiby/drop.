using UnityEngine;
using System.Collections;

//生命力パーティクルの処理
public class VitalityParticle : MonoBehaviour {
	public ParticleSystem particle;
	public float[] startSize;
	public float[] startLifetime;
	public Gradient[] ColorOverLifeTime;
	public Random random;
	void Awake () {
		particle = this.GetComponent<ParticleSystem>();
	}

  //見た目を残機に合わせて変える life:自機の残機数
	public void ChangeUI(int life) {
		ChangeStartSize(life);
	  ChangeStartLifeTime(life);
	  ChangeColorOverLifeTime(life);
	}

	public void Stop() {
		if (particle.isStopped) return;
		particle.Stop();
	}
	public void Play() {
		particle.Play();
	}

  //大きさの変更 life:自機の残機数
	private void ChangeStartSize(int life) {
		particle.startSize = startSize[life];
	}

  //パーティクルの寿命の変更 life:自機の残機数
	private void ChangeStartLifeTime(int life) {
		particle.startLifetime = startLifetime[life];
	}

  //パーティクルの色の変更 life:自機の残機数
	private void ChangeColorOverLifeTime(int life) {
		var color = particle.colorOverLifetime;
		color.color = new ParticleSystem.MinMaxGradient(ColorOverLifeTime[life]);
		GameObject.Find("Player").GetComponent<Player>().ChangeColor(ColorOverLifeTime[life]);
	}
	
}
