using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePanelStorage : MonoBehaviour
{
    [SerializeField]
    float TimeOfMoving;

    public RectTransform rt;

    private bool _isShowed;

    private Vector2 _showedPosition;
    private Vector2 _hidedPosition;
    private float _timer;

    void Start()
    {
        _isShowed = false;
        _showedPosition = new Vector2( 5f, 0f);
        _hidedPosition = new Vector2( 16f, 0f);
        rt.anchoredPosition = _hidedPosition;
        _timer = TimeOfMoving + 1; // for not moving from start
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.A))
        {
            _isShowed = _isShowed == true ? false : true;
            _timer = 0f;
            Debug.Log($"_isShowed = {_isShowed}");
        }

        if(_timer < TimeOfMoving)
        {
            if(_isShowed)
            {
                _timer += Time.deltaTime;
                rt.anchoredPosition = Vector2.Lerp(rt.anchoredPosition, _showedPosition, _timer / TimeOfMoving);
            }
            else
            {
                _timer += Time.deltaTime;
                rt.anchoredPosition = Vector2.Lerp(rt.anchoredPosition, _hidedPosition, _timer / TimeOfMoving);
            }
        }
    }
}
