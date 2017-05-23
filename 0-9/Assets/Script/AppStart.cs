using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppStart : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Invoke ("TestA", 2);

	}
	void TestA(){
		AchievementManager.instance.SignIn ();
	}

}
