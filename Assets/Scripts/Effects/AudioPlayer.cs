using Unity.VisualScripting;
using UnityEngine;

public class AudioPlayer : MonoBehaviour
{
    [Header("Shooting")]

    [SerializeField]
    private AudioClip shootClip;

    [SerializeField]
    [Range(0, 1)]
    private float shootVolume;

    [Header("Damage")]

    [SerializeField]
    private AudioClip damageClip;

    [SerializeField]
    [Range(0, 1)]
    private float damageVolume;

    [Header("Destruction")]

    [SerializeField]
    private AudioClip destructionClip;

    [SerializeField]
    [Range(0, 1)]
    private float destructionVolume;

    private static AudioPlayer instance;

    private void Awake() => this.ManageSingleton();

    private void ManageSingleton()
    {
        if (instance != null)
        {
            this.gameObject.SetActive(false);
            Destroy(this.gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
    }

    public void PlayShootClip() => this.PlayClip(this.shootClip, this.shootVolume);

    public void PlayDamageClip() => this.PlayClip(this.damageClip, this.damageVolume);

    public void PlayDestructionClip() => this.PlayClip(this.destructionClip, this.destructionVolume);

    private void PlayClip(AudioClip clip, float volume)
    {
        AudioSource.PlayClipAtPoint(clip,
            Camera.main.transform.position,
            volume);
    }
}