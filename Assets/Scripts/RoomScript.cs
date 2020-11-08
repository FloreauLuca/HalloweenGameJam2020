using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomScript : MonoBehaviour
{
    [SerializeField] private Waypoint roomWaypoint;
    [SerializeField] private Ghost ghost;
    [SerializeField] private PlayerManager playerManager;


    [SerializeField] private bool containsPlayer = false;
    [SerializeField] private bool containsGhost = false;

    private bool attacking = false;

    void Start()
    {
        attacking = false;
        playerManager = FindObjectOfType<PlayerManager>();
    }
    void Update()
    {
        if (containsPlayer && containsGhost && !playerManager.isHidden && !attacking)
        {
            ghost.ghostBehaviour = Ghost.GhostBehaviour.ATTACKING;
            attacking = true;
        }
    }
    private void OnTriggerEnter2D(Collider2D collider2D)
    {
        if (collider2D.tag == "Player")
        {
            containsPlayer = true;
            ghost.waypointContainingPlayer = roomWaypoint;
            ghost.floorWaypointContainingPlayer = roomWaypoint.floorWaypoint;
            Debug.Log("In");
        }

        if (collider2D.tag == "Ghost")
        {
            containsGhost = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collider2D)
    {
        if (collider2D.tag == "Player")
        {
            containsPlayer = false;
            Debug.Log("Out");
        }
        if (collider2D.tag == "Ghost")
        {
            containsGhost = false;
        }
    }
}
