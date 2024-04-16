using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagers : MonoBehaviour
{
    [SerializeField] private bool Escena_cargada = false;
    public int Index_escena;
    public Jugador V_Jugador;

    private void Update()
    {
        SiMuere();
    }

    public void SiMuere()
    {
        if (V_Jugador.vida == 0) 
        {
            SceneManager.LoadSceneAsync(Index_escena, LoadSceneMode.Additive);
        }
    }
}
