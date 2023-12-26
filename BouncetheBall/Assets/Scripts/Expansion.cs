using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Expansion : MonoBehaviour
{
    [SerializeField] GameManager gameManager;
    [SerializeField] string namee;
    public string itemName;
    public bool activeHave;

    private void Start()
    {
        StartCoroutine(NoActive());
        gameManager.activeItem++;
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {

            gameManager.Expansion(namee);
            gameObject.SetActive(false);
        }

    }
    IEnumerator NoActive()
    {
        
        yield return new WaitForSeconds(3);
        gameObject.SetActive(false);
      
    }
}
