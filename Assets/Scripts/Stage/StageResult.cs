﻿using UnityEngine;
using System.Collections;

public static class StageResult {

  //ステージ結果を返す
  //理想の時間とかかった時間を比較する
	public static StageResultInfo GetStageResult(string stageName) {
		//結果時間 = かかった時間 - 理想の時間
		float resultTime = Timer.GetCurrentTime() - StageManager.GetIdealTime(stageName);
    //Debug.Log(resultTime);
		if (resultTime > 0 && resultTime <= 1.0f) { //1秒以内遅れる
      return StageResultInfo.Late;
		}
		else if (resultTime > 1.0f) return StageResultInfo.TooLate;

		return StageResultInfo.Excellent;
	}

	public static StageResultInfo GetStageResult() {
		float result = TimeLimit.GetCurrentTime();
		if (result >= 0) {
			return StageResultInfo.Excellent;
		} else //if (result < 0) {
			return StageResultInfo.Late;
	}

	//touch情報
  public enum StageResultInfo {
	  //touchなし
	  None,
	  //理想タイム
	  Excellent,
	  //遅い
	  Late,
	  //遅すぎ
	  TooLate,
  }
}
