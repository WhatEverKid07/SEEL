using UnityEngine;

public class TEST2 : MonoBehaviour
{
    //public bool rotateCamera = false;
    public float rotationSpeed = 1.0f;
    public float rotationAngle = 90.0f;
    public float leftMaxRotationAngle = 20.0f;
    private float leftMaxRotationAngle2;
    public float rightMaxRotationAngle = 20.0f;
    private float rightMaxRotationAngle2;
    public float bottomMaxRotationAngle = 20.0f;
    private float bottomMaxRotationAngle2;

    [Header("---Information---")]
    private Quaternion targetRotation;
    public float totalRotationAngle = 0.0f;
    public bool turnLeft = false;
    public bool turnRight = false;
    public bool turnDown = false;

    void Start()
    {
        // Initialize target rotation based on current rotation
        targetRotation = transform.rotation;

        leftMaxRotationAngle2 -= leftMaxRotationAngle;
        rightMaxRotationAngle2 += rightMaxRotationAngle;
        bottomMaxRotationAngle2 -= bottomMaxRotationAngle;
    }

    void Update()
    {
        if (turnLeft && totalRotationAngle < leftMaxRotationAngle)
        {
            // Calculate the target rotation based on the specified angle
            Quaternion newRotation = Quaternion.Euler(0, rotationAngle, 0) * transform.rotation;
            // Calculate the rotation step
            float step = rotationSpeed * Time.deltaTime;
            // Smoothly rotate towards the target rotation based on the specified speed
            transform.rotation = Quaternion.Slerp(transform.rotation, newRotation, step);
            // Update the total rotation angle
            totalRotationAngle += Mathf.Abs(rotationAngle) * step;
        }

        if (!turnLeft && totalRotationAngle > leftMaxRotationAngle2 && totalRotationAngle > leftMaxRotationAngle)
        {
            // Calculate the target rotation based on the specified angle
            Quaternion newRotation = Quaternion.Euler(0, -rotationAngle, 0) * transform.rotation;
            // Calculate the rotation step
            float step = rotationSpeed * Time.deltaTime;
            // Smoothly rotate towards the target rotation based on the specified speed
            transform.rotation = Quaternion.Slerp(transform.rotation, newRotation, step);
            // Update the total rotation angle
            totalRotationAngle += Mathf.Abs(rotationAngle) * step;
        }

    }
}
