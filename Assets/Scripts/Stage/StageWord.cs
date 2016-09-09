using UnityEngine;
using UnityEngine.UI;
using System.Collections;

//UIのステージ表記の処理
public class StageWord : MonoBehaviour {
	private GameObject particle;
	private float timer;
	private float maxTime;
	public GameObject stageCount;
	
	public enum eState {
    None,   //何もしないとき
    Big, //大きくなる
    Small //小さくなる
  }
  private eState state;

	void Start() {
		state = eState.None;
		particle = GameObject.Find("Effect/StageWordEffect");
	}

	void Update() {
		switch (state) {
			case eState.Big : 
			timer -= Time.deltaTime;
			ChangeScale(1 + maxTime - timer);
			if (timer <= 0) {
				state = eState.Small;
				RenewStageCount();
				//SetParticle();
			}
			break;  //大きくなる
			case eState.Small : 
			timer += Time.deltaTime;
			ChangeScale(1 + maxTime - timer);
			if (timer >= maxTime) {
				state = eState.None;
			}
			break;  //小さくなる
		}
	}

	public void ChangeStage() {
		maxTime = 0.5f;
		timer = maxTime;
		state = eState.Big;
	}

	public void RenewStageCount() {
		int value = StageManager.GetMaxStageCount() - StageManager.stageCount;
		stageCount.GetComponent<Text>().text = ""+ value;
	}
	
	private void SetParticle() {
	  //Vector3 pos = Camera.main.ViewportToWorldPoint(new Vector3(0.5f, 0.2f, Camera.main.nearClipPlane));
    Vector2 pos = this.GetComponent<RectTransform>().anchoredPosition;
		Vector3 pos3 = Camera.main.ScreenToWorldPoint(new Vector2(pos.x, pos.y + Screen.height));
		pos3.x = pos3.z;
		pos3.z = 0;
		particle.transform.position = pos3;
		particle.GetComponent<Particle>().SetPos(new Vector2(pos.x, pos.y + Screen.height));
	}

	//文字の大きさを変える
	private void ChangeScale(float value) {
		stageCount.transform.localScale = new Vector3(value, value, value);
	}
}
