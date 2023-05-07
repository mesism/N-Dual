using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Piece : MonoBehaviour
{

    private int _id;
    public int Id
    {
        get { return _id;}
        set { _id = value; }
    }
    [SerializeField] private SpriteRenderer _defaultRenderer;
    [SerializeField] private SpriteRenderer _flashRenderer;
    [SerializeField] private float _flashSpeed = 1;
    private Action _onFinished;
    private bool _isFlash;
    private float _flashTo;
    
    public void StartFlash(Action onFinished)
    {
        _isFlash = true;
        _flashTo = 1;
        _onFinished = onFinished;
    }
    private void Update()
    {

        if( !_isFlash )
            return;
        Color color = _flashRenderer.color;

        if (!Mathf.Approximately(_flashRenderer.color.a , _flashTo ))
        {
            color.a = Mathf.MoveTowards(color.a, _flashTo, _flashSpeed * Time.unscaledDeltaTime);
        }
        else
        {
            if (_flashTo > 0)
                _flashTo = 0;


            if (color.a <= 0)
            {
                _isFlash = false;
                _onFinished?.Invoke();

            }
        }
        _flashRenderer.color = color;
        

    }
    
    
}
