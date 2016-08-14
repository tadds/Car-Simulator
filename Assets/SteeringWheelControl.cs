using UnityEngine;
using System.Collections;

public class SteeringWheelControl : MonoBehaviour {
    public Transform SteeringWheel;
    public float zRotation = 0F;
    
    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

   
        zRotation -= Input.GetAxis("Horizontal");
        SteeringWheel.eulerAngles = new Vector3(0, 0 ,zRotation);
    }
}
