using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolDeBalas : MonoBehaviour
{
    public static PoolDeBalas Instance;
    public GameObject prefabBala;
    public int cantidadInicial = 10;

    private List<GameObject> balasDisponibles = new List<GameObject>();

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    private void Start()
    {
        // Crear balas iniciales y agregarlas al pool
        for (int i = 0; i < cantidadInicial; i++)
        {
            AgregarBala();
        }
    }

    private void AgregarBala()
    {
        GameObject balaObj = Instantiate(prefabBala, transform.position, Quaternion.identity);
        balaObj.SetActive(false);
        balasDisponibles.Add(balaObj);
    }

    public GameObject ObtenerBala()
    {
        GameObject bala = null;

        // Buscar una bala disponible en el pool
        foreach (GameObject b in balasDisponibles)
        {
            if (!b.activeSelf)
            {
                bala = b;
                break;
            }
        }

        // Si no hay balas disponibles, crear una nueva
        if (bala == null)
        {
            AgregarBala();
            bala = balasDisponibles[balasDisponibles.Count - 1];
        }

        return bala;
    }
}

