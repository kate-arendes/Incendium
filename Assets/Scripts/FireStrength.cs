using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireStrength : MonoBehaviour
{
    public float fireStrength = 1f, minStrength = 0.0f, maxStrength = 1000.0f;
    public ParticleSystem fireParticles;
    private float burnRate;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("LoseStrength", 0.0f, 1f);
        
    }

    // Update is called once per frame
    void Update()
    {
        burnRate = 0.05f * gameObject.transform.localScale.x;
        
    }

    void LoseStrength()
    {
        gameObject.transform.localScale -= new Vector3(burnRate, burnRate, burnRate);
        fireParticles.transform.localScale -= new Vector3(burnRate, burnRate, burnRate);
    }

    public void GainStrength(float fuel)
    {
        fuel *= 0.01f;
        gameObject.transform.localScale += new Vector3(fuel, fuel, fuel);
        fireParticles.transform.localScale += new Vector3(fuel, fuel, fuel);
    }

}
