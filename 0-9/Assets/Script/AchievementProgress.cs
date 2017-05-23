using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AchievementProgress : MonoBehaviour {

	public static string ACHIEVEMENT_10GAME = "Play 10 Games";
	public static string ACHIEVEMENT_NOOB = "test_noob";
	private static AchievementProgress _instnace;
	public static AchievementProgress instance{
		get{
			return (_instnace) ? _instnace : _instnace = new GameObject ("AchievementProgress").AddComponent<AchievementProgress> ();
		}
	}
	//เงื่อนไขการใส่ progress 
	//player 10 game

	public void IncreasePlayGame(){
		AchievementManager.instance.ReportAchievementStep (ACHIEVEMENT_10GAME,1);
	}

	public void AddAchievementNoob(){
		AchievementManager.instance.ReportAchievementProgress (ACHIEVEMENT_NOOB, 100);
	}

}
