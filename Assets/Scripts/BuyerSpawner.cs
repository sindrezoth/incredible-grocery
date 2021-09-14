using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuyerSpawner : MonoBehaviour
{

    public GameObject buyer;

    private List<GameObject> buyers;
    // Start is called before the first frame update
    void Start()
    {
        buyers = new List<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyUp(KeyCode.Space))
        {
            Spawn();
        }
    }

    void Spawn()
    {
        buyers.Add(Instantiate(buyer, transform.position, Quaternion.identity));
    }
}
