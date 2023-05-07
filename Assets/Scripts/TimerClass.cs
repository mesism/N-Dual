using UnityEngine;
using System.Collections;
using System;

public class TimerClass : MonoBehaviour {


    public static TimerClass instance;

    void Awake()
    {

        instance = this;
    }


    Action onFinished;

    public void StartTimer(float mDuration , Action mOnFinished = null )
    {
       
        duration = mDuration;
        onFinished = mOnFinished;
        //isMovie = false;
        this.enabled = true;

    }


    private bool isMovie;

    public void StopTimer()
    {
        onFinished = null;
        isMovie = false;
        onFinished = null;
        this.enabled = false;
        currentDuration = 0;
       
    }



    public float duration = 0;
    public float currentDuration = 0;
    void Update()
    {

            currentDuration += Time.deltaTime;
            if (currentDuration > duration)
            {
                currentDuration = 0;

                if(onFinished != null)
                    onFinished();

                StopTimer();
                //onFinished = null;

                return;
            }

            //currentDuration++;
        
    }

}
