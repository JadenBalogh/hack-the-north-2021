using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Photon.Pun;
using Photon.Realtime;

public class LobbyManager : MonoBehaviourPunCallbacks
{
    private static LobbyManager instance;

    private const string GAME_VERSION = "1";
    private const byte PLAYERS_PER_ROOM = 4;

    [SerializeField] private TextMeshProUGUI[] playerLabels;
    [SerializeField] private Button startButton;

    private bool isReady = false;

    protected void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;

        PhotonNetwork.AutomaticallySyncScene = true;
    }

    protected void Start()
    {
        Connect();
        StartCoroutine(WaitJoinRoom());
    }

    public void SetPlayerName(string name)
    {
        PhotonNetwork.LocalPlayer.NickName = name;
    }

    public void StartGame()
    {
        PhotonNetwork.LoadLevel("Main");
    }

    private void RefreshLabels()
    {
        for (int i = 0; i < PhotonNetwork.PlayerList.Length; i++)
        {
            Player player = PhotonNetwork.PlayerList[i];
            playerLabels[i].text = player.NickName;
        }
    }

    private void Connect()
    {
        if (!PhotonNetwork.IsConnected)
        {
            PhotonNetwork.ConnectUsingSettings();
            PhotonNetwork.GameVersion = GAME_VERSION;
        }
    }

    private IEnumerator WaitJoinRoom()
    {
        yield return new WaitUntil(() => isReady);
        PhotonNetwork.JoinRandomRoom();
    }

    private IEnumerator WaitRefreshLabels(Player targetPlayer)
    {
        yield return new WaitUntil(() => targetPlayer.NickName.Length > 0);
        RefreshLabels();
    }

    /// ~~~~ PHOTON CALLBACKS ~~~~ ///

    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        if (PhotonNetwork.CurrentRoom.PlayerCount == PhotonNetwork.CurrentRoom.MaxPlayers)
        {
            StartGame();
        }
        else
        {
            StartCoroutine(WaitRefreshLabels(newPlayer));
        }
    }

    public override void OnJoinRandomFailed(short returnCode, string message)
    {
        PhotonNetwork.CreateRoom(null, new RoomOptions { MaxPlayers = PLAYERS_PER_ROOM });
    }

    public override void OnJoinedRoom()
    {
        SetPlayerName("Player" + PhotonNetwork.LocalPlayer.ActorNumber);
        RefreshLabels();
        if (PhotonNetwork.IsMasterClient)
        {
            startButton.interactable = true;
        }
    }

    public override void OnConnectedToMaster()
    {
        isReady = true;
    }

    public override void OnDisconnected(DisconnectCause cause)
    {
        Debug.LogWarning($"Disconnected: {cause}");
    }
}
