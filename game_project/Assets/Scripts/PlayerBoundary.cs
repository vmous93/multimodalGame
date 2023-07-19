using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBoundary : MonoBehaviour
{
    public static float leftBoundry = -4f;
    public static float rightBoundry = 4f;
    public static float leftInternal;
    public static float rightInternal;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        leftInternal = leftBoundry;
        rightInternal = rightBoundry;
    }
}
