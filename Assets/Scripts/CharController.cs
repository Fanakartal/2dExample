using UnityEngine;
using System.Collections;

public class CharController : MonoBehaviour {

    float maxSpeed = 6f;
    float jumpForce = 1000f;
    float groundRadius = 0.2f;
    
    //bool facingRight = true;
    bool grounded;
    
    public Transform groundCheck;
    public LayerMask whatIsGround;

    //GameObject camera;
    Rigidbody2D cameraRigid;
    
    
    // Use this for initialization
	void Start () 
    {
        //yield return new WaitForSeconds(5.0f);
        //yield return StartCoroutine(WaitABit(5.0f));
	}
	
	// Update is called once per frame
	void FixedUpdate () 
    {
        grounded = Physics2D.OverlapCircle(groundCheck.position, groundRadius, whatIsGround);
        /*float move = -(transform.position.x);*/ //Input.GetAxis("Horizontal");

        rigidbody2D.velocity = new Vector2(/*move * */ maxSpeed, rigidbody2D.velocity.y);


        //if (move > 0 && !facingRight) Flip();
       //if (Input.GetKeyDown(KeyCode.Space)) Flip();
        //else if (move < 0 && facingRight) Flip();
        
	}

     void Update()
    {
        
         if (grounded && Input.GetKeyDown(KeyCode.Space))
        {
            if(rigidbody2D.gravityScale == 1)
                rigidbody2D.AddForce(new Vector2(0, jumpForce));
            else
                rigidbody2D.AddForce(new Vector2(0, -jumpForce));
            
            Flip();
            rigidbody2D.gravityScale *= -1;
               
        }
    }

    //void OnCollisionEnter2D(Collision2D other)
    //{
    //    if (other.gameObject.tag == "DeadEnd")
    //        Destroy(other.gameObject);
    //}

    void Flip()
    {
        //transform.rotation *= Quaternion.Euler(transform.rotation.x, transform.rotation.y, transform.rotation.z + 180);
        //facingRight = !facingRight;
        
        Vector3 theScale = transform.localScale;
        
        theScale.y = theScale.y * -1;

        //theScale.y = theScale.y * -1;
        transform.localScale = theScale;
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        //GameObject.FindGameObjectWithTag("MainCamera")

        /*if (other.gameObject.tag == "House")
        {
            //Destroy(GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CameraController>());
            //GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CameraController>().enabled = false;
            camera = GameObject.FindGameObjectWithTag("MainCamera");
            cameraRigid = camera.GetComponent<Rigidbody2D>();
            cameraRigid.velocity = new Vector2(0, 0);
        }

        else
        {
        }
         * */
    }

    IEnumerator WaitABit(float waitTime)
    {
        print("start");
        yield return new WaitForSeconds(waitTime);
        print("finish");
    }
}
