using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TiendaArmas : MonoBehaviour
{
    public AudioSource sndCash;
    public GameObject btnComprarArmas;
    public GameObject btnCancelarCompra;
    public GameObject desactivarBtComprarArmas;

    public int comprarDeArma;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

       

    }


    public void btnCompraDeArmas()
    {

        switch (comprarDeArma)
        {
            case 0:

                //CARGAR DATOS DE SCRIPT PLAYER CONTROLLER
                GameObject player = GameObject.Find("Player");
                PlayerController playerController = player.GetComponent<PlayerController>();
                ArmasController armasController = player.GetComponent<ArmasController>();

                sndCash.Play();
                armasController.armaPistolaComprada = true;
                playerController.dineroJugador = playerController.dineroJugador - 300;
                playerController.velocidadJugador = playerController.velocidadJugadorAvanzando;

                Debug.Log("COMPRA HECHA");
                desactivarBotonesCompra();

                break;



            case 1:

                //CARGAR DATOS DE SCRIPT PLAYER CONTROLLER
                GameObject player1 = GameObject.Find("Player");
                PlayerController playerController1 = player1.GetComponent<PlayerController>();
                ArmasController armasController1 = player1.GetComponent<ArmasController>();

                sndCash.Play();
                armasController1.armaEscopetaComprada = true;
                playerController1.dineroJugador = playerController1.dineroJugador - 900;
                playerController1.velocidadJugador = playerController1.velocidadJugadorAvanzando;

                Debug.Log("COMPRA HECHA");
                desactivarBotonesCompra();

                break;



            case 2:

                //CARGAR DATOS DE SCRIPT PLAYER CONTROLLER
                GameObject player2 = GameObject.Find("Player");
                PlayerController playerController2 = player2.GetComponent<PlayerController>();
                ArmasController armasController2 = player2.GetComponent<ArmasController>();

                sndCash.Play();
                armasController2.armaEscopetaCombateComprada = true;
                playerController2.dineroJugador = playerController2.dineroJugador - 1100;
                playerController2.velocidadJugador = playerController2.velocidadJugadorAvanzando;

                Debug.Log("COMPRA HECHA");
                desactivarBotonesCompra();

                break;

        }

    }

    public void btnCancelarCompras()
    {

        //CARGAR DATOS DE SCRIPT PLAYER CONTROLLER
        GameObject player = GameObject.Find("Player");
        PlayerController playerController = player.GetComponent<PlayerController>();
        playerController.velocidadJugador = playerController.velocidadJugadorAvanzando;
        desactivarBotonesCompra();
    }


    private void OnCollisionEnter(Collision collision)
    {

         if (collision.gameObject.tag == "desactivarBtnCompraArmas")
        {
            btnComprarArmas.SetActive(false);
        }


        if (collision.gameObject.tag == "tiendaPistola")
        {
            detenerJugadorEnTienda();
            comprarDeArma = 0;
            activarBotonesCompra();
        }

        if (collision.gameObject.tag == "tiendaEscopeta")
        {
            detenerJugadorEnTienda();
            comprarDeArma = 1;
            activarBotonesCompra();

        }

        if (collision.gameObject.tag == "tiendaEscopetaCombate")
        {
            detenerJugadorEnTienda();
            comprarDeArma = 2;
            activarBotonesCompra();

        }

    }


    public void activarBotonesCompra()
    {
        btnComprarArmas.SetActive(true);
        btnCancelarCompra.SetActive(true);
    }

    public void desactivarBotonesCompra()
    {
        btnComprarArmas.SetActive(false);
        btnCancelarCompra.SetActive(false);
    }

    public void detenerJugadorEnTienda()
    {
        //CARGAR DATOS DE SCRIPT PLAYER CONTROLLER
        GameObject player = GameObject.Find("Player");
        PlayerController playerController = player.GetComponent<PlayerController>();
        playerController.velocidadJugador = playerController.velocidadJugadorDetenido;
    }

    



}
