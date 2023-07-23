using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WrongAnswerCollect : MonoBehaviour
{

    public AudioSource wrongFX;
    void OnTriggerEnter(Collider other){

        wrongFX.Play();
        WrongAnswerControl.wrongAnswerCount += 1;
        this.gameObject.SetActive(false);
    }


}
