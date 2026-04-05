using UnityEngine;

public class PathFinding : MonoBehaviour
{
    EnemySpawn enemySpawn;
    Wave waveConfig;
    Transform[] Waypoints;
    int WaypointIndex = 0;

    void Start()
    {
        enemySpawn = FindFirstObjectByType<EnemySpawn>();
        waveConfig = enemySpawn.GetCurrentWave();
        Waypoints = waveConfig.GetWayPoint();
        transform.position = waveConfig.GetStartingWaypoint().position;
    }

    
    void Update()
    {
        FollowPath();
    }
    void FollowPath()
    {
        if (WaypointIndex < Waypoints.Length)
        {
            Vector3 targetposition = Waypoints[WaypointIndex].position;
            float moveDelta = waveConfig.GetEnemySpeed()*Time.deltaTime;
            transform.position = Vector2.MoveTowards(transform.position,targetposition,moveDelta);
            if (transform.position == targetposition)
            {
                WaypointIndex++;
            }
        }
         else
         {
            Destroy(gameObject);
         }
    }
}
