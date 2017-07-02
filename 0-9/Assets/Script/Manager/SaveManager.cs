using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveManager : MonoBehaviour {
    private static SaveManager _instnace;
    public static SaveManager instance
    {
        get
        {
            return (_instnace) ? _instnace : _instnace = new GameObject("SaveManager").AddComponent<SaveManager>();
        }
    }


    int gamePlayed = 0;
    public bool firstPlay = false;
    public int GamePlayed
    {
        get { return gamePlayed; }
        set { gamePlayed = value;
            Save();
        }
    }

    public void Save()
    {
        PlayerPrefsUtility.Save("gamePlayed",gamePlayed);
        PlayerPrefsUtility.Save("firstPlay", firstPlay ? 1 : 0);
    }
    public void Load()
    {
        gamePlayed = PlayerPrefsUtility.Load("gamePlayed", default(int));
        firstPlay = PlayerPrefsUtility.Load("firstPlay", default(int)) == 1 ? true : false;
    }
}
