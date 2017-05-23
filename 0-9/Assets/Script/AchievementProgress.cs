using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AchievementProgress : MonoBehaviour {

	public static string ACHIEVEMENT_10_GAME = "Play 10 Games";
    public static string ACHIEVEMENT_50_GAME = "Play 50 Games";
    public static string ACHIEVEMENT_FAIL_10_GAME = "Miss 10 Time";
    public static string ACHIEVEMENT_FAIL_20_GAME = "Your a Shame";
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
		AchievementManager.instance.ReportAchievementStep (ACHIEVEMENT_10_GAME, 1);
        AchievementManager.instance.ReportAchievementStep(ACHIEVEMENT_50_GAME, 1);
    }

    public void InCreaseFailGame()
    {
        AchievementManager.instance.ReportAchievementStep(ACHIEVEMENT_FAIL_10_GAME, 1);
        AchievementManager.instance.ReportAchievementStep(ACHIEVEMENT_FAIL_20_GAME, 1);
    }

	public void AddAchievementNoob(){
		AchievementManager.instance.ReportAchievementProgress (ACHIEVEMENT_NOOB, 100);
	}

}
