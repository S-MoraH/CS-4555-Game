using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerScript : MonoBehaviour
{
    public CharacterController controller;

    Animator anim;
    float speed = 5.0f;
    float speedRotate = 100.0f;
    float damage = 3;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //move up 
        if (Input.GetKey("w"))
        {
            anim.SetBool("isWalkingForward", true);    //walking animation

            
            print("w");
            Vector3 movement = new Vector3(0.0f, 0.0f, 1.0f * Time.deltaTime * speed);
            movement = transform.TransformDirection(movement);
            controller.Move(movement);
            
        }
        //if user releases key, set bool back to false
        if (!Input.GetKey("w"))
            anim.SetBool("isWalkingForward", false);

        //sprinting
        if(Input.GetKey("left shift") && Input.GetKey("w"))
        {
            print("left shift + w");

            anim.SetBool("isSprintingForward", true);
            Vector3 movement = new Vector3(0.0f, 0.0f, 1.0f * Time.deltaTime * speed * 2);
            movement = transform.TransformDirection(movement);
            controller.Move(movement);
        }
        if(!Input.GetKey("left shift") && !Input.GetKey("w"))
        {
            anim.SetBool("isSprintingForward", false);
        }

        //move left
        if (Input.GetKey("a"))
        {
            print("a");
            anim.SetBool("isWalkingLeft", true);
            Vector3 movement = new Vector3(-1.0f * Time.deltaTime * speed, 0.0f, 0.0f);
            movement = transform.TransformDirection(movement);
            controller.Move(movement);
        }
        if (!Input.GetKey("a"))
            anim.SetBool("isWalkingLeft", false);

        //rotate left
        if (Input.GetKey("w") && Input.GetKey("a"))
        {
            print("w & a");
            Vector3 rotation = new Vector3(0.0f, -1.0f * Time.deltaTime * speedRotate, 0.0f);
            transform.Rotate(rotation);
        }

        //move backwards
        if (Input.GetKey("s"))
        {
            print("s");
            anim.SetBool("isWalkingBackward", true);
            Vector3 movement = new Vector3(0.0f, 0.0f, -1.0f * Time.deltaTime * speed);
            movement = transform.TransformDirection(movement);
            controller.Move(movement);
        }
        if (!Input.GetKey("s"))
            anim.SetBool("isWalkingBackward", false);

        //move right
        if (Input.GetKey("d"))
        {
            print("d");
            anim.SetBool("isWalkingRight", true);
            Vector3 movement = new Vector3(1.0f * Time.deltaTime * speed, 0.0f, 0.0f);
            movement = transform.TransformDirection(movement);
            controller.Move(movement);
        }
        if (!Input.GetKey("d"))
            anim.SetBool("isWalkingRight", false);

        //rotate right
        if (Input.GetKey("w") && Input.GetKey("d"))
        {
            print("w & d");
            Vector3 rotation = new Vector3(0.0f, 1.0f * Time.deltaTime * speedRotate, 0.0f);
            transform.Rotate(rotation);
        }

        //jump
        if(Input.GetKey("space"))
        {
            anim.SetBool("isJumping", true);

            Vector3 jump = new Vector3(0.0f, 5.0f * Time.deltaTime, 0.0f);
            jump = transform.TransformDirection(jump);
            controller.Move(jump);
        }
        if (!Input.GetKey("space"))
            anim.SetBool("isJumping", false);

        //attack (left mouse button
        if(Input.GetMouseButton(0))
        {
            anim.SetBool("isAttack", true);
        }
        if (!Input.GetMouseButton(0))
            anim.SetBool("isAttack", false);
         
        //detects anything objects that it faces (the direction it's looking at)
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out RaycastHit hitinfo, 20f))
        {
            Debug.Log("SOMETHING is ahead");
        }
        else
            Debug.Log("NOTHING ahead");
    }

    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Monster")
        {
            Debug.Log("Monster detected");
        }

    }
}