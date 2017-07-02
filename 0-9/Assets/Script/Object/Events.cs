using UnityEngine;
using System.Collections;

public class Events : MonoBehaviour {
    private static Events _instance;
    //ตัวอย่างนะ
    //  public delegate void GravityEvent(Vector2 gravityDirection);
    // public static event GravityEvent OnGravity;
    public delegate void OnDebugConsoleEvent(string message);
    public static event OnDebugConsoleEvent OnDebugConsole;

    public delegate void OnActiveEffectEvent();
    public static event OnActiveEffectEvent OnActiveEffect;

    public delegate void OnResetEffectEvent();
    public static event OnResetEffectEvent OnResetEffect;

    public delegate void OnPauseEffectEvent();
    public static event OnPauseEffectEvent OnPauseEffect;

    public static Events instance
    {
        get
        {
            if(_instance == null)
            {
                _instance = new GameObject("Events").AddComponent<Events>();
            }
            return _instance;
        }
    }
    
   public void OnDebugConsole_Dispatch(string message)
    {
        OnDebugConsole(message);
    }
    public void OnActiveEffect_dispatch()
    {
        OnActiveEffect();
    }
    public void OnResetEffect_Dispatch()
    {
        OnResetEffect();
    }

    public void OnPauseEffect_Dispatch()
    {
        OnPauseEffect();
    }
}
