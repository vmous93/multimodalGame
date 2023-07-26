using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

public class PlayerMovement : MonoBehaviour
{
    public float playerSpeed = 5;
    public float playerFasterSpeed = 10;
    private bool useFasterSpeed = false;
    public float moveSideSpeed = 2.3f;
    static public bool hallucination = false;
    public float accelerometerSensitivity = 3.0f;
    public bool jumping = false;
    public bool landing = false;
    public int jumpingTreshold = 3;
    public GameObject player;
    
    // Make connection to Python script for HR
    Thread mThread;
    public string connectionIP = "127.0.0.1";
    public int connectionPort = 25001;
    IPAddress localAdd;
    TcpListener listener;
    TcpClient client;
    bool running;

    // Start is called before the first frame update
    void Start()
    {
        ThreadStart ts = new ThreadStart(GetInfo);
        mThread = new Thread(ts);
        mThread.Start();
    }

    // Update is called once per frame
    void Update()
    {
        // Check the player speed based on heart rate
        float currentSpeed = useFasterSpeed ? playerFasterSpeed : playerSpeed;

        if (currentSpeed == playerFasterSpeed){
            player.GetComponent<Animator>().Play("Fast Run");
        }
        else player.GetComponent<Animator>().Play("Slow Run");

        transform.Translate(Vector3.forward * Time.deltaTime * currentSpeed, Space.World);
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

    void GetInfo()
    {
        localAdd = IPAddress.Parse(connectionIP);
        listener = new TcpListener(IPAddress.Any, connectionPort);
        listener.Start();

        client = listener.AcceptTcpClient();

        running = true;
        while (running)
        {
            SendAndReceiveData();
        }
        listener.Stop();
    }

    
    void SendAndReceiveData()
    {
        NetworkStream nwStream = client.GetStream();
        byte[] buffer = new byte[client.ReceiveBufferSize];

        // Getting data from Python
        int bytesRead = nwStream.Read(buffer, 0, client.ReceiveBufferSize);
        string dataReceived = Encoding.UTF8.GetString(buffer, 0, bytesRead);

        if (dataReceived != null)
        {
            // Assigning useFasterSpeed value from Python
            useFasterSpeed = StringToVector(dataReceived); 
            //print("received HR data and set the Player speed");

            // Sending the data in Bytes to Python
            byte[] myWriteBuffer = Encoding.ASCII.GetBytes("Player Speed Value hase been recieved!");
            nwStream.Write(myWriteBuffer, 0, myWriteBuffer.Length);
        }
    }

    public static bool StringToVector(string sVector)
    {
        // Remove the parentheses
        if (sVector.StartsWith("(") && sVector.EndsWith(")")){
            sVector = sVector.Substring(1, sVector.Length - 2);
        }

        bool result;
        if (sVector == "1"){
            result = true;
        }
        else result = false;

        return result;
    }
}
