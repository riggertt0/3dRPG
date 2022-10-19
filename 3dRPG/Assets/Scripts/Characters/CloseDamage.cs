using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseDamage : MonoBehaviour
{
    public GameObject projectile;
    public float minDamage;
    public float maxDamage;
    public float cooldownTime;
    public float projectileForce;
    public float projectile_distance;
    private float nextFireTime = 0f;

    void Start()
    {
        nextFireTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > nextFireTime)
        {
            if (Time.timeScale != 0f)
            {
                if (Input.GetMouseButtonDown(0))
                {
                    nextFireTime = Time.time + cooldownTime;

                    GameObject Hit = Instantiate(projectile, transform.position, Quaternion.identity);
                    Vector3 myPos = transform.position;

                    Hit.transform.rotation = transform.rotation;

                    var prediction = transform.forward;

                    Hit.GetComponent<DistanceProjectile>().start_pos = myPos;
                    Hit.GetComponent<DistanceProjectile>().distance = projectile_distance;

                    Hit.GetComponent<Rigidbody>().velocity = prediction * projectileForce + GetComponent<Rigidbody>().velocity;
                    Hit.GetComponent<CloseProjectile>().Damage = Random.Range(minDamage, maxDamage);
                }
            }
        }

    }
}
