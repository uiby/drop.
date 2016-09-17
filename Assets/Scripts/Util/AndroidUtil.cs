using UnityEngine;
using System.Collections;

//android
public class AndroidUtil : MonoBehaviour {

	void Start () {
		Input.gyro.enabled = true; //ジャイロセンサ―をON
	}
	
	void Update () {
		transform.rotation = Input.gyro.attitude; //ジャイロでデバイスの傾きを取得
	}
}
