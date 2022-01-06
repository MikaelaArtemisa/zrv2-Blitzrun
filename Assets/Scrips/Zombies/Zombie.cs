using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie : MonoBehaviour
{

    public float vida = 15;

    public float speed = 0;
    public float RotationSpeed;
    public Transform target;
    private Quaternion _lookRotation;
    private Vector3 _direction;

    void Start()
    {


    }

    // Update is called once per frame
    void Update()
    {

        movimientoZombie();



    }

    public void movimientoZombie() {

        //ZOMBIE SIGUE A JUGADOR
        float step = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, target.position, step);

        //ZOMBIE ROTA A DIRECCI�N DE JUGADOR
        //find the vector pointing from our position to the target
        _direction = (target.position - transform.position).normalized;

        //create the rotation we need to be in to look at the target
        _lookRotation = Quaternion.LookRotation(_direction);

        //rotate us over time according to speed until we are in the required rotation
        transform.rotation = Quaternion.Slerp(transform.rotation, _lookRotation, Time.deltaTime * RotationSpeed);

    }



    private void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.tag == "bala")
        {
            //=======================================================
            // ZOMBIE PIERDE VIDA
            //=======================================================
            GameObject player = GameObject.Find("Player");
            ArmasController armasController = player.GetComponent<ArmasController>();
            PlayerController playerController = player.GetComponent<PlayerController>();

            if (ArmasController.armaUsada == 1)
            {
                vida = vida - 1;
                Debug.Log("disparo recibido.... vidas: " + vida);
            }

            if (ArmasController.armaUsada == 2)
            {
                vida = vida - 3;
                Debug.Log("disparo recibido.... vidas: " + vida);
            }

            if (ArmasController.armaUsada == 3)
            {
                vida = vida - 5;
                Debug.Log("disparo recibido.... vidas: " + vida);
            }

            //RECOMPENSA AL ELIMINAR ZOMBIE

            if (vida <= 0)
            {
                //Destruir Zombie
                Destroy(gameObject);


                playerController.dineroJugador += 5;
            }


        }

    }


}
