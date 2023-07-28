using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

public class SpawnObject : MonoBehaviour
{

    public GameObject targetPrefab; 
    private int delay;
    // Update is called once per frame
    void Start()
    {
        
    }
    void Update()
    {
        Random ran = new Random();
        var shoot = Input.GetAxis("Fire2");
        if (shoot > 0 && delay <= 0)
        {
            delay = 10;
            Gravity velo = Instantiate(targetPrefab, new Vector3(90,ran.Next(-90,90),90), Quaternion.identity).GetComponent<Gravity>();
            velo.Velocity = new Vector3(ran.Next(-20,20) * 2, ran.Next(-20, 20) * 2, ran.Next(-20, 20) * 2);
            //Gravity velo = object.getComponent<Gravity>();
        }
        delay--;
    }
}
