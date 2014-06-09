using UnityEngine;
using System.Collections;

public class SoundUnitySingleton : MonoBehaviour 
{
    
    private static SoundUnitySingleton instance = null;

    private AudioSource backSource;
    private Rigidbody2D backSourceRigid = null;
    public AudioClip backClip;

    void Awake()
    {

        backSource = gameObject.AddComponent<AudioSource>();

        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
            return;
        }
        else
        {
            instance = this;
        }

        DontDestroyOnLoad(gameObject);        
    }

    void Start () 
    {
 
        backSource.audio.clip = backClip;
        backSource.loop = true; 
        backSource.audio.Play();        
        
	}

    void OnLevelWasLoaded()
    {
        if (Application.loadedLevel == 2 || Application.loadedLevel == 3 || Application.loadedLevel == 4)
        {
            backSourceRigid = gameObject.AddComponent<Rigidbody2D>();
            backSourceRigid.isKinematic = true;
        }
        else if (backSourceRigid != null)
        {
            backSource.transform.position = new Vector3(0, 0, 0);
            Destroy(backSourceRigid);
        }
    }
    
    // Update is called once per frame
    void Update()
    {
        if (backSourceRigid != null)
        {
            if (backSource.transform.position.x > 152.5f)
            {
                backSourceRigid.velocity = new Vector2(0.0f, rigidbody2D.velocity.y);
            }
            else
                backSourceRigid.velocity = new Vector2(7.9f, rigidbody2D.velocity.y);
        }
    }
}
