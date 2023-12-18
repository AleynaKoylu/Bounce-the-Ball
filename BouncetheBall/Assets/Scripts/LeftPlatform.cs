using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class LeftPlatform : MonoBehaviour
{
    public float angle;
    public float power ;
  
 
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.gameObject.GetComponent<Rigidbody>().AddForce(new Vector3(angle, 90, 0) * power, ForceMode.Force);
        }
        if (other.gameObject.CompareTag("Balls"))
        {
            other.gameObject.GetComponent<Rigidbody>().AddForce(new Vector3(angle, 90, 0) * power, ForceMode.Force);
        }
    }
}
