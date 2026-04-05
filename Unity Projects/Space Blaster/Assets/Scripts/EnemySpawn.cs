using UnityEngine;
using System.Collections;

public class EnemySpawn : MonoBehaviour
{
    [SerializeField] bool isLooping;
    [SerializeField] float timeBtwWaves =2f;
    [SerializeField] Wave [] WaveCofig;
     Wave Spawn;
    void Start()
    {
      StartCoroutine(SpawnEnemies());
    }
    IEnumerator SpawnEnemies()
    {
        do
        {
            foreach(Wave wave in WaveCofig)
        {
            Spawn = wave;
            for (int i = 0; i < Spawn.GetEnemyCount(); i++)
            {
               Instantiate(Spawn.GetEnemyPrefabs(i),
                Spawn.GetStartingWaypoint().position, 
                Quaternion.identity, transform);

               yield return new WaitForSeconds(Spawn.GetRandomEnemySpawnTime());
            }
            yield return new WaitForSeconds(timeBtwWaves);
        } 
        }
        while(isLooping);
        
    }

    public Wave GetCurrentWave()
    {
        return Spawn;
    }
}
