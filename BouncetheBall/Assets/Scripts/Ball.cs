using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public GameManager gameManager;
    void Start()
    {
        
    }

    
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Basket"))
        {
            gameManager.Basket();
        }
        if (collision.gameObject.CompareTag("Down"))
        {
            Time.timeScale = 0;
        }
    }
   
}
