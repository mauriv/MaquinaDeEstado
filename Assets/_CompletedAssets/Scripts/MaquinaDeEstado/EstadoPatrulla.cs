using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EstadoPatrulla : MonoBehaviour
{

    public Transform[] waypoints;
    public Color colorEstado = Color.green;

    private ControladorNavMesh controladorNavMesh;
    private int siguenteWaypoint;
    private MaquinaDeEstado maquinaDeEstado;
    private ControladorVision controladorVision;

    private void Awake()
    {
        maquinaDeEstado = GetComponent<MaquinaDeEstado>();
        controladorNavMesh = GetComponent<ControladorNavMesh>();
        controladorVision = GetComponent<ControladorVision>();
    }

    void Update()
    {
        RaycastHit hit;
        if (controladorVision.PuedeVerAlJugador(out hit))
        {
            controladorNavMesh.perseguirObjetivo = hit.transform;
            maquinaDeEstado.ActivarEstado(maquinaDeEstado.estadoPersecucion);
            return;
        }

        if (controladorNavMesh.HemosLlegado())
        {
            siguenteWaypoint = (siguenteWaypoint + 1) % waypoints.Length;
            maquinaDeEstado.ActivarEstado(maquinaDeEstado.estadoAlerta);
            //ActualizarWaypointDestino();
        }
    }


    private void OnEnable()
    {
        maquinaDeEstado.meshRendererCube.material.color = colorEstado;
        ActualizarWaypointDestino();
    }
    private void ActualizarWaypointDestino()
    {
        controladorNavMesh.ActualizarPuntoDestinoNavMeshAgent(waypoints[siguenteWaypoint].position);  
    }


    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && enabled)
        {
            controladorNavMesh.perseguirObjetivo = other.transform;
            maquinaDeEstado.ActivarEstado(maquinaDeEstado.estadoPersecucion);
        }
    }
}
