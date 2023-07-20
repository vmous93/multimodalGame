using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheeseCollect : MonoBehaviour
{

    public AudioSource cheeseFX;
    void OnTriggerEnter(Collider other){

        cheeseFX.Play();
        CollectingControl.cheeseCount += 1;
        this.gameObject.SetActive(false);
    }


}
