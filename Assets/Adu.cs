using UnityEngine;
using System.IO.Ports;
using UnityEngine.UI;
using System.Collections;

public class Adu : MonoBehaviour {

    public Text sensor;
    public Text buttumspeed;
    public Text brake;
    public string Portconnect;
    SerialPort Sp;
    // Use this for initialization
    void Start()
    {
        Sp = new SerialPort(Portconnect, 9600);
        Sp.Open();
    }

    // Update is called once per frame
    void Update()
    {
        sensor.text = Sp.ReadLine();
        buttumspeed.text = Sp.ReadLine();
        brake.text = Sp.ReadLine();
    }
}
