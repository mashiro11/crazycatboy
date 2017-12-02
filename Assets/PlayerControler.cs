﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControler : MonoBehaviour {

    private Transform transform;
    // Use this for initialization
    private GameObject room;
    void Start () {
        transform = gameObject.GetComponent<Transform>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void FixedUpdate()
    { 
        if (Input.GetKey(KeyCode.UpArrow))
        {
            Vector3 temp = transform.position;
            temp.y += 0.1f;
            transform.position = temp;

        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            Vector3 temp = transform.position;
            temp.y -= 0.1f;
            transform.position = temp;

        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            Vector3 temp = transform.position;
            temp.x -= 0.1f;
            transform.position = temp;

        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            Vector3 temp = transform.position;
            temp.x += 0.1f;
            transform.position = temp;

        }
    }
    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.name.Equals("Room"))
        {
            Debug.Log("Colidiu");
        }

    }
}