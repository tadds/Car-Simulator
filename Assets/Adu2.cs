using UnityEngine;
using System.Collections;
using System.IO.Ports;
using UnityEngine.UI;

public class Adu2 : MonoBehaviour {

    public Text sensor;
    public string Portconnect;
    SerialPort Sp;
    // Use this for initialization
    void Start () {
        Sp = new SerialPort(Portconnect, 9600);
        Sp.Open();
    }
	
	// Update is called once per frame
	void Update () {

        sensor.text = Sp.ReadLine();
       /* if (0>int.Parse(Sp.ReadLine())) 
        {
            sensor.text = Sp.ReadLine();
        }
        else
        {
            sensor.text = "+" + Sp.ReadLine();
        }*/
        
    }
}
