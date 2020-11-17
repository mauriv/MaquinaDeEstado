using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaquinaDeEstado : MonoBehaviour
{
    public MonoBehaviour estadoInicial, estadoPatrulla, estadoAlerta, estadoPersecucion;

    private MonoBehaviour estadoActual;

    public MeshRenderer meshRendererCube;





    void Start()
    {
        ActivarEstado(estadoInicial);
    }

    public void ActivarEstado(MonoBehaviour nuevoEstado)
    {
        if(estadoActual!=null) estadoActual.enabled = false;
        estadoActual = nuevoEstado;
        estadoActual.enabled = true;
    }


}
