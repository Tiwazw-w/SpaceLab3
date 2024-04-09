using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Piedra : MonoBehaviour
{
    [SerializeField] private float velocidad;
    public float vida;
    void Update()
    {
        transform.Translate(Vector2.left * velocidad * Time.deltaTime);
        if (transform.position.x < -12f)
        {
            ResetRock();
        }
        FerificarVida();
    }
    public void ResetRock()
    {
        transform.position = new Vector2(10.0f, Random.Range(-3.0f, 3.0f));
    }

    public void FerificarVida()
    {
        if(vida ==0)
        {
            Destroy(gameObject);
        }
    }
}
