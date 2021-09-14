using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buyer : MonoBehaviour
{
    [SerializeField]
    private float _timeOfMove = 5f;

    private float _timer = 0.00001f;
    private  Vector3 _startPosition;
    private  Vector3 _endPosition;

    void Start()
    {
        _startPosition = transform.position;
        _endPosition = new Vector3(-3.6f, -0.65f, 0);
    }

    // Update is called once per frame
    void Update()
    {
        _timer += Time.deltaTime;
        transform.position = Vector3.Lerp(_startPosition, _endPosition, _timer / _timeOfMove);
    }
}
