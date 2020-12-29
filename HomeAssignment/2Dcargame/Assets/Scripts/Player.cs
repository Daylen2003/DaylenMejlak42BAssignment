using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] float moveSpeed = 8f;

    [SerializeField] float padding = 0.4f;

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
