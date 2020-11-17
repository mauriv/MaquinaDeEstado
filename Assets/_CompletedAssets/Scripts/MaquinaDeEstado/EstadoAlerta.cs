using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EstadoAlerta : MonoBehaviour
{

    public Color colorEstado = Color.yellow;
    public float velocidadGiro = 120f;
    public float duracionBusqueda = 4f;

    private MaquinaDeEstado maquinaDeEstado;
    private ControladorNavMesh controladorNavMesh;
    private float tiempoBuscando;
    private ControladorVision controladorVision;

    private void Awake()
    {
        maquinaDeEstado = GetComponent<MaquinaDeEstado>();
        controladorNavMesh = GetComponent<ControladorNavMesh>();
        controladorVision = GetComponent<ControladorVision>();
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        if (controladorVision.PuedeVerAlJugador(out hit))
        {
            controladorNavMesh.perseguirObjetivo = hit.transform;
            maquinaDeEstado.ActivarEstado(maquinaDeEstado.estadoPersecucion);
            return;
        }

        transform.Rotate(0f, velocidadGiro * Time.deltaTime, 0f);
        tiempoBuscando += Time.deltaTime;
        if (tiempoBuscando >= duracionBusqueda)
        {
            maquinaDeEstado.ActivarEstado(maquinaDeEstado.estadoPatrulla);
        }
    }

    private void OnEnable()
    {
        tiempoBuscando = 0;
        maquinaDeEstado.meshRendererCube.material.color = colorEstado;
        controladorNavMesh.DetenerNavMeshAgent();
    }
}
