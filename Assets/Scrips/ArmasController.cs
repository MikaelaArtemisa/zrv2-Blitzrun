

using System.Diagnostics;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class ArmasController : MonoBehaviour
{
    public static int armaUsada = 0;

    //BALAS
    public GameObject balaInicio;
    public GameObject balaPrefab;
    public float balaVelocidad;
    public bool balaCreada = false;

    //ARMAS CHARACTER
    public GameObject armaCharacterPistola;
    public GameObject armaCharacterEscopeta;
    public GameObject armaCharacterEscopetaCombate;

    //ARMAS MALETIN
    public GameObject armaMaletinPistola;
    public GameObject armaMaletinEscopeta;
    public GameObject armaMaletinEscopetaCombate;

    //ARMAS INTERFAZ aU
    public GameObject aUPistola;
    public GameObject auEscopeta;   
    public GameObject auEscopetaCombate;
    

    //TEXT BALAS
    public Text txtBalasPistola;
    public Text txtBalasEscopeta;
    public Text txtBalasEscopetaCombate;

    //TEXT BALAS MALETIN
    public Text txtMaletinBalasPistola;
    public Text txtMaletinBalasEscopeta;
    public Text txtMaletinBalasEscopetaCombate;

    //CANTIDAD BALAS
    public int balaPistola;
    public int balaEscopeta;
    public int balaEscopetaCombate;
    
    //SONIDOS
    public AudioSource sndCambioArmas;
    public AudioSource sndPistola;
    public AudioSource sndEscopeta;
    public AudioSource sndEscopetaCombate;

    //ARMAS COMPRADAS
    public bool armaPistolaComprada = false;
    public bool armaEscopetaComprada = false;
    public bool armaEscopetaCombateComprada = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        usarArmas();
       mostrarArmasCompradas();
    }

    public void mostrarArmasCompradas(){
    
    if (armaPistolaComprada == true)
    {
        armaMaletinPistola.SetActive(true);
    }else{
       armaMaletinPistola.SetActive(false); 
    }

    //

    if (armaEscopetaComprada == true)
    {
        armaMaletinEscopeta.SetActive(true);
    }else{
        armaMaletinEscopeta.SetActive(false);
    }

    //

    if (armaEscopetaCombateComprada == true)
    {
        armaMaletinEscopetaCombate.SetActive(true);
    }else{
        armaMaletinEscopetaCombate.SetActive(false);
    }
    
    }

    public void usarArmas(){

        switch (armaUsada)
        {
            case 0:
            
            armaCharacterPistola.SetActive(false);
            armaCharacterEscopeta.SetActive(false);
            armaCharacterEscopetaCombate.SetActive(false);
            break;

            case 1:

            if (armaPistolaComprada == true)
            {

            aUPistola.SetActive(true);    
            auEscopeta.SetActive(false);
            auEscopetaCombate.SetActive(false);

            armaCharacterPistola.SetActive(true);
            armaCharacterEscopeta.SetActive(false);
            armaCharacterEscopetaCombate.SetActive(false);
            }else{
            armaCharacterPistola.SetActive(false);    
            }
           
            break;

            case 2:

            if (armaEscopetaComprada == true)
            {
                aUPistola.SetActive(false);    
                auEscopeta.SetActive(true);
                auEscopetaCombate.SetActive(false);

                armaCharacterPistola.SetActive(false);
                armaCharacterEscopeta.SetActive(true);
                armaCharacterEscopetaCombate.SetActive(false);
            }else{
                armaCharacterEscopeta.SetActive(false);
            }
            
            break;

            case 3:

            if (armaEscopetaCombateComprada == true)
            {
                
                aUPistola.SetActive(false);    
                auEscopeta.SetActive(false);
                auEscopetaCombate.SetActive(true);

                armaCharacterPistola.SetActive(false);
                armaCharacterEscopeta.SetActive(false);
                armaCharacterEscopetaCombate.SetActive(true);
            }else{
                armaCharacterEscopetaCombate.SetActive(false);
            }
            
            break;

            default:
            armaCharacterPistola.SetActive(false);
            armaCharacterEscopeta.SetActive(false);
            armaCharacterEscopetaCombate.SetActive(false);
            
            break;

        }

    }

    public void dispararBalas(){
        balaCreada = true;

        if (armaUsada == 1 && balaPistola>0)
        {
            sndPistola.Play();
            crearBalas();
            balaPistola = balaPistola - 1;
        }

        if (armaUsada == 2 && balaEscopeta>0)
        {
            sndEscopeta.Play();
            crearBalas();
            balaEscopeta = balaEscopeta - 1;
        }


        if (armaUsada == 3 && balaEscopetaCombate>0)
        {
            sndEscopetaCombate.Play();
            crearBalas();
            balaEscopetaCombate = balaEscopetaCombate - 1;
        }

    }


    public void crearBalas(){
            
            actualizarHudBalas();
            limitesBalas();

            //1-Instanciar la BalaPrefab en las posiciones de BalaInicio
            GameObject balaTemporal = Instantiate(balaPrefab, balaInicio.transform.position, balaInicio.transform.rotation) as GameObject;

            //Obtener Rigidbody para agregar Fuerza. 
            Rigidbody rb = balaTemporal.GetComponent<Rigidbody>();

            //Agregar la fuerza a la Bala
            rb.AddForce(transform.forward * balaVelocidad);

            //Debemos Destruir la bala
            Destroy(balaTemporal, 5.0f);
    }


    public void actualizarHudBalas(){
        txtBalasPistola.text = balaPistola + "";
        txtBalasEscopeta.text = balaEscopeta + "";
        txtBalasEscopetaCombate.text = balaEscopetaCombate + "";

        //MALETIN
        txtMaletinBalasPistola.text = balaPistola + "";
        txtMaletinBalasEscopeta.text = balaEscopeta + "";
        txtMaletinBalasEscopetaCombate.text  = balaEscopetaCombate + "";

}


    public void limitesBalas(){

        //BALA PISTOLA
        if(balaPistola>100){
            balaPistola = 100;
        }
        if(balaPistola <= 0){
            balaPistola =0;
        }

        //BAlA ESCOPETA
        if (balaEscopeta > 100)
        {
            balaEscopeta = 100;
        }
        if (balaEscopeta <= 0)
        {
            balaEscopeta = 0;
        }

        //BAlA ESCOPETA COMBATE
        if (balaEscopetaCombate > 100)
        {
            balaEscopetaCombate = 100;
        }
        if (balaEscopetaCombate <= 0)
        {
            balaEscopetaCombate = 0;
        }

    }

    //======================================
    //BOTONES MALETIN
    //======================================
    public void btnPuno(){
        armaUsada = 0;
    }

    public void btnPistola(){
        armaUsada = 1;

        sndCambioArmas.Play();

    }

    public void btnEscopeta(){
        armaUsada = 2;
        sndCambioArmas.Play();
        
    }

    public void btnEscopetaCombate(){
        armaUsada = 3;
        sndCambioArmas.Play();
        
    }



}
