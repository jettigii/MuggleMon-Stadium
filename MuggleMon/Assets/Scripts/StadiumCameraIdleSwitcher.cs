using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StadiumCameraIdleSwitcher : MonoBehaviour
{
    public GameObject ui;
    private float scrollSpeed = 1F;
    private float nextActionTime = 0f;
    private float scrollSpeed2 = 10F;
    private float nextActionTime2 = 0f;
    int intStep = 0;

    public Camera cam01;
    public Camera cam02;
    public Camera cam03;
    public Camera cam04;
    public Camera cam06;
    public Camera cam07;
    public Camera cam08;
    public Camera cam09;
    public Camera cam10;

    public Camera menuCamera;

    public Camera camZoom1;
    public GameObject camZoom1Gimbal;
    private ZoomGimbalScript zgs1;
    public Camera camZoom2;
    public GameObject camZoom2Gimbal;
    private ZoomGimbalScript zgs2;

    public GameObject monAnimsController;
    private StadiumMonAnims monAnims;

    public bool idle;

    private void Start()
    {
        zgs1 = camZoom1Gimbal.GetComponent(typeof(ZoomGimbalScript)) as ZoomGimbalScript;
        zgs2 = camZoom2Gimbal.GetComponent(typeof(ZoomGimbalScript)) as ZoomGimbalScript;
        monAnims = monAnimsController.GetComponent(typeof(StadiumMonAnims)) as StadiumMonAnims;
        
        //idle = true;
    }

    
    // Update is called once per frame
    void Update()
    {

        if (idle)
        {
            if (Time.time > nextActionTime)
            {

                // execute block of code here
                if (intStep == 0)
                {
                    //sweep to sweep camera2
                    cameraSwitch(cam01, true);//cameraSwitch("Main Camera (1)", true);
                    scrollSpeed = 6.5F;
                    intStep++;
                }
                else if (intStep == 1)
                {
                    //sweep to rear camera2
                    if (Random.RandomRange(0F, 1F) <= 0.3)
                        cameraSwitch(cam02, true);//cameraSwitch("RearCamera2", true);
                    else if (Random.RandomRange(0F, 1F) >= 0.6)
                        cameraSwitch(cam08, true);
                    else
                        cameraSwitch(cam10, true);
                    scrollSpeed = 5F;
                    intStep++;
                }
                else if (intStep == 2)
                {
                    //cameraSwitchDual(cam10, cam09, true);
                    if (Random.RandomRange(0F, 1F) <= 0.5)
                        cameraSwitch(cam06, true);//cameraSwitch("TopCamera", true);
                    else if (Random.RandomRange(0F, 1F) >= 0.5)
                        cameraSwitch(cam03, true);
                    //else
                    //    //show both
                    //    cameraSwitchDual(cam09, cam10, true);

                    scrollSpeed = 4F;
                    intStep++;
                }
                else if (intStep == 3)
                {
                    //cameraSwitchDual(cam10, cam09, false);

                    //sweep to rear camera1
                    if (Random.RandomRange(0F, 1F) <= 0.6)
                        cameraSwitch(cam04, true);//cameraSwitch("RearCamera", true);
                    else if (Random.RandomRange(0F, 1F) >= 0.6)
                        cameraSwitch(cam07, true);
                    else
                        cameraSwitch(cam09, true);
                    scrollSpeed = 4F;
                    intStep++;
                    //intStep = 0;
                } else if (intStep == 4)
                {
                    
                    intStep = 0;
                }

                nextActionTime += scrollSpeed;
            }

            //random animations
            if (Time.time > nextActionTime2)
            {
                nextActionTime2 += scrollSpeed2;

                if (Random.RandomRange(0F, 1F) <= 0.5)
                    monAnims.player1Animation("Excite");
                else
                    monAnims.player2Animation("Excite");
            }

        } //idling

    }

    //void cameraSwitch(string cam, bool keepUI)
    //{
    //    GameObject switchToCamera = GameObject.Find(cam);

    //    //Camera.main.enabled = false;
    //    //Camera.main.gameObject.active = false;

    //    if (keepUI)
    //        ui.active = true;
    //    else
    //        ui.active = false;

    //    Camera.current.gameObject.active = false;

    //    switchToCamera.GetComponent<AudioListener>().enabled = true;
    //    switchToCamera.active = true;
    //    switchToCamera.gameObject.active = true;
        
    //}
    public void cameraSwitch(Camera cam, bool keepUI)
    {
        //Camera.main.gameObject.active = false;
        //Camera.current.enabled = false;

        //if (keepUI)
        ui.active = true;
        //else
        //    ui.active = false;

        try
        {
            foreach (Camera camm in Camera.allCameras)
                camm.GetComponent<AudioListener>().enabled = false;
        } catch { }
        try
        {
            Camera.current.gameObject.active = false;
        } catch { }
        try
        {
            Camera.current.enabled = false;
        }
        catch { }
        //try
        //{
        //    Camera.main.GetComponent<AudioListener>().enabled = false;
        //}
        //catch { }
        try
        {
            Camera.main.gameObject.active = false;
        } catch { }


        cam.GetComponent<AudioListener>().enabled = true;
        cam.enabled = true;
        cam.gameObject.active = true;
        

    }
    //void cameraSwitchDual(Camera cam, Camera cam2, bool state)
    //{
    //    if (state)
    //    {
    //        Camera.current.gameObject.active = false;

    //        cam.enabled = true;
    //        cam.gameObject.active = true;
    //        cam2.enabled = true;
    //        cam2.gameObject.active = true;

    //        //dual screen
    //        cam.rect = new Rect(-0.5F, 0F, 1F, 1F);
    //        cam2.rect = new Rect(0.5F, 0F, 1F, 1F);

    //    } else
    //    {
    //        //Camera.current.gameObject.active = false;
    //        Camera.current.gameObject.active = false;

    //        cam.rect = new Rect(0.5F, 0F, 1F, 1F);
    //        cam2.rect = new Rect(0.5F, 0F, 1F, 1F);
    //    }

    //}

    public void zoomPlayer1()
    {
        cameraSwitch(camZoom1, true);
        zgs1.Play();
    }
    public void zoomPlayer1Reset()
    {
        zgs1.restart();
    }

    public void zoomPlayer2()
    {
        cameraSwitch(camZoom2, true);
        zgs2.Play();
    }
    public void zoomPlayer2Reset()
    {
        zgs2.restart();
    }

    public void onCameraPlayer1()
    {
        cameraSwitch(cam09, true);
    }
    public void onCameraPlayer2()
    {
        cameraSwitch(cam10, true);
    }

}
