using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleCrash : MonoBehaviour
{
    public GameObject mousy;
    public GameObject moveType;
    public GameObject moveTypeAfter;
    public AudioSource hitFX;

    private bool isColliding = false;

    void OnTriggerEnter(Collider other){
        if (!isColliding){
            isColliding = true;
            StartCoroutine(ObstacleCollision());
        }
        StartCoroutine(KeepGoing());

    }

    IEnumerator ObstacleCollision(){
        hitFX.Play();
        this.gameObject.GetComponent<BoxCollider>().enabled = false;
        mousy.GetComponent<PlayerMovement>().enabled = false;
        moveType.GetComponent<Animator>().Play("Rifle Hit To Back");
        CrashControl.healthCount -= 5; //Reducing health
        yield return new WaitForSeconds(1); // Adjust the duration of the animation
        StartCoroutine(BlinkMousy(.5f));
    }

    IEnumerator BlinkMousy(float duration){
        float blinkTime = 0.05f; 
        float endTime = Time.time + duration;

        while (Time.time < endTime){
            mousy.SetActive(!mousy.activeSelf); 
            yield return new WaitForSeconds(blinkTime);
        }

        mousy.SetActive(true);
    }

    IEnumerator KeepGoing(){
        yield return new WaitForSeconds(1);
        mousy.GetComponent<PlayerMovement>().enabled = true;
        moveTypeAfter.GetComponent<Animator>().Play("Slow Run");
        this.gameObject.GetComponent<BoxCollider>().enabled = true;
    }
}

