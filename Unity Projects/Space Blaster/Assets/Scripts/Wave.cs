using UnityEngine;

[CreateAssetMenu(fileName = "Wave", menuName = "Wave")]
public class Wave : ScriptableObject
{
    [SerializeField] GameObject[] EnemyPrefabs;
    [SerializeField] Transform Path;
    [SerializeField] float EnemySpeed = 5f;
    [SerializeField] float timeBtwEnemySpawn =1f;
    [SerializeField] float EnemyVariance =0f;
    [SerializeField] float MinimumSpawnTime =0.2f;

    public int GetEnemyCount()
    {
        return EnemyPrefabs.Length;
    }
    public GameObject GetEnemyPrefabs(int index)
    {
        return EnemyPrefabs[index];
    }

    public Transform GetStartingWaypoint()
    {
        return Path.GetChild(0);
    }
    public float GetEnemySpeed()
    {
        return EnemySpeed;
    }
    public Transform[] GetWayPoint()
    {
        Transform[] Waypoints = new Transform [Path.childCount];
        for (int i=0; i<Path.childCount; i++)
        {
            Waypoints[i]=Path.GetChild(i);
        }
        return Waypoints; 
    }

    public float GetRandomEnemySpawnTime()
    {
        float spawnTime = Random.Range(timeBtwEnemySpawn-EnemyVariance,timeBtwEnemySpawn+EnemyVariance);

        spawnTime = Mathf.Clamp(spawnTime, MinimumSpawnTime,float.MaxValue);
        return spawnTime;
    }


}
