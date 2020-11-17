using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EstadoPersecucion : MonoBehaviour
{
    public Color colorEstado = Color.red;

    private MaquinaDeEstado maquinaDeEstado;
    private ControladorNavMesh controladorNavMesh;
    private ControladorVision controladorVision;

    void Awake()
    {
        maquinaDeEstado = GetComponent<MaquinaDeEstado>();
        controladorNavMesh = GetComponent<ControladorNavMesh>();
        controladorVision = GetComponent<ControladorVision>();
    }

    private void OnEnable()
    {
        maquinaDeEstado.meshRendererCube.material.color = colorEstado;
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        if (!controladorVision.PuedeVerAlJugador(out hit, true))
        {
            maquinaDeEstado.ActivarEstado(maquinaDeEstado.estadoAlerta);
            return;
        }
        controladorNavMesh.ActualizarPuntoDestinoNavMeshAgent();
    }
}
