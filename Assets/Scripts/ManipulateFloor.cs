using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Leap;

//床をLeapで操作する
//ManipulateFloorはもっと似合う名前があるはずなので要修正.
//FIXME y軸だけLeapでの操作対象から外して欲しい
public class ManipulateFloor : MonoBehaviour {
	private int rollY;
	public bool isOneHand;
	void Start () {
	}
	
	void Update () {
	  //InteractionBox interactionBox = frame.InteractionBox;
	  OperationByOneHand();
	}
	private Vector3 ToVector3(Vector v)//座標の変換
	{
		return new UnityEngine.Vector3(v.x, v.y, v.z);
	}
	public void SetRollY(int y) {
		rollY = y;
	}

  //両手での操作
	private void OperationByBothHand() {
		//手の検出
	  Hand leftHand = LeapUtil.GetLeftHand();//左手
		Hand rightHand = LeapUtil.GetRightHand();//右手

	  if (leftHand.IsValid && rightHand.IsValid) {
	  	Vector distance =  rightHand.PalmPosition - leftHand.PalmPosition;//両手の距離をベクトル
	  	float directionY = -(leftHand.Direction.y + rightHand.Direction.y) * 30 / 2; //両手の向き(角度)
		  distance.y /= (float)5.0;
		  if (distance.y <= -30)	distance.y = -30;
		  if (distance.y >= 30) distance.y = 30;

		  //leap motion の座標軸を unityの座標軸に変換
		  distance.z = distance.y;
		  distance.y = 0;
		  distance.x = directionY;

		  //Debug.Log(ToVector3(distance));
		  Vector3 rotate = Camera.main.transform.TransformDirection(ToVector3(distance)); //カメラから見たベクトルに変換
		  //rotate.y = rollY;
		  //Debug.Log(rotate +" : "+ rollY);
		  this.transform.rotation = Quaternion.Euler(rotate);
		}
	}

  //片手での操作
	private void OperationByOneHand() {
		if (!LeapUtil.IsValid()) return;
		Hand hand = LeapUtil.GetHands()[0];
		//Debug.Log( +" :: "+ hand.Direction);

		Vector angle = hand.PalmNormal * 30;
		
		//leap motion の座標軸を unityの座標軸に変換
		float value = angle.z;
		angle.z = angle.x;
		angle.y = 0;
		angle.x = value;

		Vector3 rotate = Camera.main.transform.TransformDirection(ToVector3(angle)); //カメラから見たベクトルに変換

		this.transform.rotation = Quaternion.Euler(rotate.x , this.transform.rotation.y, rotate.z);
	}
}
