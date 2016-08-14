using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SteeringWheelControl2 : MonoBehaviour {
    public Transform SteeringWheel;
    public Text zRotation ;
    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        float zRotationint = float.Parse(zRotation.text);
        //zRotation -= Input.GetAxis("Horizontal");
        SteeringWheel.eulerAngles = new Vector3(0, 0, zRotationint);
    }
}
