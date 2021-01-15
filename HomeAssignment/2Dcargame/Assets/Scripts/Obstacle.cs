using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    [SerializeField] AudioClip ObstacleDeathSound;
    [SerializeField] [Range(0, 1)] float ObstacleDeathSoundVolume = 0.75f;

    [SerializeField] GameObject deathExplosion;
    [SerializeField] float durationOfExplosion = 1f;
    
    [SerializeField] float health = 1f; 
    [SerializeField] float Shot;
    [SerializeField] float minTimeBetweenShots = 0.2f;
    [SerializeField] float maxTimeBetweenShots = 3f;
    [SerializeField] GameObject obstacleBullet;
    [SerializeField] float obstactleBulletSpeed = 0.3f;

    [SerializeField] int scoreValue = 5;
    

    private void OnTriggerEnter2D(Collider2D otherObject)
    {
        DamageDealer dmgDealer = otherObject.gameObject.GetComponent<DamageDealer>();

        health -= dmgDealer.GetDamage();

        if (health <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        Destroy(gameObject);
        AudioSource.PlayClipAtPoint(ObstacleDeathSound, Camera.main.transform.position, ObstacleDeathSoundVolume);
        GameObject explosion = Instantiate(deathExplosion, transform.position, Quaternion.identity);
        Destroy(explosion, durationOfExplosion);
    }
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
