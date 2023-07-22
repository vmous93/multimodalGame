using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Text = TMPro.TextMeshProUGUI;

public class CrashControl : MonoBehaviour
{

    public static int healthCount = 200;
    public GameObject healthCountShow;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        healthCountShow.GetComponent<Text>().text = "" + healthCount;
    }
}
