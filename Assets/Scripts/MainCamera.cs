using UnityEngine;
using System.Collections;

public class MainCamera : MonoBehaviour {
	public GameObject player;
	public Vector3 pos;
	public float interval = 2.0f;
	
	public void DownPos() {
		//differencePos : 今と次のステージの差分ベクトル
	  Vector3 differencePos = StageManager.nowStage.transform.position - StageManager.prevStage.transform.position;
	  Vector3 endPos = transform.position;
		endPos.y -= StageManager.stageInterval;
		endPos.x += differencePos.x;
		endPos.z += differencePos.z;
		StartCoroutine(SmoothMovement(endPos));
	}

  //ゲームスタート時のカメラポジションを整える(0, 2, -7) x:20度
	public void SetFirstPos() {

	}

	//現在地から目的地(引数end)へ移動するためのメソッド
	public IEnumerator SmoothMovement(Vector3 end)
	{
		Rigidbody rigidbody = GetComponent<Rigidbody>();
		float inverseMoveTime = 1f / 0.15f;
		//現在地から目的地を引き、2点間の距離を求める(Vector3型
		//sqrMagnitudeはベクトルを2乗したあと2点間の距離に変換する(float型)
		float sqrRemainingDistance = (this.transform.position - end).sqrMagnitude;
		//2点間の距離が0になった時、ループを抜ける
		//Epsilon : ほとんど0に近い数値を表す
		while (sqrRemainingDistance > float.Epsilon)
		{
			//現在地と移動先の間を1秒間にinverseMoveTime分だけ移動する場合の
			//1フレーム分の移動距離を算出する
			Vector3 newPosition = Vector3.MoveTowards(rigidbody.position, end, inverseMoveTime * Time.deltaTime);
			//算出した移動距離分、移動する
			rigidbody.MovePosition(newPosition);
			//現在地が目的地寄りになった結果、sqrRemainDistanceが小さくなる
			sqrRemainingDistance = (this.transform.position - end).sqrMagnitude;
			//1フレーム待ってから、while文の先頭へ戻る
			yield return null;
		}

	}
}
