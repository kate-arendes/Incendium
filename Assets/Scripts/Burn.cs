using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Burn : MonoBehaviour
{
    public float fuel = 10f, burnThreshold = 10f, burnRate = 1f, sizeMultiplier = 1f;
    public GameObject player;
    public GameObject fireParticles;
    public GameObject cam;
    
    private bool onFire = false;
    private GameObject fire;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("BurnUp", 0.0f, 1f);
        cam = GameObject.Find("Main Camera");
    }

    // Update is called once per frame
    void Update()
    {
        

    }

 

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Fire") && !onFire)
        {
            
            onFire = true;
            collision.gameObject.GetComponent<FireStrength>().GainStrength(fuel);
            fire = Instantiate(fireParticles, gameObject.transform);
            fire.transform.localScale *= sizeMultiplier;
            

            // Update Y target of camera when object set on fire

            cam.GetComponent<CameraControl>().UpdateYTarget();
        }
    }


    private void BurnUp()
    {
        if(onFire)
        {
            gameObject.transform.localScale -= new Vector3(0.01f, 0.01f, 0.01f);
            
            if (fire)
            {
                fire.transform.localScale -= new Vector3(0.05f, 0.05f, 0.05f);
            }

            if (fire && fire.transform.localScale.x < 0.01f)
            {
                Destroy(fire);
            }

            if (gameObject.transform.localScale.x <= 0.1f)
            {
                Destroy(gameObject);
            }
        }

        
    }
}
