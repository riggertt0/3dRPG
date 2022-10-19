using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseProjectile : MonoBehaviour
{
    public float Damage;

    void OnTriggerEnter(Collider Collision)
    {
        if (Collision.tag != "Player" && Collision.tag != "Projectile" && Collision.tag != "Open_door")
        {
            if (Collision.GetComponent<ReceiveDamage>() != null)
            {
                Collision.GetComponent<ReceiveDamage>().DealDamage(Damage);
            }
        }
    }
}
