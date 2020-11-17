using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ControladorNavMesh : MonoBehaviour
{
    [HideInInspector]
    public Transform perseguirObjetivo;

    private NavMeshAgent navMeshAgent;
    


    // Start is called before the first frame update
    void Awake()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    public void ActualizarPuntoDestinoNavMeshAgent(Vector3 puntoDestino)
    {
        navMeshAgent.destination = puntoDestino;
        navMeshAgent.isStopped = false;
    }


    public void ActualizarPuntoDestinoNavMeshAgent()
        {
        ActualizarPuntoDestinoNavMeshAgent(perseguirObjetivo.position);
        }

    public void DetenerNavMeshAgent()
    {
        navMeshAgent.isStopped = true;
    }

    public bool HemosLlegado()
    {
        return navMeshAgent.remainingDistance <= navMeshAgent.stoppingDistance && !navMeshAgent.pathPending;
    }
}
