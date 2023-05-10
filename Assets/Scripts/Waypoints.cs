using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoints : MonoBehaviour
{
    public Vector3 position;

    private void Start()
    {
        position = transform.position;
    }

    public Waypoints(Vector3 pos)
    {
        this.position = pos;
    }
}
