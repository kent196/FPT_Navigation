using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows;
using UnityEngine.AI;
using Input = UnityEngine.Input;

public class JumpController : MonoBehaviour
{
    public float InputY, InputX, InputZ;

    public NavMeshAgent agent;

    [SerializeField] private float moveSpeed = 5f;
    public Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        HandleMovement();
    }

    void HandleMovement()
    {
        //InputX = Input.GetAxis("Horizontal");
        //InputZ = Input.GetAxis("Vertical");

        //if (InputX != 0)
        //{
        //    rb.velocity = new Vector3(InputX * moveSpeed * Time.deltaTime, rb.velocity.y, rb.velocity.z);
        //}
        //if (InputZ != 0)
        //{
        //    rb.velocity = new Vector3(rb.velocity.x, rb.velocity.y, InputZ * moveSpeed * Time.deltaTime);
        //}

        if (Input.GetMouseButtonDown(0))
        {
            Ray movePos = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(movePos, out RaycastHit hit))
            {
                agent.SetDestination(hit.point);
            }
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        Debug.Log(collision.gameObject.name);
        if (collision.gameObject.tag == "Stair")
        {
            rb.AddForce(new Vector3(0f, 50f, 0f), ForceMode.Impulse);
        }
    }
}
