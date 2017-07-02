using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VoxelBusters.NativePlugins;
using TMPro;
public class CloudService : MonoBehaviour {
    int gamePlayed = 0;
    public bool firstPlay = false;
    public static string GAME_PLAYED = "GAMEPLAYED";
    public static string FIRST_PLAY = "FIRST_PLAY";
    public TextMeshProUGUI t_txt;
    private static CloudService _instnace;
    public static CloudService instance
    {
        get
        {
            return (_instnace) ? _instnace : _instnace = new GameObject("CloudService").AddComponent<CloudService>();
           // NPBinding.CloudServices.Synchronise();
        }
    }
    private void Awake()
    {
        _instnace = this;
    }
    void OnEnable()
    {
        CloudServices.KeyValueStoreDidChangeExternallyEvent += OnKeyValueStoreChanged;
        CloudServices.KeyValueStoreDidSynchroniseEvent += OnKeyValueStoreDidSynchronise;
    }
    void OnDisable()
    {
        CloudServices.KeyValueStoreDidChangeExternallyEvent -= OnKeyValueStoreChanged;
        CloudServices.KeyValueStoreDidSynchroniseEvent -= OnKeyValueStoreDidSynchronise;
    }
    public void Intilize()
    {
        if (NPBinding.CloudServices.isActiveAndEnabled)
        {
            t_txt.text = "to Initialise";
            NPBinding.CloudServices.Initialise();
            NPBinding.CloudServices.Synchronise();
            /// LoadCould();
        }
       
    }
    public int GamePlayed
    {
        get {return gamePlayed; }
        set {
            gamePlayed = value;
        }
    }
    void LoadCould()
    {
        Debug.Log("LoadCould "+ NPBinding.CloudServices.isActiveAndEnabled);
        t_txt.text = "loadcloud";
        gamePlayed = (int)NPBinding.CloudServices.GetDouble(GAME_PLAYED);
        firstPlay = NPBinding.CloudServices.GetBool(FIRST_PLAY);
        t_txt.text = "gamePlayed "+gamePlayed;
        Debug.Log("LoadCould gameplay "+NPBinding.CloudServices.GetDouble(GAME_PLAYED));
    }
    public void SetToClound(string name,long number)
    {
        NPBinding.CloudServices.SetDouble(name,number);
    }
    public void SetToClound(string name, bool val)
    {
        NPBinding.CloudServices.SetBool(name, val);
    }
    void OnKeyValueStoreChanged(eCloudDataStoreValueChangeReason _reason, string[] _changedKeys)
    {
        t_txt.text = "to OnKeyValueStoreChanged";
        foreach (string _changedKey in _changedKeys)
        {
            if (_changedKey.Equals(GAME_PLAYED)) // Shows example of resolving a conflict
            {
                long _gamePlayed = NPBinding.CloudServices.GetLong(GAME_PLAYED);
                gamePlayed = gamePlayed > (int)_gamePlayed ? gamePlayed : (int)_gamePlayed;
                NPBinding.CloudServices.SetLong(GAME_PLAYED, gamePlayed);
            }

        }
    }
    private void OnKeyValueStoreDidSynchronise(bool _success)
    {
        if (_success)
        {
            t_txt.text = "init complete";
            LoadCould();
            NPBinding.CloudServices.Synchronise();
        }
        else
        {
            Debug.Log("Failed to synchronise in-memory keys and values.");
        }
    }
}
