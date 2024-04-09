using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ControladorDelMapa : MonoBehaviour
{
    [SerializeField] float PuntoDeTeletransporte;
    [SerializeField] float PuntoFinal;
    [SerializeField] float velocidad;
    
    public void DarUnValorVelocidad()
    {
        velocidad = ControladorTiempo.instance.VelocidadDeLaNave;
    }
    void Update()
    {
        transform.position += Vector3.left * ControladorTiempo.instance.velocidad * velocidad * Time.deltaTime;
        if (transform.position.x < PuntoFinal)
        {
            transform.position = new Vector2(PuntoDeTeletransporte, transform.position.y);
        }
    }
}
