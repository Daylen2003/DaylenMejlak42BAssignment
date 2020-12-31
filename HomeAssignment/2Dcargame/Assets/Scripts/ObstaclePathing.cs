using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstaclePathing : MonoBehaviour
{
    [SerializeField] List<Transform> Waypoint1;

    [SerializeField] float ObstacleMoveSpeed = 2f;

    [SerializeField] WavConfig waveConfig;

    int waypointIndex = 0;

    // Start is called before the first frame update
    void Start()
    {
        Waypoint1 = waveConfig.GetWayPoints();
        transform.position = Waypoint1[waypointIndex].transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        ObstacleMove();
    }

    private void ObstacleMove()
    {
        if(waypointIndex <= Waypoint1.Count -1)
        {
            var targetPosition = Waypoint1[waypointIndex].transform.position;

            targetPosition.z = 0f;

            var obstacleMovment = ObstacleMoveSpeed * Time.deltaTime;

            transform.position = Vector2.MoveTowards(transform.position, targetPosition, obstacleMovment);

            if(transform.position == targetPosition)
            {
                waypointIndex++;
            }
        }

        else
        {
            Destroy(gameObject);
        }
    }

    public void settingWaveConfig(WavConfig waveConfigToset)
    {
        waveConfig = waveConfigToset;  
    }
    
}
