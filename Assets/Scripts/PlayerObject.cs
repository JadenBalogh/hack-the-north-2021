using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerObject : MonoBehaviour
{
    [SerializeField] private int defaultPlayerId;
    private int playerId;
    public int PlayerId
    {
        get => playerId;
        set
        {
            playerId = value;
            OnPlayerIdChanged.Invoke(playerId);
        }
    }
    public UnityEvent<int> OnPlayerIdChanged { get; private set; }

    protected virtual void Awake()
    {
        OnPlayerIdChanged = new UnityEvent<int>();
        playerId = defaultPlayerId;
    }

    protected bool IsEnemy(PlayerObject other)
    {
        return playerId != other.PlayerId;
    }
}
