using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class LogicaRed : MonoBehaviourPunCallbacks
{
    public static LogicaRed isntancia;

    private void Awake()
    {
        isntancia = this;
        DontDestroyOnLoad(gameObject);  
    }

    // Start is called before the first frame update
    void Start()
    {
        PhotonNetwork.ConnectUsingSettings();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void OnConnectedToMaster()
    {
        Debug.Log("Estamos en linea");    
     }
}
