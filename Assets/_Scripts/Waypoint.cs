using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour
{
    [SerializeField] private Waypoint nextWaypoint;

    /// <summary>
    /// Devuelve la posicion actual del waypoint.
    /// </summary>
    public Vector3 GetPosition()
    {
        return this.transform.position;
    }

    public Waypoint GetNextWaypoint()
    {
        return nextWaypoint;
    }
}
