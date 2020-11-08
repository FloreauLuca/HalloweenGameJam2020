using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class Ghost : MonoBehaviour
{
    [SerializeField] private Waypoint ghostSpawnerWaypoint;
    [SerializeField] private Waypoint stairsWaypoint;
    [SerializeField] private float speed;
    [SerializeField] private TimeManager timeManager;
    [SerializeField] private GameObject ghostSprite;
    [SerializeField] private Rigidbody2D ghostRigidbody2D;
    [SerializeField] private WaypointManager waypointManager;

    public Waypoint floorWaypointContainingPlayer;
    public Waypoint waypointContainingPlayer;

    private Waypoint targetWaypoint;
    enum GhostBehaviour
    {
        SLEEPING,
        GOING_TO_STAIRS,
        GOING_TO_FLOOR,
        VISITING_FLOOR,
        DISAPEARING
    }

    private GhostBehaviour ghostBehaviour;

    private bool spawnIsLeft;
    private bool isWaypointDown;
    private bool isWaypointLeft;
    private bool hasVisitedOtherSide;

    private void Start()
    {
        ghostBehaviour = GhostBehaviour.SLEEPING;
        if (ghostSpawnerWaypoint.transform.position.x < stairsWaypoint.transform.position.x)
        {
            spawnIsLeft = true;
        }
        else
        {
            spawnIsLeft = false;
        }
    }

    private void Update()
    {
        if (ghostBehaviour != GhostBehaviour.SLEEPING)
        {
            if (timeManager.GameTime < 13)
            {
                ghostBehaviour = GhostBehaviour.DISAPEARING;
            }
        }

        switch (ghostBehaviour)
        {
            case GhostBehaviour.SLEEPING:
                if (timeManager.GameTime >= 13)
                {
                    ghostSprite.SetActive(true);
                    transform.position = ghostSpawnerWaypoint.transform.position;
                    ghostBehaviour = GhostBehaviour.GOING_TO_STAIRS;
                    if (spawnIsLeft)
                    {
                        ghostRigidbody2D.velocity = Vector2.right * speed; 
                    }
                    else
                    {
                        ghostRigidbody2D.velocity = Vector2.left * speed;
                    }
                }
                break;
            case GhostBehaviour.GOING_TO_STAIRS:
                if (spawnIsLeft)
                {
                    if (transform.position.x >= stairsWaypoint.transform.position.x)
                    {
                        transform.position = stairsWaypoint.transform.position;
                        int randomFloor = Random.Range(0, waypointManager.floorWaypoints.Count);
                        ghostRigidbody2D.velocity = Vector2.down * speed;
                        targetWaypoint = waypointManager.floorWaypoints[randomFloor];
                        isWaypointDown = true;
                        ghostBehaviour = GhostBehaviour.GOING_TO_FLOOR;
                    }
                }
                else
                {
                    if (transform.position.x <= stairsWaypoint.transform.position.x)
                    {
                        transform.position = stairsWaypoint.transform.position;
                        int randomFloor = Random.Range(0, waypointManager.floorWaypoints.Count);
                        ghostRigidbody2D.velocity = Vector2.down * speed;
                        targetWaypoint = waypointManager.floorWaypoints[randomFloor];
                        isWaypointDown = true;
                        ghostBehaviour = GhostBehaviour.GOING_TO_FLOOR;
                    }
                }
                break;
            case GhostBehaviour.GOING_TO_FLOOR:
                if (isWaypointDown)
                {
                    if (transform.position.y < targetWaypoint.transform.position.y)
                    {
                        SelectRoomWaypoint();
                    }
                }
                else
                {
                    if (transform.position.y > targetWaypoint.transform.position.y)
                    {
                        SelectRoomWaypoint();
                    }
                }
                break;
            case GhostBehaviour.VISITING_FLOOR:
                if (isWaypointLeft)
                {
                    if (transform.position.x < targetWaypoint.transform.position.x)
                    {
                        if (targetWaypoint.type == Waypoint.WaypointType.STAIRS)
                        {
                            if (hasVisitedOtherSide)
                            {
                                SelectFloorWaypoint();
                            }
                            else
                            {
                                hasVisitedOtherSide = true;
                                SelectNextWaypoint();
                            }
                        }
                        else
                        {

                            SelectNextWaypoint();
                        }
                    }
                }
                else
                {
                    if (transform.position.x > targetWaypoint.transform.position.x)
                    {
                        if (targetWaypoint.type == Waypoint.WaypointType.STAIRS)
                        {
                            if (hasVisitedOtherSide)
                            {
                                SelectFloorWaypoint();
                            }
                            else
                            {
                                hasVisitedOtherSide = true;
                                SelectNextWaypoint();
                            }
                        }
                        else
                        {

                            SelectNextWaypoint();
                        }
                    }
                }
                break;
            case GhostBehaviour.DISAPEARING:
                ghostRigidbody2D.velocity = Vector2.zero;
                ghostSprite.SetActive(false);
                ghostBehaviour = GhostBehaviour.SLEEPING;
                break;
        }
    }

    void SelectFloorWaypoint()
    {
        transform.position = targetWaypoint.transform.position;
        int randomFloor = Random.Range(0, waypointManager.floorWaypoints.Count);
        targetWaypoint = waypointManager.floorWaypoints[randomFloor];
        if (targetWaypoint.transform.position.y > transform.position.y)
        {
            ghostRigidbody2D.velocity = Vector2.up * speed;
            isWaypointDown = false;
        }
        else
        {
            ghostRigidbody2D.velocity = Vector2.down * speed;
            isWaypointDown = true;
        }
        ghostBehaviour = GhostBehaviour.GOING_TO_FLOOR;
    }

    void SelectRoomWaypoint()
    {
        transform.position = targetWaypoint.transform.position;
        hasVisitedOtherSide = false;
        if (Random.Range(0, 2) == 1)
        {
            //Going Left
            targetWaypoint = targetWaypoint.left;
            ghostRigidbody2D.velocity = Vector2.left * speed;
            isWaypointLeft = true;

        }
        else
        {
            //Going Right
            targetWaypoint = targetWaypoint.right;
            ghostRigidbody2D.velocity = Vector2.right * speed;
            isWaypointLeft = false;
        }

        ghostBehaviour = GhostBehaviour.VISITING_FLOOR;
    }

    void SelectNextWaypoint()
    {
        if (isWaypointLeft)
        {
            if (targetWaypoint.left == null)
            {
                transform.position = targetWaypoint.transform.position;
                isWaypointLeft = false;
            }
        }
        else
        {
            if (targetWaypoint.right == null)
            {
                transform.position = targetWaypoint.transform.position;
                isWaypointLeft = true;
            }
        }

        if (isWaypointLeft)
        {
            ghostRigidbody2D.velocity = Vector2.left * speed;
            targetWaypoint = targetWaypoint.left;
        }
        else
        {
            ghostRigidbody2D.velocity = Vector2.right * speed;
            targetWaypoint = targetWaypoint.right;
        }
    }
}
