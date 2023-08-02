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
        StartCoroutine(TriggerHapticFeedback(3f));
        this.gameObject.GetComponent<BoxCollider>().enabled = false;
        mousy.GetComponent<PlayerMovement>().enabled = false;
        moveType.GetComponent<Animator>().Play("Rifle Hit To Back");
        CrashControl.healthCount -= 5; //Reducing health
        yield return new WaitForSeconds(1); // Adjust the duration of the animation
        StartCoroutine(BlinkMousy(.5f));
    }

    IEnumerator TriggerHapticFeedback(float duration)
    {
		Handheld.Vibrate();
		yield return new WaitForSeconds(duration);
    }

    IEnumerator BlinkMousy(float duration){
        float blinkTime = 0.05f; 
        float endTime = Time.time + duration;
        PlayerMovement.hallucination = true;
        while (Time.time < endTime){
            mousy.SetActive(!mousy.activeSelf); 
            yield return new WaitForSeconds(blinkTime);
        }

        mousy.SetActive(true);
        PlayerMovement.hallucination = false;
    }

    IEnumerator KeepGoing(){
        yield return new WaitForSeconds(1f);
        mousy.GetComponent<PlayerMovement>().enabled = true;
        this.gameObject.GetComponent<BoxCollider>().enabled = true;
        moveTypeAfter.GetComponent<Animator>().Play("Slow Run");
        Vector3 newPosition = mousy.transform.position;
        newPosition.y = 1.4f;
        mousy.transform.position = newPosition;
    }
}

