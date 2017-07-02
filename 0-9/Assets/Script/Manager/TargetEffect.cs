using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using DG.Tweening;
public class TargetEffect : MonoBehaviour {
    public TextMeshProUGUI target;

    int indexEffect;
    string effectName;
    int scale_limit = 5;
    int scale_current = 0;
    bool isRotate = false;
    bool isShake = false;
    bool isScale = false;

    Dictionary<string, bool> effectActiveList;
    Dictionary<string, System.Action> effectActionList;
    List<string> methodList;

    //
    List<string> memMethodList;
    private void OnEnable()
    {
        Events.OnActiveEffect += Events_OnActiveEffect;
        Events.OnResetEffect += Events_OnResetEffect;
        Events.OnPauseEffect += Events_OnPauseEffect;
    }

   

    private void OnDisable()
    {
        Events.OnActiveEffect -= Events_OnActiveEffect;
        Events.OnResetEffect -= Events_OnResetEffect;
        Events.OnPauseEffect -= Events_OnPauseEffect;
    }
    private void Events_OnActiveEffect()
    {
        StartEffect();
    }
    private void Events_OnResetEffect()
    {
        ResetEffect();
    }
    private void Events_OnPauseEffect()
    {
        PauseEffect();
    }
    private void Start()
    {
        effectActiveList = new Dictionary<string, bool>();
        effectActionList = new Dictionary<string, System.Action>();
        methodList = new List<string>();
        memMethodList = new List<string>();
        effectActiveList.Add("rotate", isRotate);
        effectActiveList.Add("shake", isShake);
        effectActiveList.Add("scale", isScale);

        effectActionList.Add("rotate", Rotate);
        effectActionList.Add("shake", Shake);
        effectActionList.Add("scale", Scale);

        methodList.Add("rotate");
        methodList.Add("shake");
        methodList.Add("scale");
        //  Scale();
       // StartEffect();
    }

    public void StartEffect()
    {
        memMethodList.Clear();
        foreach (KeyValuePair<string,bool> t in effectActiveList)
        {
            if (t.Value == false)
            {
                memMethodList.Add(t.Key);
            }
           
        }
        if (memMethodList.Count > 0)
        {
            indexEffect = Random.Range(0, memMethodList.Count);
            effectName = memMethodList[indexEffect];
            effectActionList[effectName]();
        }
    }
    public void ResetEffect()
    {

        target.transform.DOKill();
        target.transform.DOScale(1, 0);
        target.transform.DORotate(Vector3.zero, 0);
        target.transform.DOShakePosition(1, 1, 0, 0);
        isRotate = false;
        SetActiveEffect("rotate", isScale);
        isShake = false;
        SetActiveEffect("shake", isShake);
        isScale = false;
        SetActiveEffect("scale", isScale);
        scale_current = 0;
    }
    public void PauseEffect()
    {

        target.transform.DOKill();
        scale_current = 100;
    }
    public void Rotate()
    {
        isRotate = true;
        SetActiveEffect("rotate", isRotate);
        target.transform.DORotate(new Vector3(0, 0, -360), 100, RotateMode.FastBeyond360).SetLoops(10).OnComplete(()=> {
            isRotate = false;
            SetActiveEffect("rotate", isRotate);
        });
    }

    public void Shake()
    {
        isShake = true;
        SetActiveEffect("shake", isShake);
        target.transform.DOShakePosition(1,25,50,90).SetLoops(10).OnComplete(()=> {
            isShake = false;
            SetActiveEffect("shake", isShake);

        });
    }
    public void Scale()
    {
        isScale = true;
        SetActiveEffect("scale", isRotate);
        target.transform.DOScale(0.2f, 10).OnComplete(() =>
        {
             target.transform.DOScale(1, 10).OnComplete(() =>
             {
                if(scale_current < scale_limit)
                 {
                     scale_current++;
                     Scale();
                 }
                 else
                 {
                     scale_current = 0;
                     isScale = false;
                     SetActiveEffect("scale", isScale);
                 }
             });
        });
  
    }
    public void StopAll()
    {
        target.DOKill();
    }

    void SetActiveEffect(string name , bool isActive)
    {
        effectActiveList[name] = isActive;
    }
}
