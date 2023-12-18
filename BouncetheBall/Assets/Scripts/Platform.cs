using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Platform : MonoBehaviour
{
    Vector3 firsScale;
    float time;
    void Start()
    {
        firsScale= transform.localScale;
        
    }
    void Update()
    {
      
        if (firsScale.y != transform.localScale.y)
        {
            FirsScale();
        }
    }
    void FirsScale()
    {
        time += Time.deltaTime;
        if (time >= 3)
        {
            transform.localScale = firsScale;
            time = 0;
        }
    }
}
