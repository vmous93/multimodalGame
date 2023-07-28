using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Text = TMPro.TextMeshProUGUI;

public class CorrectAnswerControl : MonoBehaviour
{

    public static int correctAnswerCount = 0;
    public GameObject CorrectAnswerShow;
    public GameObject CorrectAnswerFinishShow;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        CorrectAnswerShow.GetComponent<Text>().text = "" + correctAnswerCount;
        CorrectAnswerFinishShow.GetComponent<Text>().text = "" + correctAnswerCount;
    }
}
