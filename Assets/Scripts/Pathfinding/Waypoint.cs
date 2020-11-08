using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Waypoint : MonoBehaviour
{
    public enum WaypointType
    {
        STAIRS,
        ROOM
    }

    public WaypointType type;

    [SerializeField] public Waypoint up;
    [SerializeField] public Waypoint down;
    [SerializeField] public Waypoint left;
    [SerializeField] public Waypoint right;

    [SerializeField] public Waypoint floorWaypoint;

    [SerializeField] private List<Waypoint> neighbours;

    [SerializeField] public bool containsPlayer = false;

    // [SerializeField] private float waypointGizmoRadius;

    // private void OnDrawGizmos()
    // {
    //     Gizmos.DrawSphere(transform.position, waypointGizmoRadius);
    //     foreach (Waypoint waypoint in neighbours)
    //     {
    //         Gizmos.DrawLine(transform.position, waypoint.transform.position);
    //     }
    // }

}
