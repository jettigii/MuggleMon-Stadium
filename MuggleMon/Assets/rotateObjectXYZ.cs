using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotateObjectXYZ : MonoBehaviour
{
    public float scrollSpeedX = 0.5F;
    public float scrollSpeedY = 0.5F;
    public float scrollSpeedZ = 0.5F;
    
    // Update is called once per frame
    void Update()
    {
        //float offsetH = transform.rotation.x + scrollSpeedH;
        //float offsetV = transform.rotation.y + scrollSpeedV;

        //transform.Rotate(offsetH, offsetV, 0);
        transform.Rotate((scrollSpeedX * Time.deltaTime), (scrollSpeedY * Time.deltaTime), (scrollSpeedZ * Time.deltaTime));
    }
}
