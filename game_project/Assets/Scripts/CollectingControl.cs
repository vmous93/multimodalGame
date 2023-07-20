using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Text = TMPro.TextMeshProUGUI;

public class CollectingControl : MonoBehaviour
{

    public static int cheeseCount;
    public GameObject cheeseCountShow;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        cheeseCountShow.GetComponent<Text>().text = "" + cheeseCount;
    }
}
