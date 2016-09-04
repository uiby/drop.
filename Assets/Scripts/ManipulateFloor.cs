using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Leap;

//床をLeapで操作する
public class ManipulateFloor : MonoBehaviour {
	
	void Start () {
	}
	
	void Update () {
	  //InteractionBox interactionBox = frame.InteractionBox;

	  //手の検出
	  Hand leftHand = LeapUtil.GetLeftHand();//左手
		Hand rightHand = LeapUtil.GetRightHand();//右手

	  if (leftHand.IsValid && rightHand.IsValid) {
	  	Vector distance =  rightHand.PalmPosition - leftHand.PalmPosition;//両手の距離をベクトル
	  	float directionY = -(leftHand.Direction.y + rightHand.Direction.y) * 30 / 2; //両手の向き(角度)
		  distance.y /= (float)5.0;
		  if (distance.y <= -30)	distance.y = -30;
		  if (distance.y >= 30) distance.y = 30;
		  distance.z = distance.y;
		  distance.y = 0;
		  distance.x = directionY;
		  //Debug.Log(ToVector3(distance));
		  Vector3 rotate = Camera.main.transform.TransformDirection(ToVector3(distance));
		  this.transform.rotation = Quaternion.Euler(rotate);
		}
	  
	}
	private Vector3 ToVector3(Vector v)//座標の変換
	{
		return new UnityEngine.Vector3(v.x, v.y, v.z);
	}
}
