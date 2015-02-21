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
    public GUIStyle guiStyle = new GUIStyle();
    //public GUIText textYouWon;
   
    // Use this for initialization
	void Start () 
    {

        /* SaveLoad */
        //_SaveLoad.savedGames.RemoveAll(_Game);
        _Game.current.currScene = Application.loadedLevel;
        Debug.Log(_Game.current.currScene);

        //collidedWithEnemy = 0;
        Debug.Log("Time is set.");
        Time.timeScale = 1;
        timePassed = 0.0f;
        
        //textYouWon.enabled = false;
	}
	
	// Update is called once per frame
    void Update()
    {

        /* SaveLoad */
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            _SaveLoad.Save();
            Application.LoadLevel(8);
        }
        
        //if (collidedWithEnemy == 0)
        //{
        
        /* Belli bir süre sonra manyetizma bittiği için aşağı düşmemizi sağlayan parçacık */ 
        if (grounded && rigidbody2D.gravityScale == -1)
        {
            timePassed = timePassed + Time.deltaTime;
            Debug.Log(timePassed);

            if (timePassed >= timeToFly)
            {
                rigidbody2D.AddForce(new Vector2(0, -jumpForce));
                Flip();
                rigidbody2D.gravityScale *= -1;
            }
        }

        /* Yerdeyken manyetizma çubuğunun bir anda değil süreyle dolmasını sağlayan parçacık */
        if (grounded && rigidbody2D.gravityScale == 1)
        {
            if (timePassed > 0.0f * timeToFly)
            {
                Debug.Log(timePassed);
                timePassed = timePassed - Time.deltaTime;
            }
        }    
        
        if (grounded && Input.GetKeyDown(KeyCode.Space))
        {
            if (rigidbody2D.gravityScale == 1)
            {
                // Manyetizma çubuğu tam dolmadan zıplanması istenmiyorsa bu açılır.
                //if (timePassed < 0.03f)
                //{
                rigidbody2D.AddForce(new Vector2(0, jumpForce));
                Flip();
                rigidbody2D.gravityScale *= -1;
                //}
            }
            else if (rigidbody2D.gravityScale == -1)
            {
                rigidbody2D.AddForce(new Vector2(0, -jumpForce));
                Flip();
                rigidbody2D.gravityScale *= -1;
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
        guiStyle.fontStyle = FontStyle.Bold;
        guiStyle.fontSize = 30;

        if (timePassed > 0.0f && timePassed < 0.7f /*|| timeGround > 1.4f && timeGround < 2.05f*/)
        {
            GUI.Box(new Rect(Screen.width - 210, 0, 180, 50), "");
            GUI.Label(new Rect(Screen.width - 210, 60, 180, 50), "Magnetism", guiStyle);
            
            GUI.Label(new Rect(Screen.width - 150, 0, 50, 50), image);
            GUI.Label(new Rect(Screen.width - 190, 0, 50, 50), image);
        }
        else if (timePassed > 0.7f && timePassed < 1.4f /*|| timeGround > 0.7f && timeGround < 1.4f*/)
        {
            GUI.Box(new Rect(Screen.width - 210, 0, 180, 50), "");
            GUI.Label(new Rect(Screen.width - 210, 60, 180, 50), "Magnetism", guiStyle);
            
            GUI.Label(new Rect(Screen.width - 190, 0, 50, 50), image);
        }
        else if (timePassed > 1.4f && timePassed < 2.05f /*|| timeGround > 0.2f && timeGround < 0.7f*/)
        {
            GUI.Box(new Rect(Screen.width - 210, 0, 180, 50), "");
            GUI.Label(new Rect(Screen.width - 210, 60, 180, 50), "Magnetism", guiStyle);
        }

        else
        {
            GUI.Box(new Rect(Screen.width - 210, 0, 180, 50), "");
            GUI.Label(new Rect(Screen.width - 210, 60, 180, 50), "Magnetism", guiStyle);
            
            GUI.Label(new Rect(Screen.width - 110, 0, 50, 50), image);
            GUI.Label(new Rect(Screen.width - 150, 0, 50, 50), image);
            GUI.Label(new Rect(Screen.width - 190, 0, 50, 50), image);            
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
