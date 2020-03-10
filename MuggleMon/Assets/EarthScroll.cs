using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EarthScroll : MonoBehaviour
{

    public Transform target;
    public float distance = 2.0f;
    public float xSpeed = 20.0f;
    public float ySpeed = 20.0f;
    public float zSpeed = 20.0f;
    public float yMinLimit = -90f;
    public float yMaxLimit = 90f;
    public float distanceMin = 10f;
    public float distanceMax = 10f;
    public float smoothTime = 2f;
    float rotationYAxis = 0.0f;
    float rotationXAxis = 0.0f;
    float rotationZAxis = 0.0f;
    float velocityX = 0.0f;
    float velocityY = 0.0f;
    float velocityZ = 0.0f;

    bool xPos, yPos, colliding;

    bool slowed = false;

    //for zooming in camera
    bool zoominIn = false;
    float zoomSpeed = 1.5f;
    float zoomStart;
    float zoomEnd;
    float zoomFrac = 0;

    Resolution screenSize;
    //public RectTransform displayPanel;
    public int cameraAreaSizePercent = 5;
    //public GameObject cameraMain;
    public bool inputEnabled = true;

    public GameObject TitlePanel;

    // Start is called before the first frame update
    void Start()
    {
        Vector3 angles = transform.eulerAngles;
        rotationZAxis = angles.z;
        rotationYAxis = angles.y;
        rotationXAxis = angles.x;

        screenSize = Screen.currentResolution;

        //zoom
        zoomStart = Camera.main.fieldOfView;
        zoomEnd = 100;
    }

    // Update is called once per frame
    void Update()
    {
        if (target)
        {
            if (Input.GetMouseButton(0))
            {

                if (inputEnabled)
                {
                    //if (transform.rotation.x >= 130 || transform.rotation.x <= -130)
                    //    velocityX += xSpeed * Input.GetAxis("Mouse X") * distance * 0.02f;
                    //else
                    //    velocityX -= xSpeed * Input.GetAxis("Mouse X") * distance * 0.02f;

                    //velocityY -= ySpeed * Input.GetAxis("Mouse Y") * 0.02f;
                    
                } else
                {
                    
                }
            }
            //rotationZAxis += velocityY;
            rotationYAxis += velocityX;
            //rotationXAxis -= velocityY;
            
            Quaternion fromRotation = Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y, transform.rotation.eulerAngles.z);
            Quaternion toRotation = Quaternion.Euler(rotationXAxis, 0, rotationYAxis);

            GameObject playerC = GameObject.Find("CapsulePlayer");
            PlayerCollisions pc = playerC.GetComponent<PlayerCollisions>();

            if (playerC.tag == "Untagged")
            {
                ////collide with building
                //if (playerC.tag == "CenterToBuilding")
                //{
                //    //center to sphere collider
                //    //velocityX = .01f; velocityY = .01f;

                //}
                //else if (playerC.tag == "Player")
                //{
                //    velocityX = -.01f; velocityY = -.01f;
                //}

                if (pc.colliderA.collider.name != "Earth")
                {
                    if (pc.colliderA.collider.GetType() == typeof(BoxCollider) || pc.colliderA.collider.GetType() == typeof(MeshCollider))
                    {
                        //print("Box");
                        if (!colliding)
                        {
                            
                            colliding = true;

                            //building
                            if (velocityX > 0)
                            {

                                xPos = false;
                            }
                            else if (velocityX < 0)
                            {
                                xPos = true;
                            }

                            if (velocityY > 0)
                            {
                                yPos = false;
                            }
                            else if (velocityY < 0)
                            {
                                yPos = true;
                            }

                            //velocityX = -velNum;
                            //velocityY = -velNum;
                        } else
                        {
                            float velNum = 0.02f;

                            //building
                            if (!xPos)
                            {
                                velocityX = -velNum;
                            }
                            else if (xPos)
                            {
                                velocityX = velNum;
                            }

                            if (!yPos)
                            {
                                velocityY = -velNum;
                            }
                            else if (yPos)
                            {
                                velocityY = velNum;
                            }
                        }
                    }
                    else if (pc.colliderA.collider.GetType() == typeof(SphereCollider))
                    {
                        //Zoom area

                        //print("Sphere");
                        //building center
                        //velocityX = velocityX / .1f; velocityY = velocityY / .1f;
                        //toRotation = Quaternion.Euler(trans.rotation.x - rotationXAxis, 0, trans.rotation.y - rotationYAxis);
                        zoominIn = true;
                        if (inputEnabled)
                            zoomStart = Camera.main.fieldOfView;
                        zoomEnd = 80;
                        zoomFrac = 0;

                        slowed = true;
                        xSpeed = 2.5f;

                        //show title
                        TitlePanel.active = true;

                    }
                    else if (pc.colliderA.collider.GetType() == typeof(CapsuleCollider))
                    {
                        //Interaction 

                        //print(pc.colliderA.collider.name);
                        toRotation = transform.rotation;
                    }
                }
                else
                {
                    colliding = false;
                    //zoominIn = false;
                    if (inputEnabled)
                        zoomStart = Camera.main.fieldOfView;
                        
                    
                    zoomEnd = 100;
                    zoomFrac = 0;

                    slowed = false;
                    xSpeed = 5f;

                    //TitlePanel.active = false;
                    //print("Done colliding");
                }

            }
            
            Quaternion rotation = toRotation;// * Quaternion.Euler(Camera.main.transform.forward.x, Camera.main.transform.forward.y, Camera.main.transform.forward.z);
            
            target.transform.rotation = rotation;// * Quaternion.Euler(Camera.main.transform.forward.x, Camera.main.transform.forward.y, Camera.main.transform.forward.z);

            velocityX = Mathf.Lerp(velocityX, 0, Time.deltaTime * smoothTime);
            velocityY = Mathf.Lerp(ClampAngle(velocityY, -30, 30), 0, Time.deltaTime * smoothTime);
            velocityZ = Mathf.Lerp(velocityZ, 0, Time.deltaTime * smoothTime);

            //zoom in
            if (zoomFrac < 1 || zoomFrac > 1)
            {
                zoomFrac += Time.deltaTime * zoomSpeed;
                if (inputEnabled)
                    Camera.main.fieldOfView = Mathf.Lerp(zoomStart, zoomEnd, zoomFrac);
            }

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
