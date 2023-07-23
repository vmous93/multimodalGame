using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float playerSpeed = 5;
    public float moveSideSpeed = 2.3f;
    static public bool hallucination = false;
    public float accelerometerSensitivity = 3.0f;
    public bool jumping = false;
    public bool landing = false;
    public int jumpingTreshold = 3;
    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * playerSpeed, Space.World);
        if (hallucination == false){

            float accelerationX = Input.acceleration.x;

            if ((accelerationX < -0.1f) || (Input.GetKey(KeyCode.LeftArrow))){
                // Move left if the device is tilted to the left
                if (this.gameObject.transform.position.x > PlayerBoundary.leftBoundry)
                {
                    transform.Translate(Vector3.left * Time.deltaTime * moveSideSpeed);
                }
            }
            else if ((accelerationX > 0.1f) || (Input.GetKey(KeyCode.RightArrow))){
                // Move right if the device is tilted to the right
                if (this.gameObject.transform.position.x < PlayerBoundary.rightBoundry)
                {
                    transform.Translate(Vector3.right * Time.deltaTime * moveSideSpeed);
                }
            }
            if (Input.GetKey(KeyCode.Space)){
                if (jumping == false){
                    jumping = true;
                    player.GetComponent<Animator>().Play("Jump");
                    StartCoroutine(jumpduration());
                }
            }
        }
        if (jumping == true){
            if (landing == false){
                transform.Translate(Vector3.up * Time.deltaTime * jumpingTreshold, Space.World);
            }
            if (landing == true){
                transform.Translate(Vector3.up * Time.deltaTime * -jumpingTreshold, Space.World);
            }
        }
    }
    IEnumerator jumpduration(){
        yield return new WaitForSeconds(0.5f);
        landing = true;
        yield return new WaitForSeconds(0.5f);
        jumping = false;
        landing = false;
        player.GetComponent<Animator>().Play("Slow Run");
    }
}
