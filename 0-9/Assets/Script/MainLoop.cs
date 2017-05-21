﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using DG.Tweening;
public class MainLoop : MonoBehaviour {
    public TextMeshProUGUI num_txt,target_txt,tap_start_txt,score_txt,time_sec_txt,bonus_txt;
    public float speed = 1;
    public float increaseSpeed = 0;
    public int level = 1;
    private float index = 0;
    public float currentTime = 0;
    public float timeToChange = 1;
    public int target = 0;
    //time
    public float timeSpeed = 1;
    public float secound = 5;
    private float current_time = 0;
    private float bonus_time = 0;
    //reset
    private float tempSpeed;

    //Color
    public Color colorCorrect, colorWrong;
    //Animation 
    public Animator bonus_animator;

    // Use this for initialization
    GameManager game_manager;
	void Start () {
        tempSpeed = speed;

        game_manager = GameManager.instance;
        current_time = secound;
        bonus_time = secound;

    }
	
	// Update is called once per frame
	void Update () {
        if (game_manager.game_start)
        {
            index += Time.deltaTime * speed;
            bonus_time -= Time.deltaTime * timeSpeed;
           
           
            if (index >= 10)
            {
                index = 0;
            }
            if(current_time <= 0)
            {
                current_time = 0;
                GameOver();
            }
            else
            {
                current_time -= Time.deltaTime * timeSpeed;
                time_sec_txt.text = current_time.ToString("0.00");
            }
           
            num_txt.text = "" + (int)index;
          
        }
        else
        {
          //  tap_start_txt.enabled = true;
        }
        
       
       

        #if UNITY_EDITOR

                if (Input.GetKeyDown(KeyCode.Space))
                {
                    if (!game_manager.game_start&&!game_manager.game_over)
                    {
                        
                         GameStart();
                    }
                    else if(!game_manager.game_start && game_manager.game_over)
                    {
                         ResetGame();
                    }
                    else
                    {
                         CheckAnswer();
                    }
                }

#else
                              foreach (Touch touch in Input.touches)
                                    {
                                        if (touch.phase == TouchPhase.Began)
                                        {
                                             if (!game_manager.game_start&&!game_manager.game_over)
                                                {
                        
                                                     GameStart();
                                                }
                                                else if(!game_manager.game_start && game_manager.game_over)
                                                {
                                                     ResetGame();
                                                }
                                                else
                                                {
                                                   speed = 0;
                                                  CheckAnswer();
                                                }
                                        }
                                    }

#endif
    }


    void CheckAnswer()
    {
        game_manager.game_start = false;
        if(target == (int)index)
        {
            Correct();
        }
        else
        {
            GameOver();
        }
    }
   
    void Correct()
    {
        GameManager.instance.score++;
       
        num_txt.DOColor(colorCorrect, 0);
        score_txt.text = "" + GameManager.instance.score + " : SCORE";
        GameManager.instance.game_start = false;
        speed += increaseSpeed;
        level++;
        current_time += secound;
        bonus_txt.text = "+"+ bonus_time.ToString("0.00");
        if (bonus_time > 0)
        {
            bonus_animator.SetTrigger("play");
        }
        StartCoroutine("DelayStart");
       
    }
    void GameStart()
    {
        game_manager.game_start = true;
        game_manager.game_over = false;
        num_txt.DOColor(Color.white, 0);
        target = (int)Random.Range(0, 10);
        tap_start_txt.enabled = false;
        target_txt.text = "TARGET : " + target;
        bonus_time = secound;
    }
    void GameOver()
    {
        num_txt.DOColor(colorWrong, 0);
        GameManager.instance.game_start = false;

        speed = tempSpeed;
        tap_start_txt.enabled = true;
        GameManager.instance.score = 0;
        score_txt.text = "" + GameManager.instance.score + " : SCORE";
        game_manager.game_over = true;
    }
    void ResetGame()
    {
        current_time = secound;
        GameStart();
    }
    IEnumerator DelayStart()
    {
        yield return new WaitForSeconds(0.5f);
        GameStart();
    }
}
