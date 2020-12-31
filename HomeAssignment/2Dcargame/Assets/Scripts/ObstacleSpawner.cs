using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    [SerializeField] List<WavConfig> waveConfigList;

    [SerializeField] bool looping = false;


 
    IEnumerator Start()
    {
        do
        {
            yield return StartCoroutine(SpawnAllWaves());
        }
      
        while (looping); 

    }


    
    void Update()
    {

    }

    
    private IEnumerator SpawnAllEnemiesInWave(WavConfig waveToSpawn)
    {
        for (int Obstcount = 1; Obstcount <= waveToSpawn.GetNumberOfObstacles(); Obstcount++)
        {
            var newObstacle = Instantiate(
                       waveToSpawn.GetObstaclePrefeb(),
                       waveToSpawn.GetWayPoints()[0].transform.position,
                       Quaternion.identity) as GameObject;
          
            newObstacle.GetComponent<ObstaclePathing>().settingWaveConfig(waveToSpawn);

            yield return new WaitForSeconds(waveToSpawn.GetTimeBetweenSpawns());

        }
        

    }
    private IEnumerator SpawnAllWaves()
    {
        
        foreach (WavConfig currentWave in waveConfigList)
        {
            

            yield return StartCoroutine(SpawnAllEnemiesInWave(currentWave));
        }
    }
}

