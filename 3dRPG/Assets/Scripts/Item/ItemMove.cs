using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemMove : MonoBehaviour
{
    private GameObject player;
    public float speed;
    public float distance;

    void Start()
    {
        player = GameObject.Find("Player");
    }

    void Update()
    {
        if (player != null)
        {
            Vector3 playerPos = player.transform.position;
            Vector3 itemPos = transform.position;

            if (Vector3.Distance(playerPos, itemPos) < distance)
            {
                transform.position = Vector3.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
            }
        }
    }
}
