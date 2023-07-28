using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishSceneShow : MonoBehaviour
{
    public GameObject cheeseTop;
    public GameObject questionTop;
    public GameObject healthTop;
    public GameObject finishScreen;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(FinishGame());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator FinishGame(){
        yield return new WaitForSeconds(3);
        cheeseTop.SetActive(false);
        healthTop.SetActive(false);
        questionTop.SetActive(false);
        finishScreen.SetActive(true);
    }
}
