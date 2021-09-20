using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanelButton : MonoBehaviour
{
    [SerializeField]
    GameObject PanelStorage;
    [SerializeField]
    Image Im;
    [SerializeField]
    Button button;
    [SerializeField]
    GameObject UnpickButtonPrefab;
    [SerializeField]
    public Products Prod;

    Product product;
    PanelStorage panel;
    Vector2 position;
    GameObject unpickButton;



    void Start()
    {
        panel = PanelStorage.GetComponent<PanelStorage>();
        button = GetComponent<Button>();
        Im = GetComponent<Image>();
        position = button.GetComponent<RectTransform>().anchoredPosition;

        button.onClick.AddListener(OnClick);
    }

    public void OnClick()
    {
        button.interactable = false;
        panel.Pick(Prod);
        unpickButton = Instantiate(UnpickButtonPrefab) as GameObject;
        unpickButton.transform.SetParent(PanelStorage.transform, false);
        Button newButton = unpickButton.GetComponent<Button>();
        newButton.GetComponent<RectTransform>().anchoredPosition = position;
        newButton.onClick.AddListener(OnUnpickClick);
    }

    public void OnUnpickClick()
    {
        button.interactable = true;
        panel.Unpick(Prod);
        Destroy(unpickButton);
    }
}
