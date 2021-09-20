using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Apple : Product
{

    void Start()
    {
        sprite = Resources.Load<Sprite>("Sprites/Products/Apple");
        //GetComponent<SpriteRenderer>().sprite = sprite;
    }
}
