using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CorrectAnswerCollect : MonoBehaviour
{

    public AudioSource correctFX;
    void OnTriggerEnter(Collider other){

        correctFX.Play();
        CorrectAnswerControl.correctAnswerCount += 1;
        this.gameObject.SetActive(false);
    }


}
