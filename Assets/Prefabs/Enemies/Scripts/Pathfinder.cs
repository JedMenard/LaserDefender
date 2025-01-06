using System.Collections.Generic;
using UnityEngine;

public class Pathfinder : MonoBehaviour
{
    private EnemySpawner enemySpawner;

    private WaveConfigSO currentWave;

    private List<Transform> waypoints;

    private int waypointIndex = 0;

    private float moveSpeed => this.currentWave.MoveSpeed;

    private void Awake()
    {
        this.enemySpawner = FindObjectOfType<EnemySpawner>();
        this.currentWave = this.enemySpawner.CurrentWave;
        this.waypoints = this.currentWave.Waypoints;
    }

    private void Start()
    {
        this.transform.position = this.waypoints[this.waypointIndex].position;
    }

    private void Update()
    {
        this.MoveToNextPoint();
    }

    private void MoveToNextPoint()
    {
        if (this.waypointIndex < this.waypoints.Count)
        {
            Vector3 targetPoint = this.waypoints[this.waypointIndex].position;
            float moveDelta = this.moveSpeed * Time.deltaTime;
            this.transform.position = Vector2.MoveTowards(this.transform.position, targetPoint, moveDelta);

            if (this.transform.position == targetPoint)
            {
                this.waypointIndex += 1;
            }
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
}
