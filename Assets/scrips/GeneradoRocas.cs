using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneradoRocas : MonoBehaviour
{
    public GameObject rockPrefab;
    public int poolSize = 10;
    public float spawnRate = 2f;

    private List<GameObject> rocks = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        // Crear la piscina de rocas
        for (int i = 0; i < poolSize; i++)
        {
            GameObject rock = Instantiate(rockPrefab, transform);
            rock.SetActive(false);
            rocks.Add(rock);
        }

        // Iniciar la generación de rocas
        InvokeRepeating("SpawnRock", 0f, spawnRate);
    }

    // Generar una roca desde la piscina
    void SpawnRock()
    {
        foreach (GameObject rock in rocks)
        {
            if (!rock.activeInHierarchy)
            {
                rock.SetActive(true);
                rock.GetComponent<Piedra>().ResetRock();
                break;
            }
        }
    }
}
