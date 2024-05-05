using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    [SerializeField] float timerToCompleteQuestion = 30;
    [SerializeField] float timerToShowAnswer = 10;
    //[SerializeField] Image timerImg;
    float timerValue;
    public bool loadNextQuestion=false;
    public bool isAnsweringQuestion = true;
    public float fillFraction;
    void Start(){
        timerValue = timerToCompleteQuestion;
    }
    public void startTimer(){
        Start() ;
    }
    // Update is called once per frame
    void Update()
    {
        updateTimer();
    }
    public void cancleTimer(){
        timerValue=0;
    }
    void updateTimer()
    {
        timerValue -= Time.deltaTime;
        if (isAnsweringQuestion)
        {
            if (timerValue > 0)
            {
                fillFraction = timerValue / timerToCompleteQuestion;
                // timerImg.fillAmount

            }
            else
            {
                isAnsweringQuestion = false;
                timerValue=timerToShowAnswer;
                //timerValue=timerToCompleteQuestion;
            }
        }
        else
        {
            if (timerValue > 0)
            {
                fillFraction = timerValue / timerToShowAnswer;
                //timerImg.fillAmount=fillFraction;
            }
            else
            {
                isAnsweringQuestion = true;
                loadNextQuestion = true;
                // timerValue=timerToShowAnswer;
            }

        }

        //Debug.Log("time remain:" + timerValue);
    }
    public float getFillFraction(){
        return fillFraction;
    }
}
