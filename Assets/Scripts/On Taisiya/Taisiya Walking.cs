using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaisiyaWalking : MonoBehaviour
{
    private Rigidbody2D taisiya;
    public float speedHor = 1f, speedVer = 0.3f;
    public Animator anim;
    private Vector2 moveVector;

    private void Awake(){
        taisiya = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    private void FixedUpdate(){
        Walking();
    }

    private void Walking(){
        StopAnimation();
        moveVector = new Vector2(Input.GetAxis("Horizontal")*speedHor, Input.GetAxis("Vertical")*speedVer);
        taisiya.velocity = transform.TransformDirection(moveVector);
        StartAnimation();
    }

    private void StopAnimation(){
        anim.SetBool("W", false);
        anim.SetBool("A", false);
        anim.SetBool("S", false);
        anim.SetBool("D", false);
    }

    private void StartAnimation(){
        if(taisiya.velocity != new Vector2(0, 0)){
            if (moveVector.x > 0) anim.SetBool("D", true);
            if (moveVector.x < 0) anim.SetBool("A", true);
            if (moveVector.y > 0) anim.SetBool("W", true);
            if (moveVector.y < 0) anim.SetBool("S", true);
        }
    }
}
