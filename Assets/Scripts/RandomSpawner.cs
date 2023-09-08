using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSpawner : MonoBehaviour
{
    public GameObject item;
    public float radius;
    public int maxSticks;
    private int sticks = 0;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Spawn", 0.0f, 3f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Spawn()
    {
        if(sticks < maxSticks)
        {
            Instantiate(item, Random.insideUnitSphere * radius + transform.position, Random.rotation);
            sticks++;
        }
        
    }
}
