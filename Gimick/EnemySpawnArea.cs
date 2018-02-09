﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnArea : MonoBehaviour
{
    //public bool inArea { get { return (OldinArea || NowInArea); } }
    public bool inArea = false;
    [SerializeField]
    private bool NowInArea,OldinArea;
    public float time;

    private void Update()
    {
        //OldinArea = NowInArea;
        //NowInArea = false;
        //Debug.Log("Update");
        if (time - Time.time < -1) {
            inArea = false;
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.GetComponent<Character>())
        {
            time = Time.time;
            //NowInArea = true;
            inArea = true;
            //Debug.Log("Stay");
        }
    }
    
}
