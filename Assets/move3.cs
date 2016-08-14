using UnityEngine;
//using System.IO;
using UnityEngine.UI;
using System.Collections;

public class move3 : MonoBehaviour {

    private Rigidbody rb;
    public float motorForce;
    public float steerForce;
    public WheelCollider WheelFR;
    public WheelCollider WheelFL;
    public WheelCollider WheelBR;
    public WheelCollider WheelBL;
    public Text Gear;
    public Text sensor;
    public Text speed;
    public Text brake;
    public float movev;
    public float moveh;
    public int gear;
    public Transform SteeringWheel;
    // Use this for initialization
    void Start()
    {
        movev = 0;
        gear = 1;
    }
    void Update()
    {
        /*
         if (Input.GetButtonDown("Vertical"))
             if (Input.GetAxis("Vertical") > 0)
                 gear = gear + 1;
             else
                 gear = gear - 1;




         Debug.Log("Vertical " + Input.GetAxis("Vertical"));

         if (gear == 4)
         {
             gear = 0;
         }
         if (gear == -1)
         {
             gear = 3;
         }
         */

        
        int a = int.Parse(sensor.text);
        if (a > 30)
        {
            gear = 0;
        }
        else if (a > 25)
        {
            gear = 1;
        }
        else if (a > 20)
        {
            gear = 2;
        }
        else
        {
            gear = 3;
        }

        


    }

    void FixedUpdate()
    {
        float zRotation = SteeringWheel.eulerAngles.z;
        Debug.Log("SteeringWheel " + zRotation);



        if (zRotation > 180)
        {
            moveh = (360 - zRotation) * steerForce / 360;
        }
        else
        {
            moveh = zRotation * -steerForce / 360;
        }


        //float moveh = Input.GetAxis("Horizontal") * -steerForce;
        //float movev = Input.GetAxis("Vertical") * motorForce;


        int b = int.Parse(speed.text);


        if (gear == 1)
        {
            Gear.text = "Gear 0";
           // if (Input.GetButtonDown("Jump"))
          //      movev = 0 * motorForce;
          //  else if (Input.GetButtonUp("Jump"))
         //      movev = 0 * motorForce;

            if (b== 1)
                movev = 0 * motorForce;
            else 
                movev = 0 * motorForce;
        }
        else if (gear == 2)
        {
            Gear.text = "Gear 1";
            // if (Input.GetButtonDown("Jump"))
            //     movev = 1 * motorForce;
            // else if (Input.GetButtonUp("Jump"))
            //     movev = 0 * motorForce;
            if (b == 1)
                movev = 1 * motorForce;
            else
                movev = 0 * motorForce;
        }
        else if (gear == 3)
        {
            Gear.text = "Gear 2";
            //if (Input.GetButtonDown("Jump"))
            //    movev = 2 * motorForce;
            //else if (Input.GetButtonUp("Jump"))
            //   movev = 0 * motorForce;
            if (b == 1)
                movev = 2 * motorForce;
            else
                movev = 0 * motorForce;
        }
        else
        {
            Gear.text = "Gear R";
            //if (Input.GetButtonDown("Jump"))
            //    movev = -1 * motorForce;
            //else if (Input.GetButtonUp("Jump"))
            //    movev = 0 * motorForce;
            if (b == 1)
                movev = -1 * motorForce;
            else
                movev = 0 * motorForce;

        }

        Debug.Log(" movev " + movev);
        WheelBR.motorTorque = movev;
        WheelBL.motorTorque = movev;
        // Vector3 move = new Vector3(moveh, 0, movev);
        //rb.AddForce(move*5);
        WheelBR.steerAngle = moveh;
        WheelBL.steerAngle = moveh;

        int c = int.Parse(brake.text);
        if (c == 1)
        {


            float movej = 500;
            WheelFR.brakeTorque = movej;
            WheelFL.brakeTorque = movej;
        }
        else
        {


            float movej = 0;
            WheelFR.brakeTorque = movej;
            WheelFL.brakeTorque = movej;
        }



    }
}
