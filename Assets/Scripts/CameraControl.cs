using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    public GameObject player;
    public float originalPosition, currentTarget, minPos, maxPos, zoomOutSpeed, zoomInSpeed;
    private bool targetHit = false;

    // Start is called before the first frame update
    void Start()
    {
        originalPosition = transform.localPosition.y;
    }

    // Update is called once per frame
    void Update()
    {

        if (currentTarget > transform.position.y)
        {
            targetHit = false;
        }
        else
        {
            targetHit = true;
            currentTarget = 0.0f;
        }

        UpdateYPos();

        MoveCamera();
    }

    public void UpdateYTarget()
    {
        float newTarget = transform.position.y * player.transform.localScale.x;

        if(newTarget > maxPos)
        {
            newTarget = maxPos;
        }

        if(newTarget > currentTarget)
        {
            currentTarget = newTarget;
        }
        
    }

    void UpdateYPos()
    {

        if(targetHit && transform.position.y > minPos)
        {
            transform.localPosition -= new Vector3(0f, zoomInSpeed * Time.deltaTime, 0f);
        }
        else if(!targetHit && transform.position.y < currentTarget)
        {
            transform.localPosition += new Vector3(0f, zoomOutSpeed * Time.deltaTime, 0f);
        }
    }

    void MoveCamera()
    {
        float currentSpeed = player.gameObject.GetComponent<FireMove>().currentSpeed;
        Vector3 pos = transform.position;
        pos.x += Input.GetAxis("Horizontal") * currentSpeed * Time.deltaTime;
        pos.z += Input.GetAxis("Vertical") * currentSpeed * Time.deltaTime;
        transform.position = pos;
    }
}
