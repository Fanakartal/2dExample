using UnityEngine;
using System.Collections;

public class PlatformMultiplexer : MonoBehaviour
{

    Component script;
    GameObject clone;
    //System.Type type;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        /*if (Input.GetKeyDown(KeyCode.Tab))
        {
            clone = Instantiate(this.transform, new Vector3(transform.position.x + 20, transform.position.y, transform.position.z), Quaternion.identity) as GameObject;
            GetComponent<PlatformMultiplexer>().enabled = false;
        }*/
    }

    void LateUpdate()
    {

    }
}
