using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomScript : MonoBehaviour
{
    [SerializeField] private Waypoint roomWaypoint;
    [SerializeField] private Ghost ghost;
    private void OnTriggerEnter2D(Collider2D collider2D)
    {
        if (collider2D.tag == "Player")
        {
            roomWaypoint.containsPlayer = true;
            ghost.waypointContainingPlayer = roomWaypoint;
            ghost.floorWaypointContainingPlayer = roomWaypoint.floorWaypoint;
            Debug.Log("In");
        }

        if (collider2D.tag == "Ghost")
        {

        }
    }

    private void OnTriggerExit2D(Collider2D collider2D)
    {
        if (collider2D.tag == "Player")
        {
            roomWaypoint.containsPlayer = false;
            Debug.Log("Out");
        }
    }
}
