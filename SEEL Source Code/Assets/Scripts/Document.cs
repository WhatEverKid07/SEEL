using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Document : MonoBehaviour
{
    public float speed; 
    public float rotateSpeed;
    public Transform target;

    private bool targetReached = false;

    void Update()
    {
        if(targetReached == false)
        {
            // Move our position a step closer to the target.
            var step = speed * Time.deltaTime; // calculate distance to move
            transform.position = Vector3.MoveTowards(transform.position, target.position, step);
            transform.Rotate(-rotateSpeed, 0.0f, 0.0f);
            if (Vector3.Distance(transform.position, target.position) < 0.001f)
            {
                Debug.Log("Target Reached");
                targetReached = true;
            }
        }
        
    }
}
