using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cuvecam : MonoBehaviour
{
    LayerMask mask;
    // Start is called before the first frame update
    void Start()
    {
        mask = LayerMask.GetMask("Place");
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mouse = Input.mousePosition;
        Ray castPoint = Camera.main.ScreenPointToRay(mouse);
        RaycastHit hit;
        if (Physics.Raycast(castPoint, out hit, Mathf.Infinity, mask))
        {
            this.transform.position = hit.point;
        }
    }
}
