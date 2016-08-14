using UnityEngine;
//using System.IO;
using UnityEngine.UI;
using System.Collections;

public class move : MonoBehaviour {
    private Rigidbody rb;
    public float motorForce;
    public float steerForce;
    //public Text sensor;
    public WheelCollider WheelFR;
    public WheelCollider WheelFL;
    public WheelCollider WheelBR;
    public WheelCollider WheelBL;
    public Text Gear;
    public float movev ;
    public int gear ;
    // Use this for initialization
    void Start () {
	    movev = 0;
        gear = 1;
    }
    void Update()
    {
        if (Input.GetButtonDown("Vertical"))
            if (Input.GetAxis("Vertical") > 0)
                gear = gear+1;
            else
                gear = gear-1;

        Debug.Log("Vertical " + Input.GetAxis("Vertical"));

        if (gear == 4)
        {
            gear = 0;
        }
        if (gear == -1)
        {
            gear = 3;
        }


        if (gear == 1)
        {
            Gear.text = "Gear 0";
            if (Input.GetButtonDown("Jump"))
                movev = 0 * motorForce;
            else if (Input.GetButtonUp("Jump"))
                movev = 0 * motorForce;
        }
        else if (gear == 2)
        {
            Gear.text = "Gear 1";
            if (Input.GetButtonDown("Jump"))
                movev = 1 * motorForce;
            else if (Input.GetButtonUp("Jump"))
                movev = 0 * motorForce;
        }
        else if (gear == 3)
        {
            Gear.text = "Gear 2";
            if (Input.GetButtonDown("Jump"))
                movev = 2 * motorForce;
            else if (Input.GetButtonUp("Jump"))
                movev = 0 * motorForce;
        }
        else
        {
            Gear.text = "Gear R";
            if (Input.GetButtonDown("Jump"))
                movev = -1 * motorForce;
            else if (Input.GetButtonUp("Jump"))
                movev = 0 * motorForce;

        }
    }

    void FixedUpdate()
    {
       
        

        float moveh = Input.GetAxis("Horizontal") * -steerForce;
        //float movev = Input.GetAxis("Vertical") * motorForce;



    


        Debug.Log(" movev " + movev);
        WheelBR.motorTorque = movev;
        WheelBL.motorTorque = movev;
        // Vector3 move = new Vector3(moveh, 0, movev);
        //rb.AddForce(move*5);
        WheelBR.steerAngle = moveh;
        WheelBL.steerAngle = moveh;
        if (Input.GetButtonDown("Fire1"))
        {


            float movej = 500;
            WheelFR.brakeTorque = movej;
            WheelFL.brakeTorque = movej;
        }
        if (Input.GetButtonUp("Fire1"))
        {


            float movej = 0;
            WheelFR.brakeTorque = movej;
            WheelFL.brakeTorque = movej;
        }
    }
}
