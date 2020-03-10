using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class CameraScript : MonoBehaviour
{
    

    public Transform target;
    public float distance = 2.0f;
    public float xSpeed = 20.0f;
    public float ySpeed = 20.0f;
    public float yMinLimit = -90f;
    public float yMaxLimit = 90f;
    public float distanceMin = 10f;
    public float distanceMax = 10f;
    public float smoothTime = 2f;
    float rotationYAxis = 0.0f;
    float rotationXAxis = 0.0f;
    float velocityX = 0.0f;
    float velocityY = 0.0f;

    Resolution screenSize;
    public RectTransform displayPanel;
    public int cameraAreaSizePercent = 6;

    // Use this for initialization
    void Start()
    {
        Vector3 angles = transform.eulerAngles;
        rotationYAxis = angles.y;
        rotationXAxis = angles.x;

        screenSize = Screen.currentResolution;
        displayPanel.sizeDelta = new Vector2(displayPanel.sizeDelta.x, screenSize.height / cameraAreaSizePercent);

    }
    
    void LateUpdate()
    {
        if (target)
        {
            if (Input.GetMouseButton(0))
            {
                
                if (Input.mousePosition.y <= (screenSize.height / cameraAreaSizePercent)) {
                    velocityX += xSpeed * Input.GetAxis("Mouse X") * distance * 0.02f;
                    velocityY += ySpeed * Input.GetAxis("Mouse Y") * 0.02f;
                }
                //print(Input.mousePosition);
                //print(screenSize + "   " + Input.mousePosition);
            }

            

            rotationYAxis += velocityX;
            rotationXAxis -= velocityY;
            rotationXAxis = ClampAngle(rotationXAxis, yMinLimit, yMaxLimit);
            Quaternion fromRotation = Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y, 0);
            Quaternion toRotation = Quaternion.Euler(130, rotationYAxis, 0);
            Quaternion rotation = toRotation;

            //distance = Mathf.Clamp(distance - Input.GetAxis("Mouse ScrollWheel") * 5, distanceMin, distanceMax);
            //RaycastHit hit;
            //if (Physics.Linecast(target.position, transform.position, out hit))
            //{
            //distance -= hit.distance;
            //}
            //Vector3 negDistance = new Vector3(0.0f, 0.0f, -distance);
            //Vector3 position = rotation * negDistance + target.position;

            target.transform.rotation = rotation;
            //transform.position = position;
            velocityX = Mathf.Lerp(velocityX, 0, Time.deltaTime * smoothTime);
            velocityY = Mathf.Lerp(velocityY, 0, Time.deltaTime * smoothTime);
        }
        if (Input.GetAxis("Mouse ScrollWheel") > 0f)
        {
            if (target.transform.localScale.y >= .33)
                target.transform.localScale -= new Vector3(0, 0.1f, 0);
        } else if (Input.GetAxis("Mouse ScrollWheel") < 0f)
        {
            if (target.transform.localScale.y <= 1.3)
                target.transform.localScale += new Vector3(0, 0.1f, 0);
        }
    }
    public static float ClampAngle(float angle, float min, float max)
    {
        if (angle < -360F)
            angle += 360F;
        if (angle > 360F)
            angle -= 360F;
        return Mathf.Clamp(angle, min, max);
    }
}