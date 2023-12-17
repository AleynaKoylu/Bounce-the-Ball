using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject platform,leftSide,rightSide;
    public Vector3 firsPos, lastPos;
    public List<GameObject> ticks=new List<GameObject>();
    int number =0;
    [SerializeField]int basketNumber;
    void Start()
    {
        
    }

    void Update()
    {
        if (number >= basketNumber) 
        {
            print("bitti");
        }
    }
    public void Basket()
    {
        if (number < basketNumber)
        {
            number++;

            ticks[number - 1].SetActive(true);
        }
    }
    public void Move()
    {
        
        Vector3 pos = Input.mousePosition;
        pos.z = 0;
        lastPos = pos;
        Vector3 dif = lastPos-firsPos;
        platform.transform.position += new Vector3(dif.x,0,0)*Time.deltaTime;
        platform.transform.position = new Vector3(Mathf.Clamp(platform.transform.position.x, leftSide.transform.position.x, rightSide.transform.position.x), platform.transform.position.y, 0);
        firsPos = lastPos;
    }
    public void FirstMove()
    {
        Vector3 pos = Input.mousePosition;
        pos.z = 0;
        firsPos = pos;
    }
}

