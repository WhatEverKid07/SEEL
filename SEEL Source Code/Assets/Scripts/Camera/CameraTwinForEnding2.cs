using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTwinForEnding2 : MonoBehaviour
{
    public Transform head;
    public Transform realCamera;

    float r;
    float m;
    public float turningAngle;
    void Update()
    {
        realCamera.transform.position = head.position;
        float newX = Mathf.SmoothDampAngle(realCamera.eulerAngles.x, head.eulerAngles.x, ref r, 0.4f);
        float newy = Mathf.SmoothDampAngle(realCamera.eulerAngles.y, head.eulerAngles.y, ref m, 0.4f);
        realCamera.localRotation = Quaternion.Euler(newX, newy, 0);
    }
}
