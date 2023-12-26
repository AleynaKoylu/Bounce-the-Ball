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
           
            gameManager.Lose();
            
        }
        if (collision.gameObject.CompareTag("DownBasket"))
        {
            gameManager.DownorUpBasket("DownBasket");
        }
        if (collision.gameObject.CompareTag("UpBasket"))
        {
            gameManager.DownorUpBasket("UpBasket");
        }
        
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("UP"))
        {
            gameManager.DownorUpBasket("UP");
           
        }
    }

}
