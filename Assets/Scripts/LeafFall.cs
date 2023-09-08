using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeafFall : MonoBehaviour
{
    public float rotationSpeed = 180f, circleSpeed = 1f, diameter = 3f;

    private bool isFalling = true;
    private float timer = 0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(isFalling)
        {
            Rotate();
            Circle();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.CompareTag("Ground"))
        {
            isFalling = false;
        }
    }

    private void Rotate()
    {
        float rotationAmount = rotationSpeed * Time.deltaTime;
        float currentRotation = transform.localRotation.eulerAngles.y;
        transform.localRotation = Quaternion.Euler(new Vector3(0f, currentRotation + rotationAmount, 0f));
    }

    private void Circle()
    {
        timer += Time.deltaTime * circleSpeed;
        float xPos = Mathf.Cos(timer) * diameter;
        float zPos = Mathf.Sin(timer) * diameter;
        float yPos = transform.position.y;

        transform.position = new Vector3(xPos, yPos, zPos);
    }
}
