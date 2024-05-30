using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class meteoro : MonoBehaviour
{
    public GameObject explosionObj;
    public Transform miTransform;
    [SerializeField] public float cantidadPuntos;
    [SerializeField] public Puntaje puntaje;

    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, 3f);
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "bala")
        {
            if (explosionObj != null && miTransform != null)
            {
                Instantiate(explosionObj, miTransform.position, miTransform.rotation);
            }
            else
            {
                Debug.LogWarning("explosionObj o miTransform no están asignados.");
            }

            if (puntaje != null)
            {
                puntaje.SumarPuntos(cantidadPuntos);
            }
            else
            {
                Debug.LogWarning("El objeto puntaje no está asignado.");
            }

            Destroy(collision.gameObject);
        }
    }
}
