using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    [SerializeField] float Shot;
    [SerializeField] float minTimeBetweenShots = 0.2f;
    [SerializeField] float maxTimeBetweenShots = 3f;
    [SerializeField] GameObject obstacleBullet;
    [SerializeField] float obstactleBulletSpeed = 0.3f;  



    private void Start()
    {
        Shot = Random.Range(minTimeBetweenShots, maxTimeBetweenShots);
    }

    private void Update()
    {
        ShootCountdown();
    }

    private void ShootCountdown()

    {
        Shot -= Time.deltaTime;

        if (Shot <= 0f)
        {
            ObstacleShoot();

            Shot = Random.Range(minTimeBetweenShots, maxTimeBetweenShots);
        }

    }
    public void ObstacleShoot()
    {
        GameObject ObstacleLaser = Instantiate(obstacleBullet, transform.position, Quaternion.identity) as GameObject;

        ObstacleLaser.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -obstactleBulletSpeed);
    }
}
