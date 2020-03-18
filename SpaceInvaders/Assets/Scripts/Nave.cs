using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nave : MonoBehaviour
{
    Rigidbody2D nave;
    public GameObject bala;
    GameObject balaDisparada;
    float movimiento;
    public float speed;
    public int vida;
    GameObject[] enemigos;
    public static int navesE;

    // Start is called before the first frame update
    void Start()
    {
        nave = gameObject.GetComponent<Rigidbody2D>();
        balaDisparada = null;

        enemigos = GameObject.FindGameObjectsWithTag("Enemigo");

        foreach (GameObject e in enemigos)
        {
            navesE++;
        }
    }

    // Update is called once per frame
    void Update()
    {
        movimiento = Input.GetAxis("Horizontal") * speed;
        nave.MovePosition(new Vector2(nave.position.x + movimiento, nave.position.y));

        if (Input.GetAxis("Jump") == 1.0 && balaDisparada == null)
        {
            balaDisparada = Instantiate(bala, new Vector3(nave.position.x, nave.position.y + 1, bala.transform.position.z),new Quaternion(0,0,0,0));
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "BalaE")
        {
            vida--;
            if (vida == 0)
            {
                Destroy(gameObject);
                Debug.Log("¡Perdiste!");
            }
        }
    }
}

