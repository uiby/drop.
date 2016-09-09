using UnityEngine;
using System.Collections;

public class BackGround : MonoBehaviour {
	private int timer; //背景を変える際にかかるのフレーム数
	public Material material;
	private Color nextBottomColor; //次のカラーまでの差分をtimerで割ったもの
	private Color nextTopColor; //次のカラーまでの差分をtimerで割ったもの
	public bool canChange;
	public Color32 newColor;
	// Use this for initialization
	void Start () {
	  //material.SetColor("_Top", new Color(1,0,0));
	}
	
	// Update is called once per frame
	void Update () {
		if (canChange) ChangeColor(newColor);
		if (timer <= 0) return ;
		timer--;

		Color color = material.GetColor("_Top") + nextTopColor;
		material.SetColor("_Top", color);
		color = material.GetColor("_Bottom") + nextBottomColor;
		material.SetColor("_Bottom", color);
	}

	public void ChangeColor(Color nextColor) {
		canChange = false;
		timer = 60;
		Color nowTop = material.GetColor("_Top");
		Color nowBottom = material.GetColor("_Bottom");
		nextBottomColor = new Color((nextColor.r - nowBottom.r)/60.0f,
		                            (nextColor.g - nowBottom.g)/60.0f,
		                            (nextColor.b - nowBottom.b)/60.0f);
		nextTopColor = new Color((nowBottom.r - nowTop.r)/60.0f,
		                         (nowBottom.g - nowTop.g)/60.0f,
		                         (nowBottom.b - nowTop.b)/60.0f);
	}
}
