using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleMovement : MonoBehaviour
{
    public float movementSpeed = 5f;
    public float leftBoundary = -4f;
    public float rightBoundary = 4f;

    private bool movingRight = true;

    void Update()
    {
        if (movingRight){
            transform.Translate(Vector3.right * movementSpeed * Time.deltaTime);
        }
        else{
            transform.Translate(Vector3.left * movementSpeed * Time.deltaTime);
        }

        if (transform.position.x >= rightBoundary){
            movingRight = false;
        }
        else if (transform.position.x <= leftBoundary){
            movingRight = true;
        }
    }
}

