using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ControlTerreno : MonoBehaviour
{
    //////////////////////////////VARIABLES//////////////////////////////
    [SerializeField]
    ControlJugador jugador;

    [SerializeField]
    Camera camaraJuego;

    [SerializeField]
    GameObject[] ListaEscenarios;
    float puntero;
    float checkPointEscenario = 12;
    int indice;
    GameObject escenarioactual;
    ControlEscenario escenario;

    AudioSource sonidoSalida;

    [SerializeField]
    AudioSource Musica;
    [SerializeField]
    AudioClip perder;

    [SerializeField]
    Button salir;

    [SerializeField]
    Button reiniciar;
    //puntuaciones y reinicio//
    [SerializeField]
    Text puntuacion;

    [SerializeField]
    Text record;
    int puntuafinal;

    bool finjuego;
    


    //////////////////////////////FUNCIONES//////////////////////////////
    void Start()
    {
        inicioJuego();
    }


    void Update()
    {
        comprobarJuego();
        generarEscenario();
    }


    void inicioJuego()
    {
        puntero = -7;
        finjuego = false;
        salir.gameObject.SetActive(false);
        reiniciar.gameObject.SetActive(false);

        record.text = "Record: " + PlayerPrefs.GetInt("PuntosRecord", 0).ToString();
        sonidoSalida = GetComponent<AudioSource>();
        Musica.Play();
    }
    void comprobarJuego()
    {
        if (jugador != null)
        {
            //posicion de camara
            camaraJuego.transform.position = new Vector3(jugador.transform.position.x, camaraJuego.transform.position.y, camaraJuego.transform.position.z);
            //modifica puntuacion
            puntuafinal = jugador.getPuntos();
            puntuacion.text = "Puntuacion: " + puntuafinal;
        }
        else
        {
            if (!finjuego)
            {

                finjuego = true;
                salir.gameObject.SetActive(true);
                reiniciar.gameObject.SetActive(true);
                guardarRecord();

                Musica.Stop();
                sonidoSalida.PlayOneShot(perder, 1f);
            }

        }
    }
    void generarEscenario()
    {
        //genera el siguiente escenario
        while (jugador != null && puntero < jugador.transform.position.x + checkPointEscenario)
        {
            indice = Random.Range(1, ListaEscenarios.Length);
            if (puntero < 0)
            {
                //obligo que el primer escenario sea siempre el simple
                indice = 0;
            }

            //creamos la instancia del escenario
            escenarioactual = Instantiate(ListaEscenarios[indice]);
            //creamos la escena a continuacion de la nuestra
            escenarioactual.transform.SetParent(transform);
            //donde creamos
            escenario = escenarioactual.GetComponent<ControlEscenario>();
            escenarioactual.transform.position = new Vector2(puntero + escenario.getTamanio() / 2, 0);

            puntero += escenario.getTamanio();
        }
    }



    public void guardarRecord()
    {
        //guarda el record si este se supera
        if (puntuafinal > PlayerPrefs.GetInt("PuntosRecord", 0)){
            PlayerPrefs.SetInt("PuntosRecord", puntuafinal);
            record.text = "Record: " + puntuafinal;
        }
        
    }

}
