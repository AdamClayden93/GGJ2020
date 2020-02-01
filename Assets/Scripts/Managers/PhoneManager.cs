using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhoneManager : MonoBehaviour
{
    Touch pinchFinger1, pinchFinger2;
    float zoomSpeed = 0.2f;
    int vibrationDur = 10;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(TestVibrationDuration());
    }

    void PinchScreen()
    {
        Touch finger1 = Input.GetTouch(0);
        Touch finger2 = Input.GetTouch(1);

        Vector2 finger1PrevPos = finger1.position - finger1.deltaPosition;
        Vector2 finger2PrevPos = finger2.position - finger2.deltaPosition;

        float prevTouchDeltaMag = (finger1PrevPos - finger2PrevPos).magnitude;
        float touchDeltaMag = (finger1.position - finger2.position).magnitude;
        float deltaMagnitudeDiff = prevTouchDeltaMag - touchDeltaMag;

        Camera.main.orthographicSize += deltaMagnitudeDiff * zoomSpeed;
        float maxSize = Mathf.Max(Camera.main.orthographicSize, 0.1f);
        Camera.main.orthographicSize = Mathf.Clamp(Camera.main.orthographicSize, 0.1f, 5f);
        /*if (finger1.phase == TouchPhase.Began && finger2.phase == TouchPhase.Began)
        {
            pinchFinger1 = finger1;
            pinchFinger2 = finger2;
        }
        if (finger1.phase == TouchPhase.Moved && finger2.phase == TouchPhase.Moved)
        {
            float baseDistance = Vector2.Distance(pinchFinger1.position, pinchFinger2.position);
            float currentDistance = Vector2.Distance(finger1.position, finger2.position);

            float percent = currentDistance / baseDistance;
            Debug.Log("perc" + percent);
            Camera.main.fieldOfView += percent;

        }*/
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0)
        {
            /*Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Began)
            {
                Vibration.Vibrate(20);
            }*/
            if (Input.touchCount == 2)
            {

                PinchScreen();
            }
        }
    }

    IEnumerator TestVibrationDuration()
    {
        Vibration.Vibrate(vibrationDur);
        yield return new WaitForSeconds(3);
        vibrationDur += 10;
        StartCoroutine(TestVibrationDuration());
    }
}