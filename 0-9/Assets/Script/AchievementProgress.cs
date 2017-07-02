using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AchievementProgress : MonoBehaviour {

	public static string ACHIEVEMENT_10_GAME = "Play 5 Games";
    public static string ACHIEVEMENT_50_GAME = "Play 10 Games";
    public static string ACHIEVEMENT_FAIL_10_GAME = "Miss 10 Time";
    public static string ACHIEVEMENT_FAIL_20_GAME = "Your a Shame";
    public static string ACHIEVEMENT_FIRST_PLAY = "First Play";
	private static AchievementProgress _instnace;
	public static AchievementProgress instance{
		get{
			return (_instnace) ? _instnace : _instnace = new GameObject ("AchievementProgress").AddComponent<AchievementProgress> ();
		}
	}
	//เงื่อนไขการใส่ progress 
	//player 10 game

	public void IncreasePlayGame(){
        #if !UNITY_EDITOR
                SaveManager.instance.GamePlayed++;
		        AchievementManager.instance.ReportAchievementStep (ACHIEVEMENT_10_GAME, SaveManager.instance.GamePlayed);
                AchievementManager.instance.ReportAchievementStep(ACHIEVEMENT_50_GAME, SaveManager.instance.GamePlayed);
        #endif

    }

    public void InCreaseFailGame()
    {
        #if !UNITY_EDITOR
                AchievementManager.instance.ReportAchievementStep(ACHIEVEMENT_FAIL_10_GAME, 1);
                AchievementManager.instance.ReportAchievementStep(ACHIEVEMENT_FAIL_20_GAME, 1);
        #endif
    }

    public void AddAchievementNoob(){
        #if !UNITY_EDITOR
		        AchievementManager.instance.ReportAchievementProgress (ACHIEVEMENT_FIRST_PLAY, 100);
        #endif
    }
    public void CheckFirstPlay()
    {
#if !UNITY_EDITOR
        Events.instance.OnDebugConsole_Dispatch("FirstPlay Save  " + SaveManager.instance.firstPlay);
                if (!SaveManager.instance.firstPlay)
                {
                    AchievementManager.instance.ReportAchievementProgress(ACHIEVEMENT_FIRST_PLAY, (double)100);
                    SaveManager.instance.firstPlay = true;
                    SaveManager.instance.Save();
                }
#endif
    }

}
