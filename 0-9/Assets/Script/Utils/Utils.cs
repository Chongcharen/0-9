using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine.UI;
using System;
using System.Linq;
using UnityEngine.EventSystems;
using System.Globalization;
using System.Threading;
using DG.Tweening;
public class DAUtils : MonoBehaviour {

	public static void SendEmail(string mail){
		Application.OpenURL("mailto:" + mail);
	}
    public static void OpenTelephone(string phoneNumber)
    {
        Application.OpenURL("tel://" + phoneNumber);
    }

    public static void ClearBoard(Transform content)
    {
        for (int i = 0; i < content.childCount; i++)
        {
            Destroy(content.GetChild(i).gameObject);
        }
    }
    public static void AddTriggerDown(GameObject obj , Action callback)
    {
        EventTrigger trigger = obj.gameObject.AddComponent<EventTrigger>();
        EventTrigger.Entry entry = new EventTrigger.Entry();
        entry.eventID = EventTriggerType.PointerDown;
        entry.callback.AddListener((eventData) => { callback(); });
        trigger.triggers.Add(entry); 
    }
	public static bool IsValidEmailAddress(string s)
	{
		Regex regex = new Regex(@"[a-z0-9!#$%&amp;'*+/=?^_`{|}~-]+(?:.[a-z0-9!#$%&amp;'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?");
		return regex.IsMatch(s);
	}
    public static byte[] Texture2dToByteArray(Texture2D texture2d)
    {
        byte[] byteArray = texture2d.EncodeToJPG();
        return byteArray;
    }
    public static string ConvertTimestampToDate(long unixDate)
    {
        DateTime start, date;
        double milli = Convert.ToDouble(unixDate);
        start = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
        date = start.AddMilliseconds(milli).ToLocalTime();
        return date.ToString("G");
    }
    public static string ConvertTimestampToDate(string timestamp,bool th = true)
    {
        DateTime d = DateTime.Parse(timestamp);
        string dateString;
        if (!th)
        {
            dateString = d.ToString("dd MMMM yy");
        }
        else
        {
            Thread.CurrentThread.CurrentCulture = new CultureInfo("th-TH");
            dateString = DateTime.Today.ToString("dd MMMM yyyy") ;
        }

        return dateString;
    }
	public static float CalculateImageScale(float screen,float textHeight){
		float scale;
		scale = screen / textHeight;
		return scale;
	}




    #region Map และการคำนวณเลขจากพิกัด
    public static string ConvertToMeter(double meter)
    {
        float m;
        string string_meter;
        if (meter > 1000)
        {
            m = System.Convert.ToSingle(meter / 1000);
            string_meter = m.ToString("0") + " กม.";
        }
        else
        {
            m = System.Convert.ToSingle(meter);
            string_meter = m.ToString("0") + " ม.";
        }
        return string_meter;
    }
    public static double CalculateDistance(double lat1 , double lon1 ,double lat2 , double lon2){
		int R = 6371000;
		double o1 = ConvertToRadian (lat1);
		double o2 = ConvertToRadian (lat2);
		double vo1 = ConvertToRadian (lat2 - lat1);
		double vo2 = ConvertToRadian (lon2- lon1);

		double a =  System.Math.Sin (vo1 / 2) * System.Math.Sin (vo1 / 2) +
					System.Math.Cos (o1) * System.Math.Cos (o2) *
					System.Math.Sin (vo2 / 2) * System.Math.Sin (vo2/ 2);
		double c = 2 * System.Math.Atan2 (System.Math.Sqrt(a),System.Math.Sqrt (1-a));
		double d = R * c;
		return d;
	}

	// สูตร นี้ เหมือนกันนะ 
	public static float operacion(float lat1 , float lon1 ,float lat2 , float lon2){
		float R = 6371000; // metres
		float omega1 = ((lat1/180)*Mathf.PI);
		float omega2 = ((lat2/180)*Mathf.PI);
		float variacionomega1 = (((lat2 - lat1)/180)*Mathf.PI);
		float variacionomega2 = (((lon2 - lon1) / 180) * Mathf.PI);
		float a = Mathf.Sin(variacionomega1/2) * Mathf.Sin(variacionomega1/2) +
					Mathf.Cos(omega1) * Mathf.Cos(omega2) *
					Mathf.Sin(variacionomega2/2) * Mathf.Sin(variacionomega2/2);
		float c = 2 * Mathf.Atan2(Mathf.Sqrt(a), Mathf.Sqrt(1-a));

		float d = R * c;
		return d;
	}

	//ห้ามใช้ x*(Mathf.PI/180) เลขจะเพี๊ยนมาก
	public static float ConvertToRadian(float doub){
		return  (doub / 180) * Mathf.PI;
	}

	public static double ConvertToRadian(double doub){
		return  (doub / 180) * System.Math.PI;
	}
    #endregion
}
