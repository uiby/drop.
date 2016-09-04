using UnityEngine;
using System.Collections;

//パーティクル
public class Particle : MonoBehaviour {
	private ParticleSystem particle;
	private Vector2 pos = Vector2.zero;
	
	void Start () {
		particle = this.GetComponent<ParticleSystem>();
	}
	
	void Update () {
		if(pos == Vector2.zero) return ;
		Vector3 pos3 = Camera.main.ScreenToWorldPoint(pos);
	  pos3.z = 0;
		this.transform.position = pos3;
		if (particle.isStopped)  pos = Vector2.zero;
	}

	public void SetPos(Vector2 pos2) {
		pos = pos2;
	}
}
