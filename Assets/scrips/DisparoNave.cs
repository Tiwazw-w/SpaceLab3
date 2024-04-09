using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisparoNave : MonoBehaviour
{
    public GameObject prefabBala;
    public Transform puntoDisparo;
    public float frecuenciaDisparo = 0.5f; // Tiempo entre cada disparo
    private float tiempoUltimoDisparo;

    private void Update()
    {
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Stationary)
        {
            Disparar();
        }
    }

    private void Disparar()
    {
        if (Time.time > tiempoUltimoDisparo + frecuenciaDisparo)
        {
            GameObject balaObj = PoolDeBalas.Instance.ObtenerBala();
            if (balaObj != null)
            {
                balaObj.transform.position = puntoDisparo.position;
                balaObj.transform.rotation = puntoDisparo.rotation;
                balaObj.SetActive(true);
            }
            tiempoUltimoDisparo = Time.time;
        }
    }
}

