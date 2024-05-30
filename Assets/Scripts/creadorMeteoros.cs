using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class creadorMeteoros : MonoBehaviour
{
    public GameObject meteoros;
    public Transform miTransform;
    public float xNumeroAleatorio;
    public float tiempoAleatorio;
    // Start is called before the first frame update
    void Start()
    {
        Invoke("CreadorMeteoros",1f);
    }

    // Update is called once per frame
    void Update()
    {
        
    
    }

    void CreadorMeteoros()
    {
        xNumeroAleatorio = Random.Range(-8, 8);
        tiempoAleatorio = Random.Range(1, 2);
        miTransform.position = new Vector3(xNumeroAleatorio, 6, 0);
        Instantiate(meteoros, miTransform.position, miTransform.rotation);

        Invoke("CreadorMeteoros", tiempoAleatorio);
    }
}
