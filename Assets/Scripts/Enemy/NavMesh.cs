using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NavMesh : MonoBehaviour
{
    // ----- Serialized ----- //

    [SerializeField] public Transform[] points;

    // ----- Private ----- //

    private int destPoint = 0;
    private NavMeshAgent navMeshAgent;

    // ----- Public ----- //

    public Transform target;

    // ---- Others ----- //

    Vector3 vector3 = Vector3.zero;
    float distance = 0.0f;

    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        navMeshAgent.autoBraking = false;
    }

    void Update()
    {
        Route();
    }

    private void Route()
    {
        if (navMeshAgent.remainingDistance < 1.5f)
        {
            navMeshAgent.destination = points[destPoint].position;

            destPoint = (destPoint + 1) % points.Length;
        }
        if (points.Length == 0)
            return;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, 4);

        vector3 = target.position - transform.position;
        distance = vector3.magnitude;

        if (distance <= 4)
        {
            Gizmos.color = Color.red;
        }
        else
        {
            Gizmos.color = new Color(0f, 0.7f, 0f, 1f);
        }

        Gizmos.DrawLine(transform.position, target.position);
    }
}
