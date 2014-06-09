using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour 
{

    public GameObject player;
    //public GUIText textGameOver;
    private Vector3 offset = new Vector3(6, 2.35f, -10);
    private float positionDiff;

    //AudioSource dogBark;
    //public AudioClip dogBarkClip;

    //GameObject dog;
    //Vector3 lastPos;

	void Start () 
    {
        //textGameOver.enabled = false;
        
        transform.position = player.transform.position + offset;
        positionDiff = transform.position.x - player.transform.position.x;
        
        //Debug.Log(positionDiff);
        //rigidbody2D.velocity = new Vector2(6f, 0);
	}

    //lastPos = transform.position;

    /******************************************************
     * void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "DeadEnd")
        {
            transform.position = new Vector3(100,100,100);
        }
            
    }
     * *****************************************************
     * **/

    void LateUpdate()
    {
        //Debug.Log(transform.position.x - player.transform.position.x);
        if ((transform.position.x - player.transform.position.x) >= (positionDiff * 2) + 1.0f)
        {
            //textGameOver.enabled = true;
            StartCoroutine(WaitAndLoadLevel(3.0f));
            
            //yield return StartCoroutine(StopEverything());
        }

        if (player.transform.position.x > 150.0f)
        {
            rigidbody2D.velocity = new Vector2(0.0f, rigidbody2D.velocity.y);
        }
        else
        {
            rigidbody2D.velocity = new Vector2(7.9f, rigidbody2D.velocity.y);
        }     
    }

    /*void Update()
    {
        Debug.Log("Dog");
        dog = GameObject.FindGameObjectWithTag("Dog");
        //dogBark.clip = dogBarkClip;
        //dogBark.Play();
        AudioSource.PlayClipAtPoint(dogBarkClip, dog.transform.position); 
    }*/

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

    IEnumerator WaitAndLoadLevel(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        //print("WaitAndPrint " + Time.time);
        Application.LoadLevel(7);
    }
}
