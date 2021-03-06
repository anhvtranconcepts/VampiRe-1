﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NpcBehaviour : MonoBehaviour
{
    public Transform target;
    public float angleOfView;
    public float distanceOfView;
    public bool isDead;
    public bool rightShoulderGrabbed;
    public bool leftShoulderGrabbed;
    Animator anim;
    RaycastHit hit;

    void Start() 
    {
        anim = GetComponent<Animator>();
        isDead = false;
	}

    void Update ()
    {

        PlayerDetection();

        //if (Input.GetKey(KeyCode.A))
        //{
        //    leftShoulderGrabbed = true;
        //}
        //else
        //{
        //    leftShoulderGrabbed = false;
        //}
        //if (Input.GetKey(KeyCode.D))
        //{
        //    rightShoulderGrabbed = true;
        //}
        //else
        //{
        //    rightShoulderGrabbed = false;
        //}
        if (Input.GetKey(KeyCode.Space))
        {
            isDead = true;
            anim.SetBool("isDead", true);
        }
	}

    public bool ICanSeeThePlayer = false;

    void PlayerDetection()
    {
        var targetDir = target.position - transform.position;
        float angle = Vector3.Angle(targetDir, transform.forward);
        float distance = Vector3.Distance(target.position, transform.position);
        print(distance + ": between target and npc");
        if (angle <= angleOfView && distance <= distanceOfView)
        {
            Debug.DrawLine(transform.position, target.transform.position, Color.blue);
            if (Physics.Linecast(transform.position, target.transform.position, out hit))
            {
                if (hit.collider.CompareTag("Player"))
                {
                    print("NPC can see player");
                    ICanSeeThePlayer = true;
                }
                else
                {
                    ICanSeeThePlayer = false;
                }
            }
        }
    }
}
