using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Leap;

//LeapMotionの操作を認識するスクリプト
//基本手は毎フレームごと取得しないといけない
public static class LeapUtil {
	private static Controller controller = new Controller();

	//手の情報の取得.
	//<returns>手の情報。手がない場合場合は errorが起きるのである前提で使う必要あり.要修正</returns>
	public static HandList GetHands() {
		Frame frame = controller.Frame();
	  InteractionBox interactionBox = frame.InteractionBox;
	  HandList hands = frame.Hands;  	//手の検出

	  return hands;
	}

	//左手の取得
	public static Hand GetLeftHand() {
		Frame frame = controller.Frame();
	  InteractionBox interactionBox = frame.InteractionBox;

	  return frame.Hands.Leftmost;
	}

	//右手の取得
	public static Hand GetRightHand() {
		Frame frame = controller.Frame();
	  InteractionBox interactionBox = frame.InteractionBox;
	  
	  return frame.Hands.Rightmost;
	}

  //手があるか判断
  public static bool IsValid() {
  	Frame frame = controller.Frame();
		return frame.Hands[0].IsValid;
  }
  
  //左手が握ってるかどうか判断
  //0.8以上 : true
	public static bool IsLeftHandGrab() {
		Frame frame = controller.Frame();
		InteractionBox interactionBox = frame.InteractionBox;

		if (frame.Hands.Leftmost.GrabStrength > 0.8f)  return true;

		return false;
	}

	  //左手が握ってるかどうか判断
  //0.8以上 : true
	public static bool IsRightHandGrab() {
		Frame frame = controller.Frame();
		InteractionBox interactionBox = frame.InteractionBox;

		if (frame.Hands.Rightmost.GrabStrength > 0.8f)  return true;

		return false;
	}

	//とりあえず手が握ってるか取得
	public static bool IsHandGrab() {
		Frame frame = controller.Frame();
		//Debug.Log(frame.Hands[0].GrabStrength);
		if (frame.Hands[0].GrabStrength > 0.9f) return true;

		return false;
	}

  //ピンチ(親指と人差し指の開閉度)が閉じてるかどうか判断
	public static bool IsHandPinch() {
		Frame frame = controller.Frame();
		if (frame.Hands[0].PinchStrength > 0.8f) return true;

		return false;
	}

	public static float GetGrabStrength() {
		Frame frame = controller.Frame();
		return frame.Hands[0].GrabStrength;
	}

}
