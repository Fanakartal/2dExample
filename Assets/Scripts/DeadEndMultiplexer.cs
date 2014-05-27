using UnityEngine;
using System.Collections;

public class DeadEndMultiplexer : MonoBehaviour {


    Component script;
    GameObject clone;
    // Use this for initialization
	void Start () 
    {
	
	}
	
	// Update is called once per frame
	void Update () 
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            Instantiate(this.transform, new Vector3(transform.position.x + 20, transform.position.y, transform.position.z), Quaternion.identity);
            GetComponent<DeadEndMultiplexer>().enabled = false;
        }
	}
}
