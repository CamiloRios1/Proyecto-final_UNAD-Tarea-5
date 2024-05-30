using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Runtime.CompilerServices;

public class Puntaje : MonoBehaviour
{
    public float puntos;
    public TextMeshProUGUI textMesh;

    // Start is called before the first frame update
    void Start()
    {
        textMesh = GetComponent<TextMeshProUGUI>();
        if (textMesh == null)
        {
            Debug.LogError("TextMeshProUGUI no se encontró en el objeto Puntaje.");
        }
    }

    // Update is called once per frame
    private void Update()
    {
        puntos += Time.deltaTime;
        if (textMesh != null)
        {
            textMesh.text = puntos.ToString("0");
        }
    }

    public void SumarPuntos(float puntosEntrada)
    {
        puntos += puntosEntrada;
        if (textMesh != null)
        {
            textMesh.text = puntos.ToString("0");
        }
    }
}
