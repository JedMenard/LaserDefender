using System;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    [SerializeField]
    protected float MaxHealth = 0;

    [SerializeField]
    private bool isPlayer = false;
    public bool IsPlayer { get => this.isPlayer; private set => this.isPlayer = value; }

    [SerializeField]
    private bool isEnemy = false;
    public bool IsEnemy { get => this.isEnemy; set => this.isEnemy = value; }

    [SerializeField]
    private ParticleSystem hitEffect = null;

    [SerializeField]
    private Slider healthBar;

    protected float currentHealth;

    protected bool IsAlive => this.currentHealth > 0;

    protected AudioPlayer audioPlayer;

    protected ScoreKeeper scoreKeeper;

    protected virtual void Awake()
    {
        this.currentHealth = this.MaxHealth;
        this.audioPlayer = FindObjectOfType<AudioPlayer>();
        this.scoreKeeper = FindObjectOfType<ScoreKeeper>();
    }

    protected virtual void Start()
    {
        if (this.healthBar != null)
        {
            this.healthBar.value = this.currentHealth;
            this.healthBar.maxValue = this.currentHealth;
        }
    }

    /// <summary>
    /// Checks for damage caused by the trigger crossing and applies as necessary.
    /// </summary>
    /// <param name="collision"></param>
    protected virtual void OnTriggerEnter2D(Collider2D collision)
        => this.ProcessDamage(collision.gameObject);

    /// <summary>
    /// Checks for damage caused by the collision and applies as necessary.
    /// </summary>
    /// <param name="collision"></param>
    protected virtual void OnCollisionEnter2D(Collision2D collision)
        => this.ProcessDamage(collision.gameObject);

    /// <summary>
    /// Checks if the other object deals damage and applies as necessary.
    /// </summary>
    /// <param name="other"></param>
    protected virtual void ProcessDamage(GameObject other)
    {
        if (other.TryGetComponent(out DamageDealer damager))
        {
            damager.DealDamage(this);
        }
    }

    /// <summary>
    /// Applies any damage caused.
    /// By default, reduces health and destroys self if health goes below zero.
    /// </summary>
    /// <param name="damager"></param>
    public virtual void ApplyDamage(float damage)
    {
        if (this.hitEffect != null)
        {
            ParticleSystem activeEffect = Instantiate(this.hitEffect, this.transform.position, Quaternion.identity);
            Destroy(activeEffect.gameObject, activeEffect.main.duration + activeEffect.main.startLifetime.constantMax);
        }

        if (this.IsAlive)
        {
            this.currentHealth -= Math.Min(this.currentHealth, damage);

            if (this.healthBar != null)
            {
                this.healthBar.value = this.currentHealth;
            }
        }

        if (!this.IsAlive)
        {
            this.Die();
        }
    }

    public virtual void Die()
    {
        this.audioPlayer.PlayDestructionClip();

        if (this.TryGetComponent<ScoreGiver>(out ScoreGiver scoreGiver))
        {
            scoreGiver.GiveScore();
        }

        Destroy(this.gameObject);
    }
}