using UnityEngine;

public class TEST : MonoBehaviour
{
    // Rotation variables
    public Quaternion originalRotation;
    public float turnAmount = 90f;
    public float turnSpeed = 5f;

    // Flags to track rotation availability
    private bool canTurnLeft = true;
    private bool canTurnRight = true;
    private bool canTurnDown = true;

    // Start is called before the first frame update
    void Start()
    {
        // Store original rotation
        originalRotation = transform.rotation;
        canTurnLeft = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (canTurnLeft)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, originalRotation * Quaternion.Euler(0, turnAmount, 0), turnSpeed * Time.deltaTime);
        }
        
    }

    // Function to rotate the camera left
    public void RotateLeft()
    {
        if (canTurnLeft)
        {
            turnAmount -= 90f; // Rotate left by 90 degrees
            canTurnLeft = false; // Disable left rotation
            canTurnRight = true; // Enable right rotation
            canTurnDown = true; // Enable down rotation
        }
    }

    // Function to rotate the camera right
    public void RotateRight()
    {
        if (canTurnRight)
        {
            turnAmount += 90f; // Rotate right by 90 degrees
            canTurnLeft = true; // Enable left rotation
            canTurnRight = false; // Disable right rotation
            canTurnDown = true; // Enable down rotation
        }
    }

    // Function to rotate the camera down
    public void RotateDown()
    {
        if (canTurnDown)
        {
            // Perform rotation downwards
            // You may need to adjust the rotation angles and axis based on your camera setup
            transform.Rotate(Vector3.right, -90f);
            canTurnLeft = true; // Enable left rotation
            canTurnRight = true; // Enable right rotation
            canTurnDown = false; // Disable down rotation
        }
    }

    // Function to reset the camera rotation to original position
    public void ResetRotation()
    {
        turnAmount = 0f; // Reset turn amount
        canTurnLeft = true; // Enable left rotation
        canTurnRight = true; // Enable right rotation
        canTurnDown = true; // Enable down rotation
    }

}
