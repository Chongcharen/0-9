using UnityEngine;
using System.Collections;
public class TimeUtil : MonoBehaviour {
	//DateTime time;
	//TimeSpan timeSpan;
	//TimeSpan timeNow;
	static System.TimeSpan timespan;
	static System.DateTime startGameTime;

	public static float TimeHasPlay(){
		return Time.time;
	}
	public static System.TimeSpan GetTimeSpanWasPlayed(){
		return new System.TimeSpan (System.TimeSpan.FromSeconds (Time.time).Ticks);
	}
	public static System.TimeSpan SubTractTimeSpan(System.TimeSpan span){
		return timespan.Subtract (span);
	}
	public static System.TimeSpan SaveTimeSpan(System.TimeSpan spanTarget){
		System.TimeSpan elapsedTime = new System.TimeSpan ((long)Mathf.Abs(spanTarget.Ticks - System.TimeSpan.FromSeconds (Time.time).Ticks - spanTarget.Ticks));
		return spanTarget.Add (elapsedTime);
	}
	public static double GetElapsedMinute(System.DateTime elapsedDate){
		System.TimeSpan elapsedTime = System.DateTime.Now.Subtract (elapsedDate);
        return ConvertTickToMinute(elapsedTime.Ticks);
    }
    public static double ConvertTickToHour(long ticks)
    {
        timespan = System.TimeSpan.FromTicks(ticks);
        return timespan.TotalHours;
    }
    public static double ConvertTickToMinute(long ticks)
    {
        timespan = System.TimeSpan.FromTicks(ticks);
        return timespan.TotalMinutes;
    }
    public static void GetCurrentTime()
    {
        GetElapsedMinute(System.DateTime.Now);
    }
}
