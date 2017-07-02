using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
public class UIButton : MonoBehaviour {
    public static UIButton instance;
	public Button b_show_achievement,b_leaderboard;
    public int showPosX, hidePosX;
    // Use this for initialization
    private void Awake()
    {
        instance = this;
    }
    void Start () {
		b_show_achievement.onClick.AddListener (ShowAchievementUI);
		b_leaderboard.onClick.AddListener (ShowLeaderBoardUI);
        Show();
	}
    public void Hide()
    {
        ResetTween();
        b_show_achievement.transform.DOMoveX(hidePosX, 0.5f);
        b_leaderboard.transform.DOMoveX(hidePosX, 0.5f);
    }
    public void Show()
    {
        ResetTween();
        b_show_achievement.transform.DOMoveX(showPosX, 1f);
        b_leaderboard.transform.DOMoveX(showPosX, 1f);
    }
    void ShowAchievementUI(){
		AchievementManager.instance.ShowAchievementUI ();
	}

	void ShowLeaderBoardUI(){
		AchievementManager.instance.ShowLederBoardUI ();
	}
    void ResetTween()
    {
        b_show_achievement.transform.DOKill();
        b_leaderboard.transform.DOKill();
    }
}
