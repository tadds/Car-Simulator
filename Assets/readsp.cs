using UnityEngine;
using System.Collections;
using System.IO.Ports;
using UnityEngine.UI;

public class readsp : MonoBehaviour {

    public Text sensor;
    SerialPort Sp = new SerialPort("COM3", 9600);
    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (!Sp.IsOpen)
            Sp.Open();
        //       float a = float.Parse(Serial.ReadLine());
        sensor.text = Sp.ReadLine();
    }
}
