using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float movementSpeed = 10;
    public static float vertical, horizontal;

    Vector3 directive = new Vector3(0, 0, 1);

    private Rigidbody rb;
    Vector3 moveVect = new Vector3(0.0f, 0.0f, 2.0f);

    LayerMask mask;

    public Vector3 moveVector;

    GameObject enemy;


    void Start()
    {
        mask = LayerMask.GetMask("Place");
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (!(Camera.main.GetComponent<InventoryActivate>().isPaused))
        {
            moveVector.x = Input.GetAxis("Horizontal");
            moveVector.z = Input.GetAxis("Vertical");
            if (Input.GetButton("Horizontal") && Input.GetButton("Vertical"))
            {
                rb.velocity = new Vector3(moveVector.x * movementSpeed / Mathf.Sqrt(2), rb.velocity.y, rb.velocity.z);
                rb.velocity = new Vector3(rb.velocity.x, rb.velocity.y, moveVector.z * movementSpeed / Mathf.Sqrt(2));
            }
            else if (Input.GetButton("Vertical"))
            {
                rb.velocity = new Vector3(0, rb.velocity.y, moveVector.z * movementSpeed);
            }
            else if (Input.GetButton("Horizontal"))
            {
                rb.velocity = new Vector3(moveVector.x * movementSpeed, rb.velocity.y, 0);
            }
            else
            {
                rb.velocity = new Vector3(moveVector.x * movementSpeed / Mathf.Sqrt(2), rb.velocity.y, rb.velocity.z);
                rb.velocity = new Vector3(rb.velocity.x, rb.velocity.y, moveVector.z * movementSpeed / Mathf.Sqrt(2));
            }

            Vector3 mouse = Input.mousePosition;
            Ray castPoint = Camera.main.ScreenPointToRay(mouse);
            RaycastHit hit;

            if (Physics.Raycast(castPoint, out hit, Mathf.Infinity, mask))
            {
                Vector3 rotation_vec = new Vector3(0, 0, 0);
                rotation_vec.x = hit.point.x - transform.position.x;
                rotation_vec.z = hit.point.z - transform.position.z;
                transform.rotation = Quaternion.FromToRotation(directive, rotation_vec);
            }
        }
    }
}
