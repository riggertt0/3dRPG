using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryActivate : MonoBehaviour
{
    [SerializeField] private GameObject canvas;

    public bool isPaused = false;
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            canvas.SetActive(!canvas.activeSelf);
            if (!isPaused)
            {
                Time.timeScale = 0;
                isPaused = true;
            }
            else
            {
                Time.timeScale = 1;
                isPaused = false;
            }
        }
    }
}
