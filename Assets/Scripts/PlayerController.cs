using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float movementSpeed;
    public float rotateSpeed;
    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    //called before physics calculations
    private void FixedUpdate()
    {
        Movement();
        //get input from arrow keys (set from input manager)
        /*
        float moveHorizontal = Input.GetAxisRaw("Horizontal");
        float moveVertical = Input.GetAxisRaw("Vertical");

        Vector3 movementDirection = new Vector3(moveHorizontal, 0.0f, moveVertical);
        rb.AddForce(movementDirection * movementSpeed);
        transform.rotation = Quaternion.LookRotation(-rb.velocity);
        */       
    
        /*
        float moveHorizontal = Input.GetAxisRaw("Horizontal");
        float moveVertical = Input.GetAxisRaw("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        transform.rotation = Quaternion.LookRotation(movement);


        transform.Translate(movement * speed * Time.deltaTime, Space.World);
        */       


    }

    void Movement() 
    {
        //get input from arrow keys (set from input manager)
        float moveHorizontal = Input.GetAxisRaw("Horizontal");
        float moveVertical = Input.GetAxisRaw("Vertical");
        Vector3 movementDirection = new Vector3(moveHorizontal, 0.0f, moveVertical);

        if (movementDirection != Vector3.zero) {
            transform.rotation = Quaternion.Slerp(transform.rotation,Quaternion.LookRotation(movementDirection),rotateSpeed*Time.deltaTime);
        }
        rb.MovePosition(transform.position+movementSpeed*Time.deltaTime*movementDirection);
    }
}
