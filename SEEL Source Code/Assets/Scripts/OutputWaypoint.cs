using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecondWaypoint : MonoBehaviour
{
    public bool isOn2 = true;

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
        if(isOn2 == true)
        {
            Waypoint2();
        }
    }
    void Waypoint2()
    {
        // If there are waypoints and a target waypoint is set
        if (waypoints.Count > 0 && targetWaypoint != null)
        {
            // Move towards the target waypoint
            transform.position = Vector3.MoveTowards(transform.position, targetWaypoint.position, speed * Time.deltaTime);
            // If the object reaches the current waypoint, set the next waypoint as the target
            if (Vector3.Distance(transform.position, targetWaypoint.position) < 0.1f)
            {
                currentWaypointIndex++;
                // Check if reached the last waypoint
                if (currentWaypointIndex >= waypoints.Count)
                {
                    ReachedLastWaypoint();
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
        victimManager.GetNextPerson();
    }
}
