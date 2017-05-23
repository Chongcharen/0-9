using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UIButton : MonoBehaviour {
	public Button b_show_achievement,b_leaderboard;
	// Use this for initialization
	void Start () {
		b_show_achievement.onClick.AddListener (ShowAchievementUI);
		b_leaderboard.onClick.AddListener (ShowLeaderBoardUI);
	}
	void ShowAchievementUI(){
		AchievementManager.instance.ShowAchievementUI ();
	}

	void ShowLeaderBoardUI(){
		AchievementManager.instance.ShowLederBoardUI ();
	}
}
