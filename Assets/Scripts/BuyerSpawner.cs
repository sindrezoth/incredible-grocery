using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuyerSpawner : MonoBehaviour
{

    public GameObject Buyer;

    private List<GameObject> _buyers;
    // Start is called before the first frame update
    void Start()
    {
        _buyers = new List<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyUp(KeyCode.Space))
        {
            Spawn();
        }

        for (int i = 0; i < _buyers.Count; i++) {
            /*if((_buyers[i] as Buyer)._isReadyToDie == true)
            {
                GameObject temp = _buyers[i];  //idk, one gameobject inside my list and another unity's gameobjects array
                _buyers.Remove(_buyers[i]);    //probably delete from at least one of them i can lose both references (but i think of course no)
                Destroy(temp);
            }*/
        }
    }

    void Spawn()
    {
        _buyers.Add(Instantiate(Buyer, transform.position, Quaternion.identity));
    }
}
