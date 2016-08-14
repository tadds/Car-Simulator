using UnityEngine;
using System.IO.Ports;
using System.Threading;
using System.Collections;

public class adusend : MonoBehaviour {
    public static SerialPort sp = new SerialPort("COM3", 9600);
    public string massage = "gg";
    string massage1 = "g";
    string massage2 = "g";
    // Use this for initialization
    void Start () {
	if (sp != null)
        {
            if(sp.IsOpen)
            {
                sp.Close();
            }
            else
            {
                sp.Open();
                sp.ReadTimeout = 16;
            }

        }
	}
	
	// Update is called once per frame
	void Update () {
        massage = massage1 + massage2;
        sp.Write(massage);
    }

    public void ONCick1r()
    {
        massage1 = "r";
        
    }
    public void ONCick1b()
    {
        massage1 = "b";
    }

    public void ONCick1g()
    {
        massage1 = "g";
    }

    public void ONCick2r()
    {
        massage2 = "r";

    }
    public void ONCick2b()
    {
        massage2 = "b";
    }

    public void ONCick2g()
    {
        massage2 = "g";
    }
}
