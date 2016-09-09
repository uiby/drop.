using UnityEngine;
using System.Collections;

//キーボードの処理
public class KeyUtil : MonoBehaviour {
	
	public static bool IsDownEnter(){//Enter
		return Input.GetKeyDown(KeyCode.Return);
	}

	public static bool IsDownUpArrow() {
		return Input.GetKeyDown(KeyCode.UpArrow);
	}
	public static bool IsDownDownArrow() {
		return Input.GetKeyDown(KeyCode.DownArrow);
	}
	public static bool IsDownRightArrow() {
		return Input.GetKeyDown(KeyCode.RightArrow);
	}
	public static bool IsDownLeftArrow() {
		return Input.GetKeyDown(KeyCode.LeftArrow);
	}

	public static bool IsDownEsc() {
		return Input.GetKeyDown(KeyCode.Escape);
	}
}
