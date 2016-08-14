using UnityEngine;
using System.Collections;
using System.IO.Ports;

public class Arduino : MonoBehaviour {
    public Transform Ob;
    // Use this for initialization
    void Start() {

    }

    string a,b;
    SerialPort Serial = new SerialPort("COM3", 9600);
    // Update is called once per frame
    void Update() {

        if (!Serial.IsOpen)
            Serial.Open();
        /*
        int a = int.Parse(Serial.ReadLine());
       
        int b = int.Parse(Serial.ReadLine());
        Debug.Log("A "+ a);
        Debug.Log("B " + b);
        */
        float a = float.Parse(Serial.ReadLine());



        Ob.position = new Vector3(0, 0, -a/10);


        //   float  b = Ob.position.z ;

        Debug.Log("A " + a);
        /*
        a = a +" "+ Serial.ReadLine();
        Debug.Log("A " + a);
        b = b + " " + Serial.ReadLine();
        Debug.Log("B " + b);
        */
    }
}
