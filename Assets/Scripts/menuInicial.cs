using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuInicial : MonoBehaviour
{
    [SerializeField] private int nextSceneIndex = 1; 

    [SerializeField] public void Jugar() 
    {
        Debug.Log("Cargando la escena SampleScene...");
        SceneManager.LoadScene("SampleScene");
    }
    [SerializeField] public void Multiplayer()

    {
        Debug.Log("Cargando partida...");
        SceneManager.LoadScene("Multijugador");
    }
    public void Salir() 
    
    {
        Debug.Log("Hemos finalizado el juego");
        Application.Quit();
    }
}
