using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public GameObject maletinArmas;


    public int vidaJugador = 100;
    public Text txtVidaJugador;
    public int dineroJugador = 100;
    public Text txtDineroJugador;

    //ESTADISTICAS DE FISICAS
    public float velocidadJugador;

    public float velocidadJugadorDetenido = 0;
    public float velocidadJugadorAvanzando = 3f;
    public float velocidadRotacion;
    public float fuerzaSalto;
    public bool tocaPiso = true;
    
    //FISICAS / COMPONENTES
    public Rigidbody rb;
    Animator anim;
    private Vector2 newSpeed;



    // Start is called before the first frame update
    void Start()
    {
       rb = GetComponent<Rigidbody>();
        anim = GetComponentInChildren<Animator>();
        anim.speed = 0.7f;
    }

    // Update is called once per frame
    void Update()
    {
        movimientoJugador();
        actualizarHud();
        transform.Translate(Vector3.forward * velocidadJugador * Time.deltaTime);
    }


    private void actualizarHud(){
        txtVidaJugador.text = vidaJugador + "";
        txtDineroJugador.text = dineroJugador + "";

        //=====================================================================
        //LIMITES HUD
        //=====================================================================


        //VIDA
        if(vidaJugador>100){
            vidaJugador = 100;
        }
        if(vidaJugador <= 0){
            vidaJugador =0;
        }

        //DINERO
        if(dineroJugador>999999999){
            dineroJugador = 999999999;
        }
        if(dineroJugador <= 0){
            dineroJugador = 0;
        }


    }



    private void movimientoJugador()
    {

        //CONTROL TECLADO

        float deltaX = Input.GetAxis("Horizontal");
        float deltaZ = Input.GetAxis("Vertical");
        newSpeed = new Vector2(deltaX, deltaZ);
     
        //JUGADOR AVANZA AL PRESIONAR BOTÓN
        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(Vector3.forward * velocidadJugador * Time.deltaTime);
        }

        //GIRAR IZQUIERDA | PRESIONANDO A
        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(0f, -velocidadRotacion * Time.deltaTime, 0f);
        }

        //DETENERSE | PRESIONANDO S
        if (Input.GetKey(KeyCode.S))
        {
            velocidadJugador = 0f;
        }

        //GIRAR DERECHA | PRESIONANDO D    
        if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(0f, velocidadRotacion * Time.deltaTime, 0f);
        }

        
        if (Input.GetKey(KeyCode.Z))
        {
           vidaJugador = vidaJugador + 1;
           Debug.Log(vidaJugador);
        }

       

        //SALTAR PRESIONANDO ESPACIO  
        if (Input.GetButton("Jump") && tocaPiso)
        {
            rb.AddForce(new Vector3(0, fuerzaSalto, 0), ForceMode.Impulse);
            tocaPiso = false;
        }

    }


    public void testeos(){

         if (Input.GetKey(KeyCode.X))
        {
           vidaJugador = vidaJugador - 1;
           Debug.Log(vidaJugador);
        }


        if (Input.GetKey(KeyCode.C))
        {
           dineroJugador = dineroJugador + 1;
           Debug.Log(dineroJugador);
        }

        if (Input.GetKey(KeyCode.V))
        {
           dineroJugador = dineroJugador - 1;
           Debug.Log(dineroJugador);
        }

    }


    //============================================================
    //CONTROLES TOUCH
    //============================================================
    void OnMouseDrag()
    {
        //ROTACIÓN DE JUGADOR TOUCH
        float rotX = Input.GetAxis("Mouse X") * velocidadRotacion * Mathf.Deg2Rad;
        transform.Rotate(Vector3.up, rotX);
        
    }

    public void btnSaltar()
    {
        if (tocaPiso == true)
        {
            rb.AddForce(new Vector3(0, fuerzaSalto, 0), ForceMode.Impulse);
            tocaPiso = false;
        }
    }

        private void OnCollisionEnter(Collision collision)
        {


        if (collision.gameObject.tag == "Piso")
        {
            tocaPiso = true;
        }



    }


    //======================================================================
    // MALETIN DE ARMAS
    //======================================================================

    public void abrirMaletin(){
        maletinArmas.SetActive(true);
    }

    public void cerrarMaletin(){
        maletinArmas.SetActive(false);
    }


}
