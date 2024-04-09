using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class Bala : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] float daño;
    Rigidbody2D rb2d;
    private void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }
    private void OnEnable()
    {
        rb2d.velocity = Vector3.right * speed;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Piedra"))
        {
            Piedra vidaObjeto = collision.gameObject.GetComponent<Piedra>();

            if (vidaObjeto != null)
            {
                vidaObjeto.vida -= 5;
                Debug.Log(vidaObjeto.vida);
            }
            gameObject.SetActive(false);
        }
    }
}

