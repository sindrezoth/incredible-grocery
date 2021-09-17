using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cachier : MonoBehaviour
{

    private bool _isOrderReady;
    private Products[] _productsToSell;
    // Start is called before the first frame update
    void Start()
    {
        _isOrderReady = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.Y))
        {
            _isOrderReady = true;
        }
    }


    public bool IsOrderReady()
    {
        return _isOrderReady;
    }

    public void ProductsSolts(ref Products[] productsToSell)
    {
        _isOrderReady = false;
        _productsToSell = productsToSell;
    }
}
