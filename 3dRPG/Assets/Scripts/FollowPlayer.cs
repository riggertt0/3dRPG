using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public float distance = 30;
    
    GameObject player;
    public List<GameObject> transparentObj;
    LayerMask mask;

    void Start()
    {
        player = GameObject.Find("Player");
        mask = LayerMask.GetMask("Building", "Place", "Transparent Place");
    }

    void Update()
    {
        transform.position = new Vector3(player.transform.position.x,
        player.transform.position.y + distance / 2, 
        player.transform.position.z - Mathf.Sqrt(3) * distance / 2);

        Vector3 start = new Vector3(Screen.width / 2, Screen.height / 2, 0);

        Ray castPoint = Camera.main.ScreenPointToRay(start);
        RaycastHit[] hitColliders = Physics.RaycastAll(castPoint, distance, mask);

        foreach (RaycastHit iter in hitColliders)
        {
            GameObject building = iter.transform.gameObject;
            Color color = iter.transform.gameObject.GetComponent<MeshRenderer>().materials[0].color;
            iter.transform.gameObject.GetComponent<MeshRenderer>().materials[0].color = new Color(color.r, color.g, color.b, 0.5f);
            if(iter.transform.gameObject.layer == 6)
                iter.transform.gameObject.layer = LayerMask.NameToLayer("Transparent Place");

            transparentObj.Add(building);
        }

        for (int i = 0; i < transparentObj.Count; ++i)
        {
            if (!CheckElementsMatch(hitColliders, transparentObj[i])) 
            {
                Color color = transparentObj[i].GetComponent<MeshRenderer>().materials[0].color;
                transparentObj[i].GetComponent<MeshRenderer>().materials[0].color = new Color(color.r, color.g, color.b, 1.0f);
                if(transparentObj[i].layer == 8)
                    transparentObj[i].layer = LayerMask.NameToLayer("Place");
                transparentObj.RemoveAt(i);
            }
        }
    }

    bool CheckElementsMatch(RaycastHit[] hitColliders, GameObject obj)
    {
        foreach (RaycastHit iter in hitColliders)
        {
            if (iter.transform.gameObject == obj)
                return true;
        }
        return false;
    }
}
