using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.SceneManagement;


public class GestorPhoton : MonoBehaviourPunCallbacks
{
    private bool isTryingToJoinLobby = false;
    public MenuInicial menuInicial;
    void Start()
    {
        PhotonNetwork.ConnectUsingSettings();
    }

    void Update()
    {
        // Verifica si se está intentando unir al lobby pero aún no está conectado
        if (isTryingToJoinLobby && PhotonNetwork.IsConnectedAndReady)
        {
            PhotonNetwork.JoinLobby();
            isTryingToJoinLobby = false;
        }
    }

    public override void OnConnectedToMaster()
    {
        Debug.Log("Conectado al Master Server");
        if (PhotonNetwork.IsConnectedAndReady)
        {
            PhotonNetwork.JoinLobby();
        }
        else
        {
            isTryingToJoinLobby = true;
        }
    }

    public override void OnJoinedLobby()
    {
        Debug.Log("Unido al Lobby");
        PhotonNetwork.JoinOrCreateRoom("Cuarto", new RoomOptions { MaxPlayers = 2 }, TypedLobby.Default);
    }

    public override void OnJoinedRoom()
    {
        Debug.Log("Unido a la Sala");
        PhotonNetwork.Instantiate("nave", new Vector2(Random.Range(-6, 6), 2), Quaternion.identity);
    }

    public override void OnDisconnected(DisconnectCause cause)
    {
        Debug.LogError("Desconectado del servidor: " + cause);
        // Intentar reconectar
        PhotonNetwork.ConnectUsingSettings();
        menuInicial.GetInstanceID();
    }
}
