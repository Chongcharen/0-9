using UnityEngine;
using System.Collections;

public class Events : MonoBehaviour {
    private static Events _instance;
    //ตัวอย่างนะ
  //  public delegate void GravityEvent(Vector2 gravityDirection);
   // public static event GravityEvent OnGravity;

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
    

}
