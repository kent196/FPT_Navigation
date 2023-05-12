using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows;
using UnityEngine.AI;
using Input = UnityEngine.Input;

public class JumpController : MonoBehaviour
{
    public List<Waypoints> waypoints;
    public NavMeshAgent agent;
    private int currentWaypointIndex = 0;

    [SerializeField] private float moveSpeed = 5f;
    public Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void SetDestination()
    {
        //Set destination with waypoints


        //if (currentWaypointIndex < waypoints.Count)
        //{
        //    Waypoints waypoint = waypoints[currentWaypointIndex];
        //    agent.SetDestination(waypoint.position);
        //}

        //Set destination with hit points

        Ray movePos = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(movePos, out var hitInfo))
        {
            agent.SetDestination(hitInfo.point);
        }
    }

    void Update()
    {
        //Set destination with waypoints

        //if (agent.remainingDistance < 0.1f && currentWaypointIndex < waypoints.Count - 1)
        //{
        //    currentWaypointIndex++;
        //    SetDestination();
        //}

        //Set destination with hit points
        if (Input.GetMouseButtonDown(0))
        {

            SetDestination();
        }
    }
}
