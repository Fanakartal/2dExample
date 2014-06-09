using UnityEngine;
using System.Collections;

public class CharController : MonoBehaviour {

    float maxSpeed = 8.0f;
    float jumpForce = 1000f;
    float groundRadius = 0.2f;
    float timeToFly = 2.0f;
    float timePassed;
    //int collidedWithEnemy;
    
    //bool facingRight = true;
    bool grounded;
    
    public Transform groundCheck;
    public Texture2D image;
    public LayerMask whatIsGround;
    //public GUIText textYouWon;
   
    // Use this for initialization
	void Start () 
    {
        //collidedWithEnemy = 0;
        Debug.Log("Time is set.");
        Time.timeScale = 1;
        
        //textYouWon.enabled = false;
	}
	
	// Update is called once per frame
    void Update()
    {
        //if (collidedWithEnemy == 0)
        //{
            if (grounded && Input.GetKeyDown(KeyCode.Space))
            {
                if (rigidbody2D.gravityScale == 1)
                    rigidbody2D.AddForce(new Vector2(0, jumpForce));
                else if (rigidbody2D.gravityScale == -1)
                    rigidbody2D.AddForce(new Vector2(0, -jumpForce));

                Flip();
                rigidbody2D.gravityScale *= -1;
                timePassed = 0.0f;
            }

            if (grounded && rigidbody2D.gravityScale == -1)
            {
                timePassed = timePassed + Time.deltaTime;
                Debug.Log(timePassed);

                if (timePassed >= timeToFly)
                {
                    rigidbody2D.AddForce(new Vector2(0, -jumpForce));
                    Flip();
                    rigidbody2D.gravityScale *= -1;
                    timePassed = 0.0f;
                }
            }
        //}
    }
    
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

    void OnGUI()
    {
        if (timePassed > 0.0f && timePassed < 0.7f)
        {
            //GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), image, ScaleMode.ScaleToFit, true);
            
            //GUI.Box(new Rect(Screen.width / 2 - image.width, 0, 50, 50), image);
            //GUI.Box(new Rect(Screen.width / 2 - (image.width * 2), 0, 50, 50), image);
            
            //GUI.Box(new Rect(Screen.width - (Screen.width / 16), 0, 50, 50), image);
            //GUI.Box(new Rect(Screen.width - ((Screen.width / 16) * 2), 0, 50, 50), image);
            //GUI.Box(new Rect(Screen.width - ((Screen.width / 16) * 3), 0, 50, 50), image);

            GUI.Box(new Rect(1520, 0, 50, 50), image);
            GUI.Box(new Rect(1480, 0, 50, 50), image);
            GUI.Box(new Rect(1440, 0, 50, 50), image);
        }
        else if (timePassed > 0.7f && timePassed < 1.4f)
        {
            GUI.Box(new Rect(1480, 0, 50, 50), image);
            GUI.Box(new Rect(1440, 0, 50, 50), image);
        }
        else if (timePassed > 1.4f && timePassed < 2.05f)
        {
            GUI.Box(new Rect(1440, 0, 50, 50), image);
        }

        else
        {
            GUI.Box(new Rect(1520, 0, 50, 50), image);
            GUI.Box(new Rect(1480, 0, 50, 50), image);
            GUI.Box(new Rect(1440, 0, 50, 50), image);
        }
    }
    
    void Flip()
    {
        //transform.rotation *= Quaternion.Euler(transform.rotation.x, transform.rotation.y, transform.rotation.z + 180);
        //facingRight = !facingRight;
        
        Vector3 theScale = transform.localScale;
        theScale.y = theScale.y * -1;
        transform.localScale = theScale;
        
    }

    // TODO: Sağdan ya da soldan yani hangi yönden collision olduğu tespit edildiğinde bunu çalıştırabiliriz.

    /*void OnCollisionStay2D(Collision2D other)
    {
        if (other.gameObject.tag == "DeadEnd" || other.gameObject.tag == "Dog" || other.gameObject.tag == "Dave")
        {
            collidedWithEnemy = 1;
            Debug.Log("Collided with something");
        }
    }*/

    IEnumerator OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "House")
        {
            //textYouWon.enabled = true;
            //print("Starting " + Time.time);
            yield return StartCoroutine(WaitABit(1.5f));
            //print("Before WaitAndPrint Finishes " + Time.time);
            //yield return StartCoroutine(StopEverything());

            Application.LoadLevel(5);
        }
    }

    IEnumerator WaitABit(float waitTime)
    {

        yield return new WaitForSeconds(waitTime);

        //print("WaitAndPrint " + Time.time);
    }

    IEnumerator StopEverything()
    {
        yield return new WaitForSeconds(0.0f);
        Time.timeScale = 0.0f;
        //print("Time has stopped.");
    }
}
