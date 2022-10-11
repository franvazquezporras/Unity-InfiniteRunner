using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlJugador : MonoBehaviour
{
    //////////////////////////////VARIABLES//////////////////////////////
    int salto = 350;
    [SerializeField]
    float velocidad = 5;
    bool tocasuelo = false;

    [SerializeField]
    AudioClip SonidoSalto;
    [SerializeField]
    AudioClip SonidoMuerte;
    [SerializeField]
    AudioClip coin;
    AudioSource audioSalida;
    int puntos;


    //////////////////////////////FUNCIONES//////////////////////////////

    void Start()
    {
        puntos = 0;
        audioSalida = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        movimientoJugador();
    }


    void movimientoJugador()
    {
        //salto
        if (Input.GetKeyDown("space") && tocasuelo)
        {
            audioSalida.clip = SonidoSalto;
            audioSalida.Play();
            tocasuelo = false;
            gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, salto));
        }

        //movimiento
        gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(velocidad, gameObject.GetComponent<Rigidbody2D>().velocity.y);
        velocidad = 5 + (puntos * 0.1f);
    }



    //controla que exista contacto con el suelo
    private void OnCollisionEnter2D(Collision2D collision)
    {
        tocasuelo = true;
    }

    //cuando choca con un obstaculo o moneda
    private void OnTriggerEnter2D(Collider2D item)
    {
        
        
        if(item.tag == "Obstaculo")
        {
            tocasuelo = true;
            //aqui mataremos al jugador por chocar con un obstaculo                  
            GameObject.Destroy(gameObject);
        }else if(item.tag == "Coin")
        {

            //suma punto al recoger monedas
            audioSalida.PlayOneShot(coin);
            puntos++;
        }

    }


    public int getPuntos()
    {
        return puntos;
    }




}
