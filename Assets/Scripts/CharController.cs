using UnityEngine;
using System.Collections;

public class CharController : MonoBehaviour {

    float maxSpeed = 8.0f;
    float jumpForce = 1000f;
    float groundRadius = 0.2f;
    float timeToFly = 3.0f;
    float timePassed;
    
    //bool facingRight = true;
    bool grounded;
    
    public Transform groundCheck;
    public LayerMask whatIsGround;
    public GUIText textYouWon;

    //GameObject camera;
    //Rigidbody2D cameraRigid;
    
    
    // Use this for initialization
	void Start () 
    {
        Debug.Log("Time is set.");
        Time.timeScale = 1;
        textYouWon.enabled = false;
        //yield return new WaitForSeconds(5.0f);
        //yield return StartCoroutine(WaitABit(5.0f));
	}
	
	// Update is called once per frame
	void FixedUpdate () 
    {
        grounded = Physics2D.OverlapCircle(groundCheck.position, groundRadius, whatIsGround);
        rigidbody2D.velocity = new Vector2(/*move * */ maxSpeed, rigidbody2D.velocity.y);


        /*float move = -(transform.position.x);*/
        //Input.GetAxis("Horizontal");

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
            else if(rigidbody2D.gravityScale == -1)
                rigidbody2D.AddForce(new Vector2(0, -jumpForce));
            
            Flip();
            rigidbody2D.gravityScale *= -1;
            timePassed = 0.0f;
               
        }

        if (grounded && rigidbody2D.gravityScale == -1)
        {
            //print("yukarıda");
            timePassed = timePassed + Time.deltaTime;// 1.0f;
            Debug.Log(timePassed);

            if (timePassed >= timeToFly)
            {
                rigidbody2D.AddForce(new Vector2(0, -jumpForce));
                Flip();
                rigidbody2D.gravityScale *= -1;
                timePassed = 0.0f;
            }
        }

        //Debug.Log(rigidbody2D.velocity.x);
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
        transform.localScale = theScale;
        
    }

    IEnumerator OnTriggerEnter2D(Collider2D other)
    {
        //GameObject.FindGameObjectWithTag("MainCamera")

        if (other.gameObject.tag == "House")
        {
            textYouWon.enabled = true;
            print("Starting " + Time.time);
            yield return StartCoroutine(WaitABit(2.0f));
            print("Before WaitAndPrint Finishes " + Time.time);
            yield return StartCoroutine(StopEverything());

            Application.LoadLevel(0);
        }

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

        yield return new WaitForSeconds(waitTime);

        print("WaitAndPrint " + Time.time);
    }

    IEnumerator StopEverything()
    {
        yield return new WaitForSeconds(0.0f);
        Time.timeScale = 0.0f;
        print("Time has stopped.");
    }
}
