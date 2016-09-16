using UnityEngine;
using System.Collections;

//生命力アイテムの処理
//取ると画面右下の魂ゲージが増える
public class VitalityItem : MonoBehaviour {

  //触れた瞬間
	void OnTriggerEnter(Collider col) {
		if (col.gameObject.tag != "Player") return;
		this.GetComponent<Renderer>().enabled = false; //画面に映すのをやめる
		//Debug.Log("OK");
		this.transform.FindChild("GetEffect").GetComponent<ParticleSystem>().Emit(50);
		Destroy(this.gameObject, 1.0f); //1秒後に消滅
		GameObject.Find("Player").GetComponent<Player>().GetItem(this.transform.position);
	}
}
