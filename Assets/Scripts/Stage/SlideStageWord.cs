using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SlideStageWord : MonoBehaviour {
	// RectTransform
  RectTransform _rectTransform = null;
  public RectTransform RectTrans
  {
    get { return _rectTransform ?? ( _rectTransform = GetComponent<RectTransform>()); }
  }
  // uGUI Text
  Text _text = null;
  public Text UiText
  {
    get { return _text ?? (_text = GetComponent<Text>()); }
  }

  //描画フラグ
	public bool Visible
  {
    get { return UiText.enabled; }
    set { UiText.enabled = value; }
  }
	// X座標
  public float X
  {
    get { return RectTrans.localPosition.x; }
    set
    {
      Vector3 p = RectTrans.localPosition;
      p.x = value;
      transform.localPosition = p;
    }
  }

  // Y座標
  public float Y
  {
    get { return RectTrans.localPosition.y; }
    set
    {
      Vector3 p = RectTrans.localPosition;
      p.y = value;
      RectTrans.localPosition = p;
    }
  }

	//状態定数
	enum eState {
		Appear, //出現
		Wait,   //停止
		Disappear, //退出
		End, //おしまい
	}

	//座標の定数
	//中心座標
	const float CENTER_X = 0;
	//中心からのオフセット座標(X)
	const float OFFSET_X = 600;

	//状態
	eState _state = eState.End;
	//タイマー
	float _timer = 0;

	void Start() {
		//画面外に出しておく
		X = CENTER_X + OFFSET_X;
		//非表示にしておく
		Visible = false;
	}

	//演出開始
	public void Begin() {
		//開始演出スタート
		_timer = OFFSET_X;
		_state = eState.Appear;
		//表示する
		Visible = true;
	}

	void FixedUpdate() {
		switch (_state) {
			case eState.Appear:
				_timer *= 0.9f;
				X = CENTER_X - _timer;
				if (_timer < 1)  {
					//20フレーム停止する
					_timer = 20;
					_state = eState.Wait;
				}
				break;
			case eState.Wait:
				_timer -= 1;
				if (_timer < 1) {
					_timer = OFFSET_X;
					_state = eState.Disappear;
				}
				break;
			case eState.Disappear:
				_timer *= 0.9f;
				X = CENTER_X + (OFFSET_X - _timer);
				if (_timer < 1) {
					//おしまい
					_state = eState.End;
					//非表示にしておく
					Visible = false;
				}
				break;
			case eState.End:
				break;
		}
	}
}
