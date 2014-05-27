using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour 
{

    public GameObject player;
    private Vector3 offset;

	void Start () 
    {
        offset = transform.position * 2;
	}

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
    
    void LateUpdate () 
    {
        transform.position = player.transform.position + offset;
	}
}
