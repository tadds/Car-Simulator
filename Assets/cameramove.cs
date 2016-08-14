using UnityEngine;
using System.Collections;

public class cameramove : MonoBehaviour {

    // Use this for initialization
    public GameObject play;
    private Vector3 obset;
    public float xRotation = 0F;
    public float yRotation = 0F;
    public float zRotation = 0F;
    public float yRotationPlay = 0F;
    // Use this for initialization
    void Start()
    {
        obset = transform.position - play.transform.position;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = play.transform.position + obset;
        // zRotation = SteeringWheel.eulerAngles.z;
        xRotation = transform.eulerAngles.x;
        yRotation = transform.eulerAngles.y;
        zRotation = transform.eulerAngles.z;

        yRotationPlay = play.transform.eulerAngles.y;

        transform.eulerAngles = new Vector3(xRotation, yRotationPlay-45, zRotation);

    }
}
