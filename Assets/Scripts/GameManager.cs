using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Photon.Pun;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;

    public static SpriteSystem SpriteSystem { get; private set; }
    public static ManaSystem ManaSystem { get; private set; }
    public static ActionSystem ActionSystem { get; private set; }

    public static bool Alive { get; set; }
    public static List<int> RemainingPlayers { get; private set; }
    public static UnityEvent<string> OnGameOver { get; private set; }

    [SerializeField] private UnitBase[] bases;

    protected void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;

        SpriteSystem = GetComponent<SpriteSystem>();
        ManaSystem = GetComponent<ManaSystem>();
        ActionSystem = GetComponent<ActionSystem>();

        RemainingPlayers = new List<int>() { 1, 2, 3, 4 };
        OnGameOver = new UnityEvent<string>();
        Alive = true;
    }

    public static UnitBase GetLocalBase()
    {
        return instance.bases[PhotonNetwork.LocalPlayer.ActorNumber - 1];
    }
}
