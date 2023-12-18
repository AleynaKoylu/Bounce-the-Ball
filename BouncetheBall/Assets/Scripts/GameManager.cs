using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject platform,leftSide,rightSide,ball;
    Vector3 firsPos, lastPos;
    [SerializeField] List<GameObject> ticks=new List<GameObject>();
    int number =0;
    [SerializeField]int basketNumber;
    [SerializeField] GameObject upBasket, downBasket,basket;
    [SerializeField] List<GameObject> basketWeights = new List<GameObject>();
    int basketWeightsNumber;
    float platformLSY;
    [SerializeField] float awardTime;
    [SerializeField] List<GameObject>balls =new List<GameObject>();
    public float time;
    bool ballsActive;
    void Start()
    {
        InvokeRepeating("_BasketWeights", 2f, awardTime);
        platformLSY = platform.transform.localScale.y;
    }

    void Update()
    {

        ActiveFalseBalls();

    }
    void ActiveFalseBalls()
    {
        if (ballsActive == true)
        {
            time += Time.deltaTime;
            print((int)time);
            if (time >= 5)
            {
                foreach (var item in balls)
                {
                    item.transform.localPosition = Vector3.zero;
                    item.gameObject.SetActive(false);
                }
                time = 0;
                ballsActive= false;
            }
        }
        
    }
    public void DownorUpBasket(string name)
    {
        if (name=="UpBasket")
        {
            downBasket.SetActive(false);
            basket.SetActive(true);
        }
        else if(name=="DownBasket")
        {
            basket.SetActive(false) ;
        }
        else if (name == "UP")
        {
            downBasket.SetActive(true);
            basket.SetActive(false);
        }
        
    }
    public void Basket()
    {
        if (number < basketNumber)
        {
            number++;

            ticks[number - 1].SetActive(true);
        }
        if (number >= basketNumber)
        {
            print("bitti");
        }
    }
    public void Lose()
    {
        print("LOse");
    }

    public void Move()
    {
        
        Vector3 pos = Input.mousePosition;
        pos.z = 0;
        lastPos = pos;
        Vector3 dif = lastPos-firsPos;
        platform.transform.position += new Vector3(dif.x,0,0)*Time.deltaTime;
        ExpansionPos();
        firsPos = lastPos;
    }
    public void FirstMove()
    {
        Vector3 pos = Input.mousePosition;
        pos.z = 0;
        firsPos = pos;
    }
    void _BasketWeights()
    {
        basketWeightsNumber = Random.Range(0, basketWeights.Count);
        basketWeights[basketWeightsNumber].SetActive(true); 
    }
    public void Expansion(string name)
    {
        switch (name)
        {
            case "Expansion":
                
                    platform.transform.localScale = new Vector3(platform.transform.localScale.x, -67, platform.transform.localScale.z);
                break;
            case "Minimization":  
                    platform.transform.localScale = new Vector3(platform.transform.localScale.x, -17, platform.transform.localScale.z);
                    break;

            case "Replication":

                ballsActive = true;
                time = 0;
                if (!balls[0].activeInHierarchy)
                {
                    balls[0].transform.position = new Vector3(ball.transform.position.x + 1, ball.transform.position.y + 1, ball.transform.position.z);
                    balls[0].SetActive(true);
                }
                if (!balls[1].activeInHierarchy)
                {
                    balls[1].transform.position = new Vector3(ball.transform.position.x - 1, ball.transform.position.y + 1, ball.transform.position.z);
                    balls[1].SetActive(true);
                }
                
                break;
        }
       
    }
    void ExpansionPos()
    {
        if (platformLSY > platform.transform.localScale.y)
        {
            platform.transform.position = new Vector3(Mathf.Clamp(platform.transform.position.x,-.95f, .95f), platform.transform.position.y, 0);
        }
        else if (platformLSY < platform.transform.localScale.y)
        {
            platform.transform.position = new Vector3(Mathf.Clamp(platform.transform.position.x,-2,2), platform.transform.position.y, 0);
        }
        else if (platformLSY == platform.transform.localScale.y)
        {
            platform.transform.position = new Vector3(Mathf.Clamp(platform.transform.position.x, -1.5f, 1.5f), platform.transform.position.y, 0);
        }
    }
    
}

