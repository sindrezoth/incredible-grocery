using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cachier : MonoBehaviour
{
    [SerializeField]
    GameObject Panel;

    public bool IsOrderReady;
    public bool IsCachierRight;
    private Products[] _productsToSell;
    private Products[] _productsPicked;
    // Start is called before the first frame update
    void Start()
    {
        IsCachierRight = false;
        IsOrderReady = false;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Sell()
    {
        Panel.GetComponent<PanelStorage>().Hide();
        _productsPicked = Panel.GetComponent<PanelStorage>().Picked.ToArray();
        IsCachierRight = CheckEquality();
        IsOrderReady = true;
    }

    private bool CheckEquality()
    {
        return true;
    }

    public void ProductsSolts(Products[] productsToSell)
    {
        Panel.GetComponent<PanelStorage>().Show(productsToSell.Length);
        IsOrderReady = false;
        _productsToSell = productsToSell;
    }
}
