using UnityEngine;
using System.Collections;

//キーボードの処理
public class KeyControllor : MonoBehaviour {
	
	public static bool IsEnter(){//Enter
		return Input.GetKeyDown(KeyCode.Return);
	}

	public static bool IsUpArrow() {
		return Input.GetKeyDown(KeyCode.UpArrow);
	}
	public static bool IsDownArrow() {
		return Input.GetKeyDown(KeyCode.DownArrow);
	}
	public static bool IsRightArrow() {
		return Input.GetKeyDown(KeyCode.RightArrow);
	}
	public static bool IsLeftArrow() {
		return Input.GetKeyDown(KeyCode.LeftArrow);
	}

	public static bool IsEsc() {
		return Input.GetKeyDown(KeyCode.Escape);
	}
}
