using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour 
{

    public GameObject player;
    private Vector3 offset = new Vector3(6, 2, -10);
    //Vector3 lastPos;
    //float threshold = 20.0f;

	void Start () 
    {
        transform.position = player.transform.position + offset;
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
        //print("Player: " + (int)(player.transform.position.x) + ", Camera: " + (int)(transform.position.x));
        if (player.transform.position.x > 150.0f)
        {
            //print("if");
            rigidbody2D.velocity = new Vector2(0.0f, rigidbody2D.velocity.y);
        }
        else
        {
            //print("else");
            rigidbody2D.velocity = new Vector2(7.9f, rigidbody2D.velocity.y);
        }
    }

    //Vector3 offset = transform.position - lastPos;
    //if (offset.x < threshold)
    //{
    //    Debug.Log("if");
    //    transform.position = player.transform.position + new Vector3(8, 0, -10);
    //}
    //else
    //{
    //    Debug.Log("else");

    //}


    /* if (Vector3.Distance(player.transform.position, transform.position) > 0)
     {
         Debug.Log("if");
         transform.position = player.transform.position + new Vector3(8, 0, -10);
     }
     else
         transform.position = transform.position + new Vector3(8, 0, -10);
     * */
}
