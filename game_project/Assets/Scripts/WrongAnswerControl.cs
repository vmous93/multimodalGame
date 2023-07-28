using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Text = TMPro.TextMeshProUGUI;

public class WrongAnswerControl : MonoBehaviour
{

    public static int wrongAnswerCount = 0;
    public GameObject WrongAnswerShow;
    public GameObject WrongAnswerFinishShow;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        WrongAnswerShow.GetComponent<Text>().text = "" + wrongAnswerCount;
        WrongAnswerFinishShow.GetComponent<Text>().text = "" + wrongAnswerCount;
    }
}
