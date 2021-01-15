using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Player : MonoBehaviour
{
    [SerializeField] AudioClip playerDeathSound;
    
    [SerializeField] [Range(0, 1)] float playerDeathSoundVolume = 0.75f;

    [SerializeField] float health = 50f; 

    [SerializeField] float moveSpeed = 8f;

    [SerializeField] float padding = 0.4f;

    int Score = 0;

    float xMin, xMax;  
    void Start()
    {
        SetUpMoveBoundaries();
    }

    

    // Update is called once per frame
    void Update()
    {
        moveCar();
    }

    private void OnTriggerEnter2D(Collider2D otherObject)
    {
        DamageDealer dmgDealer = otherObject.gameObject.GetComponent<DamageDealer>();

        ProcessDamage(dmgDealer);
    }

    private void ProcessDamage(DamageDealer dmgDealer)
    {
        health -= dmgDealer.GetDamage();
        Score = FindObjectOfType<GameSession>().GettingScore();

        if (health <= 0 && Score < 100)
        {
            
            Die();
        }
    }

    private void Die()
    {
        Destroy(gameObject);
        AudioSource.PlayClipAtPoint(playerDeathSound, Camera.main.transform.position, playerDeathSoundVolume);
        FindObjectOfType<Level>().LoadGameOverScene();
    }

    private void SetUpMoveBoundaries()
    {
        Camera cameraView = Camera.main;

        xMin = cameraView.ViewportToWorldPoint(new Vector3(0, 0, 0)).x + padding;
        xMax = cameraView.ViewportToWorldPoint(new Vector3(1, 0, 0)).x - padding;

        


    }



    private void moveCar()
    {
        var moveX = Input.GetAxis("Horizontal")* Time.deltaTime * moveSpeed;

        var moveXPos = Mathf.Clamp(transform.position.x + moveX, xMin , xMax);

        

        transform.position = new Vector2(moveXPos,transform.position.y);
    }

}
