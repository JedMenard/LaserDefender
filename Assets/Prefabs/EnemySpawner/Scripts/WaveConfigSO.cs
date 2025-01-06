using System.Collections.Generic;
using UnityEngine;
using System.Linq;

[CreateAssetMenu(menuName = "Wave Config", fileName = "New Wave Config")]
public class WaveConfigSO : ScriptableObject
{
    [SerializeField]
    private Transform pathPrefab;

    [SerializeField]
    private float moveSpeed = 5;
    public float MoveSpeed { get => this.moveSpeed; private set => this.moveSpeed = value; }

    [SerializeField]
    private List<GameObject> enemies;

    [SerializeField]
    private float waveDuration = 8;
    public float WaveDuration { get => this.waveDuration; private set => this.waveDuration = value; }

    public Transform StartWaypoint => this.pathPrefab.GetChild(0);

    public List<Transform> Waypoints
        => (from Transform transform in this.pathPrefab select transform).ToList();

    public GameObject GetEnemyByIndex(int index)
        => this.enemies[index];

    public int EnemyCount => this.enemies.Count;
}
