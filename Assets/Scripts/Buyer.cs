using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buyer : MonoBehaviour
{
    const int MIN_ORDER_COUNT = 1;
    const int MAX_ORDER_COUNT = 4;
    private static int _enumProductsCount = Products.GetNames(typeof(Products)).Length;

    [SerializeField]
    private float _timeOfMove = 5f;
    [SerializeField]
    private GameObject _union;
    [SerializeField]
    private Cachier _cachier;

    private float _timer;
    private Vector2 _startPosition;
    private Vector2 _endPosition;
    private bool _isReadyToOrder; //final destination in each move
    public bool _isReadyToDie;
    private int _productsToOrderCount;
    protected Products[] _prods;

    protected bool _isOrderGetted;
    protected bool _isHappy;

    void Start()
    {
        _cachier = GameObject.Find("Cachier").GetComponent<Cachier>();
        Debug.Log($"_cachier = {_cachier}");
        _timer = 0f;
        _startPosition = new Vector2(transform.position.x, transform.position.y);
        _endPosition = new Vector3(-3.6f, -0.65f);
        _isReadyToOrder = false;
        _isReadyToDie = false;

        _productsToOrderCount = Random.Range(MIN_ORDER_COUNT, MAX_ORDER_COUNT);
        _prods = new Products[_productsToOrderCount];

        _isOrderGetted = false;
        _isHappy = true;

        StartCoroutine(CycleCoroutine());
    }

    void Update()
    {
        if(!_isReadyToDie && !_isReadyToOrder)
        {
            if(!_isOrderGetted)
            {
                _isReadyToOrder = Move(_startPosition, _endPosition);
            }
            else
            {
                transform.localScale = new Vector3(-1, 1, 1);
                _isReadyToDie = Move(_endPosition, _startPosition);
            }
        }
    }

    IEnumerator CycleCoroutine()
    {
        Debug.Log("Almost Come!");
        yield return new WaitUntil(() => _isReadyToOrder);

        Debug.Log("Is Come To Order!");
        _isReadyToOrder = true;
        Debug.Log($"_isReadyToOrder = {_isReadyToOrder}\n_productsToOrderCount = {_productsToOrderCount}\n_prods = {_prods[0]}");
        _cachier.ProductsSolts(ref _prods);
        _union.SetActive(true);
        yield return new WaitUntil(() => _cachier.IsOrderReady());

        _isOrderGetted = true;
        _isReadyToOrder = false;
        Debug.Log("Order is Getted!");
        yield return new WaitUntil(() => _isReadyToDie);
    }

    private void ProductGenerating()
    {
        for (int i = 0; i < _prods.Length; i++)
        {
            _prods[i] = (Products)Random.Range(1, _enumProductsCount + 1);
        }
    }



    private bool Move(Vector2 a, Vector2 b)
    {
        bool isCome = false;
        _timer += Time.deltaTime;
        transform.position = Vector2.Lerp(a, b, _timer / _timeOfMove);
        if(_timer > _timeOfMove)
        {
            isCome = true;
            _timer = 0f;
        }

        return isCome;
    }
}
