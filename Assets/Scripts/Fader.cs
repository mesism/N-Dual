using UnityEngine;
using System.Collections;
using System;
using UnityEngine.EventSystems;

public class Fader : MonoBehaviour {

    [HideInInspector]
    public bool isFade = false;
    
    private CanvasGroup faderCanvasGroup;
    private float _fadeTo;
    private float _fadeSpeed = 1;
    private Action _onFinished;



    void Awake()
    {
        faderCanvasGroup = GetComponent<CanvasGroup>();
    }

    
    public void Fade(float fadeTo, Action onFinished = null, float speed = 2f)
    {
        _onFinished = null;

        _fadeTo = fadeTo;
       
        _onFinished = onFinished;

        _fadeSpeed = speed;
        
        isFade = true;
        EventSystem.current.sendNavigationEvents = false;

       
    }
    



    void Update()
    {
        
        if( !isFade )
            return;
        
        if (!Mathf.Approximately(faderCanvasGroup.alpha, _fadeTo ))
        {
            faderCanvasGroup.alpha = Mathf.MoveTowards(faderCanvasGroup.alpha, _fadeTo, _fadeSpeed * Time.unscaledDeltaTime);
        }
        else
        {
            if (_fadeTo == 0)
            {
               //EventSystem.current.sendNavigationEvents = GuiManager.instance.isActiveUiInput;
                isFade = false;
            }
            faderCanvasGroup.blocksRaycasts = false;
            if (_onFinished != null)
                _onFinished();
        }

    }

}
