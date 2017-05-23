using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VoxelBusters.NativePlugins;
using System.Linq;
public class AchievementManager : MonoBehaviour {
	public string leaderBoardGID = "LeaderBoard";
	private static AchievementManager _instnace;
	public static AchievementManager instance{
		get{
			return (_instnace) ? _instnace : _instnace = new GameObject ("AchievementManager").AddComponent<AchievementManager> ();
		}
	}

	// login
	bool isAuthenticated = false;
	int stepRequiredToUnlock;
	double _progressPercentage;
	public Leaderboard leaderBoard;
	public Achievement[] achievements;
	public AchievementDescription[] descriptions;
	public List<AchievementDescription> descriptionList;

	string leaderBoardGlobalID = "";

	public void SignIn(){
			NPBinding.GameServices.LocalUser.Authenticate((bool _success, string _error)=>{
				if (_success)
				{
					isAuthenticated = _success;
					FecthAchievement();
					FecthAchievementDescription();
					CreateLeaderboardWithGlobalID(leaderBoardGID);
				}
				else
				{
					Debug.Log("Sign-In Failed with error " + _error);
					Debug.Log("test "+NetworkPeerType.Client);
				}
			});
	}

	//Fecth Achievement is you get or pass ;
	public void FecthAchievement(){
		NPBinding.GameServices.LoadAchievements((Achievement[] _achievements, string _error)=>{

			if (_achievements == null)
			{
				Debug.Log("Couldn't load achievement list with error = " + _error);
				return;
			}

			achievements = _achievements;
            Debug.Log("achievements " + achievements.Length);
            for (int _iter = 0; _iter < achievements.Length; _iter++)
			{
				Debug.Log(string.Format("[Index {0}]: {1}", _iter, _achievements[_iter]));
			}
		});
	}
	// load all achievement;
	public void FecthAchievementDescription(){
		NPBinding.GameServices.LoadAchievementDescriptions((AchievementDescription[] _descriptions, string _error)=>{

			if (_descriptions == null)
			{
				Debug.Log("Couldn't load achievement description list with error = " + _error);
				return;
			}

			descriptions = _descriptions;
			Debug.Log("descriptions "+descriptions);
			for (int _iter = 0; _iter < descriptions.Length; _iter++)
			{
				Debug.Log(string.Format("[Index {0}]: {1}", _iter, _descriptions[_iter]));
			}
		});
	}

	public void ShowAchievementUI(){
		NPBinding.GameServices.ShowAchievementsUI((string _error)=>{
			Debug.Log("Achievements view dismissed.");
			if (!string.IsNullOrEmpty(_error)){

			}
		});
	}

	public void ReportAchievementStep(string _achievementGID,int step){
		stepRequiredToUnlock = NPBinding.GameServices.GetNoOfStepsForCompletingAchievement(_achievementGID);
		_progressPercentage = (double)(step/stepRequiredToUnlock) * 100d;
		ReportAchievementProgress (_achievementGID, _progressPercentage);
	}
	public void ReportAchievementProgress(string _achievementGID,double _percentage){
		NPBinding.GameServices.ReportProgressWithGlobalID (_achievementGID, _percentage,( bool _success, string _error ) => {
			
		});
	}
		
	public void CreateLeaderboardWithGlobalID(string _leaderboardGID){
		leaderBoard = NPBinding.GameServices.CreateLeaderboardWithGlobalID(_leaderboardGID);
	}
	//leaderboard
	public void ShowLederBoardUI(){
		NPBinding.GameServices.ShowLeaderboardUIWithGlobalID(leaderBoardGID, eLeaderboardTimeScope.ALL_TIME, (string _error )=>{
			Debug.Log("error ? "+_error);
		});
	}
	public void ReportLeaderBoardScore(int score){
		NPBinding.GameServices.ReportScoreWithGlobalID(leaderBoardGlobalID, score, (bool _success, string _error)=>{

			if (_success)
			{
				Debug.Log(string.Format("Request to report score to leaderboard with GID= {0} finished successfully.", leaderBoardGlobalID));
				Debug.Log(string.Format("New score= {0}.", score));
			}
			else
			{
				Debug.Log(string.Format("Request to report score to leaderboard with GID= {0} failed.", leaderBoardGlobalID));
			}
		});
	}


}
