using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animal : MonoBehaviour
{
    
    public float jumpSpeed { get; protected set;}
    public float walkSpeed { get; protected set;}
    public float turnSpeed { get; protected set;}

    protected bool isGrounded = false;
    public bool isSelected { get; set; } = false;


    void Start()
    {
    }

    void FixedUpdate()
    {
        if (isSelected){
            if (isGrounded && Input.GetKeyDown(KeyCode.Space)){
                Jump();
            }else{
                Walk();
            }
        }           
    }

    

    private void OnCollisionEnter(Collision other) {
        if(other.gameObject.tag == "Ground"){
            isGrounded=true;
            onJumpEnded();
        }
    }

    

    public virtual void Jump(){
        GetComponent<Rigidbody>().velocity = Vector3.up * jumpSpeed;
        isGrounded=false;
    }

    public virtual void onJumpEnded(){
    }

    protected virtual void Walk(){
        float verticalInput=Input.GetAxis("Vertical");
        float horizontalInput=Input.GetAxis("Horizontal");

        Vector3 forwardMovement = transform.forward * verticalInput;
        Vector3 rightMovement = transform.right * horizontalInput;

        GetComponent<Rigidbody>().velocity = (forwardMovement) * walkSpeed;
        transform.Rotate(Vector3.up * Time.deltaTime * turnSpeed * horizontalInput);
    }

    public virtual string GetName(){
        return "Animal";
    }

}
