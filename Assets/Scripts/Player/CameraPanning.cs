using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPanning : MonoBehaviour
{
    Vector2 rotLimits;
    Vector3 angle, tempAngle;
    float rotSpeed, restingState;
    public Transform childPos;
    WaitForSeconds threeSec = new WaitForSeconds(3);
    // Start is called before the first frame update
    void Start()
    {
        rotSpeed = 10;
        rotLimits.x = 34;
        rotLimits.y = 10;
        restingState = (-Input.acceleration.y * rotLimits.x);
    }

    IEnumerator EnableControls()
    {
        yield return threeSec;
        GameManager.Instance.freezeControls = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!GameManager.Instance.freezeControls)
        {
            angle.y = (Input.acceleration.x * rotLimits.y);
            //angle.y = (Input.GetAxis("Horizontal") * rotLimits.y);
            if (!GameManager.Instance.inPhaseOne)
            {
                angle.x = 0;
            }
            else
            {
                angle.x = (-Input.acceleration.y * rotLimits.x);
                //angle.x = (Input.GetAxis("Vertical") * rotLimits.x);
                //print(angle.x);
                if (angle.x < 0)

                {
                    angle.x = 0;
                    //print("That's enough o that!");
                }
            }
            angle.z = 0;
            tempAngle = Vector3.Lerp(tempAngle, angle, Time.deltaTime * 5);
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(tempAngle), Time.deltaTime * rotSpeed);
        }
    }
}