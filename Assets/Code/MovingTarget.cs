﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingTarget : MonoBehaviour
{
    public Animator anim;
    private float distancePj;
    public GameObject pj;
    public Boolean hited;
    // Start is called before the first frame update
    void Start()
    {
        hited = false ;
    }

    // Update is called once per frame
    void Update()
    {
        distancePj = Vector3.Distance(pj.transform.position, this.gameObject.transform.position);
        if (distancePj <= 25.0f && hited == false)
        {
            if (this.gameObject.CompareTag("MovingTarget") )
            {
                anim.Play("Movment");
            }
        }
        else
        {
            anim.Play("default");
        }
               
    }

}
