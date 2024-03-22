using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTwin : MonoBehaviour
{
    public Transform camratwin;
    public Transform realCamera;

    float r;
    float m;
    public float turningAngle;
    void Update()
    {
        float newX = Mathf.SmoothDampAngle(realCamera.eulerAngles.x, camratwin.eulerAngles.x, ref r, 0.1f);
        float newy = Mathf.SmoothDampAngle(realCamera.eulerAngles.y, camratwin.eulerAngles.y, ref m, 0.1f);
        realCamera.localRotation = Quaternion.Euler(newX, newy, 0);
    }
}
