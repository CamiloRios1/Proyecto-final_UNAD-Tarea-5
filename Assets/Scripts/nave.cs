using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class nave : MonoBehaviour
{
    public Transform miTransform;
    public float speed = 5f;
    public GameObject objeto;
    public Transform objetivoT; // Haz que este campo sea [SerializeField] o público para que sea visible en el Inspector.
    public int vida;
    public int maximoVida;
    [SerializeField] private BarraVida barraVida; // Asegúrate de que este campo sea [SerializeField] o público.
    public GameObject explosionObj;

    void Start()
    {
        vida = maximoVida;

        if (barraVida != null)
        {
            barraVida.InicializarBarraDeVida(vida);
        }
        else
        {
            Debug.LogError("El campo barraVida no está asignado.");
        }
    }

    void Update()
    {
        // Movimientos en el espacio
        if (Input.GetKey(KeyCode.D))
        {
            miTransform.position += new Vector3(1, 0, 0) * speed * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.A))
        {
            miTransform.position -= new Vector3(1, 0, 0) * speed * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.W))
        {
            miTransform.position += new Vector3(0, 1, 0) * speed * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.S))
        {
            miTransform.position -= new Vector3(0, 1, 0) * speed * Time.deltaTime;
        }

        // GameOver
        if (vida <= 0)
        {
            Destroy(gameObject);
            Instantiate(explosionObj, miTransform.position, miTransform.rotation);
            Debug.Log("Game over");

            SceneManager.LoadScene("Menuinicial"); // Asegúrate de que el nombre de la escena es correcto
        }

        // Rotación
        if (objetivoT != null)
        {
            objetivoT.position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            miTransform.rotation = Quaternion.LookRotation(new Vector3(0, 0, 1), objetivoT.position - miTransform.position);
        }

        if (Input.GetKey(KeyCode.E))
        {
            transform.Rotate(new Vector3(0, 0, -1));
        }

        if (Input.GetKey(KeyCode.Q))
        {
            transform.Rotate(new Vector3(0, 0, 1));
        }

        // Disparo del arma
        if (Input.GetMouseButtonDown(0))
        {
            Instantiate(objeto, miTransform.position, miTransform.rotation);
        }
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        barraVida.CambiarVidaActual(vida);

        if (collision.gameObject.tag == "enemigo")
        {
            Debug.Log("Me daño un asteroide");
            vida -= 10;
            Destroy(collision.gameObject);
        }

        //if (collision.gameObject.tag == "bala")
        //{
        //    Debug.Log("Recibiste un balazo");
        //    vida -= 20;
        //    Destroy(collision.gameObject);
        //}

        if (collision.gameObject.tag == "pocion")
        {
            Debug.Log("Te curo una estrella");
            vida += 10;
            Destroy(collision.gameObject);
        }
    }
}
