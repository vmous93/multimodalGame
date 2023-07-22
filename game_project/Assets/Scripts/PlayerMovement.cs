using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float playerSpeed = 5;
    public float moveSideSpeed = 2.3f;
    static public bool hallucination = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * playerSpeed, Space.World);
        if (hallucination == false){

            if (Input.GetKey(KeyCode.LeftArrow)){
                if (this.gameObject.transform.position.x > PlayerBoundary.leftBoundry){
                    transform.Translate(Vector3.left * Time.deltaTime * moveSideSpeed);
                }
            }

            if (Input.GetKey(KeyCode.RightArrow)){
                if (this.gameObject.transform.position.x < PlayerBoundary.rightBoundry){
                    transform.Translate(Vector3.left * Time.deltaTime * moveSideSpeed * -1);
                }
            }
        }
    }
}
