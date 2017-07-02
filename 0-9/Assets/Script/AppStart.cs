using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppStart : MonoBehaviour {

	// Use this for initialization
	void Start () {
        PlayerPrefs.DeleteAll();
		Invoke ("TestA", 2);

	}
	void TestA(){
        #if !UNITY_EDITOR
                AchievementManager.instance.SignIn ();
        #endif
    }

}
