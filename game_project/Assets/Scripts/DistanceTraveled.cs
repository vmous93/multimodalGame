using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Text = TMPro.TextMeshProUGUI;

public class DistanceTraveled : MonoBehaviour
{
    public GameObject distShow;
    public int distCount;
    public bool distPlus = false;
    public float distCountDelay = 0.5f; 

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (distPlus == false){
            distPlus = true;
            StartCoroutine(PlusDistance());
        }
    }

    IEnumerator PlusDistance(){
        distCount += 1;
        distShow.GetComponent<Text>().text = "" + distCount;
        yield return new WaitForSeconds(distCountDelay);
        distPlus = false;
    }
}
