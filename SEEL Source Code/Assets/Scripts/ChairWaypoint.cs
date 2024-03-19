using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.Animations;

public class FirstWaypoint : MonoBehaviour
{
    public bool isOn = true;
    public bool AA = false;

    public Transform camera;

    public VictimManager victimManager;
    public List<Transform> waypoints = new List<Transform>(); // List of waypoints

    public float speed = 5f; // Speed at which the object moves

    private int currentWaypointIndex = 0; // Index of the current waypoint
    private Transform targetWaypoint; // Reference to the current target waypoint

    public void StartMovement()
    {
        // Set the initial target waypoint
        if (waypoints.Count > 0)
            targetWaypoint = waypoints[currentWaypointIndex];
    }
    void Update()
    {
        if(isOn == true)
        {
            Waypoint();
        }
    }
    void Waypoint()
    {
        // If there are waypoints and a target waypoint is set
        if (waypoints.Count > 0 && targetWaypoint != null)
        {
            Vector3 relativePos = targetWaypoint.position - transform.position;
            // Move towards the target waypoint
            transform.position = Vector3.MoveTowards(transform.position, targetWaypoint.position, speed * Time.deltaTime);
            transform.rotation = Quaternion.LookRotation(relativePos);
            // If the object reaches the current waypoint, set the next waypoint as the target
            if (Vector3.Distance(transform.position, targetWaypoint.position) < 0.1f)
            {
                currentWaypointIndex++;
                // Check if reached the last waypoint
                if (currentWaypointIndex >= waypoints.Count)
                {
                    if(AA == false)
                    {
                        ReachedLastWaypoint();
                    }
                }
                else
                {
                    targetWaypoint = waypoints[currentWaypointIndex];
                }
            }
        }
    }
    void ReachedLastWaypoint()
    {
        AA = true;
        victimManager.AtChair();

        Vector3 directionToCamera = camera.position - transform.position;
        directionToCamera.y = 0f; 
        if (directionToCamera != Vector3.zero)
        {
            transform.rotation = Quaternion.LookRotation(directionToCamera);
        }
    }
}
