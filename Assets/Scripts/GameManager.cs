using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;

    public static SpriteSystem SpriteSystem { get; private set; }
    public static ManaSystem ManaSystem { get; private set; }
    public static ActionSystem ActionSystem { get; private set; }
    public static InfluenceSystem InfluenceSystem { get; private set; }

    [SerializeField] private UnitSpawner[] bases;

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
        InfluenceSystem = GetComponent<InfluenceSystem>();
    }

    public static UnitSpawner GetLocalBase()
    {
        return instance.bases[PhotonNetwork.LocalPlayer.ActorNumber - 1];
    }
}
