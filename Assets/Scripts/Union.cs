using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Union : MonoBehaviour
{
    [SerializeField]
    GameObject Slot1;
    private SpriteRenderer _sprite1;
    [SerializeField]
    GameObject Slot2;
    private SpriteRenderer _sprite2;
    [SerializeField]
    GameObject Slot3;
    private SpriteRenderer _sprite3;
    [SerializeField]
    GameObject Slot4;
    private SpriteRenderer _sprite4;
    [SerializeField]
    GameObject Slot5;
    private SpriteRenderer _sprite5;
    [SerializeField]
    GameObject Slot6;
    private SpriteRenderer _sprite6;

    [SerializeField]
    Sprite Apple;
    [SerializeField]
    Sprite Avocado;
    [SerializeField]
    Sprite Bananas;
    [SerializeField]
    Sprite Beacaon;
    [SerializeField]
    Sprite Beer;
    [SerializeField]
    Sprite Beet;
    [SerializeField]
    Sprite Blueberry;
    [SerializeField]
    Sprite Beans;
    [SerializeField]
    Sprite Broccoli;
    [SerializeField]
    Sprite Butter;
    [SerializeField]
    Sprite Salad;
    [SerializeField]
    Sprite Cake;
    [SerializeField]
    Sprite Bone;
    [SerializeField]
    Sprite Borsch;
    [SerializeField]
    Sprite ChickenGrill;
    [SerializeField]
    Sprite Bread;
    [SerializeField]
    Sprite Chocolate;
    [SerializeField]
    Sprite CandyStick;
    [SerializeField]
    Sprite Candies;
    [SerializeField]
    Sprite Nice;
    [SerializeField]
    Sprite Unnice;
    [SerializeField]
    Sprite Wrong;
    [SerializeField]
    Sprite Right;

    public void Start()
    {
        _sprite1 = Slot1.GetComponent<SpriteRenderer>();
        _sprite2 = Slot2.GetComponent<SpriteRenderer>();
        _sprite3 = Slot3.GetComponent<SpriteRenderer>();
        _sprite4 = Slot4.GetComponent<SpriteRenderer>();
        _sprite5 = Slot5.GetComponent<SpriteRenderer>();
        _sprite6 = Slot6.GetComponent<SpriteRenderer>();

    }

    public void Show(Products[] prods)
    {
        int _countOfSigns = prods.Length;
        float mul = 0.7f;
        if (_countOfSigns == 1)
        {
            Slot1.transform.localPosition = new Vector3(0f, 0.2f, 0f);
            Slot1.transform.localScale = new Vector3(mul, mul, mul);
            Slot1.GetComponent<SpriteRenderer>().sprite = Convert(prods[0]);
            Slot1.SetActive(true);
        }
        else if(_countOfSigns == 2)
        {
            Slot1.transform.localPosition = new Vector3(-0.5f, 0.2f, 0);
            Slot1.transform.localScale = new Vector3(mul, mul, mul);
            Slot1.GetComponent<SpriteRenderer>().sprite = Convert(prods[0]);
            Slot1.SetActive(true);

            Slot2.transform.localPosition = new Vector3(0.5f, 0.2f, 0);
            Slot2.transform.localScale = new Vector3(mul, mul, mul);
            Slot2.GetComponent<SpriteRenderer>().sprite = Convert(prods[1]);
            Slot2.SetActive(true);
        }
        else if(_countOfSigns == 3)
        {
            Slot1.transform.localPosition = new Vector3(-0.8f, 0.2f, 0);
            Slot1.transform.localScale = new Vector3(mul, mul, mul);
            Slot1.GetComponent<SpriteRenderer>().sprite = Convert(prods[0]);
            Slot1.SetActive(true);

            Slot2.transform.localPosition = new Vector3(0.0f, 0.2f, 0);
            Slot2.transform.localScale = new Vector3(mul, mul, mul);
            Slot2.GetComponent<SpriteRenderer>().sprite = Convert(prods[1]);
            Slot2.SetActive(true);

            Slot3.transform.localPosition = new Vector3(0.8f, 0.2f, 0);
            Slot3.transform.localScale = new Vector3(mul, mul, mul);
            Slot3.GetComponent<SpriteRenderer>().sprite = Convert(prods[2]);
            Slot3.SetActive(true);
        }
        gameObject.SetActive(true);
    }

    public void Show(bool isHappy)
    {
        Slot1.transform.localPosition = new Vector3(0f, 0.2f, 0f);
        if (isHappy) {
            Slot1.GetComponent<SpriteRenderer>().sprite = Nice;
        }
        else
        {
            Slot1.GetComponent<SpriteRenderer>().sprite = Unnice;
        }
        Slot1.SetActive(true);
        gameObject.SetActive(true);
    }

    public void Refresh()
    {
        Slot1.SetActive(false);
        Slot2.SetActive(false);
        Slot3.SetActive(false);
        Slot4.SetActive(false);
        Slot5.SetActive(false);
        Slot6.SetActive(false);

        gameObject.SetActive(false);
    }
    Sprite Convert(Products prod)
    {
        Sprite result;
        switch(prod)
        {
            case Products.Apple:
                result = Apple;
                break;
            case Products.Avocado:
                result = Avocado;
                break;
            case Products.Bananas:
                result = Bananas;
                break;
            case Products.Beacon:
                result = Beacaon;
                break;
            case Products.Beer:
                result = Beer;
                break;
            case Products.Beet:
                result = Beet;
                break;
            case Products.Blueberry:
                result = Blueberry;
                break;
            case Products.Beans:
                result = Beans;
                break;
            case Products.Broccoli:
                result = Broccoli;
                break;
            case Products.Butter:
                result = Butter;
                break;
            case Products.Salad:
                result = Salad;
                break;
            case Products.Cake:
                result = Cake;
                break;
            case Products.Bone:
                result = Bone;
                break;
            case Products.Borsch:
                result = Borsch;
                break;
            case Products.ChickenGrill:
                result = ChickenGrill;
                break;
            case Products.Bread:
                result = Bread;
                break;
            case Products.Chocolate:
                result = Chocolate;
                break;
            case Products.CandyStick:
                result = CandyStick;
                break;
            case Products.Candies:
                result = Candies;
                break;
            default:
                result = Apple;
                break;
        }

        return result;
    }


}
