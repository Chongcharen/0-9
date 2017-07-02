using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour
{

    public static GameManager instance;
    int _score = 0;
    public bool game_start = false;
    public bool game_pause = false;
    public bool game_over = false;
    private void Awake()
    {
        instance = this;
    }
    public int score
    {
        get { return _score; }
        set
        {
            _score = value;
            if (_score % 1 == 0&&_score >=1)
            {
                Events.instance.OnActiveEffect_dispatch();
            }
        }

    }
}
