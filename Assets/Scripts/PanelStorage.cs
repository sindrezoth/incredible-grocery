using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanelStorage : MonoBehaviour
{
    [SerializeField]
    private float _timeOfMoving = 0.2f;
    [SerializeField]
    private GameObject CachierGO;

    public RectTransform rt;

    private bool _isShowed;
    private bool _isBlocked;

    private Vector2 _showedPosition;
    private Vector2 _hidedPosition;
    private float _timer;

    private Button[] _buttons;
    private Button _sell;
    private PanelButton[] _panelButtons;
    public List<Products> Picked;
    private int _maxToPick = 1;

    void Start()
    {
        _isShowed = false;
        _isBlocked = false;
        _showedPosition = new Vector2( 7f, 0f);
        _hidedPosition = new Vector2( 16f, 0f);
        rt.anchoredPosition = _hidedPosition;
        _timer = _timeOfMoving + 1; // for not moving from start

        _sell = GameObject.Find("Sell").GetComponent<Button>();
        _buttons = FindButtons();
        Picked = new List<Products>();
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.H))
        {
          if (_isShowed) {
            Hide();
          }
          else
          {
            Show(4);
          }
        }

        if(_timer < _timeOfMoving)
        {
            if(_isShowed)
            {
                _timer += Time.deltaTime;
                rt.anchoredPosition = Vector2.Lerp(rt.anchoredPosition, _showedPosition, _timer / _timeOfMoving);
            }
            else
            {
                _timer += Time.deltaTime;
                rt.anchoredPosition = Vector2.Lerp(rt.anchoredPosition, _hidedPosition, _timer / _timeOfMoving);
            }
        }
    }

    public void Show(int maxToPick)
    {
        _maxToPick = maxToPick;

        _isShowed = true;
        _timer = 0f;
    }

    public void Hide()
    {
        _isShowed = false;
        _timer = 0f;
    }

    void BlockAll()
    {
        for (int i = 0; i < _buttons.Length; i++)
        {
            _buttons[i].interactable = false;
        }
    }

    void UnblockAll()
    {
        for(int i = 0; i < _buttons.Length; i++)
        {
            bool isInThePicked = false;
            for (int j = 0; j < Picked.Count; j++) {
                if(Picked[j] == _buttons[i].GetComponent<PanelButton>().Prod)
                {
                    isInThePicked = true;
                    continue;
                }
            }
            if (!isInThePicked)
            {
                _buttons[i].interactable = true;;
            }
        }
    }

    public void Pick(Products prod)
    {
        Picked.Add(prod);
        if(Picked.Count == _maxToPick)
        {
            BlockAll();
            _sell.interactable = true;
        }
    }

    public void Unpick(Products prod)
    {
        Picked.Remove(prod);
        UnblockAll();
        _sell.interactable = false;
    }

    void Sell()
{

        Hide();
    }

    Button[] FindButtons()
    {
        GameObject[] findObjs = GameObject.FindGameObjectsWithTag("Storage Panel Buttons");

        Button[] result = new Button[findObjs.Length];
        _panelButtons = new PanelButton[findObjs.Length];

        for (int i = 0; i < findObjs.Length; i++) {
            result[i] = findObjs[i].GetComponent<Button>();
            _panelButtons[i] = result[i].GetComponent<PanelButton>();
        }

        return result;
    }
}
