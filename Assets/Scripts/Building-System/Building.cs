using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Building : MonoBehaviour
{
    //public int cost;
    //public int goldIncrease;
    //public float timeBtwIncreases;
    //public float nextIncreasesTime;

    private GameManager gm;


    void Start()
    {
        gm = FindObjectOfType<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        //if (Time.time>nextIncreasesTime) 
        //{
        //    nextIncreasesTime = Time.time+timeBtwIncreases;
        //    gm.gold += goldIncrease;
        //}
    }
}
