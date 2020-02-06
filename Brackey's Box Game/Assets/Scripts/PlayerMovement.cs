using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //reference to the RigidBody component as 'rb'
    public Rigidbody rb;
    public float forwardforce = 2000;
    public float sidewaysForce = 500;
    public float jumpSpeed = 250;

    public GameObject leftButton, rightButton;
   

    bool OnGround = true;


   
    // Update is called once per frame
    void FixedUpdate() //for physics stuff use FixUpdate()
    {
       
        //add a forward force
        rb.AddForce(0, 0, forwardforce * Time.deltaTime); //add a froce of 2000 on the Z axis

        if(Input.GetKey("d"))
        {
            //addforce to right
            rb.AddForce(sidewaysForce * Time.deltaTime, 0, 0,ForceMode.VelocityChange);
        }
        if (Input.GetKey("a"))
        {
            //add force to left
            rb.AddForce(-sidewaysForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
        }

        if (rb.position.y < -1f)
        {
            FindObjectOfType <GameManager>().GameOver();
        }
        if(OnGround)
        {
            if(Input.GetKey("w"))
            {
                rb.velocity = new Vector3(0, 7f, jumpSpeed* Time.deltaTime);
                OnGround = false;
                

            }
        }
        
    }
   
}
