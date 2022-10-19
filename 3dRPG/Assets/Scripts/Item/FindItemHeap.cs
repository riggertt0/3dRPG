using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FindItemHeap : MonoBehaviour
{
    [SerializeField] private GameObject Inventory;

    void Start()
    {
        Inventory = GameObject.Find("Inventory");
    }

    void OnTriggerEnter(Collider Collision)
    {
        if (Collision.tag == "Item heap")
        {
            Inventory.GetComponent<Inventory>().IsFreePlace = false;
            Debug.Log("cho");
        }
    }
}
