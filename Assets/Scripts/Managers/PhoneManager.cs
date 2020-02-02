using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhoneManager : MonoBehaviour
{
    Touch pinchFinger1, pinchFinger2;
    float zoomSpeed = 3f;
    int vibrationDur = 10;
    float pinchDistCriteria;
    Transform cameraTransform;

    // Start is called before the first frame update
    void Start()
    {
        pinchDistCriteria = 5;
        cameraTransform = transform;
        //StartCoroutine(TestVibrationDuration());
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

        //Camera.main.orthographicSize += deltaMagnitudeDiff * zoomSpeed;
        pinchDistCriteria -= deltaMagnitudeDiff * zoomSpeed;
        if(pinchDistCriteria <= 1)
        {
            GameManager.Instance.inPhaseOne = false;
            GameManager.Instance.freezeControls = true;
            // transition
        }
        //float maxSize = Mathf.Max(Camera.main.orthographicSize, 0.1f);
        //Camera.main.orthographicSize = Mathf.Clamp(Camera.main.orthographicSize, 0.1f, 5f);
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
    //void Update()
    //{
        //if (Input.touchCount > 0)
       // {
           // Touch touch = Input.GetTouch(0);
           // if (touch.phase == TouchPhase.Began)
           // {
                //Vibration.Vibrate(100);
           // }
            /*if (GameManager.Instance.inPhaseOne && touch.phase == TouchPhase.Began)
            {
                GameManager.Instance.inPhaseOne = false;
                GameManager.Instance.freezeControls = true;
                //PinchScreen();
            }*/
       //}
        /*if(!GameManager.Instance.inPhaseOne && !GameManager.Instance.inPhaseTwo)
        {
            cameraTransform.LookAt(GOReferences.Instance.cat);
            GOReferences.Instance.mainCam.orthographicSize -= 0.5f * zoomSpeed * Time.deltaTime;
            if(GOReferences.Instance.mainCam.orthographicSize < 2f)
            {
                GOReferences.Instance.mainCam.orthographicSize = 2f;
                GameManager.Instance.inPhaseTwo = true;
            }
        }*/
    //}
}