using UnityEngine;
using System.Collections;

//コネクトシステム
//great!が2回連続で出るとステージとステージがコネクト(申し訳程度のテーマ要素)する演出を作る
public class ConnectSystem : MonoBehaviour {
	private static LineRenderer lineRenderer;
	private static Vector3 diff; //理想の位置までをcountで割ったベクトル
	private static Vector3 now; //現在のラインの終端
	private static int count;
	private int frame; //フレーム数
	private static bool canDraw;
	public GameObject[] particleSystem;

	void Start () {
		canDraw = false;
		count = 0;
		frame = 0;
  	lineRenderer = GetComponent<LineRenderer>();
    lineRenderer.enabled = true;
    lineRenderer.sortingLayerName = "Particle";
	}
	void Update() {
		if (!canDraw) return;
		frame++;
		if (frame < 1) return;

		//10フレーム経ったら
		count--;
		frame = 0;
		now += diff;
		lineRenderer.SetPosition(1, now);
		if (count == 21) {
			particleSystem[0].transform.position = now;
			particleSystem[0].GetComponent<ParticleSystem>().Play();
		} else if (count == 14) {
			particleSystem[1].transform.position = now;
			particleSystem[1].GetComponent<ParticleSystem>().Play();
		} else if (count == 7) {
			particleSystem[2].transform.position = now;
			particleSystem[2].GetComponent<ParticleSystem>().Play();
		}
		if (count <= 0) {
			canDraw = false;
			particleSystem[3].transform.position = now;
			particleSystem[3].GetComponent<ParticleSystem>().Play();
		}
	}

  //ラインの初期位置の配置
  private static void SetFirstPos (Vector3 start) {
  	lineRenderer.SetVertexCount(2);
  	lineRenderer.SetPosition(0, start);
  	now = start;
  }
  //ラインの終端位置の配置
	private static void SetEndPos (Vector3 endPos) {
		canDraw = true;
		count += 30;
		lineRenderer.SetVertexCount(2);
		diff = (endPos - now) / (float)count;
	}

  //ラインを作画するするかどうか
  //**する場合**//
  //コンボが2以上の場合、SetFirstPos、SetEndPosの順
  //**しない場合**//
  //return;
	public static void Draw (StageResult.StageResultInfo result, Vector3 start, Vector3 endPos) {
		if (result != StageResult.StageResultInfo.Excellent) return; //
		if (ComboSystem.GetCombo() < 2) return;

		SetFirstPos(start);
		SetEndPos(endPos);
	}

	/*private void Emit (Vector3 point) {
    particleSystem.Emit(
            point,
            Random.onUnitSphere * particleSystem.startSpeed,
            particleSystem.startSize,
            particleSystem.startLifetime,
            particleSystem.startColor);
  }*/
}
