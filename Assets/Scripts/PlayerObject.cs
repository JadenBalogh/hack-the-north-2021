using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public abstract class PlayerObject : MonoBehaviour
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

    [SerializeField] private int maxHealth = 1;
    public int Health { get; private set; }
    public UnityEvent<int> OnHealthChanged { get; private set; }
    public UnityEvent OnDeath { get; private set; }

    [SerializeField] private float hitFlashDuration = 0.2f;
    [SerializeField] private float hitFlashAlpha = 0.5f;

    private SpriteRenderer spriteRenderer;
    private WaitForSeconds hitFlashDurationWait;

    protected virtual void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();

        OnPlayerIdChanged = new UnityEvent<int>();
        playerId = defaultPlayerId;

        OnHealthChanged = new UnityEvent<int>();
        OnDeath = new UnityEvent();
        Health = maxHealth;

        hitFlashDurationWait = new WaitForSeconds(hitFlashDuration);
    }

    public virtual void TakeDamage(int attackerId, int damage)
    {
        StartCoroutine(HitFlash());
        UpdateHealth(attackerId, -damage);
    }

    public virtual void RestoreHealth(int amount)
    {
        UpdateHealth(playerId, amount);
    }

    public virtual void ResetHealth()
    {
        UpdateHealth(playerId, maxHealth);
    }

    protected virtual void Die(int killerId) { }

    private void UpdateHealth(int sourceId, int delta)
    {
        Health = Mathf.Clamp(Health + delta, 0, maxHealth);
        OnHealthChanged.Invoke(Health);
        if (Health <= 0)
        {
            OnDeath.Invoke();
            Die(sourceId);
        }
    }

    private IEnumerator HitFlash()
    {
        SetAlpha(hitFlashAlpha);
        yield return hitFlashDurationWait;
        SetAlpha(1);
    }

    private void SetAlpha(float a)
    {
        Color color = spriteRenderer.color;
        color.a = a;
        spriteRenderer.color = color;
    }

    protected bool IsEnemy(PlayerObject other)
    {
        return playerId != other.PlayerId;
    }
}
