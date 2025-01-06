using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class Shooter : MonoBehaviour
{

    [SerializeField]
    private GameObject projectile;

    [Header("Auto Fire")]
    [SerializeField]
    private bool isManualControl = false;

    [SerializeField]
    private float maxAutoFireDelay = 5;

    [SerializeField]
    private float minAutoFireDelay = 0.2f;

    private SpriteRenderer shooterSpriteRenderer;

    private Coroutine firingCoroutine = null;

    private AudioPlayer audioPlayer;

    private void Awake()
    {
        this.audioPlayer = FindObjectOfType<AudioPlayer>();
        this.shooterSpriteRenderer = this.GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        if (!this.isManualControl && this.firingCoroutine == null)
        {
            this.firingCoroutine = this.StartCoroutine(this.AutoFire());
        }
    }

    private void OnFire(InputValue _)
    {
        if (this.isManualControl)
        {
            this.Fire();
        }
    }

    private IEnumerator AutoFire()
    {
        // Wait a random amount of time.
        yield return new WaitForSeconds(Random.Range(this.minAutoFireDelay, this.maxAutoFireDelay));

        // Fire.
        this.Fire();

        // Reset the coroutine tracker.
        this.firingCoroutine = null;
    }

    private void Fire()
    {
        this.audioPlayer.PlayShootClip();
        Vector3 spawnPoint = this.transform.position + this.transform.up * this.shooterSpriteRenderer.size.y / 2;
        Instantiate(this.projectile,
            spawnPoint,
            this.transform.rotation);
    }
}
