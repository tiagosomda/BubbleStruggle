﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chain : MonoBehaviour {


    public Transform player;
    public float speed;

    public static bool IsFiring;

    private Vector3 NotFired;
	// Use this for initialization
	void Start () {
        IsFiring = false;
        NotFired = new Vector3(1f, 0f, 1f);
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetButtonDown("Fire1"))
        {
            IsFiring = true;
        }

        if(IsFiring)
        {
            transform.localScale += Vector3.up * speed * Time.deltaTime;
        }
        else
        {
            transform.position = player.position;
            transform.localScale = NotFired;
        }
	}
}
