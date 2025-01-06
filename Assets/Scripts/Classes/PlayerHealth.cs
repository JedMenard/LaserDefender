using System.Collections;
using UnityEngine;

public class PlayerHealth : Health
{
    [SerializeField]
    private float gameOverDelay = 2;

    private LevelManager levelManager;

    protected override void Awake()
    {
        base.Awake();
        this.levelManager = FindObjectOfType<LevelManager>();
    }

    public override void ApplyDamage(float damage)
    {
        base.ApplyDamage(damage);

        if (this.IsAlive)
        {
            this.audioPlayer.PlayDamageClip();
            Camera.main.GetComponent<CameraShake>().Play();
        }
    }

    public override void Die()
    {
        this.levelManager.LoadGameOver(this.gameOverDelay);
        base.Die();
    }
}