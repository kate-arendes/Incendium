using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireMove : MonoBehaviour
{
    public float speed = 10, currentSpeed;
    private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        currentSpeed = gameObject.transform.localScale.x * speed;
        
        Vector3 pos = transform.position;
        pos.x += Input.GetAxis("Horizontal") * currentSpeed * Time.deltaTime;
        pos.z += Input.GetAxis("Vertical") * currentSpeed * Time.deltaTime;
        transform.position = pos;
    }
}
