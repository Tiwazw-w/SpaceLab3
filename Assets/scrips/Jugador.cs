using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;


public class Jugador : MonoBehaviour
{
    public Nave LaNave;
    SpriteRenderer MySprite;
    public float vida;
    [SerializeField] float velocidadHorizontal;
    [SerializeField] float velocidadVertical;
    [SerializeField] float alturaMax;
    [SerializeField] float alturaMin;
    bool Si_Colisiono;
    bool Murio;
    float tiempo;
    [SerializeField] float tiempoParaVolverNormal;
    Color Colorguardado;
    [SerializeField] Color ColorDeModificacion;
    [SerializeField] float LimiteMin;
    [SerializeField] float LimiteMax;
    void Start()
    {
        MySprite = GetComponent<SpriteRenderer>();
        Colorguardado = MySprite.color;
        vida = LaNave.vida;
        ControladorTiempo.instance.VelocidadDeLaNave = LaNave.velocidadHorizontal;

        velocidadVertical = LaNave.velocidadVertical;
        MySprite.sprite = LaNave.Imagen;
        ControladorTiempo.instance.Ui.actualizarVida(vida);
    }

    void Update()
    {
        Vector3 Prueba = Input.acceleration;

        if(Prueba.z < LimiteMin && transform.position.y < alturaMax && !Murio)
        {
            transform.position += Vector3.up * velocidadVertical * Time.deltaTime;
        }
        else if(Prueba.z > LimiteMax && transform.position.y > alturaMin && !Murio)
        {
            transform.position += Vector3.down * velocidadVertical * Time.deltaTime;
        }
        //efecto de daño
        if (Si_Colisiono && tiempo < tiempoParaVolverNormal)
        {
            tiempo += Time.deltaTime;
            MySprite.color = ColorDeModificacion;
        }
        else
        {
            Si_Colisiono = false;
            MySprite.color = Colorguardado;
        }
    }
   
    private void OnTriggerEnter2D(Collider2D collision)
    {
        print("coliciono");
        if (collision.tag == "Piedra" && Si_Colisiono == false)
        {
            vida -= 1;
            Si_Colisiono = true;
            tiempo = 0;
            ControladorTiempo.instance.Ui.actualizarVida(vida);
            if (vida == 0)
            {
                ControladorTiempo.instance.SeMurio = true;
                Murio = true;
                ControladorTiempo.instance.Ui.Moriste();
               
            }
        }
    }

}
