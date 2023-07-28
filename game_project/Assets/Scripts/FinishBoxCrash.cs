using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishBoxCrash : MonoBehaviour
{
    public GameObject mousy;
    public GameObject animatMousy;
    public GameObject cheeseTop;
    public GameObject questionTop;
    public GameObject healthTop;
    public GameObject finishScreen;

    private bool collisionOccurred = false;

    void OnTriggerEnter(Collider other)
    {
        if (!collisionOccurred && other.gameObject == mousy)
        {
            collisionOccurred = true;
            this.gameObject.GetComponent<BoxCollider>().enabled = false;
            mousy.GetComponent<PlayerMovement>().enabled = false;
            //animatMousy.GetComponent<Animator>().Play("Happy Idle");
            animatMousy.GetComponent<Animator>().Play("Twist Dance");
            StartCoroutine(FinishGame());
        }
    }

    IEnumerator FinishGame()
    {
        yield return new WaitForSeconds(3);
        cheeseTop.SetActive(false);
        healthTop.SetActive(false);
        questionTop.SetActive(false);
        finishScreen.SetActive(true);
    }
}