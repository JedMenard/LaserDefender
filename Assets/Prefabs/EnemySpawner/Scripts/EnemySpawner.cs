using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    private List<WaveConfigSO> allWaves;

    [SerializeField]
    private float spawnFrequency = 1;

    private int currentWaveIndex = 0;

    public WaveConfigSO CurrentWave => this.allWaves[this.currentWaveIndex];

    // Start is called before the first frame update
    private void Start()
    {
        this.StartCoroutine(this.RunWave());
    }

    private IEnumerator SpawnEnemies()
    {
        for (int i = 0; i < this.CurrentWave.EnemyCount; i++)
        {
            Instantiate(this.CurrentWave.GetEnemyByIndex(i),
                    this.CurrentWave.StartWaypoint.position,
                    Quaternion.Euler(0, 0, 180),
                    this.transform);

            yield return new WaitForSeconds(this.spawnFrequency);
        }
    }

    private IEnumerator RunWave()
    {
        this.StartCoroutine(this.SpawnEnemies());
        yield return new WaitForSeconds(this.CurrentWave.WaveDuration);
        this.currentWaveIndex = (int)Mathf.Repeat(this.currentWaveIndex + 1, this.allWaves.Count);
        this.StartCoroutine(this.RunWave());
    }
}
