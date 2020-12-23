using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "Obstacle Wave Config")]
public class WavConfig : ScriptableObject


{
    [SerializeField] GameObject ObstaclePrefeb;
    [SerializeField] float timeBetweenSpawns = 0.5f;
    [SerializeField] int numberOfOstacles = 2;
    [SerializeField] GameObject pathPrefeb;
    [SerializeField] float obstacleMoveSpeed = 0.01f; 


    public GameObject GetObstaclePrefeb()
    {
        return ObstaclePrefeb;
    }

    public GameObject GetPathPrefeb()
    {
        return pathPrefeb;
    }

    public float GetTimeBetweenSpawns()
    {
        return timeBetweenSpawns;
    }

    public int GetNumberOfObstacles()
    {
        return numberOfOstacles;
    }

    public float GetObstacleMoveSpeed()
    {
        return obstacleMoveSpeed;
    }

    public List<Transform> GetWayPoints()
    {
        var WayPoints = new List<Transform>();
        // The childs are the waypoints of the path itself. 
        foreach (Transform child in pathPrefeb.transform)
        {
            WayPoints.Add(child);
        }

        return WayPoints;
    }





    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
