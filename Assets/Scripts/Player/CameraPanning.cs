using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPanning : MonoBehaviour
{
    Vector2 rotLimits;
    Vector3 angle, tempAngle;
    float rotSpeed;
    // Start is called before the first frame update
    void Start()
    {
        rotSpeed = 10;
        rotLimits.x = 60;
        rotLimits.y = 60;
    }

    // Update is called once per frame
    void Update()
    {
        angle.y = (Input.acceleration.x * rotLimits.y);
        //angle.y = (Input.GetAxis("Horizontal") * rotLimits.y);
        if (!GameManager.Instance.freeRoam)
        {
            angle.x = 0;
        }
        else
        {
            angle.x = (Input.acceleration.y * rotLimits.x) ;
            if (angle.x < 0)
            {
                angle.x = 0;
            }
        }
        angle.z = 0;
        tempAngle = Vector3.Lerp(tempAngle, angle, Time.deltaTime * 5);
        transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(tempAngle), Time.deltaTime * 2);
    }
}