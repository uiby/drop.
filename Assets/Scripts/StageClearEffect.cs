using UnityEngine;
using System.Collections;

public class StageClearEffect : MonoBehaviour {
	private ParticleSystem particle;
	void Start () {
		particle = this.GetComponent<ParticleSystem>();
	}
	
	void Update () {
		if (!particle.isPlaying)
		  Destroy(this.gameObject);
	}
}
